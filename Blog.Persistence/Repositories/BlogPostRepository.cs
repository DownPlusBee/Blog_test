
using Blog.Domain.Entities;
using Blog.Application.Interfaces.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Blog.Persistence.Helpers;

namespace Blog.Persistence.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        private ISortHelper<BlogPost> _sortHelper;

        public BlogPostRepository(BlogContext dbContext, ISortHelper<BlogPost> sortHelper) : base(dbContext)
        {
            _sortHelper = sortHelper;
        }

        public async Task<List<BlogPost>> ListAllAsync(int PageNumber, int PageSize, string OrderBy, string Sort)
        {
            IQueryable<BlogPost> query = _dbContext.BlogPosts.AsNoTracking().Skip((PageNumber - 1) * PageSize).Take(PageSize);

            if (string.IsNullOrEmpty(OrderBy))
            {
                return await query.ToListAsync();
            }

            return await _sortHelper.ApplySort(query, OrderBy, Sort).ToListAsync();
        }
    }
}
