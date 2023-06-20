using GeographyCore.Services;
using GeographyCore.ViewModels.CityModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    [Authorize]
    public class CitiesController :Controller
    {
        private readonly CityServices cityServices;
        private readonly GeographyDb data;
        public CitiesController(CityServices _cityServices, GeographyDb _data)
        {
            cityServices = _cityServices;
            data = _data;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddNewCityModel()
            {
                Countries = data.Countries.ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Add(AddNewCityModel city)
        {
            
            await cityServices.Add(city);
            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            return View(cityServices.ListAll());
        }

        public IActionResult AllInGivenCountry(string countryName)
        {
            Country country = data.Countries.First(x => x.Name == countryName);
            if (country == null)
            {
                return RedirectToAction("All");
            }
            return View(cityServices.AllInGivenCountry(country));
        }

    }
}
