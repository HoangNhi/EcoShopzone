using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1721031291_DaoHoangNhi.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NhaCungCapController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var NhaCungCap = _db.NhaCungCaps.OrderBy(x => x.Id).ToList();
            ViewBag.NhaCungCap = NhaCungCap;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NhaCungCap model)
        {
            _db.NhaCungCaps.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.NhaCungCaps.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(NhaCungCap model)
        {
            if (ModelState.IsValid)
            {
                _db.NhaCungCaps.Update(model);
                _db.NhaCungCaps.OrderBy(x => x.Id);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.NhaCungCaps.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(NhaCungCap model)
        {
            _db.NhaCungCaps.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _db.NhaCungCaps.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
