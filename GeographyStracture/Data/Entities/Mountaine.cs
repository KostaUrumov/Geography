using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeographyStracture.Data.Entities
{
    public class Mountaine
    {
        public int Id { get; set; }

        [StringLength(DataConstraints.Mountine.MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Area { get; set; }


        public int ContinentId { get; set; }

        [ForeignKey(nameof(ContinentId))]
        public Continent? Continent { get; set; }


        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country? Country { get; set; }

    }
}
