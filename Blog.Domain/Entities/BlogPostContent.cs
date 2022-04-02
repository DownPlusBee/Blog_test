using System;

namespace Blog.Domain.Entities
{
    public class BlogPostContent
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
