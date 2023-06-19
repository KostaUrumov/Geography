using System.ComponentModel.DataAnnotations.Schema;

namespace GeographyStracture.Data.Entities
{
    public class Mountaine
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Area { get; set; }

        public int ContinentId { get; set; }

        [ForeignKey(nameof(ContinentId))]
        public Continent? Continent { get; set; }


    }
}
