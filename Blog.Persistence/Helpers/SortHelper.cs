using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Blog.Application.Interfaces.Persistance;

namespace Blog.Persistence.Helpers
{
    public class SortHelper<T> : ISortHelper<T>
    {
        public IQueryable<T> ApplySort(IQueryable<T> entities, string sortBy, string sort)
        {
            if (!entities.Any())
            {
                return entities;
            }

            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder orderQueryBuilder = new();

            PropertyInfo objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(sortBy, StringComparison.InvariantCultureIgnoreCase));

            string sortingOrder = sort.EndsWith("desc") ? "descending" : "ascending";

            orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");

            string orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ') ?? string.Empty;

            return entities.OrderBy(orderQuery);
        }
    }
}