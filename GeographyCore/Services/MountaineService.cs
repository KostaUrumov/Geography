using GeographyCore.Contracts;
using GeographyCore.ViewModels.MountaineModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.EntityFrameworkCore;

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

        public bool CheckIfItemIsThere(string name)
        {
            var findMountaine = data.Mountines.FirstOrDefaultAsync(x => x.Name == name);
            if (findMountaine.Result != null)
            {
                return true;
            }
            return false;
        }

        public async Task VisitThisPlace(string userId, string montName)
        {
            var mountan = data.Mountines.First(m => m.Name == montName);
            UserMountain uMont = new UserMountain()
            {
                MountainId = mountan.Id,
                UserId = userId
            };
            await data.UsersMoutains.AddAsync(uMont);
            await data.SaveChangesAsync();
        }

        public List<AddMounainrViewModel> MyVisits(string userId)
        {
            List<AddMounainrViewModel> result = data
                .UsersMoutains
                .Where(u => u.UserId == userId)
                .Select(f => new AddMounainrViewModel
                {
                    Name = f.Mountain.Name,
                    Continent = f.Mountain.Continent.Name,
                    Country = f.Mountain.Country.Name,
                    Area = f.Mountain.Area
                })
                .ToList();
            return result;
        }

        public bool IfUserWasThere(string userId, string montName)
        {
            var mountan = data.Mountines.First(m => m.Name == montName);
            UserMountain uMont = new UserMountain()
            {
                MountainId = mountan.Id,
                UserId = userId
            };
            bool wasThere = data.UsersMoutains.Contains(uMont);
            if (wasThere == false)
            {
                return false;
            }
            return true;

        }
    }
}
