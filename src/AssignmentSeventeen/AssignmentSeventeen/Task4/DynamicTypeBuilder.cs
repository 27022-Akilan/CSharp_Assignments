using System.Reflection;
using System.Reflection.Emit;

namespace AssignmentSeventeen.Task4
{
    /// <summary>
    /// Represents the functionalities for building assemblies,types dynamically.
    /// </summary>
    public class DynamicTypeBuilder
    {
        /// <summary>
        /// Constructs a class dynamically.
        /// </summary>
        public void ConstructClass()
        {
            AssemblyBuilder assembly = this.CreateAssembly();
            ModuleBuilder module = this.CreateModule(assembly);
            TypeBuilder typeBuilder = this.CreateType(module);
            FieldBuilder fieldBuilder = this.CreateBackingField(typeBuilder);
            PropertyBuilder property = this.CreateNameProperty(typeBuilder);
            MethodBuilder getterMethod = this.CreateGetterMethod(typeBuilder, fieldBuilder);
            MethodBuilder setterMethod = this.CreateSetterMethod(typeBuilder, fieldBuilder);
            this.ConnectGetterSetterWithProperty(property, getterMethod, setterMethod);
            this.CreateDisplayMethod(typeBuilder, getterMethod);

            Type personType = this.CreateRuntimeType(typeBuilder);
            object personObject = this.CreatePeronInstance(personType);

            this.SetName(personType, personObject, "Akil");
            this.DisplayPerson(personType, personObject);
        }

        private AssemblyBuilder CreateAssembly()
        {
            Console.WriteLine("Creating an Assembly..");
            AssemblyName assemblyName = new AssemblyName("PersonAssembly");

            AssemblyBuilder assembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            return assembly;
        }

        private ModuleBuilder CreateModule(AssemblyBuilder assembly)
        {
            Console.WriteLine("Creating a Module..");
            return assembly.DefineDynamicModule("PersonModule");
        }

        private TypeBuilder CreateType(ModuleBuilder module)
        {
            Console.WriteLine("Creating type..");
            return module.DefineType("Person", TypeAttributes.Public | TypeAttributes.Class);
        }

        private FieldBuilder CreateBackingField(TypeBuilder typeBuilder)
        {
            Console.WriteLine("Creating the Backing field property ..");
            return typeBuilder.DefineField("_name", typeof(string), FieldAttributes.Private);
        }

        private PropertyBuilder CreateNameProperty(TypeBuilder typeBuilder)
        {
            Console.WriteLine("Creating the name property ..");
            return typeBuilder.DefineProperty("Name", PropertyAttributes.None, typeof(string), null);
        }

        private MethodBuilder CreateGetterMethod(TypeBuilder typeBuilder, FieldBuilder fieldBuilder)
        {
            Console.WriteLine("Creating the getter method ..");
            MethodBuilder getterMethod = typeBuilder.DefineMethod(
                "get_Name",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                typeof(string),
                Type.EmptyTypes);

            // binding the getter with the private field name.
            ILGenerator ilGenerator = getterMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            ilGenerator.Emit(OpCodes.Ret);

            return getterMethod;
        }

        private MethodBuilder CreateSetterMethod(TypeBuilder typeBuilder, FieldBuilder fieldBuilder)
        {
            Console.WriteLine("Creating the Setter method ..");
            MethodBuilder setterMethod = typeBuilder.DefineMethod(
                            "set_Name",
                            MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                            typeof(void),
                            new[] { typeof(string) });

            ILGenerator setterIlGenerator = setterMethod.GetILGenerator();
            setterIlGenerator.Emit(OpCodes.Ldarg_0);
            setterIlGenerator.Emit(OpCodes.Ldarg_1);
            setterIlGenerator.Emit(OpCodes.Stfld, fieldBuilder);
            setterIlGenerator.Emit(OpCodes.Ret);

            return setterMethod;
        }

        private void ConnectGetterSetterWithProperty(PropertyBuilder propertyBuilder, MethodBuilder getterMethod, MethodBuilder setterMethod)
        {
            Console.WriteLine("Connecting the getters and setters with the Property");

            // Binding the getter and setter with the property.
            propertyBuilder.SetGetMethod(getterMethod);
            propertyBuilder.SetSetMethod(setterMethod);
        }

        private Type CreateRuntimeType(TypeBuilder typeBuilder)
        {
            Console.WriteLine("Creating the type ..");
            return typeBuilder.CreateType()!;
        }

        private object CreatePeronInstance(Type personType)
        {
            Console.WriteLine("Creating an instance for the person class.");
            return Activator.CreateInstance(personType)!;
        }

        private void DisplayPerson(Type personType, object personObject)
        {
            Console.WriteLine("Displaying the details..");
            personType.GetMethod("Display")!.Invoke(personObject, null);
        }

        private void SetName(Type personType, object personObject, string name)
        {
            Console.WriteLine($"Setting the person name to {name}");
            personType.GetProperty("Name")!.SetValue(personObject, name);
        }

        private void CreateDisplayMethod(TypeBuilder typeBuilder, MethodBuilder getterMethod)
        {
            Console.WriteLine("Creating a Display method ..");
            MethodBuilder displayMethod = typeBuilder.DefineMethod(
                "Display",
                MethodAttributes.Public,
                typeof(void),
                Type.EmptyTypes);

            ILGenerator displayIL = displayMethod.GetILGenerator();

            displayIL.Emit(OpCodes.Ldstr, "Name of the person : ");
            displayIL.Emit(OpCodes.Ldarg_0);
            displayIL.Emit(OpCodes.Call, getterMethod);
            displayIL.Emit(OpCodes.Call, typeof(string).GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) })!);
            displayIL.Emit(OpCodes.Call, typeof(Console).GetMethod(nameof(Console.WriteLine), new[] { typeof(string) })!);
            displayIL.Emit(OpCodes.Ret);
        }
    }
}
