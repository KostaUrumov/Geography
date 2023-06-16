using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeographyStracture.Data.Entities
{
    public class Street
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstraints.Street.MaxNameLength)]
        public string Name { get; set; } = null!;
        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; } = null!;

        [Required]
        public double Length { get; set; }

        public List<House> Houses { get; set; } = new List<House>();
    }
}
