using AutoMapper;
using Blog.Application.Features.BlogPosts.Commands.CreateBlogPost;
using Blog.Application.Features.BlogPosts.Commands.UpdateBlogPost;
using Blog.Application.Features.BlogPosts.Queries.GetBlogPostDetail;
using Blog.Application.Features.BlogPosts.Queries.GetBlogPostList;
using Blog.Domain.Entities;

namespace Blog.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, BlogPostListVM>().ReverseMap();
            CreateMap<BlogPost, CreateBlogPostCommand>().ReverseMap();
            CreateMap<BlogPost, UpdateBlogPostCommand>().ReverseMap();
            CreateMap<BlogPost, BlogPostDetailVM>().ReverseMap();

        }
    }
}
