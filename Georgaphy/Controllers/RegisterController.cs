using GeographyCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
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
    }
}
