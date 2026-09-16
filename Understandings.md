# C# Memory, Value/Reference Types, Garbage Collection & IDisposable

# 1. Value Types and Reference Types

The most useful way to understand value types and reference types is
through their **semantics**, especially what happens when something is
assigned or copied.

## Value type

A value type represents a value directly.

When a value type is assigned to another variable, the value is normally
copied.

Conceptually:

``` text
A = 10
B = A

A = 10
B = 10
```

Changing `B` does not change `A`.

This is called **value semantics**.

Common value types include:

-   `int`
-   `double`
-   `bool`
-   `char`
-   `struct`
-   `enum`

------------------------------------------------------------------------

## Reference type

A reference type represents an object through a reference.

When a reference-type variable is assigned to another variable, the
**reference is copied**, not the object itself.

Conceptually:

``` text
A ──── > Object <───── B
```

Both variables refer to the same object.

Therefore, changing the object's state through `B` can be observed
through `A`.

This is called **reference semantics**.

Common reference types include:

-   `class`
-   arrays
-   `string`
-   delegates
-   interfaces when referring to an implementing object

------------------------------------------------------------------------

# 2.Value/Reference Semantics with Stack/Heap

A common simplified explanation is:

```
Value type  → Stack
Reference type → Heap
```

This is useful but it is not a complete or reliable definition.

The important language-level distinction is:

```
Value type
    → value semantics

Reference type
    → reference semantics
```

The actual physical location of data depends on context and runtime
implementation.

For example, a value type can be a field inside a reference-type object
and therefore be part of that object's memory.

Main Observations:
- The local variables(value types) which are declared inside the methods are stored in the stack then it gets destroyed when the method completes.
- Stack is also used to store method calls which helps us to track method flows and mainly used on recursion tracing and all.

- Whereas reference types are also like that when the method gets completed the reference to gets destroyed.Then the GC takes over the action and collects it but not very instantly.

- Times when value types are stored in the HEAP : 
  - For example, we have class and inside it we have defined a value type `int` in the class. Here the int is stored in the heap not in stack because its inside a reference type `class`.
  - So always don't think stack -> value types heap -> reference types.

So:

> **"Value type means stack" and "reference type means heap" are not the
> definitions of these concepts.**

------------------------------------------------------------------------

# 3. Passing Values to Methods

Another important distinction is between:

-   **value/reference type**
-   **passed by value/passed by reference**

These are not the same thing.

By default, C# parameters are passed **by value**.

For a value type:

``` text
caller value -> copy -> method parameter
```

The method receives a copy of the value.

For a reference type:

``` text
caller reference -> copy -> method parameter -> same object
```

The method receives a copy of the reference.

Therefore, the precise statement is:

> **A reference-type object is not automatically passed by reference.
> Its reference is passed by value.**

`ref`, `out`, and `in` introduce separate parameter-passing semantics
and should be understood independently from whether the underlying type
is a value type or reference type.

------------------------------------------------------------------------

# 4. Object Lifetime

Whenever an object is created, it has a lifetime.

Conceptually:

``` text
Object created
      ↓
Object reachable
      ↓
Object no longer reachable
      ↓
Eligible for garbage collection
      ↓
Memory eventually reclaimed
```

The important word is **reachable**.

An object is useful to the GC as long as the runtime can reach it
through live references.

For example:

``` text
variable -> object
```

The object is reachable.

If there is no longer any path from live references to that object:

``` text
variable → null

object
   ↑
no reachable path
```

the object becomes eligible for collection.

Scenarios when an object life time ends :
- It depends on the scope where it has been declared.
- As so when the object is created inside the the method after the gets executed then the objects accessibility is gone then its eligible for getting collected by the GC.
- When the object is a static one then its life time would be through out the application when its running.
- Important thing : GC doesn't collect immediately after the lifetime of object is completed. It works on its own defined rules.

------------------------------------------------------------------------

# 5. Eligible for GC Does Not Mean Immediately Destroyed

The distinction is extremely important.

When an object becomes unreachable, .NET does not necessarily destroy it
at that exact moment.

Instead:

**The object becomes eligible for garbage collection.**

The GC decides when collection should occur.

So:

``` text
unreachable
    ≠
immediately deleted
```

There can be a period during which an object is unreachable but its
memory has not yet been reclaimed.

------------------------------------------------------------------------

# 6. What the Garbage Collector Does

The .NET Garbage Collector automatically manages **managed memory**.

Its job is to:

1.  Identify objects that are no longer reachable.
2.  Reclaim their managed memory.
3.  Organize/compact memory when appropriate.
4.  Optimize future allocations.

This means application code normally does not need to manually free
ordinary managed objects.

That is one of the major benefits of a managed runtime.


How GC knows that this object is un-referenced ? 
1. Reference counting 
2. Mark and sweep.
The reference counting has a drawback of Cyclic references so mark and sweep is used.

1.Reference Counting :
- Basically it maintains a reference count for each object and when its 0 then it can be marked to GC to collect it.
- THers is an flaw in this where an unreferenced object is noted as its use full.
```
obj a = obj b
obj b = obj a

Here the a is referencing b and b is referncing the a but no other thing is actually pointing to it then so its useless 
but you can see that Refernce count of A - 1 and Reference count of B - 1 so GC doesn't collects it but its useless.
```
- So to overcome this we have Mark and Sweep algorithm.

2.Mark and Sweep :
- It has 4 Phases 
    1. Mark
    2. Sweep
    3. Compact
    4. Finalization.
    1. 

### Mark :
- Starts identifying the application roots.(Static,stack,threads, CPU registers)
- From the roots it explores all the references if they are reached they are marked as **Alive** .
- Objects which are unreachable are remain Unmarked.
- So the unmarked one's are eligible to be collected by GC.

