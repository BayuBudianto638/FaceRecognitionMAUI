using FaceRecognitionMAUI.Services.Detect;
using FaceRecognitionMAUI.Services.FileAccess;

namespace FaceRecognitionMAUI;

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

		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<IFileAccessAppService, FileAccessAppService>();

        builder.Services.AddSingleton<IDetectAppService, DetectAppService>();

        return builder.Build();
	}
}
