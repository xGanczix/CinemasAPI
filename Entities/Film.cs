namespace CinemasAPI.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Minutes { get; set; }
        public decimal Price { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
