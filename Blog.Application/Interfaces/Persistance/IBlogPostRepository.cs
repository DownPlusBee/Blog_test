using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces.Persistance
{
    public interface IBlogPostRepository : IAsyncRepository<BlogPost>
    {
        Task<List<BlogPost>> ListAllAsync(int PageNumber, int PageSize, string OrderBy, string Sort);
    }
}