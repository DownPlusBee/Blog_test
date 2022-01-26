using Blog.Application.Interfaces.Persistance;
using FluentValidation;
using System;

namespace Blog.Application.Features.BlogPosts.Commands
{
    public class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
    {
        private readonly IBlogPostRepository _blogRepository;

        public CreateBlogPostCommandValidator(IBlogPostRepository blogRepository)
        {
            _blogRepository = blogRepository;

            RuleFor(p => p.Title)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50);

            RuleFor(p => p.Body)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(600);

            RuleFor(P => P.CreatedBy)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(8)
                .MinimumLength(8);
        }
    }
}