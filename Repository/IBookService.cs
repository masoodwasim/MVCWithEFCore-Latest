using SampleWebWidMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebWidMVC.Repository
{
    public interface IBookService
    {
        IEnumerable<BooksModel> GetLatestBooks();
        BooksModel GetBook(int BookId);
        IEnumerable<BooksModel> GetBook(string keyword);
        Task<BooksModel> AddNewBook(BooksModel bookModel);
        Task<BooksModel> UpdateBook(BooksModel bookModel);
        Task<bool> DeleteBook(int bookId);
    }
}
