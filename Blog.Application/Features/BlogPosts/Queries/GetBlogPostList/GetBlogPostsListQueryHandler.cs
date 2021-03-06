using AutoMapper;
using Blog.Application.Interfaces.Persistance;
using Blog.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Queries.GetBlogPostList
{
    public class GetBlogPostsListQueryHandler : IRequestHandler<GetBlogPostsListQuery, List<BlogPostListVM>>
    {
        private readonly IBlogPostRepository _repo;
        private readonly IMapper _mapper;

        public GetBlogPostsListQueryHandler(IBlogPostRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<BlogPostListVM>> Handle(GetBlogPostsListQuery request, CancellationToken cancellationToken)
        {

            List<BlogPost> blogPosts = await _repo.ListAllAsync(request.Offset, request.Limit, request.SortBy, request.Sort);

            return _mapper.Map<List<BlogPostListVM>>(blogPosts);
        }
    }
}