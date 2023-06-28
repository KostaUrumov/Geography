using GeographyCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class RegisterController : Controller
    {
        private readonly RegisterService regServ;

        public RegisterController(RegisterService _regServ)
        {
            regServ = _regServ;
        }

        [Authorize(Policy = "AdminsOnly")]
        public IActionResult AllRegisteredUsers()
        {
            return View(regServ.GetAllRegistered());
        }
        [HttpGet]
        public  IActionResult ChangeRole(string userId)
        {
            var user = regServ.FindUser(userId);

            user.Roles.Add("Admin");
            user.Roles.Add("User");

            return View(user);
        }
    }
}
