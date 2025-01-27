using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertAPI.Models.DTO
{
    public class BookingCreateDTO
    {
        public string BookingNumber { get; set; }
        public int CustomerId { get; set; }
        public int ShowId { get; set; }
    }
}
