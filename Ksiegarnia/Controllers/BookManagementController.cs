using Ksiegarnia.Data;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ksiegarnia.Controllers
{
    public class BookManagementController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookManagementController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _bookRepository.AddBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = _bookRepository.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _bookRepository.UpdateBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _bookRepository.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
