using AutoMapper;
using Blog.Application.Interfaces.Persistance;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPosts.Commands.UpdateBlogPost
{
    public class UpdateBlogPostCommandHandler
    {
        private readonly IAsyncRepository<BlogPost> _blogPostRepository;
        private readonly IMapper _mapper;

        public UpdateBlogPostCommandHandler(IMapper mapper, IAsyncRepository<BlogPost> blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<Unit> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
        {

            var eventToUpdate = await _blogPostRepository.GetByIdAsync(request.Id);

            if (eventToUpdate == null)
            {
                //throw new NotFoundException(nameof(Event), request.EventId);
            }

            var validator = new UpdateBlogPostCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _blogPostRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}