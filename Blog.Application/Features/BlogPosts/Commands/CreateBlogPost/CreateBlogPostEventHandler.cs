using AutoMapper;
using Blog.Application.Interfaces.Infrastructure;
using Blog.Application.Interfaces.Persistance;
using Blog.Application.Models;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Commands.CreateBlogPost
{
    public class CreateBlogPostEventHandler : IRequestHandler<CreateBlogPostCommand, Guid>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;
        private IEmailService _emailService;

        public CreateBlogPostEventHandler(IBlogPostRepository blogPostRepository, IMapper mapper, IEmailService emailService)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            CreateBlogPostCommandValidator validator = new(_blogPostRepository);
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                // throw Exceptions do some logging.
            }

            BlogPost @blogPost = _mapper.Map<BlogPost>(request);

            @blogPost = await _blogPostRepository.AddAsync(@blogPost);

            Email email = new()
            {
                To = "mgathwright@gmail.com",
                Body = $"A new blog post has been created by {request.CreatedBy}",
                Subject = "A New Blog Post!"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //Log and move on; let the API continue.
            }

            return @blogPost.Id;
        }
    }
}
