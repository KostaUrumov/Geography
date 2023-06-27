using Microsoft.AspNetCore.Identity;

namespace GeographyStracture.Data.Entities
{
    public class User : IdentityUser
    {
        public List<UserCity> UsersCities { get; set; } = new List<UserCity>();
        public List<UserCountry> UsersCountries { get; set; } = new List<UserCountry>();
        public List<UserMountain> UsersMountains { get; set; } = new List<UserMountain>();
        public List<UserRiver> UsersRvers { get; set; } = new List<UserRiver>();
    }
}
