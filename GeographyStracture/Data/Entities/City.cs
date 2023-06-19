using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeographyStracture.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstraints.City.MaxNameLength)]
        public string Name { get; set; } = null!;
       
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;

        [Required]
        public double Area { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        [StringLength(DataConstraints.City.MaxUrlLength)]
        public string LandscapePicture { get; set; } = null!;

    }
}
