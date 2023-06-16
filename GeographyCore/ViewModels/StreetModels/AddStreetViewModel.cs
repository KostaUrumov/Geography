using GeographyStracture.Data.Entities;
using GeographyStracture.Data;
using System.ComponentModel.DataAnnotations;

namespace GeographyCore.ViewModels.StreetModels
{
    public class AddStreetViewModel
    {
        [Required]
        [StringLength(DataConstraints.Street.MaxNameLength)]
        public string Name { get; set; } = null!;
        [Required]
        public int CityId { get; set; }

        public IEnumerable<City> Cities { get; set; } = new List<City>();

        [Required]
        public double Length { get; set; }

    }
}
