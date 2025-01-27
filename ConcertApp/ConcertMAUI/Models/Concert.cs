namespace ConcertMAUI.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
