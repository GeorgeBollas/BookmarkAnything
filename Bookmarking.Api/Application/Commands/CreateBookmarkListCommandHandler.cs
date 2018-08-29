using BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookmarking.Api.Application.Commands
{
    public class CreateBookmarkListCommandHandler:IRequestHandler<CreateBookmarkListCommand, bool>
    {
        private readonly IBookmarkListRepository _bookmarkListRepository;
        private readonly IMediator _mediator;

        public CreateBookmarkListCommandHandler(IMediator mediator, IBookmarkListRepository bookmarkListRepository)
        {
            _bookmarkListRepository = bookmarkListRepository ?? throw new ArgumentNullException(nameof(bookmarkListRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateBookmarkListCommand message, CancellationToken cancellationToken)
        {
            var bookmarkList = new BookmarkList(message.Name, message.UserId); //todo add user details to bookmarking list class

            _bookmarkListRepository.Add(bookmarkList);

            return await _bookmarkListRepository.UnitOfWork.SaveEntitiesAsync();
        }


    }
}
