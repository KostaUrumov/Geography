using GeographyCore.Services;
using GeographyCore.ViewModels.CountryModels;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    [Authorize]
    public class CountriesController : Controller
    {
        private readonly CountryServices countryServ;
        private readonly GeographyDb data;
        public CountriesController(CountryServices _countryServ, GeographyDb _data)
        {
            countryServ = _countryServ;
            data = _data;
        }

        [HttpGet]
        public IActionResult AddCountry()
        {
            var country = new AddCountryViewModel()
            {
                Continents = data.Continents.ToList()
            };
            return View(country);
        }

        [HttpPost]
        public async Task <IActionResult> AddCountry(AddCountryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            bool isThere = countryServ.CheckIfItemIsThere(model.Name);
            if (isThere == true)
            {
                
                return View("CountryIsAlreadyIn");
            }
            await countryServ.addCountryAsync(model);

            return RedirectToAction ("AllCountries");
        }

        public IActionResult AllCountries()
        {
            return View(countryServ.ListAllCountries());
        }

        public IActionResult CountryLocation(string location)
        {
            
            return Redirect(location);
        }

    }
}
