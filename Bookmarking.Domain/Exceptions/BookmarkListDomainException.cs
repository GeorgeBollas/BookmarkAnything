using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkAnything.Services.Bookmarking.Domain.Exceptions
{
    public class BookmarkListDomainException: Exception
    {
        public BookmarkListDomainException()
        { }

        public BookmarkListDomainException(string message)
            : base(message)
        { }

        public BookmarkListDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
