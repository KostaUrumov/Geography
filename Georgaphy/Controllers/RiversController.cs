using GeographyCore.Services;
using GeographyCore.ViewModels.RiverModels;
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

            await servRiv.Add(model);
            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            return View(servRiv.ListAll());
        }
    }
}
