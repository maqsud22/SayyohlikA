using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SayyohlikA.Models
{
    public class Davlat
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Davlat nomi")]
        public required string Nomi { get; set; }

        public required ICollection<Shahar> Shaharlar { get; set; }
    }
}