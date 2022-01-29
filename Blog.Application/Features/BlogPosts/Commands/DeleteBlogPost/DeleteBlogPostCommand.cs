using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Commands.DeleteBlogPost
{
    public class DeleteBlogPostCommand
    {
        public Guid BlogPostId { get; set; }
    }
}
