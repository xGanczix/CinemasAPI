using System.Collections.Generic;

namespace CinemasAPI.Models
{
    public class CinemaClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public string ContactEmail { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<FilmClient> Films { get; set; }
    }
}
