using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeographyStracture.Data.Entities
{
    public class UserRiver
    {
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public int RiverId { get; set; }

        [ForeignKey(nameof(RiverId))]
        public River River { get; set; } = null!;
    }
}
