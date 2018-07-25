using BookmarkAnything.Services.Bookmarking.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate
{
    public interface IBookmarkListRepository: IRepository<BookmarkList>
    {
        BookmarkList Add(BookmarkList bookmarkList);

        void Update(BookmarkList bookmarkList);

        //?: only get 1 record (ie look at the query section)
        Task<BookmarkList> GetAsync(int bookmarkListId);
    }
}
