# ReadOnly Dictionary and ReadOnly Collection – My Understanding
 
## ReadOnly Dictionary
 
A `ReadOnlyDictionary<TKey, TValue>` is used when I want to expose a dictionary to another part of my application without allowing that code to modify it through the exposed reference.
 
A normal `Dictionary` allows:
 
- Add
- Remove
- Update
- Read
 
A read-only dictionary allows only operations related to reading.
 
```csharp
Dictionary<int, string> users = new Dictionary<int, string>
{
    { 1, "Akil" },
    { 2, "Arun" }
};
 
IReadOnlyDictionary<int, string> readOnlyUsers = users;

After then when I try to modify it doesnt allow me to modify it, it throws an compile time error.

```csharp
readOnlyUsers[2] = "Kavin";
It Doesnt allows us to do this !!