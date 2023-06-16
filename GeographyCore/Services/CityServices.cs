using GeographyCore.ViewModels.CityModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GeographyCore.Services
{
    public class CityServices
    {
        private readonly GeographyDb data;

        public CityServices(GeographyDb _data)
        {
            data = _data;
        }

        public async Task AddcityAsync(AddNewCityModel model)
        {
            City cityNew = new City()
            {
                Area = model.Area,
                Population = model.Population,
                Name = model.Name,
                CountryId = model.CountryId,
                LandscapePicture = model.LandscapePicture
            };

            await data.Cities.AddAsync(cityNew);
            await data.SaveChangesAsync();
        }

        public List<ShowCityModelView> ListAllCities()
        {
              List<ShowCityModelView> result = data
                .Cities
                .Include(c => c.Country)
                .Select(x => new ShowCityModelView
                {
                    Name = x.Name,
                    Country = x.Country.Name,
                    Population = x.Population,
                    Landscape = x.LandscapePicture,
                    Area = x.Area
                })
                .ToList();

            return result;
        }

    }
}

