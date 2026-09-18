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

