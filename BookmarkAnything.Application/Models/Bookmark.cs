using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkAnything.Application.Models
{
    public class Bookmark
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
