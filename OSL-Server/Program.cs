using OSL_Server.Configuration;
using OSL_Server.Data;
using MudBlazor.Services;
using OSL_Server.Communication;
using OSL_Server.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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
Console.WriteLine("##### Hello and welcome to OSL Server #####");
Console.WriteLine("###### Just let this run, do nothing ######");
Console.WriteLine("###########################################\n");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("###########################");
Console.WriteLine("##### Version 0.2.0 #####");
Console.WriteLine("###########################\n");
Console.ResetColor();

Config.LoadConfig(); //Load configs

CDragonPage.UpdateManual();//Download file fr

AsyncServer.Run(); //Run Socket server
app.Run(); //Run Application