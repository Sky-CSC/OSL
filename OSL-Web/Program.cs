using OSL_Web.Configuration;
using OSL_Web.Pages.CDragon;

using System.Diagnostics;
using MudBlazor.Services;
using OSL_Web.Sockets;
using OSL_Web.Pages.InGame;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("  ______    ______   __          __       __            __ ");
Console.WriteLine(" /      \\  /      \\ |  \\        |  \\  _  |  \\          |  \\");
Console.WriteLine("|  $$$$$$\\|  $$$$$$\\| $$        | $$ / \\ | $$  ______  | $$____");
Console.WriteLine("| $$  | $$| $$___\\$$| $$ ______ | $$/  $\\| $$ /      \\ | $$    \\");
Console.WriteLine("| $$  | $$ \\$$    \\ | $$|      \\| $$  $$$\\ $$|  $$$$$$\\| $$$$$$$\\");
Console.WriteLine("| $$  | $$ _\\$$$$$$\\| $$ \\$$$$$$| $$ $$\\$$\\$$| $$    $$| $$  | $$");
Console.WriteLine("| $$__/ $$|  \\__| $$| $$_____   | $$$$  \\$$$$| $$$$$$$$| $$__/ $$");
Console.WriteLine(" \\$$    $$ \\$$    $$| $$     \\  | $$$    \\$$$ \\$$     \\| $$    $$");
Console.WriteLine("  \\$$$$$$   \\$$$$$$  \\$$$$$$$$   \\$$      \\$$  \\$$$$$$$ \\$$$$$$$");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(" __     __                                __                              __         ______       ______  ");
//Console.WriteLine("|  \\   |  \\                              |  \\                           _/  \\       /      \\     /      \\ ");
//Console.WriteLine("| $$   | $$  ______    ______    _______  \\$$  ______   _______        |   $$      |  $$$$$$\\   |  $$$$$$\\");
//Console.WriteLine("| $$   | $$ /      \\  /      \\  /       \\|  \\ /      \\ |       \\        \\$$$$       \\$$__| $$   | $$$\\| $$");
//Console.WriteLine(" \\$$\\ /  $$|  $$$$$$\\|  $$$$$$\\|  $$$$$$$| $$|  $$$$$$\\| $$$$$$$\\        | $$       /      $$   | $$$$\\ $$");
//Console.WriteLine("  \\$$\\  $$ | $$    $$| $$   \\$$ \\$$    \\ | $$| $$  | $$| $$  | $$        | $$      |  $$$$$$    | $$\\$$\\$$");
//Console.WriteLine("   \\$$ $$  | $$$$$$$$| $$       _\\$$$$$$\\| $$| $$__/ $$| $$  | $$       _| $$_  __ | $$_____  __| $$_\\$$$$");
//Console.WriteLine("    \\$$$    \\$$     \\| $$      |       $$| $$ \\$$    $$| $$  | $$      |   $$ \\|  \\| $$     \\|  \\\\$$  \\$$$");
//Console.WriteLine("     \\$      \\$$$$$$$ \\$$       \\$$$$$$$  \\$$  \\$$$$$$  \\$$   \\$$       \\$$$$$$ \\$$ \\$$$$$$$$ \\$$ \\$$$$$$ ");

Console.WriteLine(" __     __                                __                              __          __       _______  ");
Console.WriteLine("|  \\   |  \\                              |  \\                           _/  \\       _/  \\     |       \\ ");
Console.WriteLine("| $$   | $$  ______    ______    _______  \\$$  ______   _______        |   $$      |   $$     | $$$$$$$ ");
Console.WriteLine("| $$   | $$ /      \\  /      \\  /       \\|  \\ /      \\ |       \\        \\$$$$       \\$$$$     | $$____  ");
Console.WriteLine(" \\$$\\ /  $$|  $$$$$$\\|  $$$$$$\\|  $$$$$$$| $$|  $$$$$$\\| $$$$$$$\\        | $$        | $$     | $$   \\ ");
Console.WriteLine("  \\$$\\  $$ | $$    $$| $$   \\$$ \\$$    \\ | $$| $$  | $$| $$  | $$        | $$        | $$      \\$$$$$$$\\");
Console.WriteLine("   \\$$ $$  | $$$$$$$$| $$       _\\$$$$$$\\| $$| $$__/ $$| $$  | $$       _| $$_  __  _| $$_  __|  \\__| $$");
Console.WriteLine("    \\$$$    \\$$     \\| $$      |       $$| $$ \\$$    $$| $$  | $$      |   $$ \\|  \\|   $$ \\|  \\\\$$    $$");
Console.WriteLine("     \\$      \\$$$$$$$ \\$$       \\$$$$$$$  \\$$  \\$$$$$$  \\$$   \\$$       \\$$$$$$ \\$$ \\$$$$$$ \\$$ \\$$$$$$ ");                                                                                               
Console.ResetColor();
Console.WriteLine();

Config.LoadConfig(); //Load configs

CDragonPage.UpdateManual();//Download file latest fr_fr

//TimerControl.InitTimerGameStart();
Thread RunDecreasingTimer = new Thread(() => TimerControl.DecreasingTimer());
RunDecreasingTimer.Start();

AsyncServer.Run(); //Run Socket server

///Open in default browser application
Process.Start(new ProcessStartInfo
{
    FileName = $"http://{Config.webHostName}:{Config.webHttpPort}",
    UseShellExecute = true
});

app.Run();
