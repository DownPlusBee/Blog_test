using MediatR;
using System.Collections.Generic;

namespace Blog.Application.Features.BlogPosts.Queries
{
    public class GetBlogPostsListQuery : IRequest<List<BlogPostVM>>
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public string SortBy { get; set; }

        public string Sort { get; set; }
    }
}
