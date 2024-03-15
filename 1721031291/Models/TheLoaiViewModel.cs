using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1721031291_DaoHoangNhi.Models
{
    [Table("TheLoai")]
    public class TheLoaiViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Boolean IsDeleted { get; set; } = false;
    }
}
