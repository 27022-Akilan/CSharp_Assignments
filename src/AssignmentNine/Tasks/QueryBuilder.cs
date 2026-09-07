using System.Linq.Expressions;
using System.Reflection;
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
            if (source == null)
            {
                throw new ArgumentNullException("Source cannot be null");
            }

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
            PropertyInfo propertyInfo = this.HandleException(propertyName, operation, value);
            var parameter = Expression.Parameter(typeof(T), "x");

            var property = Expression.Property(parameter, propertyInfo);

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

                    var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string), typeof(StringComparison) });
                    if (containsMethod == null)
                    {
                        throw new MethodAccessException("No method found!!");
                    }

                    var containsValue = Expression.Constant(Convert.ToString(value), typeof(string));
                    var containsComparison = Expression.Constant(StringComparison.OrdinalIgnoreCase);
                    var containsWithCall = Expression.Call(property, containsMethod, containsValue, containsComparison);
                    var containsWithNotNull = Expression.NotEqual(property, Expression.Constant(null, typeof(string)));
                    body = Expression.AndAlso(containsWithNotNull, containsWithCall);
                    break;

                case FilterOperation.StartsWith:

                    var startsWithMethod = typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string), typeof(StringComparison) });
                    if (startsWithMethod == null)
                    {
                        throw new MethodAccessException("No method found!!");
                    }

                    var startsWithValue = Expression.Constant(Convert.ToString(value), typeof(string));
                    var startsWithComparison = Expression.Constant(StringComparison.OrdinalIgnoreCase);
                    var startsWithCall = Expression.Call(property, startsWithMethod, startsWithValue, startsWithComparison);
                    var startsWithNotNull = Expression.NotEqual(property, Expression.Constant(null, typeof(string)));
                    body = Expression.AndAlso(startsWithNotNull, startsWithCall);
                    break;

                case FilterOperation.EndsWith:

                    var endsWithMethod = typeof(string).GetMethod(nameof(string.EndsWith), new[] { typeof(string), typeof(StringComparison) });
                    if (endsWithMethod == null)
                    {
                        throw new MethodAccessException("No method found!!");
                    }

                    var endsWithValue = Expression.Constant(Convert.ToString(value), typeof(string));
                    var endsWithComparison = Expression.Constant(StringComparison.OrdinalIgnoreCase);
                    var endsWithCall = Expression.Call(property, endsWithMethod, endsWithValue, endsWithComparison);
                    var endsWithNotNull = Expression.NotEqual(property, Expression.Constant(null, typeof(string)));
                    body = Expression.AndAlso(endsWithNotNull, endsWithCall);

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
        /// Joins to List
        /// </summary>
        /// <typeparam name="TInner">Inner type</typeparam>
        /// <typeparam name="TKey">Result of Inner type</typeparam>
        /// <typeparam name="TResult">Entire result type</typeparam>
        /// <param name="inner">Inner list</param>
        /// <param name="outerKeySelector">Outer key function</param>
        /// <param name="innerKeySelector">Inner key function</param>
        /// <param name="resultSelector">result selector</param>
        /// <returns>Joined query result</returns>
        public QueryBuilder<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, TInner, TResult> resultSelector)
        {
            var joined = this._query.Join(inner, outerKeySelector, innerKeySelector, resultSelector);

            return new QueryBuilder<TResult>(joined);
        }

        /// <summary>
        /// Builds and execute the query.
        /// </summary>
        /// <returns>Result list</returns>
        public IEnumerable<T> Execute()
        {
            return this._query.ToList();
        }

        private PropertyInfo HandleException(string propertyName, FilterOperation operation, object value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Property cant be empty");
            }

            PropertyInfo? propertyInfo = typeof(T).GetProperty(
                propertyName,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
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
            else if (operation == FilterOperation.GreaterThanOrEqualTo
                || operation == FilterOperation.LessThanEqualTo)
            {
                if (!typeof(IComparable).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    throw new ArgumentException($"Operation {operation} cannot be applied to {propertyInfo.PropertyType.Name}");
                }
            }
            else
            {
                throw new ArgumentException("Invalid operation !!");
            }

            return propertyInfo;
        }
    }
}
