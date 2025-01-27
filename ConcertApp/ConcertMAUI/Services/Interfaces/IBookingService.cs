using ConcertMAUI.Models;

namespace ConcertMAUI.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsAsync();
        Task SaveBookingAsync(Booking booking, bool isNewBooking);
        Task DeleteBookingAsync(Booking booking);
        Task<string> GenerateUniqueBookingNumberAsync();
    }
}
