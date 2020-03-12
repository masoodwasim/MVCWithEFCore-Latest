using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebWidMVC.Models;
using SampleWebWidMVC.Repository;

namespace SampleWebWidMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookservice;
        public BooksController(IBookService bookservice)
        {
            _bookservice = bookservice;
        }
        public IActionResult Index()
        {
            return View(_bookservice.GetLatestBooks());
            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BooksModel booksModel)
        {
            if (ModelState.IsValid)
            {
               await _bookservice.AddNewBook(booksModel);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Edit(int id)
        {
             
            return View(_bookservice.GetBook(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(BooksModel booksModel)
        {
            if (ModelState.IsValid)
            {
                await _bookservice.UpdateBook(booksModel);
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        //[HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookservice.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
