namespace CinemasAPI.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Film> Films { get; set; }
    }
}
