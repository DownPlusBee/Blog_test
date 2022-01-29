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


        public Task<BlogPostDetailVM> Handle(GetBlogPostDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _blogPostRepository.GetByIdAsync(request.Id);

            var eventDetailDto = _mapper.Map<BlogPostDetailVM>(@event);

            if (category == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }
            eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return eventDetailDto;
        }
    }
}
