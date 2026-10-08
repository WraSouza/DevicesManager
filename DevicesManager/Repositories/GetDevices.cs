
using DevicesManager.Helpers;
using DevicesManager.Model;
using Flurl.Http;

namespace DevicesManager.Repositories
{
    public class GetDevices : IGetDevices
    {
        public async Task<List<Computador>> GetAllDevicesAsync()
        {
            try
            {
                return await Sites.getDevicesURL
                .GetJsonAsync<List<Computador>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return [];

        }

        public async Task<DeviceInfoResponse> GetDeviceInfoAsync(string deviceId)
        {
            try
            {
                var resultado = await $"http://192.168.1.222:5004/api/ItemDisk/{deviceId}"
                    .GetJsonAsync<DeviceInfoResponse>();
                //var resultado = await $"https://0c9fa53d3d59.ngrok-free.app/api/ItemDisk/{deviceId}"
                //    .GetJsonAsync<DeviceInfoResponse>();

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new DeviceInfoResponse();
        }
    }
}
