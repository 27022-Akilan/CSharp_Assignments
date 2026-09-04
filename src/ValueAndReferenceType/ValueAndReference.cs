using ValueAndReferenceType.Model;

namespace ValueAndReferenceType
{
    /// <summary>
    /// Represents the task of value and reference type.
    /// </summary>
    public class ValueAndReference
    {
        /// <summary>
        /// To create value and reference type.
        /// </summary>
        public void CreateValue()
        {
            bool isValid = this.TryGetNumber("\nEnter a number to put into value(struct) and reference(class) type : ", out int number);
            if (!isValid)
            {
                return;
            }

            ValueAndReferenceType.Model.ValueType valueType = new();
            valueType.Number = number;

            ReferenceType referenceType = new ReferenceType();
            referenceType.Number = number;

            if (!this.ModifyData(valueType, referenceType))
            {
                Console.WriteLine("Invalid Input Cannot change !!");
                return;
            }

            Console.WriteLine("============================" +
                              "\n--- Value Type ---" +
                              "\n============================");
            Console.WriteLine($"Before change : {number}" +
                              $"\nAfter change : {valueType.Number}");

            Console.WriteLine("============================" +
                              "\n--- Reference Type ---" +
                              "\n============================");
            Console.WriteLine($"Before change : {number}" +
                              $"\nAfter change : {referenceType.Number}");
        }

        private bool ModifyData(ValueAndReferenceType.Model.ValueType valueTypeData, ReferenceType referenceTypeData)
        {
            bool isValid = this.TryGetNumber("\nEnter a number to change the data of the value type and reference type : ", out int number);
            if (!isValid)
            {
                return isValid;
            }

            Console.WriteLine($"Changing value to {number}");
            int valueTemp = valueTypeData.Number;
            valueTypeData.Number = number;
            int referenceTemp = referenceTypeData.Number;
            referenceTypeData.Number = number;
            return isValid;
        }

        private bool TryGetNumber(string prompt, out int number)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Invalid Input !!");
                return false;
            }

            return true;
        }
    }
}
