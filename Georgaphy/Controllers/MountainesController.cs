using GeographyCore.Services;
using GeographyCore.ViewModels.MountaineModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    [Authorize]
    public class MountainesController : Controller
    {
        private readonly MountaineService montService;
        private readonly GeographyDb data;

        public MountainesController(MountaineService _montService, GeographyDb _data)
        {
            montService = _montService;
            data = _data;
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddMounainrViewModel model = new AddMounainrViewModel()
            {
                Continents = data.Continents.ToList(),
                Countries = data.Countries.ToList(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add (AddMounainrViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            bool isThere = montService.CheckIfItemIsThere(model.Name);
            if (isThere == true)
            {
                return View("MountainIsAlreadyIn");
            }

            await montService.Add(model);
            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            return View(montService.ListAll());
        }

        public IActionResult AllInGivenContinent(string continentName)
        {
            Continent continent = data.Continents.First(x => x.Name == continentName);
            if (continent == null)
            {
                return RedirectToAction("All");
            }

            return View(montService.AllInGivenContinent(continent));
        }
    }
}
