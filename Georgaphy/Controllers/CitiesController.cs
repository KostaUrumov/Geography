using GeographyCore.Services;
using GeographyCore.ViewModels.CityModels;
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
            await cityServices.AddcityAsync(city);
            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            return View(cityServices.ListAllCities());
        }

    }
}
