﻿using GeographyCore.Services;
using GeographyCore.ViewModels.MountaineModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize(Policy = "AdminsOnly")]
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

            var list = montService.AllInGivenContinent(continent);
            if (list.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(list);
        }
        public IActionResult MyMountains()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                return View(montService.MyVisits(userId));
            }
            return RedirectToAction("Index", "Home");
            
        }

        public async Task<IActionResult> VisitMountain(string mountainName)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            bool wasThere = montService.IfUserWasThere(userId, mountainName);
            if (wasThere == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (userId != null)
                {
                    await montService.VisitThisPlace(userId, mountainName);
                    return RedirectToAction("MyMountains");
                }
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
