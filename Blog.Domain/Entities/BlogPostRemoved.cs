using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class BlogPostRemoved
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public DateTime RemovedDate { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}