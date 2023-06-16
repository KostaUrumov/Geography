using GeographyCore.Services;
using GeographyCore.ViewModels.HouseModels;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Georgaphy.Controllers
{
    [Authorize]
    public class HousesController : Controller
    {
        private readonly HouseService serviceHouse;
        private readonly GeographyDb context;

        public HousesController(HouseService _serviceHouse, GeographyDb _context)
        {
            serviceHouse = _serviceHouse;
            context = _context;
        }

        [HttpGet]
        public  IActionResult AddHouse()
        {
            var model = new AddHouseViewModel()
            {
                Streets = context.Streets.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddHouse(AddHouseViewModel house)
        {
            await serviceHouse.AddHouseAsync(house);
            return RedirectToAction("AllHouses");
        }

        public IActionResult AllHouses()
        {
            return View(serviceHouse.GetAllHouses());
        }
    }
}
 
