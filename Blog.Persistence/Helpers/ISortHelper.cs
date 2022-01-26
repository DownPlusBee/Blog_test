using System.Linq;

namespace Blog.Persistence.Helpers
{
    public interface ISortHelper<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string sortBy, string sort);
    }
}