
namespace SayyohlikA.Models
{
    public class Yangiliklar
    {
        public int Id { get; set; }
        public required string Sarlavxa { get; set; }
        public required string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
