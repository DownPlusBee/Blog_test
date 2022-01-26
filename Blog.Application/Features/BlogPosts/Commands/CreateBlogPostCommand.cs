using MediatR;
using System;

namespace Blog.Application.Features.BlogPosts.Commands
{
    public class CreateBlogPostCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }
    }
}
