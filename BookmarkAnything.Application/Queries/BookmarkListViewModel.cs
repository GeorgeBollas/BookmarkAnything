using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkAnything.Application.Queries
{
    //Note only return fields we need
    public class BookmarkList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
