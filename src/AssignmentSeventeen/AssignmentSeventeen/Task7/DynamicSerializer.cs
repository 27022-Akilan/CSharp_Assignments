using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace AssignmentSeventeen.Task7
{
    /// <summary>
    /// Represents the functionalities to create a dynamic type.
    /// </summary>
    public class DynamicSerializer
    {
        private static readonly ConcurrentDictionary<Type, DynamicMethod>
        SerializerCache = new ConcurrentDictionary<Type, DynamicMethod>();

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="value">Object to be serialized.</param>
        /// <returns>Serialized form of data.</returns>
        public string Serialize(object value)
        {
            if (value == null)
            {
                return "null";
            }

            Type type = value.GetType();

            if (IsSimpleType(type))
            {
                return value.ToString()!;
            }

            if (value is IEnumerable collection)
            {
                return this.SerializeCollection(collection);
            }

            DynamicMethod method = SerializerCache.GetOrAdd(type, CreateSerializer);

            MethodInfo methodInfo = method;

            return (string)methodInfo.Invoke(
                null,
                new object[] { value })!;
        }

        private static DynamicMethod CreateSerializer(Type type)
        {
            DynamicMethod method = new DynamicMethod(
                $"Serialize_{type.Name}",
                typeof(string),
                new[] { typeof(object) },
                typeof(DynamicSerializer).Module,
                true);

            ILGenerator il = method.GetILGenerator();

            LocalBuilder builder = il.DeclareLocal(typeof(StringBuilder));
            LocalBuilder instance = il.DeclareLocal(type);
            LocalBuilder propertyValue = il.DeclareLocal(typeof(object));

            il.Emit(OpCodes.Newobj, typeof(StringBuilder).GetConstructor(Type.EmptyTypes)!);

            il.Emit(OpCodes.Stloc, builder);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, type);
            il.Emit(OpCodes.Stloc, instance);

            PropertyInfo[] properties = type.GetProperties(
                BindingFlags.Public | BindingFlags.Instance);

            bool first = true;

            foreach (PropertyInfo property in properties)
            {
                if (property.GetIndexParameters().Length > 0 ||
                    property.GetMethod == null ||
                    !property.GetMethod.IsPublic)
                {
                    continue;
                }

                if (!first)
                {
                    AppendString(il, builder, ";");
                }

                first = false;

                AppendString(il, builder, property.Name + " : ");

                il.Emit(OpCodes.Ldloc, instance);

                il.Emit(OpCodes.Callvirt, property.GetMethod);

                if (property.PropertyType.IsValueType)
                {
                    il.Emit(OpCodes.Box, property.PropertyType);
                }

                il.Emit(OpCodes.Stloc, propertyValue);

                il.Emit(OpCodes.Ldloc, builder);
                il.Emit(OpCodes.Ldloc, propertyValue);

                il.Emit(OpCodes.Call, typeof(DynamicSerializer).GetMethod(nameof(AppendSerializedValue), BindingFlags.NonPublic | BindingFlags.Static)!);

                il.Emit(OpCodes.Pop);
            }

            il.Emit(OpCodes.Ldloc, builder);

            il.Emit(OpCodes.Callvirt, typeof(StringBuilder).GetMethod(nameof(StringBuilder.ToString), Type.EmptyTypes)!);

            il.Emit(OpCodes.Ret);

            return method;
        }

        private static void AppendString(
            ILGenerator il,
            LocalBuilder builder,
            string text)
        {
            il.Emit(OpCodes.Ldloc, builder);
            il.Emit(OpCodes.Ldstr, text);

            il.Emit(OpCodes.Callvirt, typeof(StringBuilder).GetMethod(nameof(StringBuilder.Append), new[] { typeof(string) })!);

            il.Emit(OpCodes.Pop);
        }

        private static string AppendSerializedValue(
            StringBuilder builder,
            object? value)
        {
            DynamicSerializer serializer = new DynamicSerializer();

            builder.Append(serializer.Serialize(value));

            return string.Empty;
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive ||
                   type == typeof(string) ||
                   type == typeof(decimal);
        }

        private string SerializeCollection(IEnumerable collection)
        {
            StringBuilder result = new StringBuilder();

            result.Append("{");

            bool first = true;

            foreach (object? item in collection)
            {
                if (!first)
                {
                    result.Append(";");
                }

                result.Append(this.Serialize(item));

                first = false;
            }

            result.Append("}");

            return result.ToString();
        }
    }
}
