using System.ComponentModel.DataAnnotations;

namespace SayyohlikA.Models
{
    public class Xaridor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "F.I.SH majburiy")]
        public required string FISH { get; set; }

        [Required(ErrorMessage = "Telefon raqami majburiy")]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email majburiy")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Manzil majburiy")]
        public required string Manzili { get; set; }

        [Required(ErrorMessage = "Sayohat manzili majburiy")]
        public required string Sayohat_manzili { get; set; }
    }
}