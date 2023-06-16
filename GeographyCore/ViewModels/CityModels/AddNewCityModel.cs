using GeographyStracture.Data;
using GeographyStracture.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace GeographyCore.ViewModels.CityModels
{
    public class AddNewCityModel
    {
        [Required]
        [StringLength(DataConstraints.City.MaxNameLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Country>? Countries { get; set; } = new List<Country>();
        
        public int CountryId { get; set; }

        [Required]
        public double Area { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        [StringLength(DataConstraints.City.MaxUrlLength)]
        public string LandscapePicture { get; set; } = null!;
    }
}
