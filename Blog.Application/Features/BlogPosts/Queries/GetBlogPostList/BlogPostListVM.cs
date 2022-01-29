using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Queries.GetBlogPostList
{
    public class BlogPostListVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
