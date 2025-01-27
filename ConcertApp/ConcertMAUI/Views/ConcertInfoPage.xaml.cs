using ConcertMAUI.ViewModels;

namespace ConcertMAUI.Views;

public partial class ConcertInfoPage : ContentPage
{
	public ConcertInfoPage(ConcertInfoPageVM vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}