using GeographyCore.Contracts;
using GeographyCore.ViewModels.MountaineModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;

namespace GeographyCore.Services
{
    public class MountaineService : IService<AddMounainrViewModel>
    {
        private readonly GeographyDb data;
        
        public MountaineService(GeographyDb _data)
        {
              data = _data;
        }

        public async Task Add(AddMounainrViewModel model)
        {
            Mountaine mont = new Mountaine()
            {
                Name = model.Name,
                ContinentId = model.ContinentId,
                CountryId = model.CountryId,
                Area = model.Area,
            };

            await data.Mountines.AddAsync(mont);
            await data.SaveChangesAsync(); 
        }

        public List<AddMounainrViewModel> ListAll()
        {
           List<AddMounainrViewModel> models =  data
                .Mountines
                .Select(x=> new AddMounainrViewModel
                {
                    Name = x.Name,
                    ContinentId = x.ContinentId,
                    CountryId = x.CountryId,
                    Area = x.Area,
                    Continent = x.Continent.Name,
                    Country = x.Country.Name
                    
                })
                .ToList();

            return models;
        }

        public List<AddMounainrViewModel> AllInGivenContinent(Continent continent)
        {
            List<AddMounainrViewModel> result = data
                .Mountines
                .Where(x=>x.Continent == continent)
                .Select(x => new AddMounainrViewModel
                {
                    Name = x.Name,
                    ContinentId = x.ContinentId,
                    CountryId = x.CountryId,
                    Area = x.Area,
                    Continent = x.Continent.Name,
                    Country = x.Country.Name

                })
                .ToList();

            return result;
        }
    }
}
