using System.ComponentModel.DataAnnotations;

namespace GeographyStracture.Data.Entities
{
    public class Desert
    {
        [Required]
        [StringLength()]
        public string Name { get; set; } = null!;

        public int Square { get; set; }
    }
}
