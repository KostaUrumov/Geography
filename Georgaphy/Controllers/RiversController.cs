using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    public class RiversController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
