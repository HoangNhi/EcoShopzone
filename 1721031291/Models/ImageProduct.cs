using System.ComponentModel.DataAnnotations;

namespace _1721031291_DaoHoangNhi.Models
{
    public class ImageProduct
    {
        [Key]
        public long Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public long FileSize { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
