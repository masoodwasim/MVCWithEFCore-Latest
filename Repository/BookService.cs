using Microsoft.EntityFrameworkCore;
using SampleWebWidMVC.DBContext;
using SampleWebWidMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebWidMVC.Repository
{
    public class BookService : IBookService
    {
        private SampleDBContext _context;
        public BookService(SampleDBContext context)
        {
            _context = context;
        }
        public async Task<BooksModel> AddNewBook(BooksModel bookModel)
        {
            /**  Identity Value */
            // var newID = _context.BooksDbSet.Select(x => x.ID).Max() + 1;
            // bookModel.ID = newID;
            try
            {
                _context.BooksDbSet.Add(bookModel);
                await _context.SaveChangesAsync();
                return bookModel;
            }
            catch (Exception ex)
            {
                // Log exception
                return bookModel;
            }
        }

        public IEnumerable<BooksModel> GetLatestBooks()
        {

            return _context.BooksDbSet.ToList();
        }
        public async Task<bool> DeleteBook(int bookId)
        {
            try
            {
                _context.BooksDbSet.Remove(_context.BooksDbSet.Find(bookId));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public BooksModel GetBook(int BookId)
        {
            var book = _context.BooksDbSet
                  .Where(s => s.ID == BookId)
                  .FirstOrDefault<BooksModel>();
            return book;
        }

        public IEnumerable<BooksModel> GetBook(string keyword)
        {
            var book = from m in _context.BooksDbSet
                       where m.Title.Contains(keyword)
                       select m;
            return book.ToList();
        }

        public async Task<BooksModel> UpdateBook(BooksModel bookModel)
        {
            _context.Attach(bookModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return bookModel;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookModelExists(bookModel.ID))
                {
                    return bookModel;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool BookModelExists(int id)
        {
            return _context.BooksDbSet.Any(e => e.ID == id);
        }
    }

}