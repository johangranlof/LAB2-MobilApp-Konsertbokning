using CommunityToolkit.Maui;
using ConcertMAUI.Services;
using ConcertMAUI.Services.Interfaces;
using ConcertMAUI.ViewModels;
using ConcertMAUI.Views;

namespace ConcertMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
            builder.Services.AddSingleton(typeof(IRestService<>), typeof(RestService<>));
            builder.Services.AddSingleton<IBookingService, BookingService>();
            builder.Services.AddSingleton<IConcertService, ConcertService>();
            builder.Services.AddSingleton<ICustomerService,CustomerService>();
            builder.Services.AddSingleton<IShowService, ShowService>();
            builder.Services.AddSingleton<IGenreService, GenreService>();

            builder.Services.AddTransient<BookingPage>();
            builder.Services.AddTransient<ConcertInfoPage>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<BookingPageVM>();
            builder.Services.AddTransient<ConcertInfoPageVM>();
            builder.Services.AddSingleton<MainPageVM>();


            return builder.Build();
        }
    }
}
