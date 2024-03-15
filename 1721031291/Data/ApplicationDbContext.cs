using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _1721031291_DaoHoangNhi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> Aplications { get; set; }
        public DbSet<TheLoaiViewModel> TheLoaiViewModels { get; set;}
        public DbSet<Image> Images { get; set;}
        public DbSet<NhaCungCap> NhaCungCaps { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<ImageProduct> ImageProducts { get; set;}
        public DbSet<Cart> Carts { get; set;}
    }
}
