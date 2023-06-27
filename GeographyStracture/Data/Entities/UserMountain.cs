using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeographyStracture.Data.Entities
{
    public class UserMountain
    {
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public int MountainId { get; set; }

        [ForeignKey(nameof(MountainId))]
        public Mountaine Mountain { get; set; } = null!;

    }
}
