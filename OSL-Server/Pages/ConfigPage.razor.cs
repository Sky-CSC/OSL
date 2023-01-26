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
using System.Net.Http.Json;

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
                    ChampSelectView1Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
                    ChampSelectView1Page.formatingData.BlueTeamSubtext = jsonContent.BlueTeamSubtext;
                    ChampSelectView1Page.formatingData.BlueTeamNameColor = jsonContent.BlueTeamNameColor;
                    ChampSelectView1Page.formatingData.BlueTeamSubtextColor = jsonContent.BlueTeamSubtextColor;
                    ChampSelectView1Page.formatingData.BlueLogo = jsonContent.BlueLogo;
                    ChampSelectView1Page.formatingData.BlueSideTexteColor = jsonContent.BlueSideTexteColor;
                    ChampSelectView1Page.formatingData.BlueSideBackgroudColor = jsonContent.BlueSideBackgroudColor;
                    ChampSelectView1Page.formatingData.BlueSideBorderColor = jsonContent.BlueSideBorderColor;
                    ChampSelectView1Page.formatingData.BlueSideTimerBackgroudColor = jsonContent.BlueSideTimerBackgroudColor;
                    ChampSelectView1Page.formatingData.BlueSideTimerBorderColor = jsonContent.BlueSideTimerBorderColor;
                    ChampSelectView1Page.formatingData.BlueSideTimerTexteColor = jsonContent.BlueSideTimerTexteColor;
                    ChampSelectView1Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
                    ChampSelectView1Page.formatingData.RedTeamSubtext = jsonContent.RedTeamSubtext;
                    ChampSelectView1Page.formatingData.RedTeamNameColor = jsonContent.RedTeamNameColor;
                    ChampSelectView1Page.formatingData.RedTeamSubtextColor = jsonContent.RedTeamSubtextColor;
                    ChampSelectView1Page.formatingData.RedLogo = jsonContent.RedLogo;
                    ChampSelectView1Page.formatingData.RedSideTexteColor = jsonContent.RedSideTexteColor;
                    ChampSelectView1Page.formatingData.RedSideBackgroudColor = jsonContent.RedSideBackgroudColor;
                    ChampSelectView1Page.formatingData.RedSideBorderColor = jsonContent.RedSideBorderColor;
                    ChampSelectView1Page.formatingData.RedSideTimerBackgroudColor = jsonContent.RedSideTimerBackgroudColor;
                    ChampSelectView1Page.formatingData.RedSideTimerBorderColor = jsonContent.RedSideTimerBorderColor;
                    ChampSelectView1Page.formatingData.RedSideTimerTexteColor = jsonContent.RedSideTimerTexteColor;
                    ChampSelectView1Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
                    ChampSelectView1Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
                    ChampSelectView1Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
                    ChampSelectView1Page.formatingData.OverlayBackground = jsonContent.OverlayBackground;
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
                    ChampSelectView2Page.formatingData.TimerBackground = jsonContent.TimerBackground;
                    ChampSelectView2Page.formatingData.TimerBlue = jsonContent.TimerBlue;
                    ChampSelectView2Page.formatingData.TimerRed = jsonContent.TimerRed;
                    ChampSelectView2Page.formatingData.TimerEnd = jsonContent.TimerEnd;
                    ChampSelectView2Page.formatingData.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
                    ChampSelectView2Page.formatingData.BlueSideSummoner = jsonContent.BlueSideSummoner;
                    ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
                    ChampSelectView2Page.formatingData.BlueSideBlink = jsonContent.BlueSideBlink;
                    ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
                    ChampSelectView2Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
                    ChampSelectView2Page.formatingData.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
                    ChampSelectView2Page.formatingData.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
                    ChampSelectView2Page.formatingData.KeystonePickColor = jsonContent.KeystonePickColor;
                    ChampSelectView2Page.formatingData.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
                    ChampSelectView2Page.formatingData.KeystonePickColor1 = jsonContent.KeystonePickColor1;
                    ChampSelectView2Page.formatingData.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
                    ChampSelectView2Page.formatingData.KeystonePickColor2 = jsonContent.KeystonePickColor2;
                    ChampSelectView2Page.formatingData.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
                    ChampSelectView2Page.formatingData.RedSideBackgroud = jsonContent.RedSideBackgroud;
                    ChampSelectView2Page.formatingData.RedSideSummoner = jsonContent.RedSideSummoner;
                    ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
                    ChampSelectView2Page.formatingData.RedSideBlink = jsonContent.RedSideBlink;
                    ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
                    ChampSelectView2Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
                    ChampSelectView2Page.formatingData.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
                    ChampSelectView2Page.formatingData.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
                    ChampSelectView2Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
                    ChampSelectView2Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
                    ChampSelectView2Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileView2()", "Configuration View1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileView2()", "Load view 2 error : " + e.Message);
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
                    ChampSelectView3Page.formatingData.TimerBackground = jsonContent.TimerBackground;
                    ChampSelectView3Page.formatingData.TimerBlue = jsonContent.TimerBlue;
                    ChampSelectView3Page.formatingData.TimerRed = jsonContent.TimerRed;
                    ChampSelectView3Page.formatingData.TimerEnd = jsonContent.TimerEnd;
                    ChampSelectView3Page.formatingData.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
                    ChampSelectView3Page.formatingData.BlueSideSummoner = jsonContent.BlueSideSummoner;
                    ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
                    ChampSelectView3Page.formatingData.BlueSideBlink = jsonContent.BlueSideBlink;
                    ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
                    ChampSelectView3Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
                    ChampSelectView3Page.formatingData.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
                    ChampSelectView3Page.formatingData.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
                    ChampSelectView3Page.formatingData.KeystonePickColor = jsonContent.KeystonePickColor;
                    ChampSelectView3Page.formatingData.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
                    ChampSelectView3Page.formatingData.KeystonePickColor1 = jsonContent.KeystonePickColor1;
                    ChampSelectView3Page.formatingData.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
                    ChampSelectView3Page.formatingData.KeystonePickColor2 = jsonContent.KeystonePickColor2;
                    ChampSelectView3Page.formatingData.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
                    ChampSelectView3Page.formatingData.RedSideBackgroud = jsonContent.RedSideBackgroud;
                    ChampSelectView3Page.formatingData.RedSideSummoner = jsonContent.RedSideSummoner;
                    ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
                    ChampSelectView3Page.formatingData.RedSideBlink = jsonContent.RedSideBlink;
                    ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
                    ChampSelectView3Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
                    ChampSelectView3Page.formatingData.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
                    ChampSelectView3Page.formatingData.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
                    ChampSelectView3Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
                    ChampSelectView3Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
                    ChampSelectView3Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileView3()", "Configuration View1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileView3()", "Load view 3 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileView4()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //ChampSelectView4Page.DefaultPatch = jsonContent.DefaultPatch;
                    //ChampSelectView4Page.DefaultRegion = jsonContent.DefaultRegion;
                    ChampSelectView4Page.formatingData.BorderBottomPixel = jsonContent.BorderBottomPixel;
                    ChampSelectView4Page.formatingData.BorderTop = jsonContent.BorderTop;
                    ChampSelectView4Page.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    ChampSelectView4Page.formatingData.BackgroudGradientDeg = jsonContent.BackgroudGradientDeg;
                    ChampSelectView4Page.formatingData.BackgroudGradientColor1 = jsonContent.BackgroudGradientColor1;
                    ChampSelectView4Page.formatingData.BackgroudGradientPercent1 = jsonContent.BackgroudGradientPercent1;
                    ChampSelectView4Page.formatingData.BackgroudGradientColor2 = jsonContent.BackgroudGradientColor2;
                    ChampSelectView4Page.formatingData.BackgroudGradientPercent2 = jsonContent.BackgroudGradientPercent2;
                    ChampSelectView4Page.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    ChampSelectView4Page.formatingData.BlueSideBorderColorPick = jsonContent.BlueSideBorderColorPick;
                    ChampSelectView4Page.formatingData.BlueSideBorderColorBan = jsonContent.BlueSideBorderColorBan;
                    ChampSelectView4Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
                    ChampSelectView4Page.formatingData.BlueSideTeamNameSubtext = jsonContent.BlueSideTeamNameSubtext;
                    ChampSelectView4Page.formatingData.BlueSideBanText = jsonContent.BlueSideBanText;
                    ChampSelectView4Page.formatingData.BlueSidePickText = jsonContent.BlueSidePickText;
                    ChampSelectView4Page.formatingData.BlueSideColorText = jsonContent.BlueSideColorText;
                    ChampSelectView4Page.formatingData.BlueSideColorSubText = jsonContent.BlueSideColorSubText;
                    ChampSelectView4Page.formatingData.BlueSideColorTextBan = jsonContent.BlueSideColorTextBan;
                    ChampSelectView4Page.formatingData.BlueSideColorTextPick = jsonContent.BlueSideColorTextPick;
                    ChampSelectView4Page.formatingData.RedSideBorderColorPick = jsonContent.RedSideBorderColorPick;
                    ChampSelectView4Page.formatingData.RedSideBorderColorBan = jsonContent.RedSideBorderColorBan;
                    ChampSelectView4Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
                    ChampSelectView4Page.formatingData.RedSideTeamNameSubtext = jsonContent.RedSideTeamNameSubtext;
                    ChampSelectView4Page.formatingData.RedSideBanText = jsonContent.RedSideBanText;
                    ChampSelectView4Page.formatingData.RedSidePickText = jsonContent.RedSidePickText;
                    ChampSelectView4Page.formatingData.RedSideColorText = jsonContent.RedSideColorText;
                    ChampSelectView4Page.formatingData.RedSideColorSubText = jsonContent.RedSideColorSubText;
                    ChampSelectView4Page.formatingData.RedSideColorTextBan = jsonContent.RedSideColorTextBan;
                    ChampSelectView4Page.formatingData.RedSideColorTextPick = jsonContent.RedSideColorTextPick;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileView4()", "Configuration View4 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileView4()", "Load view 4 error : " + e.Message);
                }
            }
        }


        public string GenerateConfigFileView1()
        {
            try
            {
                var data = new ChampSelectView1Page.FormatingData
                {
                    DefaultPatch = ChampSelectView1Page.formatingData.DefaultPatch,
                    DefaultRegion = ChampSelectView1Page.formatingData.DefaultRegion,
                    BlueSideTeamName = ChampSelectView1Page.formatingData.BlueSideTeamName,
                    BlueTeamSubtext = ChampSelectView1Page.formatingData.BlueTeamSubtext,
                    BlueTeamNameColor = ChampSelectView1Page.formatingData.BlueTeamNameColor,
                    BlueTeamSubtextColor = ChampSelectView1Page.formatingData.BlueTeamSubtextColor,
                    BlueLogo = ChampSelectView1Page.formatingData.BlueLogo,
                    BlueSideTexteColor = ChampSelectView1Page.formatingData.BlueSideTexteColor,
                    BlueSideBackgroudColor = ChampSelectView1Page.formatingData.BlueSideBackgroudColor,
                    BlueSideBorderColor = ChampSelectView1Page.formatingData.BlueSideBorderColor,
                    BlueSideTimerBackgroudColor = ChampSelectView1Page.formatingData.BlueSideTimerBackgroudColor,
                    BlueSideTimerBorderColor = ChampSelectView1Page.formatingData.BlueSideTimerBorderColor,
                    BlueSideTimerTexteColor = ChampSelectView1Page.formatingData.BlueSideTimerTexteColor,
                    RedSideTeamName = ChampSelectView1Page.formatingData.RedSideTeamName,
                    RedTeamSubtext = ChampSelectView1Page.formatingData.RedTeamSubtext,
                    RedTeamNameColor = ChampSelectView1Page.formatingData.RedTeamNameColor,
                    RedTeamSubtextColor = ChampSelectView1Page.formatingData.RedTeamSubtextColor,
                    RedLogo = ChampSelectView1Page.formatingData.RedLogo,
                    RedSideTexteColor = ChampSelectView1Page.formatingData.RedSideTexteColor,
                    RedSideBackgroudColor = ChampSelectView1Page.formatingData.RedSideBackgroudColor,
                    RedSideBorderColor = ChampSelectView1Page.formatingData.RedSideBorderColor,
                    RedSideTimerBackgroudColor = ChampSelectView1Page.formatingData.RedSideTimerBackgroudColor,
                    RedSideTimerBorderColor = ChampSelectView1Page.formatingData.RedSideTimerBorderColor,
                    RedSideTimerTexteColor = ChampSelectView1Page.formatingData.RedSideTimerTexteColor,
                    BanBackgroundPicture = ChampSelectView1Page.formatingData.BanBackgroundPicture,
                    BanOverlayPicture = ChampSelectView1Page.formatingData.BanOverlayPicture,
                    BanBackgroundColor = ChampSelectView1Page.formatingData.BanBackgroundColor,
                    OverlayBackground = ChampSelectView1Page.formatingData.OverlayBackground,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/champselect/configChampSelectView1.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileView1()", "Generation ok");
                return "/assets/champselect/configChampSelectView1.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileView1()", "Error generation old version recive : " + e.Message);
                return "/assets/champselect/configChampSelectView1.json";
            }
        }
        private string GenerateConfigFileView2()
        {
            try
            {
                var data = new ChampSelectView2Page.FormatingData
                {
                    DefaultPatch = ChampSelectView2Page.formatingData.DefaultPatch,
                    DefaultRegion = ChampSelectView2Page.formatingData.DefaultRegion,
                    TimerBackground = ChampSelectView2Page.formatingData.TimerBackground,
                    TimerBlue = ChampSelectView2Page.formatingData.TimerBlue,
                    TimerRed = ChampSelectView2Page.formatingData.TimerRed,
                    TimerEnd = ChampSelectView2Page.formatingData.TimerEnd,
                    BlueSideBackgroud = ChampSelectView2Page.formatingData.BlueSideBackgroud,
                    BlueSideSummoner = ChampSelectView2Page.formatingData.BlueSideSummoner,
                    BlueSideBackgroudSummonerPick = ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPick,
                    BlueSideBlink = ChampSelectView2Page.formatingData.BlueSideBlink,
                    BlueSideBackgroudSummonerPickEnd = ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPickEnd,
                    BlueSideTeamName = ChampSelectView2Page.formatingData.BlueSideTeamName,
                    BlueSideTeamNameColor = ChampSelectView2Page.formatingData.BlueSideTeamNameColor,
                    BlueSideTeamNameSize = ChampSelectView2Page.formatingData.BlueSideTeamNameSize,
                    KeystonePickColor = ChampSelectView2Page.formatingData.KeystonePickColor,
                    KeystonePickColorDeg = ChampSelectView2Page.formatingData.KeystonePickColorDeg,
                    KeystonePickColor1 = ChampSelectView2Page.formatingData.KeystonePickColor1,
                    KeystonePickColorPercent1 = ChampSelectView2Page.formatingData.KeystonePickColorPercent1,
                    KeystonePickColor2 = ChampSelectView2Page.formatingData.KeystonePickColor2,
                    KeystonePickColorPercent2 = ChampSelectView2Page.formatingData.KeystonePickColorPercent2,
                    RedSideBackgroud = ChampSelectView2Page.formatingData.RedSideBackgroud,
                    RedSideSummoner = ChampSelectView2Page.formatingData.RedSideSummoner,
                    RedSideBackgroudSummonerPick = ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPick,
                    RedSideBlink = ChampSelectView2Page.formatingData.RedSideBlink,
                    RedSideBackgroudSummonerPickEnd = ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPickEnd,
                    RedSideTeamName = ChampSelectView2Page.formatingData.RedSideTeamName,
                    RedSideTeamNameColor = ChampSelectView2Page.formatingData.RedSideTeamNameColor,
                    RedSideTeamNameSize = ChampSelectView2Page.formatingData.RedSideTeamNameSize,
                    BanBackgroundPicture = ChampSelectView2Page.formatingData.BanBackgroundPicture,
                    BanOverlayPicture = ChampSelectView2Page.formatingData.BanOverlayPicture,
                    BanBackgroundColor = ChampSelectView2Page.formatingData.BanBackgroundColor,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/champselect/configChampSelectView2.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileView2()", "Generation ok");
                return "/assets/champselect/configChampSelectView2.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileView2()", "Error generation old version recive : " + e.Message);
                return "/assets/champselect/configChampSelectView2.json";
            }
        }
        private string GenerateConfigFileView3()
        {
            try
            {
                var data = new ChampSelectView3Page.FormatingData
                {
                    DefaultPatch = ChampSelectView3Page.formatingData.DefaultPatch,
                    DefaultRegion = ChampSelectView3Page.formatingData.DefaultRegion,
                    TimerBackground = ChampSelectView3Page.formatingData.TimerBackground,
                    TimerBlue = ChampSelectView3Page.formatingData.TimerBlue,
                    TimerRed = ChampSelectView3Page.formatingData.TimerRed,
                    TimerEnd = ChampSelectView3Page.formatingData.TimerEnd,
                    BlueSideBackgroud = ChampSelectView3Page.formatingData.BlueSideBackgroud,
                    BlueSideSummoner = ChampSelectView3Page.formatingData.BlueSideSummoner,
                    BlueSideBackgroudSummonerPick = ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPick,
                    BlueSideBlink = ChampSelectView3Page.formatingData.BlueSideBlink,
                    BlueSideBackgroudSummonerPickEnd = ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPickEnd,
                    BlueSideTeamName = ChampSelectView3Page.formatingData.BlueSideTeamName,
                    BlueSideTeamNameColor = ChampSelectView3Page.formatingData.BlueSideTeamNameColor,
                    BlueSideTeamNameSize = ChampSelectView3Page.formatingData.BlueSideTeamNameSize,
                    KeystonePickColor = ChampSelectView3Page.formatingData.KeystonePickColor,
                    KeystonePickColorDeg = ChampSelectView3Page.formatingData.KeystonePickColorDeg,
                    KeystonePickColor1 = ChampSelectView3Page.formatingData.KeystonePickColor1,
                    KeystonePickColorPercent1 = ChampSelectView3Page.formatingData.KeystonePickColorPercent1,
                    KeystonePickColor2 = ChampSelectView3Page.formatingData.KeystonePickColor2,
                    KeystonePickColorPercent2 = ChampSelectView3Page.formatingData.KeystonePickColorPercent2,
                    RedSideBackgroud = ChampSelectView3Page.formatingData.RedSideBackgroud,
                    RedSideSummoner = ChampSelectView3Page.formatingData.RedSideSummoner,
                    RedSideBackgroudSummonerPick = ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPick,
                    RedSideBlink = ChampSelectView3Page.formatingData.RedSideBlink,
                    RedSideBackgroudSummonerPickEnd = ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPickEnd,
                    RedSideTeamName = ChampSelectView3Page.formatingData.RedSideTeamName,
                    RedSideTeamNameColor = ChampSelectView3Page.formatingData.RedSideTeamNameColor,
                    RedSideTeamNameSize = ChampSelectView3Page.formatingData.RedSideTeamNameSize,
                    BanBackgroundPicture = ChampSelectView3Page.formatingData.BanBackgroundPicture,
                    BanOverlayPicture = ChampSelectView3Page.formatingData.BanOverlayPicture,
                    BanBackgroundColor = ChampSelectView3Page.formatingData.BanBackgroundColor,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/champselect/configChampSelectView3.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileView3()", "Generation ok");
                return "/assets/champselect/configChampSelectView3.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileView3()", "Error generation old version recive : " + e.Message);
                return "/assets/champselect/configChampSelectView3.json";
            }
        }
        private string GenerateConfigFileView4()
        {
            try
            {
                var data = new ChampSelectView4Page.FormatingData
                {
                    DefaultPatch = ChampSelectView4Page.formatingData.DefaultPatch,
                    DefaultRegion = ChampSelectView4Page.formatingData.DefaultRegion,
                    BorderBottomPixel = ChampSelectView4Page.formatingData.BorderBottomPixel,
                    BorderTop = ChampSelectView4Page.formatingData.BorderTop,
                    BackgroudGradient = ChampSelectView4Page.formatingData.BackgroudGradient,
                    BackgroudGradientDeg = ChampSelectView4Page.formatingData.BackgroudGradientDeg,
                    BackgroudGradientColor1 = ChampSelectView4Page.formatingData.BackgroudGradientColor1,
                    BackgroudGradientPercent1 = ChampSelectView4Page.formatingData.BackgroudGradientPercent1,
                    BackgroudGradientColor2 = ChampSelectView4Page.formatingData.BackgroudGradientColor2,
                    BackgroudGradientPercent2 = ChampSelectView4Page.formatingData.BackgroudGradientPercent2,
                    OverlayColorBackgroudGradient = ChampSelectView4Page.formatingData.OverlayColorBackgroudGradient,
                    BlueSideBorderColorPick = ChampSelectView4Page.formatingData.BlueSideBorderColorPick,
                    BlueSideBorderColorBan = ChampSelectView4Page.formatingData.BlueSideBorderColorBan,
                    BlueSideTeamName = ChampSelectView4Page.formatingData.BlueSideTeamName,
                    BlueSideTeamNameSubtext = ChampSelectView4Page.formatingData.BlueSideTeamNameSubtext,
                    BlueSideBanText = ChampSelectView4Page.formatingData.BlueSideBanText,
                    BlueSidePickText = ChampSelectView4Page.formatingData.BlueSidePickText,
                    BlueSideColorText = ChampSelectView4Page.formatingData.BlueSideColorText,
                    BlueSideColorSubText = ChampSelectView4Page.formatingData.BlueSideColorSubText,
                    BlueSideColorTextBan = ChampSelectView4Page.formatingData.BlueSideColorTextBan,
                    BlueSideColorTextPick = ChampSelectView4Page.formatingData.BlueSideColorTextPick,
                    RedSideBorderColorPick = ChampSelectView4Page.formatingData.RedSideBorderColorPick,
                    RedSideBorderColorBan = ChampSelectView4Page.formatingData.RedSideBorderColorBan,
                    RedSideTeamName = ChampSelectView4Page.formatingData.RedSideTeamName,
                    RedSideTeamNameSubtext = ChampSelectView4Page.formatingData.RedSideTeamNameSubtext,
                    RedSideBanText = ChampSelectView4Page.formatingData.RedSideBanText,
                    RedSidePickText = ChampSelectView4Page.formatingData.RedSidePickText,
                    RedSideColorText = ChampSelectView4Page.formatingData.RedSideColorText,
                    RedSideColorSubText = ChampSelectView4Page.formatingData.RedSideColorSubText,
                    RedSideColorTextBan = ChampSelectView4Page.formatingData.RedSideColorTextBan,
                    RedSideColorTextPick = ChampSelectView4Page.formatingData.RedSideColorTextPick,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/champselect/configChampSelectView4.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileView4()", "Generation ok");
                return "/assets/champselect/configChampSelectView4.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileView4()", "Error generation old version recive : " + e.Message);
                return "/assets/champselect/configChampSelectView4.json";
            }
        }
    }
}
