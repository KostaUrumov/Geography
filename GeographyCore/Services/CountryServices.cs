using GeographyCore.ViewModels.CountryModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.EntityFrameworkCore;

namespace GeographyCore.Services
{
    public class CountryServices
    {
        private readonly GeographyDb data;

        public CountryServices(GeographyDb _data)
        {
            data = _data;
        }


        public async Task addCountryAsync(AddCountryViewModel model)
        {
            Country countryNew = new Country()
            {
                Name = model.Name,
                Area = model.Area,
                ContinentId = model.ContinentId,
                Population = model.Population,
                RoadsKm = model.RoadsKm,
                FlagUrl = model.FlagUrl,
                LocationUrl = model.GoogleMapsUrl
            };

            await data.Countries.AddAsync(countryNew);
            await data.SaveChangesAsync();
        }

        public List<ShowCountriesModel> ListAllCountries()
        {
            var listed = data
                .Countries
                .Include(i=>i.Continent)
                .Select(x => new ShowCountriesModel
                {
                    Flag = x.FlagUrl,
                    Population = x.Population,
                    Area = x.Area,
                    Name = x.Name,
                    Continent = x.Continent.Name,
                    GoogleMapsUrl = x.LocationUrl
                })
                .ToList();
            return listed;
        }

        public Country FindCountry(string countryName)
        {
            Country cont = data.Countries.First(x=>x.Name == countryName);
            return cont;
        }

        public bool CheckIfItemIsThere(string name)
        {
            var findCountry = data.Countries.FirstOrDefaultAsync(x => x.Name == name);
            if (findCountry.Result != null)
            {
                return true;
            }
            return false;
        }

        public async Task VistThisCountry(string userId, string countryName)
        {
            var country = data.Countries.First(x => x.Name == countryName);

            UserCountry uCou = new UserCountry()
            {
                UserId = userId,
                CountryId = country.Id
            };
            await data.UsersCountries.AddAsync(uCou);
            await data.SaveChangesAsync();
        }
        public List<ShowCountriesModel> MyVisits(string userId)
        {
            List<ShowCountriesModel> listed = data
                .UsersCountries
                .Where(u => u.UserId == userId)
                .Select(c => new ShowCountriesModel()
                {
                    Flag = c.Country.FlagUrl,
                    Population = c.Country.Population,
                    Area = c.Country.Area,
                    Name = c.Country.Name,
                    Continent = c.Country.Continent.Name,
                    GoogleMapsUrl = c.Country.LocationUrl
                })
                .ToList();
            return listed;
        }

    }
}
