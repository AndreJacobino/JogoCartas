using JogoCartas.ViewModels;

namespace JogoCartas.View;

public partial class BaralhoPage : ContentPage
{
	public BaralhoPage(BaralhoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}