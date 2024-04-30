using Books_sec02revised.Data;
using Books_sec02revised.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Books_sec02revised.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private BooksDBContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BooksDBContext booksDBContext)
        {
            _logger = logger;
            _dbContext = booksDBContext;
        }

        public IActionResult Index()
        {
            var listofbooks = _dbContext.Books.Include(c => c.category);
            return View(listofbooks.ToList());
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            Book book=_dbContext.Books.Find(Id); // fetches book
            _dbContext.Books.Entry(book).Reference(b=> b.category).Load(); //laods the category

            var cart = new Cart
            {
                BookId = Id,
                book = book,
                Quantity = 1

            };


            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(Cart cart)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // fetches the user id

            cart.UserId = userId;

            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}