using OSL_Web.Configuration;
using OSL_Web.Pages.CDragon;

using System.Diagnostics;
using MudBlazor.Services;
using OSL_Web.Sockets;

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

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("###########################################");
Console.WriteLine("####### Hello and welcome to OSL Web ######");
Console.WriteLine("############ Just let this run ############");
Console.WriteLine("######### Go to the web interface #########");
Console.WriteLine("###########################################\n");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("###########################");
Console.WriteLine("###### Version 1.1.0 ######");
Console.WriteLine("###########################\n");
Console.ResetColor();

Config.LoadConfig(); //Load configs

//CDragonPage.UpdateManual();//Download file fr

AsyncServer.Run(); //Run Socket server

///Open in default browser application
Process.Start(new ProcessStartInfo
{
    FileName = $"http://{Config.webHostName}:{Config.webHttpPort}",
    UseShellExecute = true
});

app.Run();
