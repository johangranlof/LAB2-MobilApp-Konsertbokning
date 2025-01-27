using Microsoft.EntityFrameworkCore;
using System;

namespace ConcertAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string BookingNumber { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
