using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkAnything.Models
{
    public abstract class EntityBase
    {
        [Required]
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public EntityState State { get; set; }
    }

    public enum EntityState
    {
        New = 0, Active = 1, Inactive =2, Deleted = 3
    }
}
