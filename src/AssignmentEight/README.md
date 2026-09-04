# Error Handling in C# — AssignmentEight

A console application demonstrating error handling in C#: `try/catch/finally`, throwing
exceptions from a catch block, custom exception classes, global unhandled exception
handling, and reading a stack trace.

You'll get a menu where each option maps to one of the five tasks below (named after
what they demonstrate, not "Task 1", "Task 2", etc.):

1. **Division with try/catch/finally**
2. **Array index out of bounds, a re-thrown exception**
3. **User input validation with a custom exception**
4. **Global unhandled exception**
5. **Stack trace interpretation**


## What each task does

### Task 1
**Division with try/catch/finally** — Has a dividend and divisor, divides
them inside a `try` block, catches `DivideByZeroException` with a meaningful message, and
prints a `finally` message confirming the block ran regardless of outcome.

### Task 2
**Array Index out of bounds exception** — Reads an index into a fixed array of
integers.While trying to access index which is out of the range of the array 
an **IndexOutOfRangeException** is caught and its thrown to the MenuHandler.
And Menu Handler handles and prints the appropriate messages to the user.

### Task 3
**User input validation with a custom exception** — Reads a number from the console. If it
isn't a whole number between 1 and 100, throws `InvalidUserInputException` (a custom
`Exception` subclass), which is caught and its message printed.

### Task 4
**Global unhandled exception demo** — Calls a method with *no* local `try/catch` at all, so
the exception is never handled locally. It's instead observed by the
`AppDomain.UnhandledException` handler registered in `Program.cs`, which prints a custom
message. **Note:** per .NET's runtime behavior, once an exception is truly unhandled, the
process terminates immediately after the handler runs — the handler is for like
logging the errors, not for keeping the app alive. That's expected here, not a bug.

### Task 5
**Stack trace interpretation** — `Run()` Calls `Outer() → Middle() → Inner()`, where `Inner()`
throws an `InvalidOperationException`. The exception is caught in `Run()`, and
`ex.StackTrace` is printed.

### Interpreting the stack trace (Task 5)

A typical run of the stack trace task prints something like:

```
   at AssignmentEight.Tasks.StackTraceInterpretationTask.Inner() in ...
   at AssignmentEight.Tasks.StackTraceInterpretationTask.Middle() in ...
   at AssignmentEight.Tasks.StackTraceInterpretationTask.Outer() in ...
   at AssignmentEight.Tasks.StackTraceInterpretationTask.Run() in ...
```

- Each `at` line is one **call frame** — one method that was on the call stack when the
  exception was thrown.
- The order is **innermost first**: the top line is where the exception was actually
  thrown (`Inner`), and each line below it is the caller of the line above
  (`Middle` called `Inner`, `Outer` called `Middle`, `Run` called `Outer`).
- In short: read a stack trace **top to bottom** to go from "where it broke" to "how we got
  there."
