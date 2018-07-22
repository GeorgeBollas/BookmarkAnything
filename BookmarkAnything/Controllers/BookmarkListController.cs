using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookmarkAnything.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookmarkAnything.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkListController : ControllerBase
    {
        private List<BookmarkList> lists;

        public BookmarkListController()
        {
            lists = new List<BookmarkList>()
                {
                    new BookmarkList() { Name = "Favourites"},
                    new BookmarkList() { Name = "Programming"},
                    new BookmarkList() { Name = "Todo Today"}
                };
        }

        // GET: api/BookmarkList
        [HttpGet]
        public IEnumerable<BookmarkList> Get()
        {
            return lists;
        }

        // GET: api/BookmarkList/5
        [HttpGet("{id}", Name = "Get")]
        public BookmarkList Get(int id)
        {
            return new BookmarkList() { Name = "Favourites"};
        }

        // POST: api/BookmarkList
        [HttpPost]
        public void Post([FromBody] BookmarkList value)
        {
            lists.Add(value);
        }

        // PUT: api/BookmarkList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookmarkList value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
