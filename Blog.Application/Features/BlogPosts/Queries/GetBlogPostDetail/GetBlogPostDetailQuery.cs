using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Queries.GetBlogPostDetail
{
    public class GetBlogPostDetailQuery: IRequest<BlogPostDetailVM>
    {
        public Guid Id { get; set; }
    }
}
