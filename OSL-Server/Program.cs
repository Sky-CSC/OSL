using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using MudBlazor.Services;
using OSL_Server.Components;
using OSL_Server.Schema;
using OSL_Server.Services;
using OSL_Server.WebSocketServer;
using OSL_Server.WebSocketServer.Handlers;
using OSL_Utils;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

Logger.LogLevel = builder.Configuration
    .GetValue("Logger:LogLevel", LoggingLevel.DEBUG);

// Configure LeagueClientConfig from appsettings.json
builder.Services.Configure<LeagueClientConfig>(
    builder.Configuration.GetSection("LeagueClientConfig"));

builder.Services.AddSingleton<RiotGameDevelopementPortalConfig>();

// Register the LeagueClient as a singleton service
builder.Services.AddSingleton<LeagueClient>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<LeagueClient>());

// Register the WebSocketServer as a singleton service
builder.Services.AddSingleton<WebSocketServer>();

// Handler
builder.Services.AddSingleton<IMessageHandler, TerminatorHandler>();
builder.Services.AddSingleton<IMessageHandler, FearlessGameMatchHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameMatchHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameTimelineHandler>();
builder.Services.AddSingleton<IMessageHandler, SpectatorCurentGameInfoByRiotId>();

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

// Start the LeagueClient service
var wsServer = app.Services.GetRequiredService<WebSocketServer>();
_ = wsServer.StartAsync(CancellationToken.None);

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