### Sweep :
- The unmarked objects i.e unreferenced one's are collected by the GC in this phase.
- Only the unmarked objects are collected by the GC.

### Compact :
- Main purpose : Defragmentation
- After sweeping empty spaces remains , which creates fragmentation.

```
We have a sequence of 10 bytes,

Memory is filled till 6 bytes.

Then 4,5 byte are collected by the GC.

Now the memory looks like 1-3 filled 4,5 empty 6 - filled 7-10 empty.

Now When we need to store 5 bytes of sequential data we can't store,but it has the space but not in a sequential manner.
So for this the GC moves the 6 byte to the 4 byte location , now we have sequential bytes of 6 bytes free and we can use it.

```

### Finalization :
- If an object has an Finalizer (~ClassName()), GC puts in the Finalization Queue,
- So before completely removing it it runs the Finalizer to handle resource allocation inside the Finalizer.

------------------------------------------------------------------------
# 7. Garbage Collector Generations

The .NET GC uses generations as part of its optimization strategy.

Conceptually:

``` text
Generation 0
    ↓ survives
Generation 1
    ↓ survives
Generation 2
```

The fundamental observation is:

> **Many objects are short-lived.**

For example, temporary objects created while processing a request may
become unreachable very quickly.

The GC can therefore focus collection effort where objects are most
likely to have died.

A simplified mental model is:

``` text
New objects
   ↓
Gen 0

Survive collection
   ↓
Gen 1

Survive longer
   ↓
Gen 2
```

Generation 2 generally contains longer-lived objects.

This generational design helps make garbage collection efficient.

------------------------------------------------------------------------

# 8. `GC.Collect()`

.NET provides:

``` csharp
GC.Collect();
```

which requests garbage collection.

It is useful for:

-   controlled experiments
-   demonstrations
-   certain specialized diagnostic scenarios

But normal application code generally should **not** repeatedly call
`GC.Collect()` just because memory appears high.

The runtime has information about allocation and collection behavior
that allows it to make these decisions automatically.

So the normal mindset is:

> **Create objects and let the GC manage managed memory unless there is
> a specific reason to intervene.**

------------------------------------------------------------------------
# 9. What `IDisposable` Means

`IDisposable` represents a contract for deterministic cleanup.

Conceptually:

``` csharp
public interface IDisposable
{
    void Dispose();
}
```

A type implementing `IDisposable` is communicating:

> **"There is some resource or cleanup responsibility associated with
> this object's lifetime, and the consumer should explicitly end that
> lifetime when finished."**

Typical examples include:

-   streams
-   file readers/writers
-   database connections
-   timers
-   handles
-   types wrapping unmanaged/native resources

Not every `IDisposable` object directly owns an unmanaged resource. A
disposable type may also need to dispose other managed disposable
objects it owns.

------------------------------------------------------------------------

# 10. `Dispose()` VS Garbage Collection

This is probably the most important concept in the entire topic.

``` text
Dispose()
    ↓
Release resources deterministically
```

while:

``` text
Garbage Collector
    ↓
Reclaim unreachable managed memory
```

They solve different problems.
Therefore:

> **Calling `Dispose()` is not the same thing as destroying the
> object.**

`Dispose()` primarily signals that the object's resource-ownership
responsibility is finished.

The managed object itself may still exist in memory afterward until it
becomes unreachable and is eventually handled by the GC.

------------------------------------------------------------------------

# 11. Why `using` Is Important

If an object implements `IDisposable`, you usually want disposal to
happen reliably.

Instead of manually remembering:

``` csharp
resource.Dispose();
```

C# provides `using`.

Conceptually:

``` text
Acquire resource
      ↓
Use resource
      ↓
Leave scope
      ↓
Dispose resource
```

A `using` statement is designed so that disposal happens even when
control leaves the scope because of an exception.

Conceptually, this:

``` csharp
using (resource)
{
    // use resource
}
```

behaves like a protected lifetime:

``` text
try
{
    use resource
}
finally
{
    resource.Dispose()
}
```

The exact compiler transformation depends on the form used, but the
important guarantee is deterministic disposal at scope exit.

------------------------------------------------------------------------
# 12. `Dispose()` Should Usually Be Safe to Call Through a `using` Pattern

The important design goal is predictable cleanup.

For example:

``` text
using
  ↓
Dispose
  ↓
owned resources released
```

After disposal, the object should generally not be used again unless its
API explicitly documents that certain operations remain valid.

A common design expectation is:

> **Disposed means the resource-owning lifetime has ended.**

------------------------------------------------------------------------
# 13. Common Misconceptions

## Misconception 1

> "Value types are always on the stack."

Not necessarily.

Value/reference classification is primarily about semantics, not a
simple physical-memory rule.

------------------------------------------------------------------------

## Misconception 2

> "Reference types are passed by reference."

Not by default.

C# passes parameters by value by default.

For a reference type, the copied value is a reference to the object.

------------------------------------------------------------------------

## Misconception 3

> "Setting a variable to null destroys the object."

No.

It only removes that particular reference.

The object is eligible for GC only if no other reachable references
remain.

------------------------------------------------------------------------

## Misconception 4

> "As soon as an object is unreachable, the GC deletes it."

No.

It becomes **eligible** for collection.

Collection happens later according to the GC's behavior.

------------------------------------------------------------------------

## Misconception 5

> "`Dispose()` destroys the object."

No.

`Dispose()` releases resources according to the object's disposal
contract.

The managed object may remain alive afterward.

------------------------------------------------------------------------
## Misconception 6

> "`GC.Collect()` is how we manually free memory whenever we want."

It requests collection, but it is generally not something ordinary
application code should use routinely.

------------------------------------------------------------------------
