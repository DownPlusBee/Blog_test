using AutoMapper;
using Blog.Application.Interfaces.Persistance;
using Blog.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Queries.GetBlogPostDetail
{
    public class GetBlogPostDetailQueryHandler : IRequestHandler<GetBlogPostDetailQuery, BlogPostDetailVM>
    {
        private readonly IAsyncRepository<BlogPost> _blogPostRepository;
        private readonly IMapper _mapper;

        public GetBlogPostDetailQueryHandler(IMapper mapper, IAsyncRepository<BlogPost> blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }


        public async Task<BlogPostDetailVM> Handle(GetBlogPostDetailQuery request, CancellationToken cancellationToken)
        {
            var @blogPost = await _blogPostRepository.GetByIdAsync(request.Id);

            if (@blogPost == null)
            { 
                //throw new NotFoundException()
            }

            return _mapper.Map<BlogPostDetailVM>(@blogPost);
        }
    }
}
