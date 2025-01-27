using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;

namespace ConcertMAUI.Services
{
    public class ConcertService : IConcertService
    {
        IRestService<Concert> _restService;

        public ConcertService(IRestService<Concert> restService)
        {
            _restService = restService;
        }

        public Task<List<Concert>> GetConcertAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveConcertAsync(Concert concert, bool isNewItem = false)
        {
            return _restService.SaveItemAsync(concert, isNewItem);
        }

        public Task DeleteConcertAsync(Concert concert)
        {
            return _restService.DeleteItemAsync(concert.Id);
        }
    }
}
