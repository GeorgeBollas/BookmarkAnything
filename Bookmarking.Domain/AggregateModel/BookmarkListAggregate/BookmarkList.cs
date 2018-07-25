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

        public BookmarkList(string name, string userName)
        {
            Name = name;
        }


        private void AddBookmarkListCreatedDomainEvent(string userName, BookmarkList bookmarkList)
        {
            //?: should this be done when contructor called or when saved
            var bookmarkListCreatedDomainEvent = new BookmarkListCreatedDomainEvent(this, userName);

            this.AddDomainEvent(bookmarkListCreatedDomainEvent);
        }
    }
}
