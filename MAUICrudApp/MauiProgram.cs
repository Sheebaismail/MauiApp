using MAUICrudApp.Services;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MAUICrudApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .Services.AddSingleton<UserApiService>();  // Register the UserApiService

            return builder.Build();
        }
    }
}
