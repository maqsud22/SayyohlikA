using System.ComponentModel.DataAnnotations;

namespace SayyohlikA.Models
{
    public class Xaridor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "F.I.SH majburiy")]
        public string FISH { get; set; }

        [Required(ErrorMessage = "Telefon raqami majburiy")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email majburiy")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Manzil majburiy")]
        public string Manzili { get; set; }

        [Required(ErrorMessage = "Sayohat manzili majburiy")]
        public string Sayohat_manzili { get; set; }
    }
}