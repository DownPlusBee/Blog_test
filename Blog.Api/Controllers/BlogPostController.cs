using Blog.Application.Features.BlogPosts.Commands;
using Blog.Application.Features.BlogPosts.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogPostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BlogPostVM>>> GetAllBlogPosts([FromQuery] int offset = 1, int limit = 50, string sortby = "", string sort = "")
        {
            GetBlogPostsListQuery blogPostsForQuery = new() { Offset = offset, Limit = limit, SortBy = sortby, Sort = sort };

            List<BlogPostVM> blogPosts = await _mediator.Send(blogPostsForQuery);

            return Ok(blogPosts);
        }

        [HttpPost("add")]
        public async Task<ActionResult<CreateBlogPostCommand>> Create([FromBody] CreateBlogPostCommand createBlogPostCommand)
        {
            Guid response = await _mediator.Send(createBlogPostCommand);

            return Ok(response);

        }
    }
}
