using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using OSL_Server.Configuration;
using OSL_Server.Data;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.DataReciveClient.Processing.ChampSelect;
using OSL_Server.Pages;
using MudBlazor.Services;
using OSL_Server.Communication;

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

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

Config.LoadConfigCDragon();

//Dowload default config
string region = "fr_fr";
string patch = "latest";
CDragon.Download.DownloadFiles(patch, region);
//region = "en_gb";
//patch = "latest";
//CDragon.Download.DownloadFiles(patch, region);

//Faire une liste des patch et des région sur une page web et on sélectionne celui que l'on veut parmi la liste


Config.LoadConfigChampSelectView1();
Config.LoadConfigChampSelectView2();
Config.LoadConfigChampSelectView3();
//Config.LoadConfig();
//CDragonPage.UpdateManual();
//Thread DownloadFilesFr = new Thread(() => ChampSelectInfo.testChampSelectInfo());
//DownloadFilesFr.Start();


////CDragon.region = "fr_fr";
//string region = "fr_fr";
////CDragon.patch = "latest";
//string patch = "latest";
//CDragon.Download.DownloadFiles(patch, region);

////CDragon.region = "en_gb";
//region = "en_gb";
////CDragon.patch = "latest";
//patch = "latest";
//CDragon.Download.DownloadFiles(patch, region);

//Console.WriteLine(JsonConvert.SerializeObject(CDragon.dataCDragon, Formatting.Indented));

AsyncServer.Run();
app.Run();

