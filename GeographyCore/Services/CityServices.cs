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
                  Area = x.Area,
                  
              })
              .ToList();
            return result;
        }

        public List<AddNewCityModel> AllInGivenCountry(GeographyStracture.Data.Entities.Country country)
        {
            List<AddNewCityModel> result = data
                .Cities
                .Include(c => c.Country)
                .Where(x=>x.CountryId == country.Id)
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

        public List<AddNewCityModel> AllInGivenContinent(Continent continent)
        {
            List<AddNewCityModel> result = data
                .Cities
                .Where(x=>x.Country.Continent.Name == continent.Name)
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

        public bool CheckIfItemIsThere(string name)
        {
            var findCity = data.Cities.FirstOrDefaultAsync(x => x.Name == name);
            if (findCity.Result != null)
            {
                return true;
            }
            return false;
        }

        public async Task VisitCity(string userId, string cityName)
        {
            var city = data.Cities.First(x => x.Name == cityName);

            UserCity userCity = new UserCity()
            {
                UserId = userId,
                CityId = city.Id
            };

            await data.UsersCities.AddAsync(userCity);
            await data.SaveChangesAsync();
        }

        public List<AddNewCityModel> MyVisits(string userId)
        {
            List<AddNewCityModel> models = data
                .UsersCities
                .Where(u => u.UserId == userId)
                .Select(c => new AddNewCityModel
                {
                    Name = c.City.Name,
                    Country = c.City.Country.Name,
                    Population = c.City.Population,
                    LandscapePicture = c.City.LandscapePicture,
                    Area = c.City.Area
                })
                .ToList();
            return models;
        }
    }
}

