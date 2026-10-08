using CommunityToolkit.Mvvm.ComponentModel;

namespace DevicesManager.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;
    }
}
