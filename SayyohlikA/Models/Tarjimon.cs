namespace SayyohlikA.Models
{
    public class Tarjimon
    {
        public int Id { get; set; }
        public required string FISH { get; set; }
        public required string Til { get; set; }
        public required  string PhoneNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
