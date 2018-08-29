using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bookmarking.Api.Application.Commands
{
    [DataContract]
    public class CreateBookmarkListCommand: IRequest<bool>
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string UserId { get; set; }

        public CreateBookmarkListCommand(string name, string userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}
