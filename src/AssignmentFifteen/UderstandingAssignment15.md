# Understandings – File Streams and Buffering

## Writing to the File

Initially, the code was using a `MemoryStream` before writing the data to the actual file.

The flow was roughly:

```
String -> byte[] -> MemoryStream -> Array -> Another byte[] -> FileStream -> File.
```

After looking at it, I understood that the `MemoryStream` is not really required in this case.

The string is first converted into a byte array using:

```
Encoding.ASCII.GetBytes(data)
```

Since I already have the bytes, I can directly give them to the `FileStream`.

So the simpler flow is:

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

