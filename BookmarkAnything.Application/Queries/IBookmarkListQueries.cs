using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkAnything.Application.Queries
{
    public interface IBookmarkListQueries
    {
        Task<BookmarkList> GetBookmarkListAsync(int id);

        Task<IEnumerable<BookmarkList>> GetBookmarkListsAsync();
    }
}
