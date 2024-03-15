using System.ComponentModel.DataAnnotations;

namespace _1721031291_DaoHoangNhi.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
    }
}
