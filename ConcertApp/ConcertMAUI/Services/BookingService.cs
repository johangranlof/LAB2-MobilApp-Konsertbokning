using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;

namespace ConcertMAUI.Services
{
    public class BookingService : IBookingService
    {
        IRestService<Booking> _restService;

        public BookingService(IRestService<Booking> restService)
        {
            _restService = restService;
        }

        public Task<List<Booking>> GetBookingsAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveBookingAsync(Booking booking, bool isNewItem)
        {
            return _restService.SaveItemAsync(booking, isNewItem);
        }

        public Task DeleteBookingAsync(Booking booking)
        {
            return _restService.DeleteItemAsync(booking.Id);
        }

        public async Task<string> GenerateUniqueBookingNumberAsync()
        {
            var bookings = await _restService.RefreshDataAsync();
            Random random = new Random();
            string newBookingNumber;
            bool bookingNumberExists;

            do
            {
                newBookingNumber = random.Next(1000, 10000).ToString();
                bookingNumberExists = bookings.Any(b => b.BookingNumber == newBookingNumber);
            }
            while (bookingNumberExists);

            return newBookingNumber;
        }
    }
}
