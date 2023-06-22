using GeographyCore.ViewModels.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace Georgaphy.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Search()
        {
            

            var model = new SearchViewModel()
            {
               listed = new List<string>
               { "Continent",
                 "Country", 
                 "River", 
                 "City", 
                 "Mountain"
               }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {

            return View();
        }
    }
}
