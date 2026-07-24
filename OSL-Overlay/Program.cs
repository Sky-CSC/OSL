using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using MudBlazor.Services;
using OSL_CDragon;
using OSL_Overlay.Components;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.ChampSelect;
using OSL_Overlay.GameFlow.EndGame;
using OSL_Overlay.GameFlow.Fearless;
using OSL_Overlay.GameFlow.Patch;
using OSL_Overlay.GameFlow.Phase;
using OSL_Overlay.GameFlow.Rune;
using OSL_Overlay.GameFlow.Team;
using OSL_Overlay.GameFlow.Vs;
using OSL_Overlay.WebSocketClient;
using OSL_Overlay.WebSocketClient.Handlers;
using OSL_Utils;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Configure logging level from appsettings.json
Logger.LogLevel = builder.Configuration
    .GetValue("Logger:LogLevel", LoggingLevel.DEBUG);

// Register the WebSocketClient as a singleton service
builder.Services.AddSingleton<WebSocketClient>();

// Handlers
builder.Services.AddSingleton<IMessageHandler, RegionLocaleHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameMatchHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameTimelineHandler>();
builder.Services.AddSingleton<IMessageHandler, ChampSelectHandler>();
builder.Services.AddSingleton<IMessageHandler, FearlessMatchHandler>();
builder.Services.AddSingleton<IMessageHandler, RuneSpectatorCurentGameInfoByRiotId>();

// Initialize CDragon and download assets if necessary
var cdragon = new CDragon();
cdragon.DownloadLatestAssets();

// Register CDragon as a singleton service
builder.Services.AddSingleton(cdragon);

// Teams
builder.Services.AddSingleton<TeamState>();

// Bo
builder.Services.AddSingleton<BoState>();

// Fearless
builder.Services.AddSingleton<FearlessState>();
builder.Services.AddSingleton<FearlessView1State>();
builder.Services.AddSingleton<FearlessView2State>();

// Patch
builder.Services.AddSingleton<PatchState>();

// Phase
builder.Services.AddSingleton<PhaseState>();

// VS
builder.Services.AddSingleton<VsState>();

// Champ Select
builder.Services.AddSingleton<ChampSelectState>();
builder.Services.AddSingleton<ChampSelectView1State>();

// EndGame
builder.Services.AddSingleton<EndGameState>();
builder.Services.AddSingleton<EndGameView1State>();

// Runes
builder.Services.AddSingleton<RuneState>();
builder.Services.AddSingleton<RuneView1State>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Before running the app, download assets (Champions, Items, Runes, EpicMonsters, Position, Font.)

// Connect to the WebSocket server
using (var scope = app.Services.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<WebSocketClient>();
    await client.ConnectAsync();

    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    var teamState = scope.ServiceProvider.GetRequiredService<TeamState>();
    teamState.LoadDefault(env);
    var bestOfState = scope.ServiceProvider.GetRequiredService<BoState>();
    var fearlessState = scope.ServiceProvider.GetRequiredService<FearlessState>();
    var fearlessView1State = scope.ServiceProvider.GetRequiredService<FearlessView1State>();
    fearlessView1State.SyncFromGlobal();
    var fearlessView2State = scope.ServiceProvider.GetRequiredService<FearlessView2State>();
    fearlessView2State.SyncFromGlobal();
    var patchState = scope.ServiceProvider.GetRequiredService<PatchState>();
    var phaseState = scope.ServiceProvider.GetRequiredService<PhaseState>();
    var vsState = scope.ServiceProvider.GetRequiredService<VsState>();
    var champSelectState = scope.ServiceProvider.GetRequiredService<ChampSelectState>();
    var champSelectView1State = scope.ServiceProvider.GetRequiredService<ChampSelectView1State>();
    champSelectView1State.SyncFromGlobal();
    var endGameState = scope.ServiceProvider.GetRequiredService<EndGameState>();
    var endGameView1State = scope.ServiceProvider.GetRequiredService<EndGameView1State>();
    endGameView1State.SyncFromGlobal();
    var runeState = scope.ServiceProvider.GetRequiredService<RuneState>();
    var runeView1State = scope.ServiceProvider.GetRequiredService<RuneView1State>();
}

await app.StartAsync();

var openBrowser = builder.Configuration.GetValue<bool>("OpenBrowserOnStartup");
if (openBrowser)
{
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        var addressesFeature = app.Services
            .GetRequiredService<IServer>()
            .Features
            .Get<IServerAddressesFeature>();

        var listeningAddress = addressesFeature?.Addresses.FirstOrDefault();
        if (listeningAddress is null)
        {
            return;
        }

        var uri = new Uri(listeningAddress);

        // Replace "localhost"/"0.0.0.0" by the LAN IP if available.
        var ip = NetworkUtils.GetPreferredIPv4Address();
        var targetUrl = ip is not null
            ? $"{uri.Scheme}://{ip}:{uri.Port}"
            : listeningAddress;

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = targetUrl,
                UseShellExecute = true
            });
        }
        catch
        {
            // Deliberately Silent: The Browser Failed to Open
            // must never prevent the application from starting.
        }
    });
}

await app.WaitForShutdownAsync();
