using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarking.Api.Application.Queries
{
    public interface IBookmarkingQueries
    {
        Task<BookmarkList> GetBookmarkListAsync(int id);
    }
}
