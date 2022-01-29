using AutoMapper;
using Blog.Application.Interfaces.Persistance;
using Blog.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Commands.DeleteBlogPost
{
    public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand>
    {
        private readonly IAsyncRepository<BlogPost> _blogPostRepository;
        private readonly IMapper _mapper;

        public DeleteBlogPostCommandHandler(IMapper mapper, IAsyncRepository<BlogPost> blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<Unit> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
        {
            BlogPost blogPostToDelete = await _blogPostRepository.GetByIdAsync(request.BlogPostId);

            if (blogPostToDelete == null)
            {
                //throw new NotFoundException(nameof(BlogPost), request.EventId);
            }

            await _blogPostRepository.DeleteAsync(blogPostToDelete);

            return Unit.Value;
        }
    }
}
