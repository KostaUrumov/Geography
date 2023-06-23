using GeographyCore.Services;
using GeographyCore.ViewModels.RiverModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    [Authorize]
    public class RiversController : Controller
    {
        private readonly GeographyDb data;
        private readonly RiverService servRiv;

        public RiversController(GeographyDb _data, RiverService _servRiv)
        {
            data = _data;
            servRiv = _servRiv;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddRiverViewModel
            {
                Countries = data.Countries.ToList(),
                Continents = data.Continents.ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRiverViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            bool isThere = servRiv.CheckIfItemIsThere(model.Name);
            if (isThere == true)
            {
                return View("RiverIsAlreadyIn");
            }

            await servRiv.Add(model);
            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            return View(servRiv.ListAll());
        }

        public IActionResult AllInGivenContinent(string continentName)
        {
            Continent continent = data.Continents.First(x => x.Name == continentName);
            if (continent == null)
            {
                return RedirectToAction("All");
            }

            return View(servRiv.AllInGivenContinent(continent));
        }
    }
}
