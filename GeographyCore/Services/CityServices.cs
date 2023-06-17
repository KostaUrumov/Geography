using GeographyCore.Contracts;
using GeographyCore.ViewModels.CityModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.EntityFrameworkCore;

namespace GeographyCore.Services
{
    public class CityServices : IService<AddNewCityModel>
    {
        private readonly GeographyDb data;

        public CityServices(GeographyDb _data)
        {
            data = _data;
        }

        public async Task Add(AddNewCityModel model)
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

        public List<AddNewCityModel> ListAll()
        {
              List<AddNewCityModel> result = data
                .Cities
                .Include(c => c.Country)
                .Select(x => new AddNewCityModel
                {
                    Name = x.Name,
                    Country = x.Country.Name,
                    Population = x.Population,
                    LandscapePicture = x.LandscapePicture,
                    Area = x.Area
                })
                .ToList();

            return result;
        }
        
    }
}

