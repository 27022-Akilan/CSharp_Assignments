# Reflection in C# � Learnings
 
## Task 1: Inspect Assembly Metadata
- Learned to load assemblies using `Assembly.LoadFile()`.
- Used Reflection to inspect types, methods, properties, fields, and events.
- Understood how .NET metadata can be examined at runtime.
 
## Task 2: Dynamic Object Inspector
- Learned to retrieve property values using `PropertyInfo.GetValue()`.
- Used `PropertyInfo.SetValue()` to modify properties dynamically.
- Understood how Reflection enables runtime object inspection and manipulation.
 
## Task 3: Dynamic Method Invoker
- Learned to locate methods using `Type.GetMethod()`.
- Used `MethodInfo.Invoke()` to execute methods dynamically.
- Understood the importance of method signatures and parameter types.
 
## Task 4: Dynamic Type Builder
- Learned to create assemblies, modules, and types at runtime.
- Explored `AssemblyBuilder`, `ModuleBuilder`, and `TypeBuilder`.
- Used `ILGenerator` to generate executable instructions.
 
## Task 5: Plugin System
- Learned to discover and load plugin assemblies dynamically.
- Used interfaces to establish a common contract between plugins and the main application.
- Understood how Reflection supports extensible applications.
 
## Task 6: Mocking Framework
- Learned to generate types that implement interfaces at runtime.
- Used `TypeBuilder` and `MethodBuilder` to create mock implementations.
 
## Task 7: Serialization API
- Implemented a basic serializer using Reflection to inspect object properties.
- Explored handling nested objects, collections, and null values.
- Identified limitations such as repeated property inspection and circular references.
- Explored `Reflection.Emit` to generate serialization methods dynamically.
- Learned that caching generated methods can reduce repeated code-generation overhead.
