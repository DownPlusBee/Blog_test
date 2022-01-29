using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Queries.GetBlogPostDetail
{
    public class BlogPostDTO
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}