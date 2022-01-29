using MediatR;
using System;

namespace Blog.Application.Features.BlogPosts.Commands.CreateBlogPost
{
    public class CreateBlogPostCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }

        public override string ToString()
        {
            return $"BlogPost created by: {CreatedBy}; Titled: {Title}.";
        }
    }
}
