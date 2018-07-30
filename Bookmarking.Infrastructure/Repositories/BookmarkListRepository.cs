using BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate;
using BookmarkAnything.Services.Bookmarking.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarking.Infrastructure.Repositories
{
    public class BookmarkListRepository : IBookmarkListRepository
    {
        private readonly BookmarkingContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public BookmarkListRepository(BookmarkingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public BookmarkList Add(BookmarkList bookmarkList)
        {
            return _context.BookmarkLists.Add(bookmarkList).Entity;
        }

        public async Task<BookmarkList> GetAsync(int bookmarkListId)
        {
            var bookmarkList = await _context.BookmarkLists.FindAsync(bookmarkListId);

            //note loads all the entities of the Aggregate
            //if (order != null)
            //{
            //    await _context.Entry(order)
            //        .Collection(i => i.OrderItems).LoadAsync();
            //    await _context.Entry(order)
            //        .Reference(i => i.OrderStatus).LoadAsync();
            //    await _context.Entry(order)
            //        .Reference(i => i.Address).LoadAsync();
            //}

            return bookmarkList;
        }

        public void Update(BookmarkList bookmarkList)
        {
            _context.Entry(bookmarkList).State = EntityState.Modified;
        }
    }
}
