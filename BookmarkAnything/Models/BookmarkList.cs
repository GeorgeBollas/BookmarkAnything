using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkAnything.Models
{
    public class BookmarkList: EntityBase   
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public bool IsPinned { get; set; }
    }
}
