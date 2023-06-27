using GeographyCore.Contracts;
using GeographyCore.ViewModels.RiverModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.EntityFrameworkCore;

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

        public bool CheckIfItemIsThere(string name)
        {
            var findRiver = data.Rivers.FirstOrDefaultAsync(x => x.Name == name);
            if (findRiver != null)
            {
                return true;
            }
            return false;
        }

        public async Task VisitThisRiver(string userId, string riverName)
        {
            var river = data.Rivers.First(r => r.Name == riverName);
            UserRiver uRiv = new UserRiver()
            {
                RiverId = river.Id,
                UserId = userId
            };
            await data.UsersRvers.AddAsync(uRiv);
            await data.SaveChangesAsync();

        }

        public List<AddRiverViewModel> MyRivers(string userId)
        {
            List<AddRiverViewModel> models = data
                .UsersRvers
                .Where(u => u.UserId == userId)
                .Select(s => new AddRiverViewModel
                {
                    Name = s.River.Name,
                    Length = s.River.Lenghth,
                    Continent = s.River.Continent.Name,
                    Country = s.River.Country.Name
                })
                .ToList();
            return models;
        }
    }
}
