using GeographyCore.ViewModels.StreetModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;


namespace GeographyCore.Services
{
    public class StreetServices
    {
        private readonly GeographyDb data;
        public StreetServices(GeographyDb _data)
        {
            data = _data;
        }

        public async Task AddStreetAsync(AddStreetViewModel street)
        {
            Street newStreet = new Street()
            {
                Length = street.Length,
                CityId = street.CityId,
                Name = street.Name,
                Houses = new List<House>()
            };

            await data.Streets.AddAsync(newStreet);
            await data.SaveChangesAsync();
        }

        public List<StreetShowModel> GetAllHouses()
        {
            List<StreetShowModel> result = data
                .Streets
                .Select(x => new StreetShowModel
                {
                    Name = x.Name,
                    City = x.City.Name,
                    Length = x.Length
                })
                .ToList();

            return result;
        }
    }
}




