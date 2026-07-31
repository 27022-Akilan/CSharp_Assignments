using AssignmentThree.ConstantMessages;

namespace AssignmentThree
{
    /// <summary>
    /// Helper Class that handles all the Validations.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// To validate name and return the validation result as string.
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <returns>Empty string - for success || Else result message</returns>
        public static string ValidateName(string name)
        {
            if (name == string.Empty || string.IsNullOrWhiteSpace(name))
            {
                return Messages.NameCantBeEmpty;
            }
            else if (!IsValidWord(name))
            {
                return Messages.NameCannotBeOnlyNumbers;
            }
            else if (!IsAlphanumeric(name))
            {
                return Messages.NameShouldBeAlphaNumeric;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///  To Validate Product Id
        /// </summary>
        /// <param name="productId">Id of the product to be validated</param>
        /// <returns>String Message for the result of validation</returns>
        public static string ValidateId(string productId)
        {
            if (productId == string.Empty || string.IsNullOrWhiteSpace(productId))
            {
                return Messages.IdCantBeEmpty;
            }

            if (HasControlCharacter(productId))
            {
                return Messages.CantHaveControlCharacters;
            }

            return string.Empty;
        }

        /// <summary>
        ///  To validate Product price
        /// </summary>
        /// <param name="productPriceAsString">Contains the Price of the product</param>
        /// <param name="productPrice">out parameter to return the price</param>
        /// <returns>String Message for the result of validation</returns>
        public static string ValidatePrice(string productPriceAsString, out double productPrice)
        {
            if (double.TryParse(productPriceAsString, out productPrice))
            {
                if (productPrice <= 0)
                {
                    return Messages.PriceCantBeLessThanZero;
                }

                return string.Empty;
            }

            return Messages.NotAPrice;
        }

        /// <summary>
        ///  To validate Product Quantity
        /// </summary>
        /// <param name="productQuantityAsString">Contains the Quantity of the product</param>
        /// <param name="productQuantity">out parameter to return the Quantity</param>
        /// <returns>String Message for the result of validation</returns>
        public static string ValidateQuantity(string productQuantityAsString, out long productQuantity)
        {
            if (long.TryParse(productQuantityAsString, out productQuantity))
            {
                if (productQuantity < 0)
                {
                    return Messages.QuantityCantBeLessThanZero;
                }

                return string.Empty;
            }

            return Messages.NotAQuantity;
        }

        /// <summary>
        ///  To Validate Zero or One.
        /// </summary>
        /// <param name="numberAsString">Contains the input</param>
        /// <param name="number">out parameter to return the number</param>
        /// <returns>String Message for the result of validation</returns>
        public static string ValidateZeroOrOne(string numberAsString, out int number)
        {
            if (int.TryParse(numberAsString, out number))
            {
                if (number == 1 || number == 0)
                {
                    return string.Empty;
                }

                return Messages.OnlyBeOneOrZero;
            }

            return Messages.CantBeLetters;
        }

        /// <summary>
        /// To check if its a number
        /// </summary>
        /// <param name="number">Input string to be checked for a number</param>
        /// <param name="res">Validated Decimal number to be returned as out Parameter</param>
        /// <returns>True - If its a valid decimal number || False - Not a Valid decimal Number</returns>
        public static bool IsNumber(string number, out decimal res)
        {
            res = 0;
            if (number != string.Empty && !string.IsNullOrWhiteSpace(number) && decimal.TryParse(number, out res))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check Valid color or not
        /// </summary>
        /// <param name="word">color</param>
        /// <returns>True - Valid ; False - Invalid word</returns>
        public static bool IsValidWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            return !word.All(char.IsDigit);
        }

        /// <summary>
        /// To check whether the input is an AlphaNumeric one.
        /// </summary>
        /// <param name="input">Input to check whether it is AlphaNumeric or not</param>
        /// <returns>True - If the input is alphanumeric || False - If the input is not AlphaNUmeric</returns>
        public static bool IsAlphanumeric(string input)
        {
            foreach (var i in input)
            {
                if (!char.IsLetterOrDigit(i))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether the input has control character(^A,^B, etc)
        /// </summary>
        /// <param name="input">Holds the string to check for control characters</param>
        /// <returns>True - If has any control Characters || False - If it doesnt has any control characters.</returns>
        public static bool HasControlCharacter(string input)
        {
            if (input.Any(char.IsControl))
            {
                return true;
            }

            return true;
        }
    }
}