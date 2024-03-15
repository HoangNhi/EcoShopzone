using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1721031291_DaoHoangNhi.Controllers
{
    [Area("Admin")]
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ImageController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var images = _db.Images.ToList();
            return View(images);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, string description)
        {
            if (file != null && file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var image = new Image
                    {
                        ImageData = ms.ToArray(),
                        ImageName = file.FileName,
                        Description = description
                    };
                    _db.Images.Add(image);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
