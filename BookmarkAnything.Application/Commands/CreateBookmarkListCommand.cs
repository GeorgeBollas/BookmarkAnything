using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BookmarkAnything.Application.Commands
{
    [DataContract]
    public class CreateBookmarkListCommand
    {
        [DataMember]
        public string Name { get; set; }

        public CreateBookmarkListCommand(string name)
        {
            Name = name;
        }
    }
}
