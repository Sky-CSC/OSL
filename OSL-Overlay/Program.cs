using MudBlazor.Services;
using OSL_CDragon;
using OSL_Overlay.Components;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.ChampSelect;
using OSL_Overlay.GameFlow.EndGame;
using OSL_Overlay.GameFlow.Fearless;
using OSL_Overlay.GameFlow.Team;
using OSL_Overlay.WebSocketClient;
using OSL_Overlay.WebSocketClient.Handlers;
using OSL_Utils.WebSocket;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Configure Web socket server from appsettings.json
builder.Services.Configure<WebSocketConfig>(
    builder.Configuration.GetSection("WebSocketServerConfig"));

// Register the WebSocketClient as a singleton service
builder.Services.AddSingleton<WebSocketClient>();

// Handlers
builder.Services.AddSingleton<IMessageHandler, RegionLocaleHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameMatchHandler>();
builder.Services.AddSingleton<IMessageHandler, EndGameTimelineHandler>();
builder.Services.AddSingleton<IMessageHandler, ChampSelectHandler>();
builder.Services.AddSingleton<IMessageHandler, FearlessMatchHandler>();

// Initialize CDragon and download assets if necessary
var cdragon = new CDragon();
cdragon.DownloadAssetsWithCheck();

// Register CDragon as a singleton service
builder.Services.AddSingleton(cdragon);

// Champ Select
builder.Services.AddSingleton<ChampSelectState>();

// Teams
builder.Services.AddSingleton<TeamState>();

// Bo
builder.Services.AddSingleton<BoState>();

// Fearless
builder.Services.AddSingleton<FearlessState>();
builder.Services.AddSingleton<FearlessView1State>();

// EndGame
builder.Services.AddSingleton<EndGameState>();

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

app.UseHttpsRedirection();

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
}

app.Run();
