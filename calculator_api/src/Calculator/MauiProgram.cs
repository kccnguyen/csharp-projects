﻿using Calculator.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator;

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


		builder.Services.AddSingleton<MainPage> ();
		builder.Services.AddTransient<HistoryPage>();

		builder.Services.AddSingleton<MainViewModel> ();
		builder.Services.AddTransient<HistoryViewModel> ();


        return builder.Build();
	}
}
