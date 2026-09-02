# Assignment 10

## 1 .Explain what the .NET platform is and its primary purpose. 
.NET is a development platform which is provides us a **environment** to run our application.
**Purpose of .NET :**  Imagine if we need to connect to db,work with files, manage memory, handle exceptions, we cant implement these things by ourself rather than focusing on the core logic , so the .NET runtime provides resuable services,libraries,tools  so this handles internally.
**THE RUNTIME CAN :** Manage memory,perform GC,execute compiled code,handle exceptions.

## 2.What are the key components of the .NET platform? 
The major components are `CLR` `CTS` `CLS` `JIT` `ASSEMBLIES AND METADATA` .

**CLR** - Common Language Runtime is a runtime environment which the managed .NET code executes.
**Services :** Memory management,garbage collection,exception handling, assembly loading, thread management,JIT compilation.
`CIL` -> **CLR** -> `Machine code`

**CTS** - Common Type System defines how the types are represented and managed in CLR. It ensures the object written in other programming language can interact seamlessly within the .NET ecosystem .
It allows different .NET supported languages like c#,F#,VB. NET to communicate by converting their programming level datatype into a common type in the CTS , 
Example :
`int` in c# and `Integer` in vb. net are mapped to System.Int32 in CTS.

**CLS** - Common Language System defines a set of rules and guidelines by Microsoft to ensure different .NET languages can communicate without any compatibility issues.This ensures **code interoperability**  in .NET ecosystem.
**Difference between CLS and CTS**  -  CTS refers to all possible data types and programming constructs referred in the .NET,  where as **CLS is a subset of CTS** and it represents the only common features in the .NEt.

**Assemblies and MetaData**  - These are the compiled form **(.dll or .exe) + meta data** after it gets out of the compiler(Roslyn).Then its given to the JIT to convert it into machine code. It basically represents the Intermediate Language which is then converted into machine code by JIT.
MetaData are the ones which comes along the IL to represent the type definition,version info.

**File types of Assemblies**
.dll - Class library assemblies and cant run directly only used by other code.
.exe - Console or Gui Application can run it directly.

**JIT** - Just In Time compiler which is inside the CLR , it is responsible for the conversion of `IL` -> `Machine code` 
The JIT translates the IL into Machine code **only when the method is called** unless its not called it doesn't translates and the translated code is cached so then when there is subsequent call it doesn't needs to recompile it. 

It improves **Startup time and stops the recompilation process**.
## 3.Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET. 
| CLR  | CTS | 
|-------|-----|
|It executes our .NET program and provides the necessary runtime services.|CTS refers to all possible data types and programming constructs referred in the .NET| 
|It provides services such as `memory management` , `garbage collection`, `exception handling`|It defines what a `class`,`struct`,`interface` is|

## 4.What is the role of the Global Assembly Cache (GAC) in .NET? 
The Global Assembly Cache is a machine - wide repository for .NET assemblies that are intended to be shared by multiple applications and can hold multiple versions, 
For example 
ApplicationA--lib1.dll
ApplicationB--lib1.dll

So instead of having this in each file , we can have it in the Global Assembly Cache and each application can refer the shared assembly.

**Roles of GAC** 
Centralized storage 
Version management
Shared Dependencies

## 5.Explain the difference between value types and reference types in C#. 
| Value Type  | Reference Type | 
|-------|-----|
|The variable store the actual value directly in its own memory location|Variable stores the reference to the actual value that is stored else where.|
|Typically stores the data in the `STACK`, but not necessarily on the stack always|Typically stores the data in the `HEAP`|
|When its assigned to some other variable its copied and assigned|When its assigned to some other variable the reference is copied and assigned|

## 6.Describe the concept of garbage collection on .NET and its advantages. 
The **Garbage Collector** is the part of the .NET runtime responsible fo automatically reclaiming the memory occupied by managed objects that are no longer reachable by the application.
Its done automatically by the GC so we don't need to care about the memory management in the Managed code.
Important thing is that its not cleared immediately when its not referred, it periodically or it has a threshold and caches the memory.
Main objectives : Manages memory on heap,removes unused objects,executes memory defragmentation.
**Defragmentation** can be done in `Mark and sweep algorithm` or `Reference counting` but the reference counting is not used wider because of the cyclic references.

**Advantages :**
1.Automatic memory management.
2.Reduces memory leaks.
3.Memory reuse.

## 7.What is the purpose of the Globalization and Localization features in .NET? 
Globalization and Localization are essentially for building applications that work seamlessly across different regions ,regions and cultural conventions.

Globalization - It means designing your application so that it can work correctly for different cultures and regions.

Localization - It is a process of adapting the globalized application for a specific culture or region.

## 8.Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 

**CIL** - Common Intermediate Language is CPU independent instruction set generated by the .NET when the code is compiled.
Its main purpose is to convert the source code into CIL, It doesn't need know about the Machine type like if its (x64,x32,windows,mac) it doesn't care about these and focus on generating a code which is common for all the machines and then it can be converted into the machine instruction.
**CPU independent**
**Stored in assemblies**
**Not directly executed by the CPU**
**Same CIL - Different machines**

**JIT** - The Just-In-Time compiler takes the CIL and converts it into the native machine code that the current machine can execute.
**CPU - Specific**
**Runs as part of the Runtime**
**Generates native code**
**Produces the code which CPU can execute**
