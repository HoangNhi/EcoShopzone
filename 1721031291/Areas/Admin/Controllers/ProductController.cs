using _1721031291_DaoHoangNhi.Areas.Admin.Services;
using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using _1721031291_DaoHoangNhi.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _1721031291_DaoHoangNhi.Areas.Identity.Pages.Account;
using Newtonsoft.Json;

namespace _1721031291_DaoHoangNhi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ImageService _imageService;
        public ProductController(ApplicationDbContext db, ImageService imageService)
        {
            _db = db;
            _imageService = imageService;
        }
        public IActionResult Index()
        {
            // Không hiển thị các sản phẩm mà TheLoai đã bị xóa
            IEnumerable<Product> Product = _db.Products
                    .Where(item => !item.IsDeleted)
                    .Include("TheLoaiViewModel")
                    .Where(item => !item.TheLoaiViewModel.IsDeleted)
                    .Include(item => item.Images)
                    .ToList();
            ViewBag.products = Product;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> dstheloai = _db.TheLoaiViewModels
                .Where(item => !item.IsDeleted)
                .Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });
            ViewBag.DSTheLoai = dstheloai;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductRequest product)
        {
            Product newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Images = new List<ImageProduct>(),
                TheLoaiId = product.TheLoaiId
            };
            if (product.Images.Any())
            {
                foreach (IFormFile image in product.Images)
                {
                    ImageProduct img = _imageService.Upload(image).Result;
                    newProduct.Images.Add(img);
                }
            }
            _db.Products.Add(newProduct);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Product product = new Product();
            IEnumerable<SelectListItem> dstheloai = _db.TheLoaiViewModels
                .Where(item => !item.IsDeleted)
                .Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0)
            {
                return View(product);
            }
            else
            {
                product = _db.Products.Include(item => item.Images).Include("TheLoaiViewModel").FirstOrDefault(item => item.Id == id);
                ProductRequest p = new ProductRequest()
                {
                  Name = product.Name,
                  Description = product.Description,
                  Price = product.Price,
                  Id = product.Id
                };
                ViewBag.Images = product.Images;
                return View(p);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductRequest product)
        {
            Product UpdateProduct = _db.Products.Include(p => p.Images).SingleOrDefault(p => p.Id == product.Id);

            UpdateProduct.Name = product.Name;
            UpdateProduct.Description = product.Description;
            UpdateProduct.Price = product.Price;
            UpdateProduct.TheLoaiId = product.TheLoaiId;
            if(product.Images != null)
            {
                List<ImageProduct> imagesToDelete = new List<ImageProduct>();

                foreach (var image in UpdateProduct.Images)
                {
                    imagesToDelete.Add(image);
                }

                foreach (var image in imagesToDelete)
                {
                    _imageService.DeleteImage(image);
                }
                UpdateProduct.Images.Clear();
                foreach (IFormFile image in product.Images)
                {
                    ImageProduct img = _imageService.Upload(image).Result;
                    UpdateProduct.Images.Add(img);
                }
            }
            _db.Products.Update(UpdateProduct);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            product.IsDeleted = true;
            _db.Products.Update(product);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
