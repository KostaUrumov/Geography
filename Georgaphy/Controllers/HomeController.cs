using GeographyCore.Services;
using Georgaphy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Georgaphy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContinentService continent;
        public HomeController(ContinentService _continent)
        {
            continent = _continent;
        }

        public IActionResult Index()
        {
            return View(continent.getAllContinents());
        }

        public IActionResult Mine()
        {
            return View();
        }

        [Authorize(Policy = "AdminsOnly")]
        public IActionResult AddData()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}