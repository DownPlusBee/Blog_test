using System;
using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class BlogPost
    {
        public BlogPost()
        {
            BlogPostContents = new HashSet<BlogPostContent>();
            BlogPostRemoveds = new HashSet<BlogPostRemoved>();
        }

        public int Id { get; set; }
        public Guid BlogPostGuid { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<BlogPostContent> BlogPostContents { get; set; }
        public virtual ICollection<BlogPostRemoved> BlogPostRemoveds { get; set; }
    }
}