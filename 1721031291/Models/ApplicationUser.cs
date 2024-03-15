using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _1721031291_DaoHoangNhi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string Name { get; set; }
    }
}
