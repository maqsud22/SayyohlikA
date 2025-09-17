using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SayyohlikA.Models
{
    public class Davlat
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Davlat nomi")]
        public string Nomi { get; set; }

        public ICollection<Shahar> Shaharlar { get; set; }
    }
}