using _1721031291_DaoHoangNhi.Areas.Admin.Services;
using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace _1721031291_DaoHoangNhi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ImageService _imageService;

        public ImageProductController(ApplicationDbContext db, ImageService imageService)
        {
            _db = db;
            _imageService = imageService;
        }
        public IActionResult Index()
        {
            var images = _db.ImageProducts.ToList();
            return View(images);
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                _imageService.Upload(file);
            }
            return RedirectToAction("Index");
        }
    }
}
