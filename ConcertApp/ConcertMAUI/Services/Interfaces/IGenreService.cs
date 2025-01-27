using ConcertMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertMAUI.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenresAsync();
        Task SaveGenreAsync(Genre genre, bool isNewGenre);
        Task DeleteGenreAsync(Genre genre);
    }
}
