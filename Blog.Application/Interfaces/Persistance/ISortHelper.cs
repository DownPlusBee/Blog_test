using System.Linq;

namespace Blog.Application.Interfaces.Persistance
{
    public interface ISortHelper<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string sortBy, string sort);
    }
}