namespace SayyohlikA.Models.ViewModel
{
    public class AddShaharViewModel
    {
        public int Id { get; set; }
        public string Nomi { get; set; }

        public int MamlakatId { get; set; }
        public Davlat Davlat { get; set; }
    }
}
