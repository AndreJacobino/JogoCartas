using JogoCartas.Services;
using JogoCartas.View;
using JogoCartas.ViewModels;
using Microsoft.Extensions.Logging;

namespace JogoCartas
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddHttpClient<IBaralhoService, BaralhoService>(client =>
            {
                client.BaseAddress = new Uri("https://deckofcardsapi.com/api/deck/");
            });

            builder.Services.AddTransient<BaralhoViewModel>();
            builder.Services.AddTransient<BaralhoPage>();

            return builder.Build();
        }
    }
}
