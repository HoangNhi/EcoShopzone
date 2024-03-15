using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace _1721031291_DaoHoangNhi.Areas.Admin.Services
{
    public class ImageService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageService(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public Task<ImageProduct> Upload(IFormFile file)
        {
            var rootFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(rootFolder, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                file.CopyTo(stream);
                stream.Flush();
            }
            ImageProduct image = new ImageProduct
            {
                FileName = fileName,
                FilePath = "https://localhost:7021/static/images/" + fileName,
                FileSize = file.Length,
                OriginalFileName = file.FileName
            };
            _db.ImageProducts.Add(image);
            _db.SaveChanges();
            return Task.FromResult(image);
        }
        public Task DeleteImage(ImageProduct image)
        {
            var rootFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            var filePath = Path.Combine(rootFolder, image.FileName);
            var removed = _db.ImageProducts.Remove(image);
            System.IO.File.Delete(filePath);
            _db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
