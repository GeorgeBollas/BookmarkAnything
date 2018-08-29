using BookmarkAnything.Services.Bookmarking.Domain.Events;
using BookmarkAnything.Services.Bookmarking.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate
{
    public class BookmarkList: Entity, IAggregateRoot
    {
        public string Name;
        public string UserId;

        public BookmarkList(string name, string userId)
        {
            Name = name;
            UserId = userId;
        }


        private void AddBookmarkListCreatedDomainEvent(string userId, BookmarkList bookmarkList)
        {
            //?: should this be done when contructor called or when saved
            var bookmarkListCreatedDomainEvent = new BookmarkListCreatedDomainEvent(this, userId);

            this.AddDomainEvent(bookmarkListCreatedDomainEvent);
        }
    }
}
