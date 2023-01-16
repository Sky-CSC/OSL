using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using OSL_Server.FileManager;

namespace OSL_Server.Pages
{
    /// <summary>
    /// Config Page
    /// </summary>
    public partial class ConfigPage
    {
        private static OSLLogger _logger = new OSLLogger("ConfigPage");
        private IBrowserFile? fileSelected = null;

        public class ConfigOverlayText
        {
            [Required]
            [Range(0, 65535, ErrorMessage = "Accommodation invalid (1-65535).")]
            public int Port { get; set; } = 45678;
        }

        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            try
            {
                IBrowserFile file = e.File;

                if (file is not null)
                {
                    fileSelected = file;
                    StateHasChanged();
                }

                _logger.log(LoggingLevel.DEBUG, "LoadFiles()", $"{e.File} files loaded");
            }
            catch (Exception ex)
            {
                fileSelected = null;
                _logger.log(LoggingLevel.WARN, "LoadFiles()", $"Error while loading file : {ex.Message}");
            }
        }

        private async Task LoadFileView1()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //ChampSelectView1Page.DefaultPatch = jsonContent.DefaultPatch;
                    //ChampSelectView1Page.DefaultRegion = jsonContent.DefaultRegion;
                    ChampSelectView1Page.BlueSideTeamName = jsonContent.BlueSideTeamName;
                    ChampSelectView1Page.BlueTeamSubtext = jsonContent.BlueTeamSubtext;
                    ChampSelectView1Page.BlueTeamNameColor = jsonContent.BlueTeamNameColor;
                    ChampSelectView1Page.BlueTeamSubtextColor = jsonContent.BlueTeamSubtextColor;
                    ChampSelectView1Page.BlueLogo = jsonContent.BlueLogo;
                    ChampSelectView1Page.BlueSideTexteColor = jsonContent.BlueSideTexteColor;
                    ChampSelectView1Page.BlueSideBackgroudColor = jsonContent.BlueSideBackgroudColor;
                    ChampSelectView1Page.BlueSideBorderColor = jsonContent.BlueSideBorderColor;
                    ChampSelectView1Page.BlueSideTimerBackgroudColor = jsonContent.BlueSideTimerBackgroudColor;
                    ChampSelectView1Page.BlueSideTimerBorderColor = jsonContent.BlueSideTimerBorderColor;
                    ChampSelectView1Page.BlueSideTimerTexteColor = jsonContent.BlueSideTimerTexteColor;
                    ChampSelectView1Page.RedSideTeamName = jsonContent.RedSideTeamName;
                    ChampSelectView1Page.RedTeamSubtext = jsonContent.RedTeamSubtext;
                    ChampSelectView1Page.RedTeamNameColor = jsonContent.RedTeamNameColor;
                    ChampSelectView1Page.RedTeamSubtextColor = jsonContent.RedTeamSubtextColor;
                    ChampSelectView1Page.RedLogo = jsonContent.RedLogo;
                    ChampSelectView1Page.RedSideTexteColor = jsonContent.RedSideTexteColor;
                    ChampSelectView1Page.RedSideBackgroudColor = jsonContent.RedSideBackgroudColor;
                    ChampSelectView1Page.RedSideBorderColor = jsonContent.RedSideBorderColor;
                    ChampSelectView1Page.RedSideTimerBackgroudColor = jsonContent.RedSideTimerBackgroudColor;
                    ChampSelectView1Page.RedSideTimerBorderColor = jsonContent.RedSideTimerBorderColor;
                    ChampSelectView1Page.RedSideTimerTexteColor = jsonContent.RedSideTimerTexteColor;
                    ChampSelectView1Page.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
                    ChampSelectView1Page.BanOverlayPicture = jsonContent.BanOverlayPicture;
                    ChampSelectView1Page.BanBackgroundColor = jsonContent.BanBackgroundColor;
                    ChampSelectView1Page.OverlayBackground = jsonContent.OverlayBackground;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileView1()", "Configuration View1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileView1()", "Load view 1 error : " + e.Message);
                }
            }
        }
        private async Task LoadFileView2()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //ChampSelectView2Page.DefaultPatch = jsonContent.DefaultPatch;
                    //ChampSelectView2Page.DefaultRegion = jsonContent.DefaultRegion;
                    ChampSelectView2Page.TimerBackground = jsonContent.TimerBackground;
                    ChampSelectView2Page.TimerBlue = jsonContent.TimerBlue;
                    ChampSelectView2Page.TimerRed = jsonContent.TimerRed;
                    ChampSelectView2Page.TimerEnd = jsonContent.TimerEnd;
                    ChampSelectView2Page.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
                    ChampSelectView2Page.BlueSideSummoner = jsonContent.BlueSideSummoner;
                    ChampSelectView2Page.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
                    ChampSelectView2Page.BlueSideBlink = jsonContent.BlueSideBlink;
                    ChampSelectView2Page.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
                    ChampSelectView2Page.BlueSideTeamName = jsonContent.BlueSideTeamName;
                    ChampSelectView2Page.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
                    ChampSelectView2Page.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
                    ChampSelectView2Page.KeystonePickColor = jsonContent.KeystonePickColor;
                    ChampSelectView2Page.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
                    ChampSelectView2Page.KeystonePickColor1 = jsonContent.KeystonePickColor1;
                    ChampSelectView2Page.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
                    ChampSelectView2Page.KeystonePickColor2 = jsonContent.KeystonePickColor2;
                    ChampSelectView2Page.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
                    ChampSelectView2Page.RedSideBackgroud = jsonContent.RedSideBackgroud;
                    ChampSelectView2Page.RedSideSummoner = jsonContent.RedSideSummoner;
                    ChampSelectView2Page.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
                    ChampSelectView2Page.RedSideBlink = jsonContent.RedSideBlink;
                    ChampSelectView2Page.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
                    ChampSelectView2Page.RedSideTeamName = jsonContent.RedSideTeamName;
                    ChampSelectView2Page.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
                    ChampSelectView2Page.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
                    ChampSelectView2Page.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
                    ChampSelectView2Page.BanOverlayPicture = jsonContent.BanOverlayPicture;
                    ChampSelectView2Page.BanBackgroundColor = jsonContent.BanBackgroundColor;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileView1()", "Configuration View1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileView1()", "Load view 2 error : " + e.Message);
                }
            }
        }
        private async Task LoadFileView3()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //ChampSelectView3Page.DefaultPatch = jsonContent.DefaultPatch;
                    //ChampSelectView3Page.DefaultRegion = jsonContent.DefaultRegion;
                    ChampSelectView3Page.TimerBackground = jsonContent.TimerBackground;
                    ChampSelectView3Page.TimerBlue = jsonContent.TimerBlue;
                    ChampSelectView3Page.TimerRed = jsonContent.TimerRed;
                    ChampSelectView3Page.TimerEnd = jsonContent.TimerEnd;
                    ChampSelectView3Page.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
                    ChampSelectView3Page.BlueSideSummoner = jsonContent.BlueSideSummoner;
                    ChampSelectView3Page.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
                    ChampSelectView3Page.BlueSideBlink = jsonContent.BlueSideBlink;
                    ChampSelectView3Page.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
                    ChampSelectView3Page.BlueSideTeamName = jsonContent.BlueSideTeamName;
                    ChampSelectView3Page.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
                    ChampSelectView3Page.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
                    ChampSelectView3Page.KeystonePickColor = jsonContent.KeystonePickColor;
                    ChampSelectView3Page.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
                    ChampSelectView3Page.KeystonePickColor1 = jsonContent.KeystonePickColor1;
                    ChampSelectView3Page.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
                    ChampSelectView3Page.KeystonePickColor2 = jsonContent.KeystonePickColor2;
                    ChampSelectView3Page.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
                    ChampSelectView3Page.RedSideBackgroud = jsonContent.RedSideBackgroud;
                    ChampSelectView3Page.RedSideSummoner = jsonContent.RedSideSummoner;
                    ChampSelectView3Page.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
                    ChampSelectView3Page.RedSideBlink = jsonContent.RedSideBlink;
                    ChampSelectView3Page.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
                    ChampSelectView3Page.RedSideTeamName = jsonContent.RedSideTeamName;
                    ChampSelectView3Page.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
                    ChampSelectView3Page.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
                    ChampSelectView3Page.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
                    ChampSelectView3Page.BanOverlayPicture = jsonContent.BanOverlayPicture;
                    ChampSelectView3Page.BanBackgroundColor = jsonContent.BanBackgroundColor;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileView1()", "Configuration View1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileView1()", "Load view 3 error : " + e.Message);
                }
            }
        }


        public string GenerateConfigFileView1()
        {
            try
            {
                var data = new ChampSelectView1Page.ChampSelect
                {
                    DefaultPatch = ChampSelectView1Page.DefaultPatch,
                    DefaultRegion = ChampSelectView1Page.DefaultRegion,
                    BlueSideTeamName = ChampSelectView1Page.BlueSideTeamName,
                    BlueTeamSubtext = ChampSelectView1Page.BlueTeamSubtext,
                    BlueTeamNameColor = ChampSelectView1Page.BlueTeamNameColor,
                    BlueTeamSubtextColor = ChampSelectView1Page.BlueTeamSubtextColor,
                    BlueLogo = ChampSelectView1Page.BlueLogo,
                    BlueSideTexteColor = ChampSelectView1Page.BlueSideTexteColor,
                    BlueSideBackgroudColor = ChampSelectView1Page.BlueSideBackgroudColor,
                    BlueSideBorderColor = ChampSelectView1Page.BlueSideBorderColor,
                    BlueSideTimerBackgroudColor = ChampSelectView1Page.BlueSideTimerBackgroudColor,
                    BlueSideTimerBorderColor = ChampSelectView1Page.BlueSideTimerBorderColor,
                    BlueSideTimerTexteColor = ChampSelectView1Page.BlueSideTimerTexteColor,
                    RedSideTeamName = ChampSelectView1Page.RedSideTeamName,
                    RedTeamSubtext = ChampSelectView1Page.RedTeamSubtext,
                    RedTeamNameColor = ChampSelectView1Page.RedTeamNameColor,
                    RedTeamSubtextColor = ChampSelectView1Page.RedTeamSubtextColor,
                    RedLogo = ChampSelectView1Page.RedLogo,
                    RedSideTexteColor = ChampSelectView1Page.RedSideTexteColor,
                    RedSideBackgroudColor = ChampSelectView1Page.RedSideBackgroudColor,
                    RedSideBorderColor = ChampSelectView1Page.RedSideBorderColor,
                    RedSideTimerBackgroudColor = ChampSelectView1Page.RedSideTimerBackgroudColor,
                    RedSideTimerBorderColor = ChampSelectView1Page.RedSideTimerBorderColor,
                    RedSideTimerTexteColor = ChampSelectView1Page.RedSideTimerTexteColor,
                    BanBackgroundPicture = ChampSelectView1Page.BanBackgroundPicture,
                    BanOverlayPicture = ChampSelectView1Page.BanOverlayPicture,
                    BanBackgroundColor = ChampSelectView1Page.BanBackgroundColor,
                    OverlayBackground = ChampSelectView1Page.OverlayBackground,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/champselect/configChampSelectView1.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileView1()", "Generation ok");
                return "/assets/champselect/configChampSelectView1.json";
            }
            catch(Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileView1()", "Error generation old version recive : " + e.Message);
                return "/assets/champselect/configChampSelectView1.json";
            }
        }
        private string GenerateConfigFileView2()
        {
            try
            {
                var data = new ChampSelectView2Page.ChampSelect
                {
                    DefaultPatch = ChampSelectView2Page.DefaultPatch,
                    DefaultRegion = ChampSelectView2Page.DefaultRegion,
                    TimerBackground = ChampSelectView2Page.TimerBackground,
                    TimerBlue = ChampSelectView2Page.TimerBlue,
                    TimerRed = ChampSelectView2Page.TimerRed,
                    TimerEnd = ChampSelectView2Page.TimerEnd,
                    BlueSideBackgroud = ChampSelectView2Page.BlueSideBackgroud,
                    BlueSideSummoner = ChampSelectView2Page.BlueSideSummoner,
                    BlueSideBackgroudSummonerPick = ChampSelectView2Page.BlueSideBackgroudSummonerPick,
                    BlueSideBlink = ChampSelectView2Page.BlueSideBlink,
                    BlueSideBackgroudSummonerPickEnd = ChampSelectView2Page.BlueSideBackgroudSummonerPickEnd,
                    BlueSideTeamName = ChampSelectView2Page.BlueSideTeamName,
                    BlueSideTeamNameColor = ChampSelectView2Page.BlueSideTeamNameColor,
                    BlueSideTeamNameSize = ChampSelectView2Page.BlueSideTeamNameSize,
                    KeystonePickColor = ChampSelectView2Page.KeystonePickColor,
                    KeystonePickColorDeg = ChampSelectView2Page.KeystonePickColorDeg,
                    KeystonePickColor1 = ChampSelectView2Page.KeystonePickColor1,
                    KeystonePickColorPercent1 = ChampSelectView2Page.KeystonePickColorPercent1,
                    KeystonePickColor2 = ChampSelectView2Page.KeystonePickColor2,
                    KeystonePickColorPercent2 = ChampSelectView2Page.KeystonePickColorPercent2,
                    RedSideBackgroud = ChampSelectView2Page.RedSideBackgroud,
                    RedSideSummoner = ChampSelectView2Page.RedSideSummoner,
                    RedSideBackgroudSummonerPick = ChampSelectView2Page.RedSideBackgroudSummonerPick,
                    RedSideBlink = ChampSelectView2Page.RedSideBlink,
                    RedSideBackgroudSummonerPickEnd = ChampSelectView2Page.RedSideBackgroudSummonerPickEnd,
                    RedSideTeamName = ChampSelectView2Page.RedSideTeamName,
                    RedSideTeamNameColor = ChampSelectView2Page.RedSideTeamNameColor,
                    RedSideTeamNameSize = ChampSelectView2Page.RedSideTeamNameSize,
                    BanBackgroundPicture = ChampSelectView2Page.BanBackgroundPicture,
                    BanOverlayPicture = ChampSelectView2Page.BanOverlayPicture,
                    BanBackgroundColor = ChampSelectView2Page.BanBackgroundColor,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/champselect/configChampSelectView2.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileView2()", "Generation ok");
                return "/assets/champselect/configChampSelectView2.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileView1()", "Error generation old version recive : " + e.Message);
                return "/assets/champselect/configChampSelectView2.json";
            }
        }
        private string GenerateConfigFileView3()
        {
            try
            {
                var data = new ChampSelectView3Page.ChampSelect
                {
                    DefaultPatch = ChampSelectView3Page.DefaultPatch,
                    DefaultRegion = ChampSelectView3Page.DefaultRegion,
                    TimerBackground = ChampSelectView3Page.TimerBackground,
                    TimerBlue = ChampSelectView3Page.TimerBlue,
                    TimerRed = ChampSelectView3Page.TimerRed,
                    TimerEnd = ChampSelectView3Page.TimerEnd,
                    BlueSideBackgroud = ChampSelectView3Page.BlueSideBackgroud,
                    BlueSideSummoner = ChampSelectView3Page.BlueSideSummoner,
                    BlueSideBackgroudSummonerPick = ChampSelectView3Page.BlueSideBackgroudSummonerPick,
                    BlueSideBlink = ChampSelectView3Page.BlueSideBlink,
                    BlueSideBackgroudSummonerPickEnd = ChampSelectView3Page.BlueSideBackgroudSummonerPickEnd,
                    BlueSideTeamName = ChampSelectView3Page.BlueSideTeamName,
                    BlueSideTeamNameColor = ChampSelectView3Page.BlueSideTeamNameColor,
                    BlueSideTeamNameSize = ChampSelectView3Page.BlueSideTeamNameSize,
                    KeystonePickColor = ChampSelectView3Page.KeystonePickColor,
                    KeystonePickColorDeg = ChampSelectView3Page.KeystonePickColorDeg,
                    KeystonePickColor1 = ChampSelectView3Page.KeystonePickColor1,
                    KeystonePickColorPercent1 = ChampSelectView3Page.KeystonePickColorPercent1,
                    KeystonePickColor2 = ChampSelectView3Page.KeystonePickColor2,
                    KeystonePickColorPercent2 = ChampSelectView3Page.KeystonePickColorPercent2,
                    RedSideBackgroud = ChampSelectView3Page.RedSideBackgroud,
                    RedSideSummoner = ChampSelectView3Page.RedSideSummoner,
                    RedSideBackgroudSummonerPick = ChampSelectView3Page.RedSideBackgroudSummonerPick,
                    RedSideBlink = ChampSelectView3Page.RedSideBlink,
                    RedSideBackgroudSummonerPickEnd = ChampSelectView3Page.RedSideBackgroudSummonerPickEnd,
                    RedSideTeamName = ChampSelectView3Page.RedSideTeamName,
                    RedSideTeamNameColor = ChampSelectView3Page.RedSideTeamNameColor,
                    RedSideTeamNameSize = ChampSelectView3Page.RedSideTeamNameSize,
                    BanBackgroundPicture = ChampSelectView3Page.BanBackgroundPicture,
                    BanOverlayPicture = ChampSelectView3Page.BanOverlayPicture,
                    BanBackgroundColor = ChampSelectView3Page.BanBackgroundColor,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/champselect/configChampSelectView3.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileView3()", "Generation ok");
                return "/assets/champselect/configChampSelectView3.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileView1()", "Error generation old version recive : " + e.Message);
                return "/assets/champselect/configChampSelectView3.json";
            }
        }
    }
}
