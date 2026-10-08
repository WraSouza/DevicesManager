namespace DevicesManager.Model
{
    public class DeviceInfoView
    {
        public DeviceInfoView(string deviceName, string freeSize, string totalSize, double percentUsage,string borderColor, string textColor, string image)
        {
            DeviceName = deviceName;
            FreeSize = freeSize;
            TotalSize = totalSize;
            PercentUsage = percentUsage;
            BorderBackgroundColor = borderColor;
            TextColor = textColor;
            Image = image;
        }

        public string DeviceName { get; private set; }
        public string FreeSize { get; private set; }
        public string TotalSize { get; private set; }
        public double PercentUsage { get; private set; }
        public string BorderBackgroundColor { get; private set; }
        public string TextColor { get; private set; }
        public string Image { get; private set; }
    }
}
