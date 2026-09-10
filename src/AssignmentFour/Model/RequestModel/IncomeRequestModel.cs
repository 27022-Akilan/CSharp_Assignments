using AssignmentFour.Enums;
using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model.RequestModel
{
    /// <summary>
    /// Represents a request model for the Income.
    /// </summary>
    public class IncomeRequestModel : TransactionRequestModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeRequestModel"/> class.
        /// </summary>
        /// <param name="amount">Amount of the income.</param>
        /// <param name="description">Description of the income.</param>
        /// <param name="date">Date of the income.</param>
        /// <param name="source">Source of the income.</param>
        public IncomeRequestModel(decimal amount, string description, DateOnly date, Source source)
            : base(amount, TransactionType.Income, description, date)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets the source
        /// </summary>
        /// <value>Contains the source of the income</value>
        public Source Source { get; }
    }
}
