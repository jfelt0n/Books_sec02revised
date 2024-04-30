using Books_sec02revised.Data;
using Books_sec02revised.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Books_sec02revised.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private BooksDBContext _dbContext;

        public BookController(BooksDBContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            var listofbooks = _dbContext.Books.ToList();
            return View(listofbooks);

        }
        [HttpGet]

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> listofCategories = _dbContext.Categories.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString(),
            });
            BooksWithCategoriesVM bookWithCategoriesVMObj = new BooksWithCategoriesVM();

            bookWithCategoriesVMObj.Book = new Book();

            bookWithCategoriesVMObj.ListOfCategories = listofCategories;

            return View(bookWithCategoriesVMObj);
        }
        [HttpPost]

        public IActionResult Create(BooksWithCategoriesVM booksWithCategoriesVMObj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Add(booksWithCategoriesVMObj.Book);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View(booksWithCategoriesVMObj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = _dbContext.Books.Find(id);
            IEnumerable<SelectListItem> listofCategories = _dbContext.Categories.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString(),
            });
            BooksWithCategoriesVM booksWithCategoriesVM = new BooksWithCategoriesVM();
            booksWithCategoriesVM.Book = book;

            booksWithCategoriesVM.ListOfCategories = listofCategories;



            return View(booksWithCategoriesVM);
        }
        [HttpPost]
        public IActionResult Edit(BooksWithCategoriesVM booksWithCategoriesVM)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Update(booksWithCategoriesVM.Book);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(booksWithCategoriesVM);
        }
    }
}
