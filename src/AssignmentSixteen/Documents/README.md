# Records immutability

```csharp

// Here the book.Title cant be changed as its created as the created record is in the form of 
only with getter property.(Immutability)
book1.Title = "LabView";

```

```csharp
    public record Book
    {
        public Book(string title, string author, string iSBN)
        {
            this.Title = title;
        }

        public string Title {get; set;}
    }   
```

You can also create a mutable record by but its record is not designed for that.

# Var vs Dynamic

<!-- multiline -->
| var | dynamic | 
|---------|-------|
|Its purpose is not for dynamic typing.It lets the compiler to infer the type for you.|When the type is unknown until the runtime.The variable can hold different types of values.|
| Type is determined at compile time | Type is determined at runtime|
|Value for var should be assigned at the declaration itself as the compiler should find the type.|Value for dynamic can be assigned after the declaration also and at runtime also.|
| Cannot change into another type | Can be changed into another type |
|var a = 10 <br> a = "akil" //Its not allowed Compile time error.|dynamic a = "akil" ;<br> a = 10 // this can be done.<br> But an issue here as it type is determined in runtime : <br> `a.Length` is allowed at compile time but it throws a exception in runtime. |



