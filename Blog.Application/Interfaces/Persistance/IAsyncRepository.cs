using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size, string orderBy);
    }
}
