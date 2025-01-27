using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;
using ConcertMAUI.ViewModels;
using System.Diagnostics;

namespace ConcertMAUI.Views
{
    public partial class BookingPage : ContentPage
    {
        public BookingPage(BookingPageVM vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
