using ConcertMAUI.Models;

namespace ConcertMAUI.Services.Interfaces
{
    public interface IConcertService
    {
        Task<List<Concert>> GetConcertAsync();
        Task SaveConcertAsync(Concert concert, bool isNewConcert);
        Task DeleteConcertAsync(Concert concert);
    }
}
