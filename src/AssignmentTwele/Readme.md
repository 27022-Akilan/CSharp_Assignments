# Memory Management

## Task 1 - Memory Leak : 
``` 
namespace AssignmentTwelve
{
    public class MemoryEater
    {
        private List<int[]> _memoryAllocation;

        public MemoryEater()
        {
            this._memoryAllocation = new List<int[]>();
        }

        public void AllocateMemory()
        {
            while (true)
            {
                this._memoryAllocation.Add(new int[1000]);
                Thread.Sleep(1000);
            }
        }
    }
}
```

Here the new int array of size 1000 is added into list **_memoryAllocation** infinite times and as the GC doesn't collects
because the reference is held in the list, so the GC doesn't collects it which leads to the memory leak.

The memory grows by time increasingly..,

## Main Issue found:
AllocateMemory() continuously creates a new int[1000] arrays and adds them to _memory allocation. Since the list maintains reference
to the every allocated array and the list is never destroyed, the array remains reachable and the GC cannot reclaim as the loop executes 
indefinitely.
![Diagnosis Tool]("C:\C#\C#_Assignment\Demo_Asg\src\AssignmentTwele\OutputScreenShot\Task1 (2).png")


## Task 2 - Implementing Memory Management Best Practices :

### Case 1 : 
If we `don't need the list` we can remove the list and have the array alone and perform operations then and that, so when the 
loop iteration gets out of scope then the array gets destroyed and new array is created so the memory remains the same which will 
not grow exponentially.It maintains a liner memory usage as same size array is created all the time.
```
while (true)
{
    int[] array = new int[1000];

    // Perform the operations on the array. When needed break.
    Thread.Sleep(1000);
}
```

![Diagnosis Tool]("C:\C#\C#_Assignment\Demo_Asg\src\AssignmentTwele\OutputScreenShot\Task3-Analysis For method 1.png")

### Case 2 :
If we `need the list` then we can have a limit for the list size, after the limit reaches the growing of the memory
stops at that point.

## Initial Analysis
![Initial Analysis]("C:\C#\C#_Assignment\Demo_Asg\src\AssignmentTwele\OutputScreenShot\Task3 -Method2 Initial.png")

## Final Analysis
![Final Analysis]("C:\C#\C#_Assignment\Demo_Asg\src\AssignmentTwele\OutputScreenShot\Task3-Method 2 Final.png")

