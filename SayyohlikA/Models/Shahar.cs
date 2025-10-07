using System.Diagnostics.Metrics;


namespace SayyohlikA.Models
{
    public class Shahar
    {
        public int Id { get; set; }
        public required string Nomi { get; set; }

        public int MamlakatId { get; set; }
        public required Davlat Davlat { get; set; }
    }
}
