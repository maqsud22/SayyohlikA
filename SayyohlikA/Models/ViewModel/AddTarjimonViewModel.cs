namespace SayyohlikA.Models.ViewModel
{
    public class AddTarjimonViewModel
    {
        public int Id { get; set; }
        public required string FISH { get; set; }
        public required string Til { get; set; }
        public required string PhoneNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
