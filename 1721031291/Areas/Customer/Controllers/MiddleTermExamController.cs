using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace _1721031291_DaoHoangNhi.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MiddleTermExamController : Controller
    {
        private readonly ApplicationDbContext _db;

        [ActivatorUtilitiesConstructor]
        public MiddleTermExamController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> product = _db.Products.Include("TheLoaiViewModel").Include(item => item.Images).ToList();
            ViewBag.Title = "Home - ECO-SHOPZONE";
            return View(product);
        }

        public IActionResult Cart()
        {
            ViewBag.Title = "Cart - ECO-SHOPZONE";
            return View();
        }

        [Route("/Checkout")]
        public IActionResult Checkout()
        {
            ViewBag.Title = "Checkout - ECO-SHOPZONE";
            return View();
        }
        [Route("Login")]
        public IActionResult Login()
        {
            ViewBag.Title = "Login - ECO-SHOPZONE";
            return View();
        }

        [Route("/Brands/{id}")]
        public IActionResult Category(int id)
        {
            List<Product> products = _db.Products
                .Include(p => p.Images)
                .Where(x => x.TheLoaiId == id).ToList();
            ViewBag.Title = "Category - ECO-SHOPZONE";
            ViewBag.Brands = _db.TheLoaiViewModels.Find(products[0].TheLoaiId).Name;
            return View(products);
        }

        public IActionResult ProductOffer()
        {
            return View();
        }
        [Route("/ProductSingle/{id}")]
        [HttpGet]
        public IActionResult ProductSingle(int id)
        {
            ViewBag.Title = "Product - ECO-SHOPZONE";

            Cart cart = new Cart
            {
                ProductId = id,
                Quantity = 1,
                product = _db.Products.Include(item => item.Images)
                                          .Include(item => item.TheLoaiViewModel)
                                          .FirstOrDefault(item => item.Id == id)
            };
            IEnumerable<Product> products = _db.Products.Include("TheLoaiViewModel").Include(item => item.Images).ToList();
            ViewBag.Products = products;
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult ProductSingle(Cart cart)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            cart.UserId = claim.Value;

            _db.Carts.Add(cart);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
