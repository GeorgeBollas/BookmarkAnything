using Bookmarking.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Bookmarking.Api.Controllers
{
    [Route("api/v1/[controller]")]
    //[Authorize]
    [ApiController]
    public class BookmarkingController: Controller
    {
        private readonly IMediator _mediator;
        private readonly IBookmarkingQueries _bookmarkingQueries;

        public BookmarkingController(IMediator mediator, IBookmarkingQueries bookmarkingQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _bookmarkingQueries = bookmarkingQueries ?? throw new ArgumentNullException(nameof(bookmarkingQueries));
        }

        [Route("{Id:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(BookmarkList), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var bookmarkList = await _bookmarkingQueries
                    .GetBookmarkListAsync(id);

                return Ok(bookmarkList);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
