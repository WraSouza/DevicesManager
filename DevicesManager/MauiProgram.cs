using DevicesManager.Repositories;
using DevicesManager.View;
using DevicesManager.ViewModel;
using Microsoft.Extensions.Logging;

namespace DevicesManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IGetDevices, GetDevices>();

            builder.Services.AddSingleton<InitialViewModel>();
            builder.Services.AddSingleton<DeviceDetailsViewModel>();


            builder.Services.AddSingleton<InitialView>();
            builder.Services.AddSingleton<DeviceDetailsView>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
