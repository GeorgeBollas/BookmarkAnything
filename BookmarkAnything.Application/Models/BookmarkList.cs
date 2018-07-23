using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkAnything.Application.Models
{
    public class BookmarkList
    {
        public BookmarkList()
        {
            Bookmarks = new List<Bookmark>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public List<Bookmark> Bookmarks { get; set; }

    }
}
