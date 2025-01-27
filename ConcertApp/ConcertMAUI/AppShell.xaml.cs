using ConcertMAUI.Views;

namespace ConcertMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ConcertInfoPage), typeof(ConcertInfoPage));
            Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
        }
    }
}
