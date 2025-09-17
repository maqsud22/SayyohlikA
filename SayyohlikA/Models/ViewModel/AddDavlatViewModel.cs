namespace SayyohlikA.Models.ViewModel
{
    public class AddDavlatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Shahar> Shahars { get; set; }
    }
}
