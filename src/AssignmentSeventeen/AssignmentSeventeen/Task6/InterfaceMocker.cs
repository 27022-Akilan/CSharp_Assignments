using System.Reflection;
using System.Reflection.Emit;
using Contract;

namespace AssignmentSeventeen.Task6
{
    /// <summary>
    /// Represents the functionalities to mock the interface.
    /// </summary>
    public class InterfaceMocker
    {
        /// <summary>
        /// Mocks the Interface type and creates a class which inherits and tests the data.
        /// </summary>
        public void MockInterface()
        {
            Console.WriteLine("====== Dynamic Mocking Framework ======");

            AssemblyBuilder assemblyBuilder = this.CreateAssembly();

            ModuleBuilder moduleBuilder = this.CreateModule(assemblyBuilder);

            TypeBuilder mockBuilder = this.CreateType(moduleBuilder);

            this.ImplementInterface(mockBuilder, typeof(IPlugin));

            Type mockType = this.CreateRuntimeType(mockBuilder);

            object mockObject = this.CreateMockInstance(mockType);

            IPlugin mockPlugin = (IPlugin)mockObject;

            string message = "a";
            string encryptedMessage = mockPlugin.Encryption("a");
            string decryptedMessage = mockPlugin.Encryption(encryptedMessage);

            Console.WriteLine($"The original message is : {message}" +
                              $"\nThe default return value of encryption method is : {encryptedMessage}" +
                              $"\nThe default return value of decryption is : {decryptedMessage}");
        }

        private AssemblyBuilder CreateAssembly()
        {
            Console.WriteLine("Creating an Assembly..");
            AssemblyName assemblyName = new AssemblyName("EncryptionAssembly");

            AssemblyBuilder assembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            return assembly;
        }

        private ModuleBuilder CreateModule(AssemblyBuilder assembly)
        {
            Console.WriteLine("Creating a Module..");
            return assembly.DefineDynamicModule("EncryptionModule");
        }

        private TypeBuilder CreateType(ModuleBuilder module)
        {
            Console.WriteLine("Creating type..");
            return module.DefineType("ABCEncryption", TypeAttributes.Public | TypeAttributes.Class);
        }

        private void ImplementInterface(TypeBuilder typeBuilder, Type type)
        {
            Console.WriteLine($"Implementing the interface : {type.Name}");

            typeBuilder.AddInterfaceImplementation(type);

            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"Generating the method : {method.Name}()...");

                this.CreateMockMethod(typeBuilder, method);
            }
        }

        private void CreateMockMethod(TypeBuilder typeBuilder, MethodInfo interfaceMethod)
        {
            ParameterInfo[] parameters = interfaceMethod.GetParameters();

            Type[] parametersType = Array.ConvertAll(parameters, parameter => parameter.ParameterType);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                interfaceMethod.Name,
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                interfaceMethod.ReturnType,
                parametersType);

            ILGenerator iLGenerator = methodBuilder.GetILGenerator();

            this.EmitDefaultReturnValue(iLGenerator, interfaceMethod.ReturnType);
        }

        private void EmitDefaultReturnValue(ILGenerator ilGenerator, Type returnType)
        {
            if (returnType == typeof(void))
            {
                ilGenerator.Emit(OpCodes.Ret);
                return;
            }
            else if (!returnType.IsValueType)
            {
                ilGenerator.Emit(OpCodes.Ldnull);
            }
            else
            {
                LocalBuilder local = ilGenerator.DeclareLocal(returnType);
                ilGenerator.Emit(OpCodes.Ldloca_S, local);
                ilGenerator.Emit(OpCodes.Initobj, returnType);
                ilGenerator.Emit(OpCodes.Ldloc, local);
            }

            ilGenerator.Emit(OpCodes.Ret);
        }

        private Type CreateRuntimeType(TypeBuilder typeBuilder)
        {
            Console.WriteLine("Finalizing the mock class and creating its runtime type...");

            return typeBuilder.CreateType()!;
        }

        private object CreateMockInstance(Type mockType)
        {
            Console.WriteLine("Creating an instance of the mock class...");

            return Activator.CreateInstance(mockType)!;
        }
    }
}
