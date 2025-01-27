using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertMAUI.ViewModels
{
    [ObservableObject]
    [QueryProperty(nameof(Concert), "Concert")]
    public partial class ConcertInfoPageVM
    {
        private readonly IConcertService _concertService;
        private readonly IBookingService _bookingService;
        private readonly IShowService _showService;

        [ObservableProperty]
        private Concert concert;

        [ObservableProperty]
        private int totalBookings;

        private List<Booking> allBookings = new();
        private List<Show> allShows = new();

        public ConcertInfoPageVM(IBookingService bookingService, IShowService showService)
        {
            _bookingService = bookingService;
            _showService = showService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            var bookingList = await _bookingService.GetBookingsAsync();
            allBookings = bookingList;

            var showList = await _showService.GetShowsAsync();
            allShows = showList;

            var showsForThisConcert = allShows.Where(show => show.ConcertId == Concert.Id);

            var tickets = allBookings.Where(booking => showsForThisConcert.Any(show => show.Id == booking.ShowId)).Count();

            TotalBookings = tickets;
        }

        [RelayCommand]
        public async Task BookShow(Show selectedShow)
        {
            if (selectedShow == null) return;

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Show), selectedShow }
            };
            await Shell.Current.GoToAsync("BookingPage", navigationParameter);
        }
    }
}
