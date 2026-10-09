using System.Reflection;
using System.Text;

namespace AssignmentSeventeen.Task7
{
    /// <summary>
    /// Represents the functionalities for serializing.
    /// </summary>
    public class ReflectionSerializer
    {
        /// <summary>
        /// Performs serialization.
        /// </summary>
        /// <param name="value">Object that is to be serialized.</param>
        /// <returns>Serialized string</returns>
        public string Serialize(object value)
        {
            Type type = value.GetType();

            PropertyInfo[] properties = type.GetProperties();

            StringBuilder result = new StringBuilder();

            foreach (PropertyInfo property in properties)
            {
                object? propertyValue = property.GetValue(value);
                if (propertyValue == null)
                {
                    result.Append($"{property.Name} : null;");
                }
                else
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsPrimitive ||
                        propertyType == typeof(decimal) ||
                        propertyType == typeof(string))
                    {
                        result.Append($"{property.Name} : {propertyValue};");
                    }
                    else
                    {
                        string nestedValue = this.Serialize(propertyValue);
                        result.Append($"{property.Name} : {nestedValue};");
                    }
                }
            }

            return result.ToString();
        }
    }
}
