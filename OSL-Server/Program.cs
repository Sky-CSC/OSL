using MudBlazor.Services;
using OSL_Server.Components;
using OSL_Server.Schema;
using OSL_Server.Services;
using OSL_Server.WebSocket;
using OSL_Server.WebSocket.Handlers;
using OSL_Utils.WebSocket;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Configure LeagueClientConfig from appsettings.json
builder.Services.Configure<LeagueClientConfig>(
    builder.Configuration.GetSection("LeagueClientConfig"));

// Configure RiotDevelopementPortalConfig from appsettings.json
builder.Services.Configure<RiotDevelopementPortalConfig>(
    builder.Configuration.GetSection("RiotDevelopementPortalConfig"));

// Configure Web socket server from appsettings.json
builder.Services.Configure<WebSocketConfig>(
    builder.Configuration.GetSection("WebSocketServerConfig"));

// Register the LeagueClient as a singleton service
builder.Services.AddSingleton<LeagueClient>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<LeagueClient>());

// Register the WebSocketServer as a singleton service
builder.Services.AddSingleton<WebSocketServer>();

// Handler
builder.Services.AddSingleton<IMessageHandler, TerminatorHandler>();

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

// Start the LeagueClient service
var wsServer = app.Services.GetRequiredService<WebSocketServer>();
_ = wsServer.StartAsync(CancellationToken.None);

await app.RunAsync();
