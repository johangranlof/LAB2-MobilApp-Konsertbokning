using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertMAUI.Services
{
    public class GenreService : IGenreService
    {
        IRestService<Genre> _restService;

        public GenreService(IRestService<Genre> restService)
        {
            _restService = restService;
        }

        public Task<List<Genre>> GetGenresAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveGenreAsync(Genre genre, bool isNewItem = false)
        {
            return _restService.SaveItemAsync(genre, isNewItem);
        }

        public Task DeleteGenreAsync(Genre genre)
        {
            return _restService.DeleteItemAsync(genre.Id);
        }
    }
}
