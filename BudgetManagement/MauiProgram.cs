using BudgetManagement.ViewModels;
using BudgetManagement.Views;
using BudgetManagement.Models;
using Microsoft.Extensions.Logging;

namespace BudgetManagement
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

            builder.Services.AddSingleton<Home>();
            builder.Services.AddSingleton<TDepensePage>();
            builder.Services.AddSingleton<DepensePage>();
            builder.Services.AddSingleton<RevenuPage>();
            builder.Services.AddSingleton<TRevenuPage>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<TDepenseViewModel>();
            builder.Services.AddSingleton<DepenseViewModel>();
            builder.Services.AddSingleton<TRevenuViewModel>();
            builder.Services.AddSingleton<RevenuViewModel>();

            builder.Services.AddSingleton<DepenseDatabase>();
            builder.Services.AddSingleton<RevenuDatabase>();
            builder.Services.AddSingleton<EpargneDatabase>();

#endif

            return builder.Build();
        }
    }
}
