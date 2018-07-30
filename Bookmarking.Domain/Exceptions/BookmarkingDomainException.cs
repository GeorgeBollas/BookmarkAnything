using System;
using System.Collections.Generic;
using System.Text;

namespace BookmarkAnything.Services.Bookmarking.Domain.Exceptions
{
    public class BookmarkingDomainException: Exception
    {
        public BookmarkingDomainException()
        { }

        public BookmarkingDomainException(string message)
            : base(message)
        { }

        public BookmarkingDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
