using GeographyStracture.Data;
using GeographyStracture.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace GeographyCore.ViewModels.CountryModels
{
    public class AddCountryViewModel
    {
        [Required]
        [StringLength(DataConstraints.Country.MaxCountryNameLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Continent>? Continents { get; set; } = new List<Continent>();

        public int ContinentId { get; set; }

        [Required]
        public double Area { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        public double RoadsKm { get; set; }

        [Required]
        [StringLength(DataConstraints.Country.MaxUrlLength)]
        public string FlagUrl { get; set; } = null!;

    }
}
