using GeographyStracture.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GeographyCore.ViewModels.HouseModels
{
    public class HouseShowModel
    {
        public string Street { get; set; } = null!;
        public int Adress { get; set; }
        public int NumberFloors { get; set; }
        public List<IdentityUser> Resudents { get; set; } = new List<IdentityUser>();
    }
}
