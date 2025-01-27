namespace ConcertAPI.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }

        public int ConcertId { get; set; }
        public Concert Concert { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
