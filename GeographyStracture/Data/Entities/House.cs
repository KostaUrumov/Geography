using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static GeographyStracture.Data.DataConstraints;

namespace GeographyStracture.Data.Entities
{
    public class House
    {
        public int Id { get; set; }

        [Required]
        public int StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public Street Street { get; set; } = null!;

        [Required]
        public int NumberOfFloors { get; set; }

        [Required]
        public int Address { get; set; }

        public int Rooms { get; set; }

        public List<IdentityUser> Residents { get; set; } = new List<IdentityUser>();
    }
}
