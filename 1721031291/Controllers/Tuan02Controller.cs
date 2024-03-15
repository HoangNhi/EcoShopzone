using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace _1721031291_DaoHoangNhi.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Đào Hoàng Nhi";
            ViewBag.MSSV = "1721031291";
            ViewBag.Nam = "2023";
            return View();
        }
        public IActionResult MayTinh(int a, int b, String phepTinh)
        {
            double res = 0 ;
            try
            {
                switch (phepTinh) 
                {
                    case "cong":
                        {
                            res =  1.0*a + b;
                            break;
                        }
                    case "tru":
                        {
                            res = 1.0 * a - b;
                            break;
                        }
                    case "nhan":
                        {
                            res = 1.0 * a * b;
                            break;
                        }
                    case "chia":
                        {
                            if (b == 0)
                            {
                                ViewBag.KetQua = "ERROR";
                                return View();
                            }
                            res = 1.0 * a / b;
                            break;
                        }
                }
            }catch
            {
                ViewBag.KetQua = "ERROR";
                return View();
            }
            ViewBag.KetQua = res;
            return View();
        }
        public IActionResult Profile() 
        {
            return View();
        }
    }
}
