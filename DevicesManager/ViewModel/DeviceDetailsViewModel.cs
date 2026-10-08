using CommunityToolkit.Mvvm.ComponentModel;
using DevicesManager.Model;

namespace DevicesManager.ViewModel
{
    // "DeviceSelected" deve bater exatamente com a chave que enviamos no dicionário acima
    [QueryProperty(nameof(Device), "DeviceSelected")]
    public partial class DeviceDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private DeviceInfoView _device;

        // Propriedade calculada para o espaço usado (Total - Livre)
        //public double UsedSize => Device != null ? (Device.TotalSize - Device.FreeSize) : 0;

        public DeviceDetailsViewModel()
        {
        }
    }
}
