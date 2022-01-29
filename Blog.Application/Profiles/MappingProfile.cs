using AutoMapper;
using Blog.Application.Features.BlogPosts.Commands.CreateBlogPost;
using Blog.Application.Features.BlogPosts.Queries;
using Blog.Domain.Entities;

namespace Blog.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, BlogPostVM>().ReverseMap();
            CreateMap<BlogPost, CreateBlogPostCommand>().ReverseMap();
        }
    }
}
