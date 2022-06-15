using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OSL_Server.Configuration;
using OSL_Server.Data;
using OSL_Server.DataLoader.CDragon;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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

Config.LoadConfig();

CDragon.region = "fr_fr";
string region = "fr_fr";
CDragon.patch = "latest";
string patch = "latest";
CDragon.Download.DownloadFiles(patch, region);

CDragon.region = "en_gb";
region = "en_gb";
CDragon.patch = "latest";
patch = "latest";
CDragon.Download.DownloadFiles(patch, region);

//print datat from dataCDragon
//foreach (var patch in CDragon.dataCDragon.Patch)
//{
//    foreach (var region in patch.Region)
//    {
//        //region
//        foreach (var champInfo in region.RegionContent.Champion)
//        {
//            Console.WriteLine(champInfo.Id);
//            Console.WriteLine(champInfo.Name);
//            Console.WriteLine(champInfo.Alias);
//            Console.WriteLine(champInfo.SquarePortraitPath);
//            Console.WriteLine(champInfo.Sound.ChoosePath);
//            Console.WriteLine(champInfo.Sound.BanPath);
//            Console.WriteLine(champInfo.Sound.SfxPath);
//            foreach (var skinInfo in champInfo.Skins)
//            {
//                Console.WriteLine(skinInfo.Id);
//                Console.WriteLine(skinInfo.IsBase);
//                Console.WriteLine(skinInfo.SplashePath);
//                Console.WriteLine(skinInfo.SplasheUncenteredPath);
//                Console.WriteLine(skinInfo.TilePath);
//                Console.WriteLine(skinInfo.LoadScreenPath);
//            }
//        }
//    }
//}

//foreach (var patch in CDragon.dataCDragon.Patch)
//{
//    foreach (var region in patch.Region)
//    {
//        //region
//        foreach (var items in region.RegionContent.Items)
//        {
//            Console.WriteLine(items.Id);
//            Console.WriteLine(items.Name);
//            Console.WriteLine(items.IconPath);

//            foreach (var from in items.From)
//            {
//                Console.WriteLine(from);
//            }
//            foreach (var to in items.To)
//            {
//                Console.WriteLine(to);
//            }
//        }
//    }
//}

//foreach (var patch in CDragon.dataCDragon.Patch)
//{
//    foreach (var region in patch.Region)
//    {
//        //region
//        foreach (var items in region.RegionContent.SummonerSpells)
//        {
//            Console.WriteLine(items.Id);
//            Console.WriteLine(items.Name);
//            Console.WriteLine(items.IconPath);
//        }
//    }
//}

//foreach (var patchTemps in CDragon.dataCDragon.Patch)
//{
//    foreach (var regionTemps in patchTemps.Region)
//    {
//        //region
//        foreach (var items in regionTemps.RegionContent.Perks)
//        {
//            Console.WriteLine(items.Id);
//            Console.WriteLine(items.Name);
//            Console.WriteLine(items.IconPath);
//        }
//    }
//}

//app.Run();

