using ConcertMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertMAUI
{
    public static class GetEndpointForType
    {
        public static string GetEndpoint<T>()
        {
            if (typeof(T) == typeof(Booking))
                return "Bookings";
            else if (typeof(T) == typeof(Customer))
                return "Customers";
            else if (typeof(T) == typeof(Concert))
                return "Concerts";
            else if (typeof(T) == typeof(Show))
                return "Shows";
            else if (typeof(T) == typeof(Genre))
                return "Genres";

            else
                throw new InvalidOperationException("Endpoint för denna typ är inte definierad.");
        }
    }
}
