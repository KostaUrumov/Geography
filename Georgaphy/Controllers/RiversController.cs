using GeographyCore.Services;
using GeographyCore.ViewModels.RiverModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            var list = servRiv.AllInGivenContinent(continent);
            if (list.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(list);
        }

        public async Task<IActionResult> VisitRiver(string riverName)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                await servRiv.VisitThisRiver(userId, riverName);
                return RedirectToAction(nameof(MyRivers));
            }

            return RedirectToAction("Index", "Home");

        }

        public IActionResult MyRivers()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                return View(servRiv.MyRivers(userId));
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
