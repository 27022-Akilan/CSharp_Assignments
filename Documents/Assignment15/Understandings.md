# Understandings

# Stream optimizer 
## Writing to the File

Initially, the code was using a `MemoryStream` before writing the data to the actual file.

Its like,
```
String -> byte[] -> MemoryStream -> Array -> Another byte[] -> FileStream -> File.
```

After looking at it, I understood that the `MemoryStream` is not really required in this case.

The string is first converted into a byte array using:

```
Encoding.ASCII.GetBytes(data)
```

Since I already have the bytes, I can directly give them to the `FileStream`.

Now it becomes like,

```
String -> byte[] -> FileStream -> File
```

This avoids keeping the data in an unnecessary intermediate `MemoryStream`.

### `ToArray()`

One important thing I noticed is that `MemoryStream.ToArray()` creates a new byte array containing the data from the memory stream.

So when the original code does:

```
byte[] writeBuffer = memoryStream.ToArray();
```

there can be multiple copies of the same data in memory.

For a small string, this does not make a noticeable difference. But if the amount of data is very large, creating unnecessary copies can increase memory usage.

So I understood that the problem here is mainly **unnecessary memory allocation/copying**, rather than a traditional memory leak.

---

## Reading the File

For reading,

Instead of loading the complete file into memory, I can create a fixed-size buffer:

```
byte[] buffer = new byte[1024];
```

and repeatedly read chunks from the file.

The idea is:

```text
Large File -> Buffer -> Process -> Buffer -> Process...
```

This means the memory required for the buffer does not grow along with the file size.

For example, if the file is 1 GB, I don't need a 1 GB byte array just to read it.

---

## Buffer Size and Number of Read Calls

Buffer size affects how many times `Read()` has to be called.

For example, if the file is 100 MB:

- With a 1 KB buffer, there will be roughly 102,400 reads.
- With a 64 KB buffer, there will be roughly 1,600 reads.
- With a 1 MB buffer, there will be roughly 100 reads.

So a larger buffer generally means fewer `Read()` calls.

Initially, I thought that having more `Read()` calls would mean that the program is doing something wrong. But I understood that repeated reads are normal when processing a large file.

The important thing is to choose a reasonable buffer size.

---

## Why Not Read the Whole File in One Attempt?

I understood that simply making the buffer as large as the file is not a good general solution.

For example:

```
100 MB file
   ↓
100 MB byte[]
```

This would use a large amount of memory.

For a 5 GB file, trying to load the entire file into memory would require approximately 5 GB just for that data.

Using a smaller buffer allows the same program to process files much larger than the available memory.

So buffering is basically a balance between **memory usage and the number of read operations**.

```
Small buffer
→ less memory
→ more Read() calls

Large buffer
→ more memory
→ fewer Read() calls
```

---

## Understanding `bytesRead`

I understood that why the code uses the value returned by `Read()`.

For example:

```
int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
```

If the buffer can hold 1024 bytes, `Read()` does not necessarily have to fill all 1024 bytes.

It might return:

```
Buffer size = 1024
Actually read = 700
```

So only the first 700 bytes should be processed.

That is why processing should use:

```
bytesRead
```

instead of always using:

```
buffer.Length
```

---

## Byte-by-Byte Console Output

I also noticed another performance issue in the reading part.

The original approach processes every byte separately:

```
for (int i = 0; i < bytesRead; i++)
{
    Console.Write((char)buffer[i]);
}
```

The file is being read in chunks, which is good, but then each byte in the chunk is sent to `Console.Write()` individually.

For a large file, this can result in a very large number of console operations.

Instead, the whole portion that was actually read can be converted and written as a chunk:

```
Console.Write(
    Encoding.ASCII.GetString(buffer, 0, bytesRead));
```

So I understood that **buffered reading is good, but processing every byte individually can still be inefficient**.

---

## `Console.WriteLine()`

I also noticed that if `Console.WriteLine()` is placed inside the reading loop, a new line is added after every buffer.

For example, if the buffer is 1024 bytes:

```text
First 1024 bytes
Next line
Next 1024 bytes
Next line
...
```

This can change the formatting of the original file.

If I want to display the file contents as they are, I should not add an extra newline after every buffer.

---

# Logger Task 
 
The main purpose of this task was to improve the existing logger by reducing unnecessary memory usage and making it safe and efficient when multiple users log errors at the same time.
 
## What I Did and Why
 
### 1. Identified the Issues
 
The original logger was using a `MemoryStream` between the message and the `FileStream`.
 
The flow was:
 
`Message → byte[] → MemoryStream → FileStream`
 
I identified that the `MemoryStream` was unnecessary because I could directly write the `byte[]` to the file.
 
### 2. Removed the Unnecessary MemoryStream
 
I changed the logger to:
 
`Message → byte[] → FileStream`
 
This reduces unnecessary memory allocation and copying.
 
### 3. Made the Logger Thread-Safe
 
When multiple users write to the same `log.txt`, multiple threads may try to access the file at the same time.
 
I used a `static lock` around the file-writing operation so that only one thread writes to the file at a time.
 
### 4. Created Separate Log Files
 
Instead of making every user write to the same file, I created a separate file based on the username.
 
For example:
 
`User_1 → UserId_1_log.txt`  
`User_2 → UserId_2_log.txt`
 
This reduces contention between different users because they are writing to different files.

So It doesn't gives me the overhead of using lock I don't need these , but when two log errors from 
different threads came for a same user, then the race condition occurs as both tries to access the shared stream,
To over come this,

First I have created a Dictionary of user mapped with their own locks, so when the two threads of same user comes in
we can handle by locking the critical section using the `userlock` but not by a global static `lock`.`
 
### 5. Created a Load Test
 
I used `Parallel.For` to mock multiple users logging errors simultaneously.
 
For example:
 
- 100 mock users
- Each user generates 100 errors
 
Compared their performance speed using the `Stopwatch` and noted the time difference.
So by using the different files its faster than the one which is using the same file.
And `Different files` doesn't need `lock` mechanism as it works on different files , 
If so same user works on different threads then its need a lock , but here the problem is not about that hence I didn't used it.


## Difference between Synchronous and Asynchronous :

Here asynchronous doesn't mean that it automatically fasts the performance or time consumption.

When its Synchronous its flow will be like 

```
1.Read() -> 2.Reads file -> 3. Rest of the Method 
```

When thread enters the `2.Reads file` Section reading the file then the threads get blocked by this read operation,
I will not do anything (idle state) till the read operation gets completed.

But when its asynchronous rather than blocking the thread completely, the threads get some other work assigned by the thread pool manager,
It goes and do some works , then when the operation gets completed same thread or some other thread can get back and resume it. 
