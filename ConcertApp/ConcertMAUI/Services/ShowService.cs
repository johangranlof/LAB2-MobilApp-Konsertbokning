using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcertMAUI.Services
{
    public class ShowService : IShowService
    {
        private readonly IRestService<Show> _restService;

        public ShowService(IRestService<Show> restService)
        {
            _restService = restService;
        }

        public Task<List<Show>> GetShowsAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveShowAsync(Show show, bool isNewItem = false)
        {
            return _restService.SaveItemAsync(show, isNewItem);
        }

        public Task DeleteShowAsync(Show show)
        {
            return _restService.DeleteItemAsync(show.Id);
        }
    }
}
