using ConcertMAUI.ViewModels;

namespace ConcertMAUI.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}