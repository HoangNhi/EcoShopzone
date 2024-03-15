namespace _1721031291_DaoHoangNhi.Models.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public List<IFormFile>? Images { get; set; }
        public int TheLoaiId { get; set; }
    }
}
