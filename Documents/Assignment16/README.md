# Events 

- Events is built on top of delegates.Where it gives us a flexibility to
invoke the event only inside the class in which it has been declared.
- So when declared as delegate it can be invoked from any of the classes.So to restrict it 
**Events** comes into action.

e.x : If we are ordering an product, and after it it should send notification to 
- 1.Sms notification
- 2.Email notification.

**Case 1 Delegate**: We can subscribe and unsubscribe from anywhere and also Invoke sending the notification.
- This leads to without even ordering someone can Invoke the delegate.

**Case 2 Events** : This is like restricting the delegate not to be invoked outside and only can subscribe and unsubscribe.
- This leads us to only subscribe/unsubscribe to the event and restricts invoking the event.


# Var vs Dynamic

<!-- multiline -->
| var | dynamic | 
|---------|-------|
|Its purpose is not for dynamic typing.It lets the compiler to infer the type for you.|When the type is unknown until the runtime.The variable can hold different types of values.|
| Type is determined at compile time | Type is determined at runtime|
|Value for var should be assigned at the declaration itself as the compiler should find the type.|Value for dynamic can be assigned after the declaration also and at runtime also.|
| Cannot change into another type | Can be changed into another type |
|var a = 10 <br> a = "akil" //Its not allowed Compile time error.|dynamic a = "akil" ;<br> a = 10 // this can be done.<br> But an issue here as it type is determined in runtime : <br> `a.Length` is allowed at compile time but it throws a exception in runtime. |


# Lambda Methods

```csharp
Array.Sort(array, (a, b) =>
            {
                return a.CompareTo(b);
            });
```

Here the Array.Sort(para1,param2) it expects two arguments one is the array to be sorted.
And the other one is the Comparator function. So defining my own comparator function as a lambda method and passing it.

**Where() and Select()** also receives a Delegate.
Where() - Recieves a **Func<T,bool> predicate** 
So I have filtered the even numbers using the below lambda function ,

```csharp
.Where(number => number % 2 == 0);
```

Select() - Recieves a **Func<T,T> selector**
So I have squared the numbers using the below lambda function.

```csharp
.Select(number => number * number);
```


# Custom delegates :
- Here the problem states us to have a SortDelegate which need to sort based on the different parameters so each sorting method should be defined separately.

SortDelegate Signature :
```csharp
int SortDelegate (Product p1,Product p2)
```

Creating multiple sort methods , and passing to generalized method which takes in the sort function,
and performs that sort on the products.

```csharp
public void SortAndDisplayProducts(List<Product> products, SortDelegate sortDelegate)
{
     products.Sort((product1, product2) => sortDelegate(product1, product2));
     this.DisplayProducts(products);
}
```

# Records immutability

public record Book(string Title,string Author,string Isbn)

// Here the book.Title cant be changed as the records are created  
only with getter property inbuilt .(Immutability)
- **book1.Title = "LabView";**
- Basically the records are built for the **immutability**, **Value based comaparision** and need not to create a entire structure for it.
- So now when I try to modify the existing data it doesn't allow me to do that.
- Its mostly used in request objects and to check the values directly.
- Most power full advantage is that it directly compares the values rather than the object reference.

- We can also create a record with mutable property also ..,
- 
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




