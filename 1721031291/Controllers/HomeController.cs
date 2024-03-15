using _1721031291.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _1721031291_DaoHoangNhi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.HoTen = "Đào Hoàng Nhi";
            ViewBag.MSSV = "1721031291";
            ViewBag.Nam = "2023";
            return View();
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