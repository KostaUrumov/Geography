using GeographyStracture.Data;
using GeographyStracture.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace GeographyCore.ViewModels.RiverModels
{
    public class AddRiverViewModel
    {
        [StringLength(DataConstraints.Mountine.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Length { get; set; }


        public int ContinentId { get; set; }

        public IEnumerable<Continent>? Continents { get; set; } = new List<Continent>();
        public string? Continent { get; set; }

        public string? Country { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<Country>? Countries { get; set; } = new List<Country>();
    }
}
