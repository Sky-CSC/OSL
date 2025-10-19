using MudBlazor.Services;
using OSL_CDragon;
using OSL_Overlay.Components;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.ChampSelect;
using OSL_Overlay.GameFlow.EndGame;
using OSL_Overlay.GameFlow.Fearless;
using OSL_Overlay.GameFlow.Patch;
using OSL_Overlay.GameFlow.Phase;
using OSL_Overlay.GameFlow.Team;
using OSL_Overlay.GameFlow.Vs;
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
    var fearlessView2State = scope.ServiceProvider.GetRequiredService<FearlessView2State>();
    var patchState = scope.ServiceProvider.GetRequiredService<PatchState>();
    var phaseState = scope.ServiceProvider.GetRequiredService<PhaseState>();
    var vsState = scope.ServiceProvider.GetRequiredService<VsState>();
    var champSelectState = scope.ServiceProvider.GetRequiredService<ChampSelectState>();
    var champSelectView1State = scope.ServiceProvider.GetRequiredService<ChampSelectView1State>();
    champSelectView1State.SyncFromGlobal();
    var endGameState = scope.ServiceProvider.GetRequiredService<EndGameState>();
    var endGameView1State = scope.ServiceProvider.GetRequiredService<EndGameView1State>();
}

app.Run();
