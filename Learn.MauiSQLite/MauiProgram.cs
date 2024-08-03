using Test.PrismMaui.Services;
using Test.PrismMaui.Views;

namespace Test.PrismMaui;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UsePrism(ConfigureContainer)
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    return builder.Build();
  }

  public static void ConfigureContainer(PrismAppBuilder builder)
  {
    builder
      .ConfigureServices(services =>
      {
        services.AddSingleton<ISqliteService, SqliteService>();
      })
      .RegisterTypes(container =>
      {
        container.RegisterForNavigation<MainPage>();
        container.RegisterInstance(SemanticScreenReader.Default);
      })
      .OnAppStart(async navService =>
      {
        var result = await navService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        if (!result.Success)
        {
          System.Diagnostics.Debugger.Break();
        }
      });
      // .OnAppStart($"{nameof(NavigationPage)}/{nameof(MainPage)}");
      // .OnAppStart(navService =>
      //   navService.CreateBuilder()
      //             .AddSegment<MainPage>()
      //             .Navigate(OnNavigationError));
  }

  private static void OnNavigationError(Exception ex)
  {
    Console.WriteLine($"Exception navigating. {ex}");
    System.Diagnostics.Debugger.Break();
  }

  private static void OnConfigureModuleCatalog(IModuleCatalog moduleCatalog)
  {
    // Add custom Module to catalog
    //  moduleCatalog.AddModule<MauiAppModule>();
    //  moduleCatalog.AddModule<MauiTestRegionsModule>();
  }
}
