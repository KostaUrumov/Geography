using GeographyCore.ViewModels.RegisterModels;
using GeographyStracture.Data.Entities;
using GeorgaphyStracture.Data;

namespace GeographyCore.Services
{
    public class RegisterService
    {
        private readonly GeographyDb data;
        public RegisterService(GeographyDb _data)
        {
            data = _data;
        }

        public List<People> GetAllRegistered()
        {
            List<People> result = data
                .Users
                .Select(u => new People
                {
                    Name = u.UserName,
                    Id = u.Id
                })
                .ToList();
            
            return result;
        }

        public People FindUser(string userId)
        {
            var mar = data.Users.First(u => u.Id == userId);
            
            People person = new People()
            {
                Name = mar.UserName,
                Id = mar.Id,
               
            };
            return person;

        }

        



    }
}
