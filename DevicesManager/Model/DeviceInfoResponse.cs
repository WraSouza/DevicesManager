namespace DevicesManager.Model
{
    public class DeviceInfoResponse
    {
        public int totalsize { get; set; }
        public int freesize { get; set; }
        public string? mountpoint { get; set; }
    }
}
