using BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate;
using BookmarkAnything.Services.Bookmarking.Domain.SeedWork;
using Bookmarking.Infrastructure.EntityConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookmarking.Infrastructure
{
    public class BookmarkingContext :DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "bookmarking";

        public DbSet<BookmarkList> BookmarkLists { get; set; }

        private readonly IMediator _mediator;

        private BookmarkingContext(DbContextOptions<BookmarkingContext> options) : base(options) { }

        public BookmarkingContext(DbContextOptions<BookmarkingContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("BookmarkingContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookmarkListEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
