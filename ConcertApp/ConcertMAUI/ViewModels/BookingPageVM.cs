using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;

namespace ConcertMAUI.ViewModels
{
    [ObservableObject]
    [QueryProperty(nameof(Show), "Show")] 
    public partial class BookingPageVM
    {
        [ObservableProperty]
        private Customer customer = new Customer();

        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;
        private readonly IShowService _showService;


        [ObservableProperty]
        private Show show;

        public BookingPageVM(ICustomerService customerService, IBookingService bookingService, IShowService showService)
        {
            _customerService = customerService;
            _bookingService = bookingService;
            _showService = showService;
        }

        [RelayCommand]
        public async Task Book()
        {
            if (string.IsNullOrWhiteSpace(Customer.Name) ||
                string.IsNullOrWhiteSpace(Customer.Email) ||
                string.IsNullOrWhiteSpace(Customer.Phone))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            var existingCustomer = await _customerService.GetCustomerByEmailAsync(Customer.Email);
            bool isNewItem = false;
            bool isNewBooking = true;

            if (existingCustomer == null)
            {
                existingCustomer = Customer;
                existingCustomer.Bookings = new List<Booking>();
                isNewItem = true;
                await _customerService.SaveCustomerAsync(existingCustomer, isNewItem);
            }
            else
            {
                existingCustomer.Name = Customer.Name;
                existingCustomer.Phone = Customer.Phone;
                await _customerService.SaveCustomerAsync(existingCustomer, isNewItem);
            }

            var savedCustomer = await _customerService.GetCustomerByEmailAsync(existingCustomer.Email);

            Booking newBooking = new Booking()
            {
                BookingNumber = await _bookingService.GenerateUniqueBookingNumberAsync(),
                CustomerId = savedCustomer.Id,
                ShowId = Show.Id
            };

            // Spara bokningen
            await _bookingService.SaveBookingAsync(newBooking, isNewBooking);

            await App.Current.MainPage.DisplayAlert("Success", $"Bokning sparades. Ditt bokningsnummer är {newBooking.BookingNumber}", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
