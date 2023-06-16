using System.ComponentModel.DataAnnotations;
using GeographyStracture.Data.Entities;

namespace GeographyCore.ViewModels.HouseModels
{
    public class AddHouseViewModel
    {
        [Required]
        public int StreetId { get; set; }

        public ICollection<Street> Streets { get; set; } = new List<Street>();

        [Required]
        public int NumberOfFloors { get; set; }

        [Required]
        public int Address { get; set; }

        public int Rooms { get; set; }
    }

}
