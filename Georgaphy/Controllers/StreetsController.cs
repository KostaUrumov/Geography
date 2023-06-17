using GeographyCore.Services;
using GeographyCore.ViewModels.StreetModels;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    [Authorize]
    public class StreetsController : Controller
    {
        private readonly StreetServices streetServ;
        private readonly GeographyDb data;

        public StreetsController(StreetServices _streetServ, GeographyDb _data)
        {
            streetServ = _streetServ;
            data = _data;
        }

        public IActionResult AddStreet()
        {
            var model = new AddStreetViewModel()
            {
                Cities = data.Cities.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddStreet(AddStreetViewModel street)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            await streetServ.AddStreetAsync(street);
            return RedirectToAction("AllStreets");
        }

        public IActionResult AllStreets()
        {
            return View(streetServ.GetAllHouses());
        }
    }
}
