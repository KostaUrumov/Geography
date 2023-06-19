using GeographyStracture.Data;
using System.ComponentModel.DataAnnotations;
using GeographyStracture.Data.Entities;
using System.Globalization;

namespace GeographyCore.ViewModels.MountaineModels
{
    public class AddMounainrViewModel
    {

        [StringLength(DataConstraints.Mountine.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Area { get; set; }


        public int ContinentId { get; set; }

        public IEnumerable<Continent>? Continents { get; set; } = new List<Continent>();
        public string? Continent { get; set; }

        public string? Country { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<Country>? Countries { get; set; } = new List<Country>();
    }
}
