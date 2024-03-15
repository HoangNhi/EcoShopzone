using System.ComponentModel.DataAnnotations;

namespace _1721031291_DaoHoangNhi.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public string Description { get; set; }
    }
}
