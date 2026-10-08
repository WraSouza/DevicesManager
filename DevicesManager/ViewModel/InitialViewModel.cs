using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevicesManager.Model;
using DevicesManager.Repositories;
using DevicesManager.View;
using System.Collections.ObjectModel;

namespace DevicesManager.ViewModel
{
    public partial class InitialViewModel(IGetDevices getDevices) : BaseViewModel
    {
        public ObservableCollection<DeviceInfoView> Devices { get; set; }
        = new ObservableCollection<DeviceInfoView>();

        public ObservableCollection<DeviceInfoView> AlertDevices { get; set; }
       = new ObservableCollection<DeviceInfoView>();

        [ObservableProperty]
        string? hdUsagePercent;

        private readonly string _textColorWhite = "#FFFFFF";

        private readonly string _textColorBlack = "#000000";

        private string monitorWhite = "monitor_white.png";

        private string monitorBlack = "monitor.png";


        internal async Task InitAsync()
        {
            var devices = await getDevices.GetAllDevicesAsync();

            foreach (var info in devices)
            {
                var deviceView = await getDevices.GetDeviceInfoAsync(info.id.ToString());              

                if (deviceView is not null)
                {

                    double percentUsage = (((double)deviceView.totalsize - deviceView.freesize) / deviceView.totalsize) * 100;

                    if (percentUsage >= 89)
                    {
                        DeviceInfoView deviceAlarm = new DeviceInfoView(info.name, ((deviceView.freesize) / 1000).ToString(), ((deviceView.totalsize) / 1000).ToString(), percentUsage, "#FF0000", _textColorWhite, monitorWhite);

                        AlertDevices.Add(deviceAlarm);
                    }
                    else
                    {
                        DeviceInfoView device = new DeviceInfoView(info.name, ((deviceView.freesize) / 1000).ToString(), ((deviceView.totalsize) / 1000).ToString(), percentUsage, "#FFFFFF", _textColorBlack, monitorBlack);

                        Devices.Add(device);
                    }

                    //if (percentUsage >= 80 && percentUsage < 90)
                    //{
                    //    DeviceInfoView deviceAlarm = new DeviceInfoView(info.name, ((deviceView.freesize) / 1000).ToString(), ((deviceView.totalsize) / 1000).ToString(), percentUsage, "#FFFF00", _textColorBlack, monitorBlack);

                    //    AlertDevices.Add(deviceAlarm);
                    //}

                    //if (percentUsage < 80)
                    //{
                    //    DeviceInfoView device = new DeviceInfoView(info.name, ((deviceView.freesize) / 1000).ToString(), ((deviceView.totalsize) / 1000).ToString(), percentUsage, "#FFFFFF", _textColorBlack, monitorBlack);

                    //    Devices.Add(device);
                    //}
                }

            }

        }

        /// <summary>
        /// Comando que será disparado ao clicar no Card do computador
        /// </summary>
        /// <param name="selectedDevice">O objeto DeviceInfoView associado ao card clicado</param>
        [RelayCommand]
        private async Task NavigateToDetails(DeviceInfoView selectedDevice)
        {
            if (selectedDevice == null)
                return;

            // Criamos um dicionário de parâmetros para passar o objeto inteiro para a próxima tela
            var navigationParameter = new Dictionary<string, object>
        {
            { "DeviceSelected", selectedDevice }
        };

            // Navega via Shell para a DeviceDetailsView passando os parâmetros
            await Shell.Current.GoToAsync(nameof(DeviceDetailsView), navigationParameter);
        }
    }
}
