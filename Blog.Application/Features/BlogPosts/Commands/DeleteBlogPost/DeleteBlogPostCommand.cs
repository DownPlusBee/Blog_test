using MediatR;
using System;

namespace Blog.Application.Features.BlogPosts.Commands.DeleteBlogPost
{
    public class DeleteBlogPostCommand : IRequest
    {
        public Guid BlogPostId { get; set; }
    }
}
