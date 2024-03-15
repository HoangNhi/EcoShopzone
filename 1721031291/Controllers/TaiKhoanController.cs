using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1721031291.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taiKhoanViewModel)
        {
            if(taiKhoanViewModel.Fullname != null)
            {
                return Content("Username: " + taiKhoanViewModel.Username +
                                "\nPassword: " + taiKhoanViewModel.Password +
                                "\nFullname: " + taiKhoanViewModel.Fullname +
                                "\nAge: " + taiKhoanViewModel.Age);
            }else return View();
        }

        public IActionResult BaiTap2()
        {
            var sanpham = new SanPhamViewModel()
            {
                TenSanPham = "Ứng dụng Wisewallet Manager",
                GiaBan = 99000,
                AnhMoTa = "/Img/Logo.jpg"
            };
            return View(sanpham);
        }
    }
}
