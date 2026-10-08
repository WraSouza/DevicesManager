using DevicesManager.View;

namespace DevicesManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DeviceDetailsView), typeof(DeviceDetailsView));
        }
    }
}
