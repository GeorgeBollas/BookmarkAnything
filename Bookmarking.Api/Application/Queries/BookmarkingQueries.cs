using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarking.Api.Application.Queries
{
    public class BookmarkingQueries : IBookmarkingQueries
    {
        private string _connectionString = string.Empty;

        public BookmarkingQueries(string constr)
        {
            _connectionString = !string.IsNullOrEmpty(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<BookmarkList> GetBookmarkListAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select bl.[Id] as id, bl.Name as name
                        FROM Bookmarking.BookmarkLists bl
                        WHERE bl.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapBookmarkListItems(result);
            }
        }

        private BookmarkList MapBookmarkListItems(dynamic result)
        {
            var bookmarkList = new BookmarkList
            {
                id = result[0].Id,
                name = result[0].name,
            };

            return bookmarkList;
        }
    }
}
