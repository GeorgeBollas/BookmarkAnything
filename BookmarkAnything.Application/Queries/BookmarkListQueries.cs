using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BookmarkAnything.Application.Queries
{
    public class BookmarkListQueries : IBookmarkListQueries
    {
        private string _connectionString = string.Empty;

        public BookmarkListQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BookmarkList> GetBookmarkListAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                //? do we use dynamics only when we want to return some of the fields
                var result = await connection.QueryAsync<dynamic>(
                   @"select [Id] , [name]
                        FROM bookmarking.BookmarkLists
                        WHERE o.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapBookmarkListItems(result);
            }
        }

        public Task<IEnumerable<BookmarkList>> GetBookmarkListsAsync()
        {
            throw new NotImplementedException();
        }

        private BookmarkList MapBookmarkListItems(dynamic result)
        {
            var bookmarkList = new BookmarkList
            {
                Id = result[0].id,
                Name = result[0].name,
            };

            return bookmarkList;
        }
    }
}
