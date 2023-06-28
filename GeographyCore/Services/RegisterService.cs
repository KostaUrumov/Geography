using GeographyCore.ViewModels.RegisterModels;
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

    }
}
