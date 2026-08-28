using System.Linq.Expressions;
using AssignmentNine.Model.Enum;

namespace AssignmentNine.Tasks
{
    /// <summary>
    /// Represents to build the Query.
    /// </summary>
    /// <typeparam name="T">Generic type </typeparam>
    public class QueryBuilder<T>
    {
        private IEnumerable<T> _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="source">List of T</param>
        public QueryBuilder(IEnumerable<T> source)
        {
            this._query = source;
        }

        /// <summary>
        /// Filters the result based on the Lambda expression
        /// </summary>
        /// <param name="condition">A Func containing the condition</param>
        /// <returns>Current Query</returns>
        public QueryBuilder<T> Filter(Func<T, bool> condition)
        {
            this._query = this._query.Where(condition);
            return this;
        }

        /// <summary>
        /// Filters the List
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="operation">Operation to be performed</param>
        /// <param name="value">Value</param>
        /// <returns>Current Query</returns>
        /// <exception cref="NotSupportedException">Exception if its not a desired exception</exception>
        public QueryBuilder<T> Filter(string propertyName, FilterOperation operation, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            var property = Expression.Property(parameter, propertyName);

            Expression body;

            switch (operation)
            {
                case FilterOperation.GreaterThanOrEqualTo:
                    var greaterThan = Expression.Constant(Convert.ChangeType(value, property.Type), property.Type);
                    body = Expression.GreaterThanOrEqual(property, greaterThan);
                    break;
                case FilterOperation.LessThanEqualTo:
                    var lessThan = Expression.Constant(Convert.ChangeType(value, property.Type), property.Type);
                    body = Expression.LessThanOrEqual(property, lessThan);
                    break;

                case FilterOperation.Contains:

                    var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
                    if (containsMethod == null)
                    {
                        throw new MethodAccessException("No method found!!");
                    }

                    var containsValue = Expression.Constant(Convert.ChangeType(value, property.Type), property.Type);

                    body = Expression.Call(property, containsMethod, containsValue);

                    break;

                case FilterOperation.StartsWith:

                    var startsWithMethod = typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) });
                    if (startsWithMethod == null)
                    {
                        throw new MethodAccessException("No method found!!");
                    }

                    var startsWithValue = Expression.Constant(Convert.ChangeType(value, property.Type), property.Type);

                    body = Expression.Call(property, startsWithMethod, startsWithValue);

                    break;

                case FilterOperation.EndsWith:

                    var endsWithMethod = typeof(string).GetMethod(nameof(string.EndsWith), new[] { typeof(string) });
                    if (endsWithMethod == null)
                    {
                        throw new MethodAccessException("No method found!!");
                    }

                    var endsWithValue = Expression.Constant(Convert.ChangeType(value, property.Type), property.Type);

                    body = Expression.Call(property, endsWithMethod, endsWithValue);

                    break;

                default: throw new NotSupportedException($"Filter operation {operation} is not supported");
            }

            var expression = Expression.Lambda<Func<T, bool>>(body, parameter);

            this._query = this._query.Where(expression.Compile());
            return this;
        }

        /// <summary>
        /// Sorts the List
        /// </summary>
        /// <typeparam name="TKey">A result value that returns when sorting</typeparam>
        /// <param name="keySelector">Func denoting the logic of Sorting</param>
        /// <returns>Current Query</returns>
        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> keySelector)
        {
            this._query = this._query.OrderBy(keySelector);
            return this;
        }

        /// <summary>
        /// Builds and execute the query.
        /// </summary>
        /// <returns>Result list</returns>
        public IEnumerable<T> Execute()
        {
            return this._query.ToList();
        }

        private void HandleException(string propertyName, FilterOperation operation, object value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Property cant be empty");
            }

            var propertyInfo = typeof(T).GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"The property {propertyName} does not exists");
            }

            if (value == null)
            {
                throw new ArgumentNullException($"The value cannot be null");
            }

            if (operation == FilterOperation.Contains
                || operation == FilterOperation.StartsWith
                || operation == FilterOperation.EndsWith)
            {
                if (propertyInfo.PropertyType != typeof(string))
                {
                    throw new ArgumentException($"Operation {operation} can only applied on Strings");
                }
            }
        }
    }
}
