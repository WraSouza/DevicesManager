using DevicesManager.ViewModel;

namespace DevicesManager.View;

public partial class InitialView : ContentPage
{
    private readonly InitialViewModel _viewModel;

    public InitialView(InitialViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = _viewModel = viewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitAsync();
    }
}