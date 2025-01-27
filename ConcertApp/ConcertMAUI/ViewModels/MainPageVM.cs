using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;
using System.Collections.ObjectModel;

namespace ConcertMAUI.ViewModels
{
    [ObservableObject]
    public partial class MainPageVM
    {
        private readonly IConcertService _concertService;
        private readonly IGenreService _genreService;
        private readonly IBookingService _bookingService;

        [ObservableProperty]
        private ObservableCollection<Concert> concerts = new();

        [ObservableProperty]
        private ObservableCollection<Genre> genres = new();

        [ObservableProperty]
        private ObservableCollection<Booking> bookings = new();

        [ObservableProperty]
        private Genre selectedGenre;

        [ObservableProperty]
        private Concert selectedConcert;

        [ObservableProperty]
        private string searchTerm;

        [ObservableProperty]
        private Booking searchedBooking;

        private List<Concert> allConcerts = new();

        private List<Booking> allBookings = new();

        [ObservableProperty]
        private string displayConcertInfo;

        [ObservableProperty]
        public bool isBookingSelected = false;

        [ObservableProperty]
        public bool isAnySearchMade = false;

        public MainPageVM(IConcertService concertService, IGenreService genreService, IBookingService bookingService)
        {
            _concertService = concertService;
            _genreService = genreService;
            _bookingService = bookingService;
    }

        [RelayCommand]
        public async Task Search()
        {
            var bookingList = await _bookingService.GetBookingsAsync();
            allBookings = bookingList;
            SearchedBooking = allBookings.FirstOrDefault(booking => booking.BookingNumber == SearchTerm);

            var concertList = await _concertService.GetConcertAsync();
            allConcerts = concertList;
            var SearchedBookingsConcert = allConcerts.FirstOrDefault(sbc => sbc.Id == SearchedBooking?.Show.ConcertId);
            IsAnySearchMade = true;

            if (SearchedBooking != null)
            {
                DisplayConcertInfo = $"{SearchedBookingsConcert?.Title}\n{SearchedBooking.Show.DateTime:yyyy-MM-dd HH:mm}\nBokn. Nr: {SearchedBooking.BookingNumber}";
                IsBookingSelected = true;
            }
            else
            {
                DisplayConcertInfo = "Ogiltigt bokningsnummer!";
                IsBookingSelected = false;
            }
        }

        [RelayCommand]
        public async Task DeleteBooking()
        {
            if (SearchedBooking != null)
            { 
                await _bookingService.DeleteBookingAsync(SearchedBooking);
                DisplayConcertInfo = "Avbokat!";
                IsBookingSelected = false;
            }
        }
        
        [RelayCommand]
        public async Task Appearing()
        {
            var concertList = await _concertService.GetConcertAsync();
            allConcerts = concertList;
            Concerts = new ObservableCollection<Concert>(concertList);

            var genreList = await _genreService.GetGenresAsync();
            Genres = new ObservableCollection<Genre>(genreList);
        }

        [RelayCommand]
        public async Task SelectionChanged()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(Concert), SelectedConcert }
            };
            await Shell.Current.GoToAsync("ConcertInfoPage", navigationParameter);
        }

        partial void OnSelectedGenreChanged(Genre value)
        {
            if (value != null && value.Name != "Alla genres")
            {
                var filteredConcerts = allConcerts
                    .Where(concert => concert.Genres.Any(g => g.Id == value.Id))
                    .ToList();

                Concerts = new ObservableCollection<Concert>(filteredConcerts);
            }
            else
            {
                Concerts = new ObservableCollection<Concert>(allConcerts);
            }
        }
    }
}
