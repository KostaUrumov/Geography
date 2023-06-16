using System.ComponentModel.DataAnnotations;

namespace GeographyStracture.Data.Entities
{
    public class Continent
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstraints.Continent.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstraints.Continent.MaxUrlLength)]
        public string PctureUrl { get; set; } = null!;

        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
