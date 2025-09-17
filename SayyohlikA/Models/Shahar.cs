using System.Diagnostics.Metrics;


namespace SayyohlikA.Models
{
    public class Shahar
    {
        public int Id { get; set; }
        public string Nomi { get; set; }

        public int MamlakatId { get; set; }
        public Davlat Davlat { get; set; }
    }
}
