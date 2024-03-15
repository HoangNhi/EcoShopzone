using _1721031291_DaoHoangNhi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1721031291_DaoHoangNhi.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public BrandViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brand = await _db.TheLoaiViewModels.ToListAsync();
            return View(brand);
        }
    }
}
