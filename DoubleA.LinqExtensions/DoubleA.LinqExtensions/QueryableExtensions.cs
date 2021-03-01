using System;
using System.Linq;
using System.Linq.Expressions;

namespace DoubleA.LinqExtensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, params Expression<Func<T, bool>>[] filters)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return filters.WithoutNulls().Aggregate(query, (query, filter) => query = query.Where(filter));
        }
    }
}
