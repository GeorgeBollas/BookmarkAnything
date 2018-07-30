using BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookmarking.Infrastructure.EntityConfiguration
{
    public class BookmarkListEntityTypeConfiguration : IEntityTypeConfiguration<BookmarkList>
    {
        public void Configure(EntityTypeBuilder<BookmarkList> bookmarkListConfiguration)
        {
            bookmarkListConfiguration.ToTable("BookmarkLists", BookmarkingContext.DEFAULT_SCHEMA);

            bookmarkListConfiguration.HasKey(b => b.Id);

            bookmarkListConfiguration.Ignore(b => b.DomainEvents);

            bookmarkListConfiguration.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("bookmarkListseq", BookmarkingContext.DEFAULT_SCHEMA);

            bookmarkListConfiguration.Property(b => b.Id)
                .IsRequired();

            bookmarkListConfiguration.HasIndex("Id")
              .IsUnique(true);

            bookmarkListConfiguration.Property(b => b.Name);
        }
    }
}
