using ConcertMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertMAUI.Services.Interfaces
{
    public interface IShowService
    {
        Task<List<Show>> GetShowsAsync();
        Task SaveShowAsync(Show show, bool isNewShow);
        Task DeleteShowAsync(Show show);
    }
}
