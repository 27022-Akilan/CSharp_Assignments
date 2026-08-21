using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model.DTO
{
    /// <summary>
    /// Represents a request model for the Income.
    /// </summary>
    public class IncomeRequestModel : TransactionRequestModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeRequestModel"/> class.
        /// </summary>
        /// <param name="amount">Contains amount</param>
        /// <param name="description">Contains description</param>
        /// <param name="date">Contains date</param>
        /// <param name="source">Contains source</param>
        public IncomeRequestModel(decimal amount, string description, DateOnly date, Source source)
            : base(amount, TransactionType.Income, description, date)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets the source
        /// </summary>
        /// <value>Contains the source of the expense</value>
        public Source Source { get; }
    }
}
