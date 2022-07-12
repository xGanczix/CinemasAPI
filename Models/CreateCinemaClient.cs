namespace CinemasAPI.Models
{
    public class CreateCinemaClient
    {
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
