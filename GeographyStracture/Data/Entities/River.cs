using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeographyStracture.Data.Entities
{
    public class River
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstraints.River.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Lenghth { get; set; }

        public int ContinentId { get; set; }

        [ForeignKey(nameof(ContinentId))]
        public Continent? Continent { get; set; }

        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country? Country { get; set; }
    }
}
