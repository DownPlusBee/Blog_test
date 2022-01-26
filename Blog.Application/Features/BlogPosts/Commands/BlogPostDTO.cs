using System;

namespace Blog.Application.Features.BlogPosts.Commands
{
    public class BlogPostDTO
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}