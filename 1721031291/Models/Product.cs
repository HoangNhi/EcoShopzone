using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1721031291_DaoHoangNhi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Description { get; set; }
        //public string ImageUrl { get; set; }
        public Boolean IsDeleted { get; set; } = false;

        public virtual List<ImageProduct> Images { get; set; }

        [Required]
        public int TheLoaiId { get; set; }
        [ForeignKey("TheLoaiId")]
        public TheLoaiViewModel TheLoaiViewModel { get; set; }
    }
}
