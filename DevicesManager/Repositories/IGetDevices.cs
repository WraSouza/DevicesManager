using DevicesManager.Model;

namespace DevicesManager.Repositories
{
    public interface IGetDevices
    {
       Task<List<Computador>> GetAllDevicesAsync();
       
       Task<DeviceInfoResponse> GetDeviceInfoAsync(string deviceId);
    }
}
