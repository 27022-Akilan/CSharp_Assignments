using System.Text.Json;
using System.Text.Json.Serialization;
using AssignmentFive.Model;
using AssignmentFive.Model.Enums;

namespace AssignmentFive.Repository.RepositoryHelper
{
    /// <summary>
    /// Converts Transaction objects into JSON.
    /// </summary>
    public class TransactionConverter : JsonConverter<Transaction>
    {
        /// <summary>
        /// Writes a Transaction object as JSON.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The Transaction object to write.</param>
        /// <param name="options">The JSON serializer options.</param>
        public override void Write(Utf8JsonWriter writer, Transaction value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("TransactionId", value.TransactionId);

            writer.WriteNumber("Amount", value.Amount);

            writer.WriteString("TransactionType", value.TransactionType.ToString());

            writer.WriteString("Description", value.Description);

            writer.WriteString("Date", value.Date.ToString("dd-MM-yyyy"));

            if (value is Income income)
            {
                writer.WriteString("Source", income.Source.ToString());
            }
            else if (value is Expense expense)
            {
                writer.WriteString("Category", expense.Category.ToString());
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Reads a Transaction object from JSON.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type of the Transaction object to convert.</param>
        /// <param name="options">The JSON serializer options.</param>
        /// <returns>The Transaction object.</returns>
        public override Transaction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            JsonElement element = document.RootElement;

            string transactionIdText = GetRequiredString(element, "TransactionId");
            if (!Guid.TryParse(transactionIdText, out Guid transactionId))
            {
                throw new JsonException($"{transactionIdText} is not a valid Transaction Id \nCan not load file!!");
            }

            decimal amount = GetRequiredDecimal(element, "Amount");

            string transactionTypeText = GetRequiredString(element, "TransactionType");
            if (!Enum.TryParse(transactionTypeText, true, out TransactionType transactionType))
            {
                throw new JsonException($"{transactionTypeText} is a invalid type inside the file\nCan not load the file!!");
            }

            string description = GetRequiredString(element, "Description");

            string dateText = GetRequiredString(element, "Date");
            if (!DateOnly.TryParseExact(dateText, "dd-MM-yyyy", out DateOnly date))
            {
                throw new JsonException($"{dateText} is not in the correct format or empty \nCan not load the file");
            }

            if (transactionType == TransactionType.Income)
            {
                string sourceText = GetRequiredString(element, "Source");

                if (!Enum.TryParse(sourceText, true, out Source source))
                {
                    throw new JsonException($"Invalid transaction type inside the file: {transactionTypeText}");
                }

                return new Income(transactionId, amount, description, date, source);
            }

            if (transactionType == TransactionType.Expense)
            {
                string categoryText = GetRequiredString(element, "Category");

                if (!Enum.TryParse(categoryText, true, out Category category))
                {
                    throw new JsonException($"Invalid transaction type inside the file: {transactionTypeText}");
                }

                return new Expense(transactionId, amount, description, date, category);
            }

            throw new JsonException($"Unknown TransactionType: {transactionTypeText}");
        }

        private static string GetRequiredString(JsonElement element, string propertyName)
        {
            if (!element.TryGetProperty(propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                throw new JsonException($"{propertyName} has been missed or modified \nCan not load file!!!");
            }

            string? value = property.GetString();
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new JsonException($"{propertyName} is empty (File is modified) \\nCan not load file!!!");
            }

            return value;
        }

        private static decimal GetRequiredDecimal(JsonElement element, string propertyName)
        {
            if (!element.TryGetProperty(propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                throw new JsonException($"{propertyName} has been missed or modified \nCan not load file!!!");
            }

            if (!property.TryGetDecimal(out decimal value))
            {
                throw new JsonException($"{propertyName} is empty or edited (File is modified) \\nCan not load file!!!");
            }

            return value;
        }
    }
}