using Blazored.Modal;

namespace RpgEditor;
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
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        // Blazored.Modal
        builder.Services.AddBlazoredModal();

        // Custom
        builder.Services.AddSingleton<GameDataManagerOptions>(s => new()
        {
            GameDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RpgEditor\\Games"
        });
        builder.Services.AddSingleton<GameDataManager>();
        builder.Services.AddSingleton<EntityDataManager>();
        builder.Services.AddSingleton<ItemDataManager>();

        return builder.Build();
    }
}
