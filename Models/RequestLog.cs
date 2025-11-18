namespace SayyohlikA.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string Url { get; set; }
        public string UserAgent { get; set; }
        public string Device { get; set; }
        public string Language { get; set; }
        public string Referer { get; set; }
        public DateTime Time { get; set; }

        // Joylashuv qo‘shimcha maydonlar
        public string Country { get; set; }
        public string City { get; set; }
        public string ISP { get; set; }
        public string Coordinates { get; set; }
    }
}
