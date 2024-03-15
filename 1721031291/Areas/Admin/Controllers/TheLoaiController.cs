using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1721031291_DaoHoangNhi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var theloai = _db.TheLoaiViewModels.OrderBy(x => x.Id).ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoaiViewModel model)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoaiViewModels.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.TheLoaiViewModels.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TheLoaiViewModel model)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoaiViewModels.Update(model);
                _db.TheLoaiViewModels.OrderBy(x => x.Id);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.TheLoaiViewModels.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TheLoaiViewModel model)
        {
            var models = _db.TheLoaiViewModels.Find(model.Id);
            models.IsDeleted = true;
            _db.TheLoaiViewModels.Update(models);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _db.TheLoaiViewModels.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
