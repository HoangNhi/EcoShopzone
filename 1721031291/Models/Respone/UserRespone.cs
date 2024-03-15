namespace _1721031291_DaoHoangNhi.Models.Respone
{
    public class UserRespone
    {
        public ApplicationUser User { get; set; }
        public IList<string> Role { get; set; }
        public string RoleId { get; set; }
    }
}
