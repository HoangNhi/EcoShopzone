using _1721031291_DaoHoangNhi.Data;
using _1721031291_DaoHoangNhi.Models;
using _1721031291_DaoHoangNhi.Models.Respone;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace _1721031291_DaoHoangNhi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            List<UserRespone> users = new List<UserRespone>();

            var allUsers = _userManager.Users.ToList();
            foreach (var user in allUsers)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userViewModel = new UserRespone
                {
                    User = user,
                    Role = userRoles
                };
                users.Add(userViewModel);
            }
            string UserCheck = JsonConvert.SerializeObject(users); // Sử dụng Newtonsoft.Json.JsonConvert để serialize đối tượng thành JSON.
            ViewBag.UserCheck = UserCheck;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id) 
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            var Role = await _userManager.GetRolesAsync(user);
            UserRespone userRespone = new UserRespone()
            {
                User = user,
                Role = Role,
                RoleId = _roleManager.Roles.Single(x => x.Name == Role[0]).Id
            };
            IEnumerable<SelectListItem> Roles = _roleManager.Roles
                .Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });
            ViewBag.Roles = Roles;
            ViewBag.UserRespone = JsonConvert.SerializeObject(userRespone);
            return View(userRespone);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserRespone userRespone)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userRespone.User.Id);
            string RoleName = await _roleManager.GetRoleNameAsync(_roleManager.Roles.SingleOrDefault(x => x.Id == userRespone.RoleId));

            user.Name = userRespone.User.Name;
            user.PhoneNumber = userRespone.User.PhoneNumber;
            user.Email = userRespone.User.Email;

            // Update New Role For User
            await _userManager.RemoveFromRolesAsync(user, _userManager.GetRolesAsync(user).Result);
            await _userManager.AddToRoleAsync(user, RoleName);

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        
    }
}
