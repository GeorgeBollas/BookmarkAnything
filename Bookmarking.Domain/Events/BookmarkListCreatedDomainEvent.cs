using BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkAnything.Services.Bookmarking.Domain.Events
{
    /// <summary>
    /// Event is used when Bookmark List is created
    /// </summary>
    public class BookmarkListCreatedDomainEvent: INotification
    {
        public string UserId { get; }
        public BookmarkList BookmarkList { get; }

        public BookmarkListCreatedDomainEvent(BookmarkList bookmarkList, string userId)
        {
            BookmarkList = bookmarkList;
            UserId = UserId;
        }
    }
}
