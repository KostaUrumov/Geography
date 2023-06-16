using GeographyCore.ViewModels.HouseModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GeographyCore.Services
{
    public class HouseService
    {
        private readonly GeographyDb data;
        public HouseService(GeographyDb _data)
        {
            data = _data;
        }

        public async Task AddHouseAsync(AddHouseViewModel house)
        {
            var newHouse = new House()
            {
                StreetId = house.StreetId,
                NumberOfFloors = house.NumberOfFloors,
                Address = house.Address,
                Rooms = house.Rooms,
                Residents = new List<IdentityUser>()
            };

            await data.Houses.AddAsync(newHouse);
            await data.SaveChangesAsync();
        }

        public List<HouseShowModel> GetAllHouses()
        {
            List<HouseShowModel> listedHouses = data
                .Houses
                .Include(x => x.Street)
                .Select(s => new HouseShowModel
                {
                    Street = s.Street.Name,
                    Adress = s.Address,
                    Resudents = (List<IdentityUser>)s.Residents.OrderByDescending(p => p.Id),
                    NumberFloors = s.NumberOfFloors
                })
                .ToList();

            return listedHouses;
        }
    }
}
