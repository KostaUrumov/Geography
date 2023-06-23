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
                FlagUrl = model.FlagUrl
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
                    Continent = x.Continent.Name
                })
                .ToList();
            return listed;
        }

        public Country FindCountry(string countryName)
        {
            Country cont = data.Countries.First(x=>x.Name == countryName);
            return cont;
        }
    }
}
