using ConcertAPI.Models;

namespace ConcertAPI.Data
{
    public static class DBSeeder
    {
        public static void Seed(ConcertContext context)
        {
            context.Database.EnsureCreated();

            if (context.Shows.Any())
            {
                return;
            }

            #region Genres
            var genres = new Genre[]
            {
                
                new Genre { Name = "Rock" },
                new Genre { Name = "Pop" },
                new Genre { Name = "Jazz" },
                new Genre { Name = "Metal" },
                new Genre { Name = "Blues" },
                new Genre { Name = "Classical" },
                new Genre { Name = "Country" },
                new Genre { Name = "Hip Hop" },
                new Genre { Name = "Electronic" },
                new Genre { Name = "Folk" },
                new Genre { Name = "Alla genres" }
            };

            foreach (Genre genre in genres)
            {
                context.Genres.Add(genre);
            }
            context.SaveChanges();
            #endregion

            #region Concerts
            var concerts = new Concert[]
                {
                    new Concert
                    {
                        Title = "Rock Legends",
                        Description = "An epic night of rock anthems.",
                        Duration = 120,
                        Price = 70,
                        Genres = new List<Genre> { genres[0], genres[3] } // Rock and Metal
                    },
                    new Concert
                    {
                        Title = "Pop Extravaganza",
                        Description = "The greatest pop hits live on stage.",
                        Duration = 90,
                        Price = 60,
                        Genres = new List<Genre> { genres[1] } // Pop
                    },
                    new Concert
                    {
                        Title = "Jazz Vibes",
                        Description = "Smooth jazz to soothe your soul.",
                        Duration = 100,
                        Price = 50,
                        Genres = new List<Genre> { genres[2], genres[4] } // Jazz and Blues
                    },
                    new Concert
                    {
                        Title = "Classical Symphony",
                        Description = "A night with the greatest classical composers.",
                        Duration = 150,
                        Price = 80,
                        Genres = new List<Genre> { genres[5] } // Classical
                    },
                    new Concert
                    {
                        Title = "Metal Mayhem",
                        Description = "The loudest and heaviest metal hits.",
                        Duration = 110,
                        Price = 75,
                        Genres = new List<Genre> { genres[3] } // Metal
                    },
                    new Concert
                    {
                        Title = "Hip Hop Live",
                        Description = "The best hip hop artists bring the house down.",
                        Duration = 120,
                        Price = 65,
                        Genres = new List<Genre> { genres[9] } // Hip Hop
                    }
                };

            foreach (Concert concert in concerts)
            {
                context.Concerts.Add(concert);
            }
            context.SaveChanges();
            #endregion

            #region Shows
            var shows = new Show[]
            {
                new Show { Location = "Rock Arena", DateTime = DateTime.Now.AddMonths(1), ConcertId = concerts[0].Id },
                new Show { Location = "Pop Dome", DateTime = DateTime.Now.AddMonths(2), ConcertId = concerts[1].Id },
                new Show { Location = "Jazz Club", DateTime = DateTime.Now.AddMonths(3), ConcertId = concerts[3].Id },
                new Show { Location = "Grand Theater", DateTime = DateTime.Now.AddMonths(4), ConcertId = concerts[3].Id },
                new Show { Location = "Rock Arena", DateTime = DateTime.Now.AddMonths(8), ConcertId = concerts[0].Id },
                new Show { Location = "Pop Dome", DateTime = DateTime.Now.AddMonths(5), ConcertId = concerts[1].Id },
                new Show { Location = "Jazz Club", DateTime = DateTime.Now.AddMonths(6), ConcertId = concerts[2].Id },
                new Show { Location = "Grand Theater", DateTime = DateTime.Now.AddMonths(7), ConcertId = concerts[3].Id }
            };

            foreach (Show show in shows)
            {
                context.Shows.Add(show);
            }
            context.SaveChanges();
            #endregion

            #region Customers
            var customers = new Customer[]
            {
                new Customer { Name = "Alice Johnson", Email = "alice@example.com", Phone = "123-456-7890" },
                new Customer { Name = "Bob Smith", Email = "bob@example.com", Phone = "987-654-3210" },
                new Customer { Name = "Charlie Brown", Email = "charlie@example.com", Phone = "555-666-7777" }
            };

            foreach (Customer customer in customers)
            {
                context.Customers.Add(customer);
            }
            context.SaveChanges();
            #endregion

            #region Bookings
            var bookings = new Booking[]
            {
                new Booking { BookingNumber = "1001", CustomerId = customers[1].Id, ShowId = shows[0].Id },
                new Booking { BookingNumber = "1002", CustomerId = customers[2].Id, ShowId = shows[0].Id },
                new Booking { BookingNumber = "1003", CustomerId = customers[0].Id, ShowId = shows[3].Id },
                new Booking { BookingNumber = "1004", CustomerId = customers[1].Id, ShowId = shows[3].Id },
                new Booking { BookingNumber = "1005", CustomerId = customers[2].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1006", CustomerId = customers[0].Id, ShowId = shows[2].Id },
                new Booking { BookingNumber = "1007", CustomerId = customers[1].Id, ShowId = shows[3].Id },
                new Booking { BookingNumber = "1008", CustomerId = customers[2].Id, ShowId = shows[3].Id },
                new Booking { BookingNumber = "1009", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1010", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1011", CustomerId = customers[0].Id, ShowId = shows[2].Id },
                new Booking { BookingNumber = "1012", CustomerId = customers[0].Id, ShowId = shows[2].Id },
                new Booking { BookingNumber = "1013", CustomerId = customers[0].Id, ShowId = shows[2].Id },
                new Booking { BookingNumber = "1014", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1015", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1016", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1017", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1018", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1019", CustomerId = customers[0].Id, ShowId = shows[1].Id },
                new Booking { BookingNumber = "1020", CustomerId = customers[0].Id, ShowId = shows[1].Id }
            };

            foreach (Booking booking in bookings)
            {
                context.Bookings.Add(booking);
            }
            context.SaveChanges();
            #endregion
        }
    }
}
