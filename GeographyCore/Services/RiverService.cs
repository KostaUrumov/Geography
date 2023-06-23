using GeographyCore.Contracts;
using GeographyCore.ViewModels.RiverModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;

namespace GeographyCore.Services
{
    public class RiverService : IService<AddRiverViewModel>
    {
        private readonly GeographyDb data;

        public RiverService(GeographyDb _data)
        {
            data = _data;
        }
        public async Task Add(AddRiverViewModel model)
        {
            River riv = new River()
            {
                Name = model.Name,
                Lenghth = model.Length,
                ContinentId = model.ContinentId,
                CountryId = model.CountryId,
            };
            await data.AddAsync(riv);
            await data.SaveChangesAsync();
        }

        public List<AddRiverViewModel> ListAll()
        {
            List<AddRiverViewModel> models = data
                .Rivers
                .Select(c => new AddRiverViewModel
                {
                    Name = c.Name,
                    Length = c.Lenghth,
                    Continent = c.Continent.Name,
                    Country = c.Country.Name
                })
                .ToList();
            
            return models;
        }

        public List<AddRiverViewModel> AllInGivenContinent(Continent continent)
        {
            List<AddRiverViewModel> result = data
                .Rivers
                .Where(x=>x.Continent == continent)
                .Select(c => new AddRiverViewModel
                {
                    Name = c.Name,
                    Length = c.Lenghth,
                    Continent = c.Continent.Name,
                    Country = c.Country.Name
                })
                .ToList();

            return result;
        }
    }
}
