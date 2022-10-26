
using HelloMaui.BonMonitor;
using HelloMaui.PosClient;
using HelloMaui.ViewModels;
using HelloMaui.Views;

namespace HelloMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
			.UseMauiApp<App>()
			.UsePrism(prism => 
				prism.ConfigureModuleCatalog(catalog =>
				{
					catalog.AddModule<BonMonitorModule>();
                    catalog.AddModule<PosClientModule>();
                })
				.RegisterTypes(container =>
				{
					container.RegisterGlobalNavigationObserver();
					container.RegisterForNavigation<MainPage>();
					container.RegisterForNavigation<RootPage>();
                    container.RegisterForNavigation<SamplePage>();
                    container.RegisterForNavigation<SplashPage>();
				})
				.AddGlobalNavigationObserver(context => context.Subscribe(x =>
				{
					if (x.Type==NavigationRequestType.Navigate)
						Console.WriteLine($"Navigation: {x.Uri}");
					else
                        Console.WriteLine($"Navigation: {x.Type}");

					var status = x.Cancelled ? "Cancelled" : x.Result.Success ? "Success" : "Failed";
                    Console.WriteLine($"Result: {status}");

					if (status == "Failed" && !string.IsNullOrEmpty(x.Result?.Exception?.Message))
						Console.Error.WriteLine(x.Result.Exception.Message);
                }))
				.OnAppStart(service => service.CreateBuilder()
					.AddSegment<SplashPageViewModel>()
					.Navigate(HandleNavigationError))
				)
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}

	static void HandleNavigationError(Exception ex)
	{
		Console.WriteLine(ex);
		System.Diagnostics.Debugger.Break();
	}
}
