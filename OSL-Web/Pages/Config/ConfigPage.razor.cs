using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using OSL_Web.Pages.ChampSelect;
using OSL_Web.Pages.InGame;
using OSL_Web.Pages.Runes;
using OSL_Web.Pages.EndGame;
using OSL_Common.System.Logging;
using OSL_WebApiRiot.WebApiRiot;
using OSL_Common.System.FileManager;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static OSL_WebApiRiot.WebApiRiot.WebApiRiot;
using System.Net.Http.Json;

namespace OSL_Web.Pages.Config
{
    /// <summary>
    /// Config Page
    /// </summary>
    public partial class ConfigPage
    {
        private static Logger _logger = new("ConfigPage");
        private IBrowserFile? fileSelected = null;

        public class ConfigOverlayText
        {
            [Required]
            [Range(0, 65535, ErrorMessage = "Accommodation invalid (1-65535).")]
            public int Port { get; set; } = 45678;

            [Required]
            [StringLength(42, MinimumLength = 42, ErrorMessage = "API key is incorect (42 character).")]
            public string WebRiotApiKey { get; set; }

            public string ValuePatchRegion { get; set; } = "latest : fr_fr";
        }

        public static void WebRiotApiKeySubmit()
        {
            WebApiRiot.apiKey = OverlayText.WebRiotApiKey;
            var webApiRegister = new ApiKeyScheme
            {
                apiKey = WebApiRiot.apiKey,
            };
            FileManagerLocal.RewrittenFile("./Configuration/WebApiRiot/web-api-riot.json", JsonConvert.SerializeObject(webApiRegister));
            _logger.log(LoggingLevel.INFO, "WebRiotApiKeySubmit()", $"Web riot api key change : {WebApiRiot.apiKey}");
        }

        public static void PatchRegionSubmit()
        {
            OSL_CDragon.CDragon.SetPatch(OverlayText.ValuePatchRegion.Split(" : ")[0]);
            OSL_CDragon.CDragon.SetRegion(OverlayText.ValuePatchRegion.Split(" : ")[1]);
            Configuration.Config.ReloadPagesView();
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

        private async Task LoadFileChampSelectView1()
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
        private async Task LoadFileChampSelectView2()
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
        private async Task LoadFileChampSelectView3()
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

        private async Task LoadFileChampSelectView4()
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

        private async Task LoadFileInGameView1()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //InGameView1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //InGameView1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    InGameView1Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
                    InGameView1Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
                    InGameView1Page.formatingData.DragonTimerFrame = jsonContent.DragonTimerFrame;
                    InGameView1Page.formatingData.HeraldBaronTimerFrame = jsonContent.HeraldBaronTimerFrame;
                    InGameView1Page.formatingData.LeftInfoFrame = jsonContent.LeftInfoFrame;
                    InGameView1Page.formatingData.RightInfoFrame = jsonContent.RightInfoFrame;
                    InGameView1Page.formatingData.DisplayDragonTimer = jsonContent.DisplayDragonTimer;
                    InGameView1Page.formatingData.DisplayHeraldBaronTimer = jsonContent.DisplayHeraldBaronTimer;
                    InGameView1Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
                    InGameView1Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;
                    InGameView1Page.formatingData.DisplayLeftInfo = jsonContent.DisplayLeftInfo;
                    InGameView1Page.formatingData.DisplayRightInfo = jsonContent.DisplayRightInfo;
                    InGameView1Page.formatingData.TeamBanner = jsonContent.TeamBanner;
                    InGameView1Page.formatingData.TeamScoreBanner = jsonContent.TeamScoreBanner;
                    InGameView1Page.formatingData.BlueTeamText = jsonContent.BlueTeamText;
                    InGameView1Page.formatingData.BlueTeamScoreText = jsonContent.BlueTeamScoreText;
                    InGameView1Page.formatingData.RedTeamText = jsonContent.RedTeamText;
                    InGameView1Page.formatingData.RedTeamScoreText = jsonContent.RedTeamScoreText;
                    InGameView1Page.formatingData.DisplayBlueTeam = jsonContent.DisplayBlueTeam;
                    InGameView1Page.formatingData.DisplayBlueTeamScore = jsonContent.DisplayBlueTeamScore;
                    InGameView1Page.formatingData.DisplayBlueTeamText = jsonContent.DisplayBlueTeamText;
                    InGameView1Page.formatingData.DisplayRedTeam = jsonContent.DisplayRedTeam;
                    InGameView1Page.formatingData.DisplayRedTeamScore = jsonContent.DisplayRedTeamScore;
                    InGameView1Page.formatingData.DisplayRedTeamText = jsonContent.DisplayRedTeamText;
                    InGameView1Page.formatingData.ColorBlueTeamScoreText = jsonContent.ColorBlueTeamScoreText;
                    InGameView1Page.formatingData.ColorBlueTeamText = jsonContent.ColorBlueTeamText;
                    InGameView1Page.formatingData.ColorRedTeamScoreText = jsonContent.ColorRedTeamScoreText;
                    InGameView1Page.formatingData.ColorRedTeamText = jsonContent.ColorRedTeamText;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileInGameView1()", "Configuration View1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileInGameView1()", "Load view 1 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileInGameView1_1()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //InGameView1_1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //InGameView1_1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    InGameView1_1Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
                    InGameView1_1Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
                    InGameView1_1Page.formatingData.DragonTimerFrame = jsonContent.DragonTimerFrame;
                    InGameView1_1Page.formatingData.HeraldBaronTimerFrame = jsonContent.HeraldBaronTimerFrame;
                    InGameView1_1Page.formatingData.LeftInfoFrame = jsonContent.LeftInfoFrame;
                    InGameView1_1Page.formatingData.RightInfoFrame = jsonContent.RightInfoFrame;
                    InGameView1_1Page.formatingData.DisplayDragonTimer = jsonContent.DisplayDragonTimer;
                    InGameView1_1Page.formatingData.DisplayHeraldBaronTimer = jsonContent.DisplayHeraldBaronTimer;
                    InGameView1_1Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
                    InGameView1_1Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;
                    InGameView1_1Page.formatingData.DisplayLeftInfo = jsonContent.DisplayLeftInfo;
                    InGameView1_1Page.formatingData.DisplayRightInfo = jsonContent.DisplayRightInfo;
                    InGameView1_1Page.formatingData.TeamBanner = jsonContent.TeamBanner;
                    InGameView1_1Page.formatingData.TeamScoreBanner = jsonContent.TeamScoreBanner;
                    InGameView1_1Page.formatingData.BlueTeamText = jsonContent.BlueTeamText;
                    InGameView1_1Page.formatingData.BlueTeamScoreText = jsonContent.BlueTeamScoreText;
                    InGameView1_1Page.formatingData.RedTeamText = jsonContent.RedTeamText;
                    InGameView1_1Page.formatingData.RedTeamScoreText = jsonContent.RedTeamScoreText;
                    InGameView1_1Page.formatingData.DisplayBlueTeam = jsonContent.DisplayBlueTeam;
                    InGameView1_1Page.formatingData.DisplayBlueTeamScore = jsonContent.DisplayBlueTeamScore;
                    InGameView1_1Page.formatingData.DisplayBlueTeamText = jsonContent.DisplayBlueTeamText;
                    InGameView1_1Page.formatingData.DisplayRedTeam = jsonContent.DisplayRedTeam;
                    InGameView1_1Page.formatingData.DisplayRedTeamScore = jsonContent.DisplayRedTeamScore;
                    InGameView1_1Page.formatingData.DisplayRedTeamText = jsonContent.DisplayRedTeamText;
                    InGameView1_1Page.formatingData.ColorBlueTeamScoreText = jsonContent.ColorBlueTeamScoreText;
                    InGameView1_1Page.formatingData.ColorBlueTeamText = jsonContent.ColorBlueTeamText;
                    InGameView1_1Page.formatingData.ColorRedTeamScoreText = jsonContent.ColorRedTeamScoreText;
                    InGameView1_1Page.formatingData.ColorRedTeamText = jsonContent.ColorRedTeamText;
                    InGameView1_1Page.formatingData.ColorRedTeamText = jsonContent.ColorRedTeamText;
                    InGameView1_1Page.formatingData.DisplayItems = jsonContent.DisplayItems;
                    InGameView1_1Page.formatingData.DisplayLevels = jsonContent.DisplayLevels;
                    InGameView1_1Page.formatingData.DisplayDragonKill = jsonContent.DisplayDragonKill;
                    InGameView1_1Page.formatingData.DisplayInhibKill = jsonContent.DisplayInhibKill;
                    InGameView1_1Page.formatingData.DisplayBaronElderBuff = jsonContent.DisplayBaronElderBuff;

                    InGameView1_1Page.formatingData.PictureOrderDragonBanner = jsonContent.PictureOrderDragonBanner;
                    InGameView1_1Page.formatingData.PictureChaosDragonBanner = jsonContent.PictureChaosDragonBanner ;
                    InGameView1_1Page.formatingData.ElderDragonIcon = jsonContent.ElderDragonIcon ;
                    InGameView1_1Page.formatingData.HeraldIcon = jsonContent.HeraldIcon ;
                    InGameView1_1Page.formatingData.BaronIcon = jsonContent.BaronIcon ;
                    InGameView1_1Page.formatingData.PositionOrderTop = jsonContent.PositionOrderTop ;
                    InGameView1_1Page.formatingData.PositionChaosTop = jsonContent.PositionChaosTop ;
                    InGameView1_1Page.formatingData.PositionOrderJungle = jsonContent.PositionOrderJungle ;
                    InGameView1_1Page.formatingData.PositionChaosJungle = jsonContent.PositionChaosJungle ;
                    InGameView1_1Page.formatingData.PositionOrderMid = jsonContent.PositionOrderMid ;
                    InGameView1_1Page.formatingData.PositionChaosMid = jsonContent.PositionChaosMid ;
                    InGameView1_1Page.formatingData.PositionOrderBottom = jsonContent.PositionOrderBottom ;
                    InGameView1_1Page.formatingData.PositionChaosBottom = jsonContent.PositionChaosBottom ;
                    InGameView1_1Page.formatingData.PositionOrderSupport = jsonContent.PositionOrderSupport ;
                    InGameView1_1Page.formatingData.PositionChaosSupport = jsonContent.PositionChaosSupport ;
                    InGameView1_1Page.formatingData.InhibIcon = jsonContent.InhibIcon ;
                    InGameView1_1Page.formatingData.BaronBuffIcon = jsonContent.BaronBuffIcon ;
                    InGameView1_1Page.formatingData.ElderBuffIcon = jsonContent.ElderBuffIcon ;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileInGameView1_1()", "Configuration View1_1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileInGameView1_1()", "Load view 1_1 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileInGameView2()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //InGameView2Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //InGameView2Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    InGameView2Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
                    InGameView2Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
                    InGameView2Page.formatingData.DragonTimerFrame = jsonContent.DragonTimerFrame;
                    InGameView2Page.formatingData.HeraldBaronTimerFrame = jsonContent.HeraldBaronTimerFrame;
                    InGameView2Page.formatingData.LeftInfoFrame = jsonContent.LeftInfoFrame;
                    InGameView2Page.formatingData.DisplayDragonTimer = jsonContent.DisplayDragonTimer;
                    InGameView2Page.formatingData.DisplayHeraldBaronTimer = jsonContent.DisplayHeraldBaronTimer;
                    InGameView2Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
                    InGameView2Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;
                    InGameView2Page.formatingData.DisplayLeftInfo = jsonContent.DisplayLeftInfo;
                    InGameView2Page.formatingData.TeamBanner = jsonContent.TeamBanner;
                    InGameView2Page.formatingData.TeamScoreBanner = jsonContent.TeamScoreBanner;
                    InGameView2Page.formatingData.BlueTeamText = jsonContent.BlueTeamText;
                    InGameView2Page.formatingData.BlueTeamScoreText = jsonContent.BlueTeamScoreText;
                    InGameView2Page.formatingData.RedTeamText = jsonContent.RedTeamText;
                    InGameView2Page.formatingData.RedTeamScoreText = jsonContent.RedTeamScoreText;
                    InGameView2Page.formatingData.DisplayBlueTeam = jsonContent.DisplayBlueTeam;
                    InGameView2Page.formatingData.DisplayBlueTeamScore = jsonContent.DisplayBlueTeamScore;
                    InGameView2Page.formatingData.DisplayBlueTeamText = jsonContent.DisplayBlueTeamText;
                    InGameView2Page.formatingData.DisplayRedTeam = jsonContent.DisplayRedTeam;
                    InGameView2Page.formatingData.DisplayRedTeamScore = jsonContent.DisplayRedTeamScore;
                    InGameView2Page.formatingData.DisplayRedTeamText = jsonContent.DisplayRedTeamText;
                    InGameView2Page.formatingData.ColorBlueTeamScoreText = jsonContent.ColorBlueTeamScoreText;
                    InGameView2Page.formatingData.ColorBlueTeamText = jsonContent.ColorBlueTeamText;
                    InGameView2Page.formatingData.ColorRedTeamScoreText = jsonContent.ColorRedTeamScoreText;
                    InGameView2Page.formatingData.ColorRedTeamText = jsonContent.ColorRedTeamText;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileInGameView2()", "Configuration View2 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileInGameView2()", "Load view 1 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileInGameView3()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //InGameView3Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //InGameView3Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    InGameView3Page.formatingData.ReplayInfoFrame = jsonContent.ReplayInfoFrame;
                    InGameView3Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
                    InGameView3Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
                    InGameView3Page.formatingData.ReplayInfoText = jsonContent.ReplayInfoText;
                    InGameView3Page.formatingData.ColorReplayInfoText = jsonContent.ColorReplayInfoText;
                    InGameView3Page.formatingData.DisplayReplayInfoFrame = jsonContent.DisplayReplayInfoFrame;
                    InGameView3Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
                    InGameView3Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;


                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileInGameView3()", "Configuration In game View3 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileInGameView3()", "Load In game view 3 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileEndGameView1()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //EndGameView1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //EndGameView1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    EndGameView1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    EndGameView1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    EndGameView1Page.formatingData.BackgroundColor = jsonContent.BackgroundColor;
                    EndGameView1Page.formatingData.BackgroundColorDeg = jsonContent.BackgroundColorDeg;
                    EndGameView1Page.formatingData.BackgroundColorColor1 = jsonContent.BackgroundColorColor1;
                    EndGameView1Page.formatingData.BackgroundColorPercent1 = jsonContent.BackgroundColorPercent1;
                    EndGameView1Page.formatingData.BackgroundColorColor2 = jsonContent.BackgroundColorColor2;
                    EndGameView1Page.formatingData.BackgroundColorPercent2 = jsonContent.BackgroundColorPercent2;
                    EndGameView1Page.formatingData.TopBarBackgroundColor = jsonContent.TopBarBackgroundColor;
                    EndGameView1Page.formatingData.TopBarBackgroundColorDeg = jsonContent.TopBarBackgroundColorDeg;
                    EndGameView1Page.formatingData.TopBarBackgroundColorColor1 = jsonContent.TopBarBackgroundColorColor1;
                    EndGameView1Page.formatingData.TopBarBackgroundColorPercent1 = jsonContent.TopBarBackgroundColorPercent1;
                    EndGameView1Page.formatingData.TopBarBackgroundColorColor2 = jsonContent.TopBarBackgroundColorColor2;
                    EndGameView1Page.formatingData.TopBarBackgroundColorPercent2 = jsonContent.TopBarBackgroundColorPercent2;
                    EndGameView1Page.formatingData.TopBarGradiant = jsonContent.TopBarGradiant;
                    EndGameView1Page.formatingData.TopBarBorderColor = jsonContent.TopBarBorderColor;
                    EndGameView1Page.formatingData.TopBarTimerText = jsonContent.TopBarTimerText;
                    EndGameView1Page.formatingData.TopBarTimerTextColor = jsonContent.TopBarTimerTextColor;
                    EndGameView1Page.formatingData.TopBarTimerColor = jsonContent.TopBarTimerColor;
                    EndGameView1Page.formatingData.TopBarBlueTeamName = jsonContent.TopBarBlueTeamName;
                    EndGameView1Page.formatingData.TopBarBlueTeamNameColor = jsonContent.TopBarBlueTeamNameColor;
                    EndGameView1Page.formatingData.TopBarRedTeamName = jsonContent.TopBarRedTeamName;
                    EndGameView1Page.formatingData.TopBarRedTeamNameColor = jsonContent.TopBarRedTeamNameColor;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColor = jsonContent.ChampionInfoBackgroundColor;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg = jsonContent.ChampionInfoBackgroundColorDeg;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1 = jsonContent.ChampionInfoBackgroundColorColor1;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1 = jsonContent.ChampionInfoBackgroundColorPercent1;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2 = jsonContent.ChampionInfoBackgroundColorColor2;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2 = jsonContent.ChampionInfoBackgroundColorPercent2;
                    EndGameView1Page.formatingData.ChampionInfoGradiant = jsonContent.ChampionInfoGradiant;
                    EndGameView1Page.formatingData.ChampionInfoBorderColor = jsonContent.ChampionInfoBorderColor;
                    EndGameView1Page.formatingData.ChampionInfoText = jsonContent.ChampionInfoText;
                    EndGameView1Page.formatingData.ChampionInfoTextColor = jsonContent.ChampionInfoTextColor;
                    EndGameView1Page.formatingData.ChampionInfoBlueBarColor = jsonContent.ChampionInfoBlueBarColor;
                    EndGameView1Page.formatingData.ChampionInfoRedBarColor = jsonContent.ChampionInfoRedBarColor;
                    EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor = jsonContent.ChampionInfoBlueDegaTextColor;
                    EndGameView1Page.formatingData.ChampionInfoRedDegaTextColor = jsonContent.ChampionInfoRedDegaTextColor;
                    EndGameView1Page.formatingData.BansBackgroundColor = jsonContent.BansBackgroundColor;
                    EndGameView1Page.formatingData.BansBackgroundColorDeg = jsonContent.BansBackgroundColorDeg;
                    EndGameView1Page.formatingData.BansBackgroundColorColor1 = jsonContent.BansBackgroundColorColor1;
                    EndGameView1Page.formatingData.BansBackgroundColorPercent1 = jsonContent.BansBackgroundColorPercent1;
                    EndGameView1Page.formatingData.BansBackgroundColorColor2 = jsonContent.BansBackgroundColorColor2;
                    EndGameView1Page.formatingData.BansBackgroundColorPercent2 = jsonContent.BansBackgroundColorPercent2;
                    EndGameView1Page.formatingData.BansGradiant = jsonContent.BansGradiant;
                    EndGameView1Page.formatingData.BansBorderColor = jsonContent.BansBorderColor;
                    EndGameView1Page.formatingData.BansTextColor = jsonContent.BansTextColor;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColor = jsonContent.GlobalStatsBackgroundColor;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg = jsonContent.GlobalStatsBackgroundColorDeg;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1 = jsonContent.GlobalStatsBackgroundColorColor1;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1 = jsonContent.GlobalStatsBackgroundColorPercent1;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2 = jsonContent.GlobalStatsBackgroundColorColor2;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2 = jsonContent.GlobalStatsBackgroundColorPercent2;
                    EndGameView1Page.formatingData.GlobalStatsGradiant = jsonContent.GlobalStatsGradiant;
                    EndGameView1Page.formatingData.GlobalStatsBorderColor = jsonContent.GlobalStatsBorderColor;
                    EndGameView1Page.formatingData.GlobalStatsTextColor = jsonContent.GlobalStatsTextColor;
                    EndGameView1Page.formatingData.GlobalStatsBlueTextColor = jsonContent.GlobalStatsBlueTextColor;
                    EndGameView1Page.formatingData.GlobalStatsRedTextColor = jsonContent.GlobalStatsRedTextColor;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColor = jsonContent.GoldDiffBackgroundColor;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg = jsonContent.GoldDiffBackgroundColorDeg;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1 = jsonContent.GoldDiffBackgroundColorColor1;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1 = jsonContent.GoldDiffBackgroundColorPercent1;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2 = jsonContent.GoldDiffBackgroundColorColor2;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2 = jsonContent.GoldDiffBackgroundColorPercent2;
                    EndGameView1Page.formatingData.GoldDiffGradiant = jsonContent.GoldDiffGradiant;
                    EndGameView1Page.formatingData.GoldDiffBorderColor = jsonContent.GoldDiffBorderColor;
                    EndGameView1Page.formatingData.GoldDiffText = jsonContent.GoldDiffText;
                    EndGameView1Page.formatingData.GoldDiffTextColor = jsonContent.GoldDiffTextColor;
                    EndGameView1Page.formatingData.GoldDiffBlueTextGoldColor = jsonContent.GoldDiffBlueTextGoldColor;
                    EndGameView1Page.formatingData.GoldDiffRedTextGoldColor = jsonContent.GoldDiffRedTextGoldColor;
                    EndGameView1Page.formatingData.GoldDiffZeroTextGoldColor = jsonContent.GoldDiffZeroTextGoldColor;
                    EndGameView1Page.formatingData.GoldDiffBluePointGoldColor = jsonContent.GoldDiffBluePointGoldColor;
                    EndGameView1Page.formatingData.GoldDiffRedPointGoldColor = jsonContent.GoldDiffRedPointGoldColor;
                    EndGameView1Page.formatingData.GoldDiffZeroPointGoldColor = jsonContent.GoldDiffZeroPointGoldColor;
                    EndGameView1Page.formatingData.GoldDiffStartEndPointGoldColor = jsonContent.GoldDiffStartEndPointGoldColor;
                    EndGameView1Page.formatingData.GoldDiffLinkPointGoldColor = jsonContent.GoldDiffLinkPointGoldColor;
                    EndGameView1Page.formatingData.GoldDiffBarColor = jsonContent.GoldDiffBarColor;
                    EndGameView1Page.formatingData.WinText = jsonContent.WinText;
                    EndGameView1Page.formatingData.LoseText = jsonContent.LoseText;
                    EndGameView1Page.formatingData.ASSISTS = jsonContent.ASSISTS;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = jsonContent.BARRACKS_KILLED;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = jsonContent.CHAMPIONS_KILLED;
                    EndGameView1Page.formatingData.GOLD_EARNED = jsonContent.GOLD_EARNED;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = jsonContent.LARGEST_CRITICAL_STRIKE;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = jsonContent.LARGEST_KILLING_SPREE;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = jsonContent.LARGEST_MULTI_KILL;
                    EndGameView1Page.formatingData.LEVEL = jsonContent.LEVEL;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = jsonContent.MAGIC_DAMAGE_DEALT_PLAYER;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = jsonContent.MAGIC_DAMAGE_TAKEN;
                    EndGameView1Page.formatingData.MINIONS_KILLED = jsonContent.MINIONS_KILLED;
                    EndGameView1Page.formatingData.NUM_DEATHS = jsonContent.NUM_DEATHS;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = jsonContent.PHYSICAL_DAMAGE_DEALT_PLAYER;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = jsonContent.PHYSICAL_DAMAGE_TAKEN;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = jsonContent.TOTAL_DAMAGE_DEALT;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = jsonContent.TOTAL_DAMAGE_DEALT_TO_BUILDINGS;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = jsonContent.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = jsonContent.TOTAL_DAMAGE_DEALT_TO_TURRETS;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = jsonContent.TOTAL_DAMAGE_SELF_MITIGATED;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = jsonContent.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = jsonContent.TOTAL_DAMAGE_TAKEN;
                    EndGameView1Page.formatingData.TOTAL_HEAL = jsonContent.TOTAL_HEAL;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = jsonContent.TOTAL_HEAL_ON_TEAMMATES;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = jsonContent.TOTAL_TIME_CROWD_CONTROL_DEALT;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = jsonContent.TRUE_DAMAGE_DEALT_PLAYER;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TRUE_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = jsonContent.TRUE_DAMAGE_TAKEN;
                    EndGameView1Page.formatingData.TURRETS_KILLED = jsonContent.TURRETS_KILLED;
                    EndGameView1Page.formatingData.VISION_SCORE = jsonContent.VISION_SCORE;
                    EndGameView1Page.formatingData.WARD_KILLED = jsonContent.WARD_KILLED;
                    EndGameView1Page.formatingData.WARD_PLACED = jsonContent.WARD_PLACED;
                    EndGameView1Page.formatingData.TextAssist = jsonContent.TextAssist;
                    EndGameView1Page.formatingData.TextBarracksKilled = jsonContent.TextBarracksKilled;
                    EndGameView1Page.formatingData.TextChampionsKilled = jsonContent.TextChampionsKilled;
                    EndGameView1Page.formatingData.TextGoldEarned = jsonContent.TextGoldEarned;
                    EndGameView1Page.formatingData.TextLargestCriticalStrike = jsonContent.TextLargestCriticalStrike;
                    EndGameView1Page.formatingData.TextLargestKillingSpree = jsonContent.TextLargestKillingSpree;
                    EndGameView1Page.formatingData.TextLargestMultiKill = jsonContent.TextLargestMultiKill;
                    EndGameView1Page.formatingData.TextLevel = jsonContent.TextLevel;
                    EndGameView1Page.formatingData.TextMagicDamageDealtPlayer = jsonContent.TextMagicDamageDealtPlayer;
                    EndGameView1Page.formatingData.TextMagicDamageDealtToChampions = jsonContent.TextMagicDamageDealtToChampions;
                    EndGameView1Page.formatingData.TextMagicDamageTaken = jsonContent.TextMagicDamageTaken;
                    EndGameView1Page.formatingData.TextMinionsKilled = jsonContent.TextMinionsKilled;
                    EndGameView1Page.formatingData.TextNumDeaths = jsonContent.TextNumDeaths;
                    EndGameView1Page.formatingData.TextPhysicalDamageDealtPlayer = jsonContent.TextPhysicalDamageDealtPlayer;
                    EndGameView1Page.formatingData.TextPhysicalDamageDealtToChampions = jsonContent.TextPhysicalDamageDealtToChampions;
                    EndGameView1Page.formatingData.TextPhysicalDamageTaken = jsonContent.TextPhysicalDamageTaken;
                    EndGameView1Page.formatingData.TextTotalDamageDealt = jsonContent.TextTotalDamageDealt;
                    EndGameView1Page.formatingData.TextTotalDamageDealtToBuildings = jsonContent.TextTotalDamageDealtToBuildings;
                    EndGameView1Page.formatingData.TextTotalDamageDealtToChampions = jsonContent.TextTotalDamageDealtToChampions;
                    EndGameView1Page.formatingData.TextTotalDamageDealtToObjectives = jsonContent.TextTotalDamageDealtToObjectives;
                    EndGameView1Page.formatingData.TextTotalDamageDealtToTurrets = jsonContent.TextTotalDamageDealtToTurrets;
                    EndGameView1Page.formatingData.TextTotalDamageSelfMitigated = jsonContent.TextTotalDamageSelfMitigated;
                    EndGameView1Page.formatingData.TextTotalDamageShieldedOnTeammates = jsonContent.TextTotalDamageShieldedOnTeammates;
                    EndGameView1Page.formatingData.TextTotalDamageTaken = jsonContent.TextTotalDamageTaken;
                    EndGameView1Page.formatingData.TextTotalHeal = jsonContent.TextTotalHeal;
                    EndGameView1Page.formatingData.TextTotalHealOnTeammates = jsonContent.TextTotalHealOnTeammates;
                    EndGameView1Page.formatingData.TextTotalTimeCrowdControlDealt = jsonContent.TextTotalTimeCrowdControlDealt;
                    EndGameView1Page.formatingData.TextTrueDamageDealtPlayer = jsonContent.TextTrueDamageDealtPlayer;
                    EndGameView1Page.formatingData.TextTrueDamageDealtToChampions = jsonContent.TextTrueDamageDealtToChampions;
                    EndGameView1Page.formatingData.TextTrueDamageTaken = jsonContent.TextTrueDamageTaken;
                    EndGameView1Page.formatingData.TextTurretsKilled = jsonContent.TextTurretsKilled;
                    EndGameView1Page.formatingData.TextVisionScore = jsonContent.TextVisionScore;
                    EndGameView1Page.formatingData.TextWardKilled = jsonContent.TextWardKilled;
                    EndGameView1Page.formatingData.TextWardPlaced = jsonContent.TextWardPlaced;


                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileEndGameView3()", "Configuration End game View1 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileEndGameView3()", "Load end game View1 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileEndGameView2()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //EndGameView2Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //EndGameView2Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    EndGameView2Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    EndGameView2Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    EndGameView2Page.formatingData.BackgroundColor = jsonContent.BackgroundColor;
                    EndGameView2Page.formatingData.BackgroundColorDeg = jsonContent.BackgroundColorDeg;
                    EndGameView2Page.formatingData.BackgroundColorColor1 = jsonContent.BackgroundColorColor1;
                    EndGameView2Page.formatingData.BackgroundColorPercent1 = jsonContent.BackgroundColorPercent1;
                    EndGameView2Page.formatingData.BackgroundColorColor2 = jsonContent.BackgroundColorColor2;
                    EndGameView2Page.formatingData.BackgroundColorPercent2 = jsonContent.BackgroundColorPercent2;
                    EndGameView2Page.formatingData.TopBarBackgroundColor = jsonContent.TopBarBackgroundColor;
                    EndGameView2Page.formatingData.TopBarBackgroundColorDeg = jsonContent.TopBarBackgroundColorDeg;
                    EndGameView2Page.formatingData.TopBarBackgroundColorColor1 = jsonContent.TopBarBackgroundColorColor1;
                    EndGameView2Page.formatingData.TopBarBackgroundColorPercent1 = jsonContent.TopBarBackgroundColorPercent1;
                    EndGameView2Page.formatingData.TopBarBackgroundColorColor2 = jsonContent.TopBarBackgroundColorColor2;
                    EndGameView2Page.formatingData.TopBarBackgroundColorPercent2 = jsonContent.TopBarBackgroundColorPercent2;
                    EndGameView2Page.formatingData.TopBarGradiant = jsonContent.TopBarGradiant;
                    EndGameView2Page.formatingData.TopBarBorderColor = jsonContent.TopBarBorderColor;
                    EndGameView2Page.formatingData.TopBarTimerText = jsonContent.TopBarTimerText;
                    EndGameView2Page.formatingData.TopBarTimerTextColor = jsonContent.TopBarTimerTextColor;
                    EndGameView2Page.formatingData.TopBarTimerColor = jsonContent.TopBarTimerColor;
                    EndGameView2Page.formatingData.TopBarBlueTeamName = jsonContent.TopBarBlueTeamName;
                    EndGameView2Page.formatingData.TopBarBlueTeamNameColor = jsonContent.TopBarBlueTeamNameColor;
                    EndGameView2Page.formatingData.TopBarRedTeamName = jsonContent.TopBarRedTeamName;
                    EndGameView2Page.formatingData.TopBarRedTeamNameColor = jsonContent.TopBarRedTeamNameColor;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColor = jsonContent.ChampionInfoBackgroundColor;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColorDeg = jsonContent.ChampionInfoBackgroundColorDeg;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1 = jsonContent.ChampionInfoBackgroundColorColor1;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent1 = jsonContent.ChampionInfoBackgroundColorPercent1;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2 = jsonContent.ChampionInfoBackgroundColorColor2;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent2 = jsonContent.ChampionInfoBackgroundColorPercent2;
                    EndGameView2Page.formatingData.ChampionInfoGradiant = jsonContent.ChampionInfoGradiant;
                    EndGameView2Page.formatingData.ChampionInfoBorderColor = jsonContent.ChampionInfoBorderColor;
                    EndGameView2Page.formatingData.ChampionInfoText = jsonContent.ChampionInfoText;
                    EndGameView2Page.formatingData.ChampionInfoTextColor = jsonContent.ChampionInfoTextColor;
                    EndGameView2Page.formatingData.ChampionInfoBlueBarColor = jsonContent.ChampionInfoBlueBarColor;
                    EndGameView2Page.formatingData.ChampionInfoRedBarColor = jsonContent.ChampionInfoRedBarColor;
                    EndGameView2Page.formatingData.ChampionInfoBlueDegaTextColor = jsonContent.ChampionInfoBlueDegaTextColor;
                    EndGameView2Page.formatingData.ChampionInfoRedDegaTextColor = jsonContent.ChampionInfoRedDegaTextColor;
                    EndGameView2Page.formatingData.BansBackgroundColor = jsonContent.BansBackgroundColor;
                    EndGameView2Page.formatingData.BansBackgroundColorDeg = jsonContent.BansBackgroundColorDeg;
                    EndGameView2Page.formatingData.BansBackgroundColorColor1 = jsonContent.BansBackgroundColorColor1;
                    EndGameView2Page.formatingData.BansBackgroundColorPercent1 = jsonContent.BansBackgroundColorPercent1;
                    EndGameView2Page.formatingData.BansBackgroundColorColor2 = jsonContent.BansBackgroundColorColor2;
                    EndGameView2Page.formatingData.BansBackgroundColorPercent2 = jsonContent.BansBackgroundColorPercent2;
                    EndGameView2Page.formatingData.BansGradiant = jsonContent.BansGradiant;
                    EndGameView2Page.formatingData.BansBorderColor = jsonContent.BansBorderColor;
                    EndGameView2Page.formatingData.BansTextColor = jsonContent.BansTextColor;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColor = jsonContent.GlobalStatsBackgroundColor;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColorDeg = jsonContent.GlobalStatsBackgroundColorDeg;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor1 = jsonContent.GlobalStatsBackgroundColorColor1;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent1 = jsonContent.GlobalStatsBackgroundColorPercent1;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2 = jsonContent.GlobalStatsBackgroundColorColor2;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent2 = jsonContent.GlobalStatsBackgroundColorPercent2;
                    EndGameView2Page.formatingData.GlobalStatsGradiant = jsonContent.GlobalStatsGradiant;
                    EndGameView2Page.formatingData.GlobalStatsBorderColor = jsonContent.GlobalStatsBorderColor;
                    EndGameView2Page.formatingData.GlobalStatsTextColor = jsonContent.GlobalStatsTextColor;
                    EndGameView2Page.formatingData.GlobalStatsBlueTextColor = jsonContent.GlobalStatsBlueTextColor;
                    EndGameView2Page.formatingData.GlobalStatsRedTextColor = jsonContent.GlobalStatsRedTextColor;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColor = jsonContent.GoldDiffBackgroundColor;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColorDeg = jsonContent.GoldDiffBackgroundColorDeg;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1 = jsonContent.GoldDiffBackgroundColorColor1;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent1 = jsonContent.GoldDiffBackgroundColorPercent1;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2 = jsonContent.GoldDiffBackgroundColorColor2;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent2 = jsonContent.GoldDiffBackgroundColorPercent2;
                    EndGameView2Page.formatingData.GoldDiffGradiant = jsonContent.GoldDiffGradiant;
                    EndGameView2Page.formatingData.GoldDiffBorderColor = jsonContent.GoldDiffBorderColor;
                    EndGameView2Page.formatingData.GoldDiffText = jsonContent.GoldDiffText;
                    EndGameView2Page.formatingData.GoldDiffTextColor = jsonContent.GoldDiffTextColor;
                    EndGameView2Page.formatingData.WinText = jsonContent.WinText;
                    EndGameView2Page.formatingData.LoseText = jsonContent.LoseText;
                    EndGameView2Page.formatingData.ASSISTS = jsonContent.ASSISTS;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = jsonContent.BARRACKS_KILLED;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = jsonContent.CHAMPIONS_KILLED;
                    EndGameView2Page.formatingData.GOLD_EARNED = jsonContent.GOLD_EARNED;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = jsonContent.LARGEST_CRITICAL_STRIKE;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = jsonContent.LARGEST_KILLING_SPREE;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = jsonContent.LARGEST_MULTI_KILL;
                    EndGameView2Page.formatingData.LEVEL = jsonContent.LEVEL;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = jsonContent.MAGIC_DAMAGE_DEALT_PLAYER;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = jsonContent.MAGIC_DAMAGE_TAKEN;
                    EndGameView2Page.formatingData.MINIONS_KILLED = jsonContent.MINIONS_KILLED;
                    EndGameView2Page.formatingData.NUM_DEATHS = jsonContent.NUM_DEATHS;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = jsonContent.PHYSICAL_DAMAGE_DEALT_PLAYER;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = jsonContent.PHYSICAL_DAMAGE_TAKEN;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = jsonContent.TOTAL_DAMAGE_DEALT;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = jsonContent.TOTAL_DAMAGE_DEALT_TO_BUILDINGS;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = jsonContent.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = jsonContent.TOTAL_DAMAGE_DEALT_TO_TURRETS;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = jsonContent.TOTAL_DAMAGE_SELF_MITIGATED;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = jsonContent.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = jsonContent.TOTAL_DAMAGE_TAKEN;
                    EndGameView2Page.formatingData.TOTAL_HEAL = jsonContent.TOTAL_HEAL;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = jsonContent.TOTAL_HEAL_ON_TEAMMATES;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = jsonContent.TOTAL_TIME_CROWD_CONTROL_DEALT;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = jsonContent.TRUE_DAMAGE_DEALT_PLAYER;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TRUE_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = jsonContent.TRUE_DAMAGE_TAKEN;
                    EndGameView2Page.formatingData.TURRETS_KILLED = jsonContent.TURRETS_KILLED;
                    EndGameView2Page.formatingData.VISION_SCORE = jsonContent.VISION_SCORE;
                    EndGameView2Page.formatingData.WARD_KILLED = jsonContent.WARD_KILLED;
                    EndGameView2Page.formatingData.WARD_PLACED = jsonContent.WARD_PLACED;
                    EndGameView2Page.formatingData.TextAssist = jsonContent.TextAssist;
                    EndGameView2Page.formatingData.TextBarracksKilled = jsonContent.TextBarracksKilled;
                    EndGameView2Page.formatingData.TextChampionsKilled = jsonContent.TextChampionsKilled;
                    EndGameView2Page.formatingData.TextGoldEarned = jsonContent.TextGoldEarned;
                    EndGameView2Page.formatingData.TextLargestCriticalStrike = jsonContent.TextLargestCriticalStrike;
                    EndGameView2Page.formatingData.TextLargestKillingSpree = jsonContent.TextLargestKillingSpree;
                    EndGameView2Page.formatingData.TextLargestMultiKill = jsonContent.TextLargestMultiKill;
                    EndGameView2Page.formatingData.TextLevel = jsonContent.TextLevel;
                    EndGameView2Page.formatingData.TextMagicDamageDealtPlayer = jsonContent.TextMagicDamageDealtPlayer;
                    EndGameView2Page.formatingData.TextMagicDamageDealtToChampions = jsonContent.TextMagicDamageDealtToChampions;
                    EndGameView2Page.formatingData.TextMagicDamageTaken = jsonContent.TextMagicDamageTaken;
                    EndGameView2Page.formatingData.TextMinionsKilled = jsonContent.TextMinionsKilled;
                    EndGameView2Page.formatingData.TextNumDeaths = jsonContent.TextNumDeaths;
                    EndGameView2Page.formatingData.TextPhysicalDamageDealtPlayer = jsonContent.TextPhysicalDamageDealtPlayer;
                    EndGameView2Page.formatingData.TextPhysicalDamageDealtToChampions = jsonContent.TextPhysicalDamageDealtToChampions;
                    EndGameView2Page.formatingData.TextPhysicalDamageTaken = jsonContent.TextPhysicalDamageTaken;
                    EndGameView2Page.formatingData.TextTotalDamageDealt = jsonContent.TextTotalDamageDealt;
                    EndGameView2Page.formatingData.TextTotalDamageDealtToBuildings = jsonContent.TextTotalDamageDealtToBuildings;
                    EndGameView2Page.formatingData.TextTotalDamageDealtToChampions = jsonContent.TextTotalDamageDealtToChampions;
                    EndGameView2Page.formatingData.TextTotalDamageDealtToObjectives = jsonContent.TextTotalDamageDealtToObjectives;
                    EndGameView2Page.formatingData.TextTotalDamageDealtToTurrets = jsonContent.TextTotalDamageDealtToTurrets;
                    EndGameView2Page.formatingData.TextTotalDamageSelfMitigated = jsonContent.TextTotalDamageSelfMitigated;
                    EndGameView2Page.formatingData.TextTotalDamageShieldedOnTeammates = jsonContent.TextTotalDamageShieldedOnTeammates;
                    EndGameView2Page.formatingData.TextTotalDamageTaken = jsonContent.TextTotalDamageTaken;
                    EndGameView2Page.formatingData.TextTotalHeal = jsonContent.TextTotalHeal;
                    EndGameView2Page.formatingData.TextTotalHealOnTeammates = jsonContent.TextTotalHealOnTeammates;
                    EndGameView2Page.formatingData.TextTotalTimeCrowdControlDealt = jsonContent.TextTotalTimeCrowdControlDealt;
                    EndGameView2Page.formatingData.TextTrueDamageDealtPlayer = jsonContent.TextTrueDamageDealtPlayer;
                    EndGameView2Page.formatingData.TextTrueDamageDealtToChampions = jsonContent.TextTrueDamageDealtToChampions;
                    EndGameView2Page.formatingData.TextTrueDamageTaken = jsonContent.TextTrueDamageTaken;
                    EndGameView2Page.formatingData.TextTurretsKilled = jsonContent.TextTurretsKilled;
                    EndGameView2Page.formatingData.TextVisionScore = jsonContent.TextVisionScore;
                    EndGameView2Page.formatingData.TextWardKilled = jsonContent.TextWardKilled;
                    EndGameView2Page.formatingData.TextWardPlaced = jsonContent.TextWardPlaced;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileEndGameView2()", "Configuration End game View2 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileEndGameView2()", "Load end game View2 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileEndGameView3()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //EndGameView3Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //EndGameView3Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    EndGameView3Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    EndGameView3Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    EndGameView3Page.formatingData.BackgroundColor = jsonContent.BackgroundColor;
                    EndGameView3Page.formatingData.BackgroundColorDeg = jsonContent.BackgroundColorDeg;
                    EndGameView3Page.formatingData.BackgroundColorColor1 = jsonContent.BackgroundColorColor1;
                    EndGameView3Page.formatingData.BackgroundColorPercent1 = jsonContent.BackgroundColorPercent1;
                    EndGameView3Page.formatingData.BackgroundColorColor2 = jsonContent.BackgroundColorColor2;
                    EndGameView3Page.formatingData.BackgroundColorPercent2 = jsonContent.BackgroundColorPercent2;
                    EndGameView3Page.formatingData.TopBarBackgroundColor = jsonContent.TopBarBackgroundColor;
                    EndGameView3Page.formatingData.TopBarBackgroundColorDeg = jsonContent.TopBarBackgroundColorDeg;
                    EndGameView3Page.formatingData.TopBarBackgroundColorColor1 = jsonContent.TopBarBackgroundColorColor1;
                    EndGameView3Page.formatingData.TopBarBackgroundColorPercent1 = jsonContent.TopBarBackgroundColorPercent1;
                    EndGameView3Page.formatingData.TopBarBackgroundColorColor2 = jsonContent.TopBarBackgroundColorColor2;
                    EndGameView3Page.formatingData.TopBarBackgroundColorPercent2 = jsonContent.TopBarBackgroundColorPercent2;
                    EndGameView3Page.formatingData.TopBarGradiant = jsonContent.TopBarGradiant;
                    EndGameView3Page.formatingData.TopBarBorderColor = jsonContent.TopBarBorderColor;
                    EndGameView3Page.formatingData.TopBarTimerText = jsonContent.TopBarTimerText;
                    EndGameView3Page.formatingData.TopBarTimerTextColor = jsonContent.TopBarTimerTextColor;
                    EndGameView3Page.formatingData.TopBarTimerColor = jsonContent.TopBarTimerColor;
                    EndGameView3Page.formatingData.TopBarBlueTeamName = jsonContent.TopBarBlueTeamName;
                    EndGameView3Page.formatingData.TopBarBlueTeamNameColor = jsonContent.TopBarBlueTeamNameColor;
                    EndGameView3Page.formatingData.TopBarRedTeamName = jsonContent.TopBarRedTeamName;
                    EndGameView3Page.formatingData.TopBarRedTeamNameColor = jsonContent.TopBarRedTeamNameColor;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColor = jsonContent.ChampionInfoBackgroundColor;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColorDeg = jsonContent.ChampionInfoBackgroundColorDeg;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1 = jsonContent.ChampionInfoBackgroundColorColor1;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent1 = jsonContent.ChampionInfoBackgroundColorPercent1;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2 = jsonContent.ChampionInfoBackgroundColorColor2;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent2 = jsonContent.ChampionInfoBackgroundColorPercent2;
                    EndGameView3Page.formatingData.ChampionInfoGradiant = jsonContent.ChampionInfoGradiant;
                    EndGameView3Page.formatingData.ChampionInfoBorderColor = jsonContent.ChampionInfoBorderColor;
                    EndGameView3Page.formatingData.ChampionInfoText = jsonContent.ChampionInfoText;
                    EndGameView3Page.formatingData.ChampionInfoTextColor = jsonContent.ChampionInfoTextColor;
                    EndGameView3Page.formatingData.ChampionInfoBlueBarColor = jsonContent.ChampionInfoBlueBarColor;
                    EndGameView3Page.formatingData.ChampionInfoRedBarColor = jsonContent.ChampionInfoRedBarColor;
                    EndGameView3Page.formatingData.ChampionInfoBlueDegaTextColor = jsonContent.ChampionInfoBlueDegaTextColor;
                    EndGameView3Page.formatingData.ChampionInfoRedDegaTextColor = jsonContent.ChampionInfoRedDegaTextColor;
                    EndGameView3Page.formatingData.BansBackgroundColor = jsonContent.BansBackgroundColor;
                    EndGameView3Page.formatingData.BansBackgroundColorDeg = jsonContent.BansBackgroundColorDeg;
                    EndGameView3Page.formatingData.BansBackgroundColorColor1 = jsonContent.BansBackgroundColorColor1;
                    EndGameView3Page.formatingData.BansBackgroundColorPercent1 = jsonContent.BansBackgroundColorPercent1;
                    EndGameView3Page.formatingData.BansBackgroundColorColor2 = jsonContent.BansBackgroundColorColor2;
                    EndGameView3Page.formatingData.BansBackgroundColorPercent2 = jsonContent.BansBackgroundColorPercent2;
                    EndGameView3Page.formatingData.BansGradiant = jsonContent.BansGradiant;
                    EndGameView3Page.formatingData.BansBorderColor = jsonContent.BansBorderColor;
                    EndGameView3Page.formatingData.BansTextColor = jsonContent.BansTextColor;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColor = jsonContent.GlobalStatsBackgroundColor;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColorDeg = jsonContent.GlobalStatsBackgroundColorDeg;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor1 = jsonContent.GlobalStatsBackgroundColorColor1;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent1 = jsonContent.GlobalStatsBackgroundColorPercent1;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2 = jsonContent.GlobalStatsBackgroundColorColor2;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent2 = jsonContent.GlobalStatsBackgroundColorPercent2;
                    EndGameView3Page.formatingData.GlobalStatsGradiant = jsonContent.GlobalStatsGradiant;
                    EndGameView3Page.formatingData.GlobalStatsBorderColor = jsonContent.GlobalStatsBorderColor;
                    EndGameView3Page.formatingData.GlobalStatsSeparationColor = jsonContent.GlobalStatsSeparationColor;
                    EndGameView3Page.formatingData.GlobalStatsTextColor = jsonContent.GlobalStatsTextColor;
                    EndGameView3Page.formatingData.GlobalStatsBlueTextColor = jsonContent.GlobalStatsBlueTextColor;
                    EndGameView3Page.formatingData.GlobalStatsRedTextColor = jsonContent.GlobalStatsRedTextColor;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColor = jsonContent.GoldDiffBackgroundColor;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColorDeg = jsonContent.GoldDiffBackgroundColorDeg;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1 = jsonContent.GoldDiffBackgroundColorColor1;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent1 = jsonContent.GoldDiffBackgroundColorPercent1;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2 = jsonContent.GoldDiffBackgroundColorColor2;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent2 = jsonContent.GoldDiffBackgroundColorPercent2;
                    EndGameView3Page.formatingData.GoldDiffGradiant = jsonContent.GoldDiffGradiant;
                    EndGameView3Page.formatingData.GoldDiffBorderColor = jsonContent.GoldDiffBorderColor;
                    EndGameView3Page.formatingData.GoldDiffText = jsonContent.GoldDiffText;
                    EndGameView3Page.formatingData.GoldDiffTextColor = jsonContent.GoldDiffTextColor;
                    EndGameView3Page.formatingData.WinText = jsonContent.WinText;
                    EndGameView3Page.formatingData.LoseText = jsonContent.LoseText;
                    EndGameView3Page.formatingData.ASSISTS = jsonContent.ASSISTS;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = jsonContent.BARRACKS_KILLED;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = jsonContent.CHAMPIONS_KILLED;
                    EndGameView3Page.formatingData.GOLD_EARNED = jsonContent.GOLD_EARNED;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = jsonContent.LARGEST_CRITICAL_STRIKE;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = jsonContent.LARGEST_KILLING_SPREE;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = jsonContent.LARGEST_MULTI_KILL;
                    EndGameView3Page.formatingData.LEVEL = jsonContent.LEVEL;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = jsonContent.MAGIC_DAMAGE_DEALT_PLAYER;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = jsonContent.MAGIC_DAMAGE_TAKEN;
                    EndGameView3Page.formatingData.MINIONS_KILLED = jsonContent.MINIONS_KILLED;
                    EndGameView3Page.formatingData.NUM_DEATHS = jsonContent.NUM_DEATHS;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = jsonContent.PHYSICAL_DAMAGE_DEALT_PLAYER;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = jsonContent.PHYSICAL_DAMAGE_TAKEN;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = jsonContent.TOTAL_DAMAGE_DEALT;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = jsonContent.TOTAL_DAMAGE_DEALT_TO_BUILDINGS;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = jsonContent.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = jsonContent.TOTAL_DAMAGE_DEALT_TO_TURRETS;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = jsonContent.TOTAL_DAMAGE_SELF_MITIGATED;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = jsonContent.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = jsonContent.TOTAL_DAMAGE_TAKEN;
                    EndGameView3Page.formatingData.TOTAL_HEAL = jsonContent.TOTAL_HEAL;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = jsonContent.TOTAL_HEAL_ON_TEAMMATES;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = jsonContent.TOTAL_TIME_CROWD_CONTROL_DEALT;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = jsonContent.TRUE_DAMAGE_DEALT_PLAYER;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TRUE_DAMAGE_DEALT_TO_CHAMPIONS;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = jsonContent.TRUE_DAMAGE_TAKEN;
                    EndGameView3Page.formatingData.TURRETS_KILLED = jsonContent.TURRETS_KILLED;
                    EndGameView3Page.formatingData.VISION_SCORE = jsonContent.VISION_SCORE;
                    EndGameView3Page.formatingData.WARD_KILLED = jsonContent.WARD_KILLED;
                    EndGameView3Page.formatingData.WARD_PLACED = jsonContent.WARD_PLACED;
                    EndGameView3Page.formatingData.TextAssist = jsonContent.TextAssist;
                    EndGameView3Page.formatingData.TextBarracksKilled = jsonContent.TextBarracksKilled;
                    EndGameView3Page.formatingData.TextChampionsKilled = jsonContent.TextChampionsKilled;
                    EndGameView3Page.formatingData.TextGoldEarned = jsonContent.TextGoldEarned;
                    EndGameView3Page.formatingData.TextLargestCriticalStrike = jsonContent.TextLargestCriticalStrike;
                    EndGameView3Page.formatingData.TextLargestKillingSpree = jsonContent.TextLargestKillingSpree;
                    EndGameView3Page.formatingData.TextLargestMultiKill = jsonContent.TextLargestMultiKill;
                    EndGameView3Page.formatingData.TextLevel = jsonContent.TextLevel;
                    EndGameView3Page.formatingData.TextMagicDamageDealtPlayer = jsonContent.TextMagicDamageDealtPlayer;
                    EndGameView3Page.formatingData.TextMagicDamageDealtToChampions = jsonContent.TextMagicDamageDealtToChampions;
                    EndGameView3Page.formatingData.TextMagicDamageTaken = jsonContent.TextMagicDamageTaken;
                    EndGameView3Page.formatingData.TextMinionsKilled = jsonContent.TextMinionsKilled;
                    EndGameView3Page.formatingData.TextNumDeaths = jsonContent.TextNumDeaths;
                    EndGameView3Page.formatingData.TextPhysicalDamageDealtPlayer = jsonContent.TextPhysicalDamageDealtPlayer;
                    EndGameView3Page.formatingData.TextPhysicalDamageDealtToChampions = jsonContent.TextPhysicalDamageDealtToChampions;
                    EndGameView3Page.formatingData.TextPhysicalDamageTaken = jsonContent.TextPhysicalDamageTaken;
                    EndGameView3Page.formatingData.TextTotalDamageDealt = jsonContent.TextTotalDamageDealt;
                    EndGameView3Page.formatingData.TextTotalDamageDealtToBuildings = jsonContent.TextTotalDamageDealtToBuildings;
                    EndGameView3Page.formatingData.TextTotalDamageDealtToChampions = jsonContent.TextTotalDamageDealtToChampions;
                    EndGameView3Page.formatingData.TextTotalDamageDealtToObjectives = jsonContent.TextTotalDamageDealtToObjectives;
                    EndGameView3Page.formatingData.TextTotalDamageDealtToTurrets = jsonContent.TextTotalDamageDealtToTurrets;
                    EndGameView3Page.formatingData.TextTotalDamageSelfMitigated = jsonContent.TextTotalDamageSelfMitigated;
                    EndGameView3Page.formatingData.TextTotalDamageShieldedOnTeammates = jsonContent.TextTotalDamageShieldedOnTeammates;
                    EndGameView3Page.formatingData.TextTotalDamageTaken = jsonContent.TextTotalDamageTaken;
                    EndGameView3Page.formatingData.TextTotalHeal = jsonContent.TextTotalHeal;
                    EndGameView3Page.formatingData.TextTotalHealOnTeammates = jsonContent.TextTotalHealOnTeammates;
                    EndGameView3Page.formatingData.TextTotalTimeCrowdControlDealt = jsonContent.TextTotalTimeCrowdControlDealt;
                    EndGameView3Page.formatingData.TextTrueDamageDealtPlayer = jsonContent.TextTrueDamageDealtPlayer;
                    EndGameView3Page.formatingData.TextTrueDamageDealtToChampions = jsonContent.TextTrueDamageDealtToChampions;
                    EndGameView3Page.formatingData.TextTrueDamageTaken = jsonContent.TextTrueDamageTaken;
                    EndGameView3Page.formatingData.TextTurretsKilled = jsonContent.TextTurretsKilled;
                    EndGameView3Page.formatingData.TextVisionScore = jsonContent.TextVisionScore;
                    EndGameView3Page.formatingData.TextWardKilled = jsonContent.TextWardKilled;
                    EndGameView3Page.formatingData.TextWardPlaced = jsonContent.TextWardPlaced;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileEndGameView3()", "Configuration End game View3 Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileEndGameView3()", "Load end game View3 error : " + e.Message);
                }
            }
        }

        private async Task LoadFileRunesAdc()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //RunesAdcPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //RunesAdcPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    RunesAdcPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    RunesAdcPage.formatingData.BackgroudGradientDeg = jsonContent.BackgroudGradientDeg;
                    RunesAdcPage.formatingData.BackgroudGradientColor1 = jsonContent.BackgroudGradientColor1;
                    RunesAdcPage.formatingData.BackgroudGradientPercent1 = jsonContent.BackgroudGradientPercent1;
                    RunesAdcPage.formatingData.BackgroudGradientColor2 = jsonContent.BackgroudGradientColor2;
                    RunesAdcPage.formatingData.BackgroudGradientPercent2 = jsonContent.BackgroudGradientPercent2;
                    RunesAdcPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    RunesAdcPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
                    RunesAdcPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
                    RunesAdcPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
                    RunesAdcPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
                    RunesAdcPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
                    RunesAdcPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
                    RunesAdcPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
                    RunesAdcPage.formatingData.LanePicture = jsonContent.LanePicture;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileRunesAdc()", "Configuration Runes Adc Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileRunesAdc()", "Load Runes Adc error : " + e.Message);
                }
            }
        }
        private async Task LoadFileRunesAdcSupp()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //RunesAdcSuppPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //RunesAdcSuppPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    RunesAdcSuppPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    RunesAdcSuppPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    RunesAdcSuppPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
                    RunesAdcSuppPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
                    RunesAdcSuppPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
                    RunesAdcSuppPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
                    RunesAdcSuppPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
                    RunesAdcSuppPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
                    RunesAdcSuppPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
                    RunesAdcSuppPage.formatingData.LanePictureAdc = jsonContent.LanePictureAdc;
                    RunesAdcSuppPage.formatingData.LanePictureSupp = jsonContent.LanePictureSupp;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileRunesAdcSupp()", "Configuration Runes AdcSupp Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileRunesAdcSupp()", "Load Runes AdcSupp error : " + e.Message);
                }
            }
        }
        private async Task LoadFileRunesJungle()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //RunesJunglePage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //RunesJunglePage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    RunesJunglePage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    RunesJunglePage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    RunesJunglePage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
                    RunesJunglePage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
                    RunesJunglePage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
                    RunesJunglePage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
                    RunesJunglePage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
                    RunesJunglePage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
                    RunesJunglePage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
                    RunesJunglePage.formatingData.LanePicture = jsonContent.LanePicture;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileRunesJungle()", "Configuration Runes Jungle Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileRunesJungle()", "Load Runes Jungle error : " + e.Message);
                }
            }
        }
        private async Task LoadFileRunesMid()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //RunesMidPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //RunesMidPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    RunesMidPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    RunesMidPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    RunesMidPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
                    RunesMidPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
                    RunesMidPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
                    RunesMidPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
                    RunesMidPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
                    RunesMidPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
                    RunesMidPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
                    RunesMidPage.formatingData.LanePicture = jsonContent.LanePicture;

                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileRunesMid()", "Configuration Runes Mid Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileRunesMid()", "Load Runes Mid error : " + e.Message);
                }
            }
        }
        private async Task LoadFileRunesSupp()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //RunesSuppPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //RunesSuppPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    RunesSuppPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    RunesSuppPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    RunesSuppPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
                    RunesSuppPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
                    RunesSuppPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
                    RunesSuppPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
                    RunesSuppPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
                    RunesSuppPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
                    RunesSuppPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
                    RunesSuppPage.formatingData.LanePicture = jsonContent.LanePicture;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileRunesSupp()", "Configuration Runes Supp Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileRunesSupp()", "Load Runes Supp error : " + e.Message);
                }
            }
        }
        private async Task LoadFileRunesTop()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //RunesTopPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //RunesTopPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    RunesTopPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    RunesTopPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    RunesTopPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
                    RunesTopPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
                    RunesTopPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
                    RunesTopPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
                    RunesTopPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
                    RunesTopPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
                    RunesTopPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
                    RunesTopPage.formatingData.LanePicture = jsonContent.LanePicture;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileRunesTop()", "Configuration Runes Top Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileRunesTop()", "Load Runes Top error : " + e.Message);
                }
            }
        }

        private async Task LoadFileRunesAll()
        {
            if (fileSelected is not null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    await fileSelected.OpenReadStream().CopyToAsync(ms);
                    string content = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    dynamic jsonContent = JsonConvert.DeserializeObject(content);
                    //RunesAllPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
                    //RunesAllPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
                    RunesAllPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
                    RunesAllPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
                    RunesAllPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
                    RunesAllPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
                    RunesAllPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
                    RunesAllPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
                    RunesAllPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
                    RunesAllPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
                    RunesAllPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
                    RunesAllPage.formatingData.LanePictureAdc = jsonContent.LanePictureAdc;
                    RunesAllPage.formatingData.LanePictureSupp = jsonContent.LanePictureSupp;
                    RunesAllPage.formatingData.LanePictureTop = jsonContent.LanePictureTop;
                    RunesAllPage.formatingData.LanePictureMid = jsonContent.LanePictureMid;
                    RunesAllPage.formatingData.LanePictureJungle = jsonContent.LanePictureJungle;
                    fileSelected = null;
                    StateHasChanged();
                    _logger.log(LoggingLevel.INFO, "LoadFileRunesAll()", "Configuration Runes all Loaded");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "LoadFileRunesAll()", "Load Runes all error : " + e.Message);
                }
            }
        }


        public string GenerateConfigFileChampSelectView1()
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
        private string GenerateConfigFileChampSelectView2()
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
        private string GenerateConfigFileChampSelectView3()
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
        private string GenerateConfigFileChampSelectView4()
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

        private string GenerateConfigFileInGameView1()
        {
            try
            {
                var data = new InGameView1Page.FormatingData
                {
                    DefaultPatch = InGameView1Page.formatingData.DefaultPatch,
                    DefaultRegion = InGameView1Page.formatingData.DefaultRegion,
                    BluePlayerFrame = InGameView1Page.formatingData.BluePlayerFrame,
                    RedPlayerFrame = InGameView1Page.formatingData.RedPlayerFrame,
                    DragonTimerFrame = InGameView1Page.formatingData.DragonTimerFrame,
                    HeraldBaronTimerFrame = InGameView1Page.formatingData.HeraldBaronTimerFrame,
                    LeftInfoFrame = InGameView1Page.formatingData.LeftInfoFrame,
                    RightInfoFrame = InGameView1Page.formatingData.RightInfoFrame,
                    DisplayDragonTimer = InGameView1Page.formatingData.DisplayDragonTimer,
                    DisplayHeraldBaronTimer = InGameView1Page.formatingData.DisplayHeraldBaronTimer,
                    DisplayBluePlayerFrame = InGameView1Page.formatingData.DisplayBluePlayerFrame,
                    DisplayRedPlayerFrame = InGameView1Page.formatingData.DisplayRedPlayerFrame,
                    DisplayLeftInfo = InGameView1Page.formatingData.DisplayLeftInfo,
                    DisplayRightInfo = InGameView1Page.formatingData.DisplayRightInfo,
                    TeamBanner = InGameView1Page.formatingData.TeamBanner,
                    TeamScoreBanner = InGameView1Page.formatingData.TeamScoreBanner,
                    BlueTeamText = InGameView1Page.formatingData.BlueTeamText,
                    BlueTeamScoreText = InGameView1Page.formatingData.BlueTeamScoreText,
                    RedTeamText = InGameView1Page.formatingData.RedTeamText,
                    RedTeamScoreText = InGameView1Page.formatingData.RedTeamScoreText,
                    DisplayBlueTeam = InGameView1Page.formatingData.DisplayBlueTeam,
                    DisplayBlueTeamScore = InGameView1Page.formatingData.DisplayBlueTeamScore,
                    DisplayBlueTeamText = InGameView1Page.formatingData.DisplayBlueTeamText,
                    DisplayRedTeam = InGameView1Page.formatingData.DisplayRedTeam,
                    DisplayRedTeamScore = InGameView1Page.formatingData.DisplayRedTeamScore,
                    DisplayRedTeamText = InGameView1Page.formatingData.DisplayRedTeamText,
                    ColorBlueTeamScoreText = InGameView1Page.formatingData.ColorBlueTeamScoreText,
                    ColorBlueTeamText = InGameView1Page.formatingData.ColorBlueTeamText,
                    ColorRedTeamScoreText = InGameView1Page.formatingData.ColorRedTeamScoreText,
                    ColorRedTeamText = InGameView1Page.formatingData.ColorRedTeamText,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/ingame/configInGameView1.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileInGameView1()", "Generation ok");
                return "/assets/ingame/configInGameView1.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileInGameView1()", "Error generation old version recive : " + e.Message);
                return "/assets/ingame/configInGameView1.json";
            }
        }

        private string GenerateConfigFileInGameView1_1()
        {
            try
            {
                var data = new InGameView1_1Page.FormatingData
                {
                    DefaultPatch = InGameView1_1Page.formatingData.DefaultPatch,
                    DefaultRegion = InGameView1_1Page.formatingData.DefaultRegion,
                    BluePlayerFrame = InGameView1_1Page.formatingData.BluePlayerFrame,
                    RedPlayerFrame = InGameView1_1Page.formatingData.RedPlayerFrame,
                    DragonTimerFrame = InGameView1_1Page.formatingData.DragonTimerFrame,
                    HeraldBaronTimerFrame = InGameView1_1Page.formatingData.HeraldBaronTimerFrame,
                    LeftInfoFrame = InGameView1_1Page.formatingData.LeftInfoFrame,
                    RightInfoFrame = InGameView1_1Page.formatingData.RightInfoFrame,
                    DisplayDragonTimer = InGameView1_1Page.formatingData.DisplayDragonTimer,
                    DisplayHeraldBaronTimer = InGameView1_1Page.formatingData.DisplayHeraldBaronTimer,
                    DisplayBluePlayerFrame = InGameView1_1Page.formatingData.DisplayBluePlayerFrame,
                    DisplayRedPlayerFrame = InGameView1_1Page.formatingData.DisplayRedPlayerFrame,
                    DisplayLeftInfo = InGameView1_1Page.formatingData.DisplayLeftInfo,
                    DisplayRightInfo = InGameView1_1Page.formatingData.DisplayRightInfo,
                    TeamBanner = InGameView1_1Page.formatingData.TeamBanner,
                    TeamScoreBanner = InGameView1_1Page.formatingData.TeamScoreBanner,
                    BlueTeamText = InGameView1_1Page.formatingData.BlueTeamText,
                    BlueTeamScoreText = InGameView1_1Page.formatingData.BlueTeamScoreText,
                    RedTeamText = InGameView1_1Page.formatingData.RedTeamText,
                    RedTeamScoreText = InGameView1_1Page.formatingData.RedTeamScoreText,
                    DisplayBlueTeam = InGameView1_1Page.formatingData.DisplayBlueTeam,
                    DisplayBlueTeamScore = InGameView1_1Page.formatingData.DisplayBlueTeamScore,
                    DisplayBlueTeamText = InGameView1_1Page.formatingData.DisplayBlueTeamText,
                    DisplayRedTeam = InGameView1_1Page.formatingData.DisplayRedTeam,
                    DisplayRedTeamScore = InGameView1_1Page.formatingData.DisplayRedTeamScore,
                    DisplayRedTeamText = InGameView1_1Page.formatingData.DisplayRedTeamText,
                    ColorBlueTeamScoreText = InGameView1_1Page.formatingData.ColorBlueTeamScoreText,
                    ColorBlueTeamText = InGameView1_1Page.formatingData.ColorBlueTeamText,
                    ColorRedTeamScoreText = InGameView1_1Page.formatingData.ColorRedTeamScoreText,
                    ColorRedTeamText = InGameView1_1Page.formatingData.ColorRedTeamText,
                    DisplayItems = InGameView1_1Page.formatingData.DisplayItems,
                    DisplayLevels = InGameView1_1Page.formatingData.DisplayLevels,
                    DisplayDragonKill = InGameView1_1Page.formatingData.DisplayDragonKill,
                    DisplayInhibKill = InGameView1_1Page.formatingData.DisplayInhibKill,
                    DisplayBaronElderBuff = InGameView1_1Page.formatingData.DisplayBaronElderBuff,

                    PictureOrderDragonBanner = InGameView1_1Page.formatingData.PictureOrderDragonBanner,
                    PictureChaosDragonBanner = InGameView1_1Page.formatingData.PictureChaosDragonBanner ,
                    ElderDragonIcon = InGameView1_1Page.formatingData.ElderDragonIcon ,
                    HeraldIcon = InGameView1_1Page.formatingData.HeraldIcon ,
                    BaronIcon = InGameView1_1Page.formatingData.BaronIcon ,
                    PositionOrderTop = InGameView1_1Page.formatingData.PositionOrderTop ,
                    PositionChaosTop = InGameView1_1Page.formatingData.PositionChaosTop ,
                    PositionOrderJungle = InGameView1_1Page.formatingData.PositionOrderJungle ,
                    PositionChaosJungle = InGameView1_1Page.formatingData.PositionChaosJungle ,
                    PositionOrderMid = InGameView1_1Page.formatingData.PositionOrderMid ,
                    PositionChaosMid = InGameView1_1Page.formatingData.PositionChaosMid ,
                    PositionOrderBottom = InGameView1_1Page.formatingData.PositionOrderBottom ,
                    PositionChaosBottom = InGameView1_1Page.formatingData.PositionChaosBottom ,
                    PositionOrderSupport = InGameView1_1Page.formatingData.PositionOrderSupport ,
                    PositionChaosSupport = InGameView1_1Page.formatingData.PositionChaosSupport ,
                    InhibIcon = InGameView1_1Page.formatingData.InhibIcon ,
                    BaronBuffIcon = InGameView1_1Page.formatingData.BaronBuffIcon ,
                    ElderBuffIcon = InGameView1_1Page.formatingData.ElderBuffIcon ,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/ingame/configInGameView1_1.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileInGameView1_1()", "Generation ok");
                return "/assets/ingame/configInGameView1_1.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileInGameView1_1()", "Error generation old version recive : " + e.Message);
                return "/assets/ingame/configInGameView1_1.json";
            }
        }

        private string GenerateConfigFileInGameView2()
        {
            try
            {
                var data = new InGameView2Page.FormatingData
                {
                    DefaultPatch = InGameView2Page.formatingData.DefaultPatch,
                    DefaultRegion = InGameView2Page.formatingData.DefaultRegion,
                    BluePlayerFrame = InGameView2Page.formatingData.BluePlayerFrame,
                    RedPlayerFrame = InGameView2Page.formatingData.RedPlayerFrame,
                    DragonTimerFrame = InGameView2Page.formatingData.DragonTimerFrame,
                    HeraldBaronTimerFrame = InGameView2Page.formatingData.HeraldBaronTimerFrame,
                    LeftInfoFrame = InGameView2Page.formatingData.LeftInfoFrame,
                    DisplayDragonTimer = InGameView2Page.formatingData.DisplayDragonTimer,
                    DisplayHeraldBaronTimer = InGameView2Page.formatingData.DisplayHeraldBaronTimer,
                    DisplayBluePlayerFrame = InGameView2Page.formatingData.DisplayBluePlayerFrame,
                    DisplayRedPlayerFrame = InGameView2Page.formatingData.DisplayRedPlayerFrame,
                    DisplayLeftInfo = InGameView2Page.formatingData.DisplayLeftInfo,
                    TeamBanner = InGameView2Page.formatingData.TeamBanner,
                    TeamScoreBanner = InGameView2Page.formatingData.TeamScoreBanner,
                    BlueTeamText = InGameView2Page.formatingData.BlueTeamText,
                    BlueTeamScoreText = InGameView2Page.formatingData.BlueTeamScoreText,
                    RedTeamText = InGameView2Page.formatingData.RedTeamText,
                    RedTeamScoreText = InGameView2Page.formatingData.RedTeamScoreText,
                    DisplayBlueTeam = InGameView2Page.formatingData.DisplayBlueTeam,
                    DisplayBlueTeamScore = InGameView2Page.formatingData.DisplayBlueTeamScore,
                    DisplayBlueTeamText = InGameView2Page.formatingData.DisplayBlueTeamText,
                    DisplayRedTeam = InGameView2Page.formatingData.DisplayRedTeam,
                    DisplayRedTeamScore = InGameView2Page.formatingData.DisplayRedTeamScore,
                    DisplayRedTeamText = InGameView2Page.formatingData.DisplayRedTeamText,
                    ColorBlueTeamScoreText = InGameView2Page.formatingData.ColorBlueTeamScoreText,
                    ColorBlueTeamText = InGameView2Page.formatingData.ColorBlueTeamText,
                    ColorRedTeamScoreText = InGameView2Page.formatingData.ColorRedTeamScoreText,
                    ColorRedTeamText = InGameView2Page.formatingData.ColorRedTeamText,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/ingame/configInGameView2.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileInGameView2()", "Generation ok");
                return "/assets/ingame/configInGameView2.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileInGameView2()", "Error generation old version recive : " + e.Message);
                return "/assets/ingame/configInGameView2.json";
            }
        }

        private string GenerateConfigFileInGameView3()
        {
            try
            {
                var data = new InGameView3Page.FormatingData
                {
                    DefaultPatch = InGameView3Page.formatingData.DefaultPatch,
                    DefaultRegion = InGameView3Page.formatingData.DefaultRegion,
                    ReplayInfoFrame = InGameView3Page.formatingData.ReplayInfoFrame,
                    BluePlayerFrame = InGameView3Page.formatingData.BluePlayerFrame,
                    RedPlayerFrame = InGameView3Page.formatingData.RedPlayerFrame,
                    ReplayInfoText = InGameView3Page.formatingData.ReplayInfoText,
                    ColorReplayInfoText = InGameView3Page.formatingData.ColorReplayInfoText,
                    DisplayReplayInfoFrame = InGameView3Page.formatingData.DisplayReplayInfoFrame,
                    DisplayBluePlayerFrame = InGameView3Page.formatingData.DisplayBluePlayerFrame,
                    DisplayRedPlayerFrame = InGameView3Page.formatingData.DisplayRedPlayerFrame,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/ingame/configInGameView3.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileInGameView3()", "Generation ok");
                return "/assets/ingame/configInGameView3.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileInGameView3()", "Error generation old version recive : " + e.Message);
                return "/assets/ingame/configInGameView3.json";
            }
        }

        private string GenerateConfigFileEndGameView1()
        {
            try
            {
                var data = new EndGameView1Page.FormatingData
                {
                    DefaultPatch = EndGameView1Page.formatingData.DefaultPatch,
                    DefaultRegion = EndGameView1Page.formatingData.DefaultRegion,
                    BackgroundColor = EndGameView1Page.formatingData.BackgroundColor,
                    BackgroundColorDeg = EndGameView1Page.formatingData.BackgroundColorDeg,
                    BackgroundColorColor1 = EndGameView1Page.formatingData.BackgroundColorColor1,
                    BackgroundColorPercent1 = EndGameView1Page.formatingData.BackgroundColorPercent1,
                    BackgroundColorColor2 = EndGameView1Page.formatingData.BackgroundColorColor2,
                    BackgroundColorPercent2 = EndGameView1Page.formatingData.BackgroundColorPercent2,
                    TopBarBackgroundColor = EndGameView1Page.formatingData.TopBarBackgroundColor,
                    TopBarBackgroundColorDeg = EndGameView1Page.formatingData.TopBarBackgroundColorDeg,
                    TopBarBackgroundColorColor1 = EndGameView1Page.formatingData.TopBarBackgroundColorColor1,
                    TopBarBackgroundColorPercent1 = EndGameView1Page.formatingData.TopBarBackgroundColorPercent1,
                    TopBarBackgroundColorColor2 = EndGameView1Page.formatingData.TopBarBackgroundColorColor2,
                    TopBarBackgroundColorPercent2 = EndGameView1Page.formatingData.TopBarBackgroundColorPercent2,
                    TopBarGradiant = EndGameView1Page.formatingData.TopBarGradiant,
                    TopBarBorderColor = EndGameView1Page.formatingData.TopBarBorderColor,
                    TopBarTimerText = EndGameView1Page.formatingData.TopBarTimerText,
                    TopBarTimerTextColor = EndGameView1Page.formatingData.TopBarTimerTextColor,
                    TopBarTimerColor = EndGameView1Page.formatingData.TopBarTimerColor,
                    TopBarBlueTeamName = EndGameView1Page.formatingData.TopBarBlueTeamName,
                    TopBarBlueTeamScore = EndGameView1Page.formatingData.TopBarBlueTeamScore,
                    TopBarBlueTeamNameColor = EndGameView1Page.formatingData.TopBarBlueTeamNameColor,
                    TopBarBlueTeamScoreColor = EndGameView1Page.formatingData.TopBarBlueTeamScoreColor,
                    TopBarBlueTeamWinLossColor = EndGameView1Page.formatingData.TopBarBlueTeamWinLossColor,
                    TopBarRedTeamName = EndGameView1Page.formatingData.TopBarRedTeamName,
                    TopBarRedTeamScore = EndGameView1Page.formatingData.TopBarRedTeamScore,
                    TopBarRedTeamNameColor = EndGameView1Page.formatingData.TopBarRedTeamNameColor,
                    TopBarRedTeamScoreColor = EndGameView1Page.formatingData.TopBarRedTeamScoreColor,
                    TopBarRedTeamWinLossColor = EndGameView1Page.formatingData.TopBarRedTeamWinLossColor,
                    ChampionInfoBackgroundColor = EndGameView1Page.formatingData.ChampionInfoBackgroundColor,
                    ChampionInfoBackgroundColorDeg = EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg,
                    ChampionInfoBackgroundColorColor1 = EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1,
                    ChampionInfoBackgroundColorPercent1 = EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1,
                    ChampionInfoBackgroundColorColor2 = EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2,
                    ChampionInfoBackgroundColorPercent2 = EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2,
                    ChampionInfoGradiant = EndGameView1Page.formatingData.ChampionInfoGradiant,
                    ChampionInfoBorderColor = EndGameView1Page.formatingData.ChampionInfoBorderColor,
                    ChampionInfoText = EndGameView1Page.formatingData.ChampionInfoText,
                    ChampionInfoTextColor = EndGameView1Page.formatingData.ChampionInfoTextColor,
                    ChampionInfoBlueBarColor = EndGameView1Page.formatingData.ChampionInfoBlueBarColor,
                    ChampionInfoRedBarColor = EndGameView1Page.formatingData.ChampionInfoRedBarColor,
                    ChampionInfoBlueDegaTextColor = EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor,
                    ChampionInfoRedDegaTextColor = EndGameView1Page.formatingData.ChampionInfoRedDegaTextColor,
                    BansBackgroundColor = EndGameView1Page.formatingData.BansBackgroundColor,
                    BansBackgroundColorDeg = EndGameView1Page.formatingData.BansBackgroundColorDeg,
                    BansBackgroundColorColor1 = EndGameView1Page.formatingData.BansBackgroundColorColor1,
                    BansBackgroundColorPercent1 = EndGameView1Page.formatingData.BansBackgroundColorPercent1,
                    BansBackgroundColorColor2 = EndGameView1Page.formatingData.BansBackgroundColorColor2,
                    BansBackgroundColorPercent2 = EndGameView1Page.formatingData.BansBackgroundColorPercent2,
                    BansGradiant = EndGameView1Page.formatingData.BansGradiant,
                    BansBorderColor = EndGameView1Page.formatingData.BansBorderColor,
                    BansTextColor = EndGameView1Page.formatingData.BansTextColor,
                    GlobalStatsBackgroundColor = EndGameView1Page.formatingData.GlobalStatsBackgroundColor,
                    GlobalStatsBackgroundColorDeg = EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg,
                    GlobalStatsBackgroundColorColor1 = EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1,
                    GlobalStatsBackgroundColorPercent1 = EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1,
                    GlobalStatsBackgroundColorColor2 = EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2,
                    GlobalStatsBackgroundColorPercent2 = EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2,
                    GlobalStatsGradiant = EndGameView1Page.formatingData.GlobalStatsGradiant,
                    GlobalStatsBorderColor = EndGameView1Page.formatingData.GlobalStatsBorderColor,
                    GlobalStatsTextColor = EndGameView1Page.formatingData.GlobalStatsTextColor,
                    GlobalStatsBlueTextColor = EndGameView1Page.formatingData.GlobalStatsBlueTextColor,
                    GlobalStatsRedTextColor = EndGameView1Page.formatingData.GlobalStatsRedTextColor,
                    GoldDiffBackgroundColor = EndGameView1Page.formatingData.GoldDiffBackgroundColor,
                    GoldDiffBackgroundColorDeg = EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg,
                    GoldDiffBackgroundColorColor1 = EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1,
                    GoldDiffBackgroundColorPercent1 = EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1,
                    GoldDiffBackgroundColorColor2 = EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2,
                    GoldDiffBackgroundColorPercent2 = EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2,
                    GoldDiffGradiant = EndGameView1Page.formatingData.GoldDiffGradiant,
                    GoldDiffBorderColor = EndGameView1Page.formatingData.GoldDiffBorderColor,
                    GoldDiffText = EndGameView1Page.formatingData.GoldDiffText,
                    GoldDiffTextColor = EndGameView1Page.formatingData.GoldDiffTextColor,
                    GoldDiffBlueTextGoldColor = EndGameView1Page.formatingData.GoldDiffBlueTextGoldColor,
                    GoldDiffRedTextGoldColor = EndGameView1Page.formatingData.GoldDiffRedTextGoldColor,
                    GoldDiffZeroTextGoldColor = EndGameView1Page.formatingData.GoldDiffZeroTextGoldColor,
                    GoldDiffBluePointGoldColor = EndGameView1Page.formatingData.GoldDiffBluePointGoldColor,
                    GoldDiffRedPointGoldColor = EndGameView1Page.formatingData.GoldDiffRedPointGoldColor,
                    GoldDiffZeroPointGoldColor = EndGameView1Page.formatingData.GoldDiffZeroPointGoldColor,
                    GoldDiffStartEndPointGoldColor = EndGameView1Page.formatingData.GoldDiffStartEndPointGoldColor,
                    GoldDiffLinkPointGoldColor = EndGameView1Page.formatingData.GoldDiffLinkPointGoldColor,
                    GoldDiffBarColor = EndGameView1Page.formatingData.GoldDiffBarColor,
                    WinText = EndGameView1Page.formatingData.WinText,
                    LoseText = EndGameView1Page.formatingData.LoseText,
                    ASSISTS = EndGameView1Page.formatingData.ASSISTS,
                    BARRACKS_KILLED = EndGameView1Page.formatingData.BARRACKS_KILLED,
                    CHAMPIONS_KILLED = EndGameView1Page.formatingData.CHAMPIONS_KILLED,
                    GOLD_EARNED = EndGameView1Page.formatingData.GOLD_EARNED,
                    LARGEST_CRITICAL_STRIKE = EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE,
                    LARGEST_KILLING_SPREE = EndGameView1Page.formatingData.LARGEST_KILLING_SPREE,
                    LARGEST_MULTI_KILL = EndGameView1Page.formatingData.LARGEST_MULTI_KILL,
                    LEVEL = EndGameView1Page.formatingData.LEVEL,
                    MAGIC_DAMAGE_DEALT_PLAYER = EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER,
                    MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS,
                    MAGIC_DAMAGE_TAKEN = EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN,
                    MINIONS_KILLED = EndGameView1Page.formatingData.MINIONS_KILLED,
                    NUM_DEATHS = EndGameView1Page.formatingData.NUM_DEATHS,
                    PHYSICAL_DAMAGE_DEALT_PLAYER = EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER,
                    PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS,
                    PHYSICAL_DAMAGE_TAKEN = EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN,
                    TOTAL_DAMAGE_DEALT = EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT,
                    TOTAL_DAMAGE_DEALT_TO_BUILDINGS = EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS,
                    TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS,
                    TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES,
                    TOTAL_DAMAGE_DEALT_TO_TURRETS = EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS,
                    TOTAL_DAMAGE_SELF_MITIGATED = EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED,
                    TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES,
                    TOTAL_DAMAGE_TAKEN = EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN,
                    TOTAL_HEAL = EndGameView1Page.formatingData.TOTAL_HEAL,
                    TOTAL_HEAL_ON_TEAMMATES = EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES,
                    TOTAL_TIME_CROWD_CONTROL_DEALT = EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT,
                    TRUE_DAMAGE_DEALT_PLAYER = EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER,
                    TRUE_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS,
                    TRUE_DAMAGE_TAKEN = EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN,
                    TURRETS_KILLED = EndGameView1Page.formatingData.TURRETS_KILLED,
                    VISION_SCORE = EndGameView1Page.formatingData.VISION_SCORE,
                    WARD_KILLED = EndGameView1Page.formatingData.WARD_KILLED,
                    WARD_PLACED = EndGameView1Page.formatingData.WARD_PLACED,
                    TextAssist = EndGameView1Page.formatingData.TextAssist,
                    TextBarracksKilled = EndGameView1Page.formatingData.TextBarracksKilled,
                    TextChampionsKilled = EndGameView1Page.formatingData.TextChampionsKilled,
                    TextGoldEarned = EndGameView1Page.formatingData.TextGoldEarned,
                    TextLargestCriticalStrike = EndGameView1Page.formatingData.TextLargestCriticalStrike,
                    TextLargestKillingSpree = EndGameView1Page.formatingData.TextLargestKillingSpree,
                    TextLargestMultiKill = EndGameView1Page.formatingData.TextLargestMultiKill,
                    TextLevel = EndGameView1Page.formatingData.TextLevel,
                    TextMagicDamageDealtPlayer = EndGameView1Page.formatingData.TextMagicDamageDealtPlayer,
                    TextMagicDamageDealtToChampions = EndGameView1Page.formatingData.TextMagicDamageDealtToChampions,
                    TextMagicDamageTaken = EndGameView1Page.formatingData.TextMagicDamageTaken,
                    TextMinionsKilled = EndGameView1Page.formatingData.TextMinionsKilled,
                    TextNumDeaths = EndGameView1Page.formatingData.TextNumDeaths,
                    TextPhysicalDamageDealtPlayer = EndGameView1Page.formatingData.TextPhysicalDamageDealtPlayer,
                    TextPhysicalDamageDealtToChampions = EndGameView1Page.formatingData.TextPhysicalDamageDealtToChampions,
                    TextPhysicalDamageTaken = EndGameView1Page.formatingData.TextPhysicalDamageTaken,
                    TextTotalDamageDealt = EndGameView1Page.formatingData.TextTotalDamageDealt,
                    TextTotalDamageDealtToBuildings = EndGameView1Page.formatingData.TextTotalDamageDealtToBuildings,
                    TextTotalDamageDealtToChampions = EndGameView1Page.formatingData.TextTotalDamageDealtToChampions,
                    TextTotalDamageDealtToObjectives = EndGameView1Page.formatingData.TextTotalDamageDealtToObjectives,
                    TextTotalDamageDealtToTurrets = EndGameView1Page.formatingData.TextTotalDamageDealtToTurrets,
                    TextTotalDamageSelfMitigated = EndGameView1Page.formatingData.TextTotalDamageSelfMitigated,
                    TextTotalDamageShieldedOnTeammates = EndGameView1Page.formatingData.TextTotalDamageShieldedOnTeammates,
                    TextTotalDamageTaken = EndGameView1Page.formatingData.TextTotalDamageTaken,
                    TextTotalHeal = EndGameView1Page.formatingData.TextTotalHeal,
                    TextTotalHealOnTeammates = EndGameView1Page.formatingData.TextTotalHealOnTeammates,
                    TextTotalTimeCrowdControlDealt = EndGameView1Page.formatingData.TextTotalTimeCrowdControlDealt,
                    TextTrueDamageDealtPlayer = EndGameView1Page.formatingData.TextTrueDamageDealtPlayer,
                    TextTrueDamageDealtToChampions = EndGameView1Page.formatingData.TextTrueDamageDealtToChampions,
                    TextTrueDamageTaken = EndGameView1Page.formatingData.TextTrueDamageTaken,
                    TextTurretsKilled = EndGameView1Page.formatingData.TextTurretsKilled,
                    TextVisionScore = EndGameView1Page.formatingData.TextVisionScore,
                    TextWardKilled = EndGameView1Page.formatingData.TextWardKilled,
                    TextWardPlaced = EndGameView1Page.formatingData.TextWardPlaced,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/endgame/configEndGameView1.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileEndGameView1()", "Generation ok");
                return "/assets/endgame/configEndGameView1.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileEndGameView1()", "Error generation old version recive : " + e.Message);
                return "/assets/endgame/configEndGameView1.json";
            }
        }

        private string GenerateConfigFileEndGameView2()
        {
            try
            {
                var data = new EndGameView2Page.FormatingData
                {
                    DefaultPatch = EndGameView2Page.formatingData.DefaultPatch,
                    DefaultRegion = EndGameView2Page.formatingData.DefaultRegion,
                    BackgroundColor = EndGameView2Page.formatingData.BackgroundColor,
                    BackgroundColorDeg = EndGameView2Page.formatingData.BackgroundColorDeg,
                    BackgroundColorColor1 = EndGameView2Page.formatingData.BackgroundColorColor1,
                    BackgroundColorPercent1 = EndGameView2Page.formatingData.BackgroundColorPercent1,
                    BackgroundColorColor2 = EndGameView2Page.formatingData.BackgroundColorColor2,
                    BackgroundColorPercent2 = EndGameView2Page.formatingData.BackgroundColorPercent2,
                    TopBarBackgroundColor = EndGameView2Page.formatingData.TopBarBackgroundColor,
                    TopBarBackgroundColorDeg = EndGameView2Page.formatingData.TopBarBackgroundColorDeg,
                    TopBarBackgroundColorColor1 = EndGameView2Page.formatingData.TopBarBackgroundColorColor1,
                    TopBarBackgroundColorPercent1 = EndGameView2Page.formatingData.TopBarBackgroundColorPercent1,
                    TopBarBackgroundColorColor2 = EndGameView2Page.formatingData.TopBarBackgroundColorColor2,
                    TopBarBackgroundColorPercent2 = EndGameView2Page.formatingData.TopBarBackgroundColorPercent2,
                    TopBarGradiant = EndGameView2Page.formatingData.TopBarGradiant,
                    TopBarBorderColor = EndGameView2Page.formatingData.TopBarBorderColor,
                    TopBarTimerText = EndGameView2Page.formatingData.TopBarTimerText,
                    TopBarTimerTextColor = EndGameView2Page.formatingData.TopBarTimerTextColor,
                    TopBarTimerColor = EndGameView2Page.formatingData.TopBarTimerColor,
                    TopBarBlueTeamName = EndGameView2Page.formatingData.TopBarBlueTeamName,
                    TopBarBlueTeamScore = EndGameView2Page.formatingData.TopBarBlueTeamScore,
                    TopBarBlueTeamNameColor = EndGameView2Page.formatingData.TopBarBlueTeamNameColor,
                    TopBarBlueTeamScoreColor = EndGameView2Page.formatingData.TopBarBlueTeamScoreColor,
                    TopBarBlueTeamWinLossColor = EndGameView2Page.formatingData.TopBarBlueTeamWinLossColor,
                    TopBarRedTeamName = EndGameView2Page.formatingData.TopBarRedTeamName,
                    TopBarRedTeamScore = EndGameView2Page.formatingData.TopBarRedTeamScore,
                    TopBarRedTeamNameColor = EndGameView2Page.formatingData.TopBarRedTeamNameColor,
                    TopBarRedTeamScoreColor = EndGameView2Page.formatingData.TopBarRedTeamScoreColor,
                    TopBarRedTeamWinLossColor = EndGameView2Page.formatingData.TopBarRedTeamWinLossColor,
                    ChampionInfoBackgroundColor = EndGameView2Page.formatingData.ChampionInfoBackgroundColor,
                    ChampionInfoBackgroundColorDeg = EndGameView2Page.formatingData.ChampionInfoBackgroundColorDeg,
                    ChampionInfoBackgroundColorColor1 = EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1,
                    ChampionInfoBackgroundColorPercent1 = EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent1,
                    ChampionInfoBackgroundColorColor2 = EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2,
                    ChampionInfoBackgroundColorPercent2 = EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent2,
                    ChampionInfoGradiant = EndGameView2Page.formatingData.ChampionInfoGradiant,
                    ChampionInfoBorderColor = EndGameView2Page.formatingData.ChampionInfoBorderColor,
                    ChampionInfoText = EndGameView2Page.formatingData.ChampionInfoText,
                    ChampionInfoTextColor = EndGameView2Page.formatingData.ChampionInfoTextColor,
                    ChampionInfoBlueBarColor = EndGameView2Page.formatingData.ChampionInfoBlueBarColor,
                    ChampionInfoRedBarColor = EndGameView2Page.formatingData.ChampionInfoRedBarColor,
                    ChampionInfoBlueDegaTextColor = EndGameView2Page.formatingData.ChampionInfoBlueDegaTextColor,
                    ChampionInfoRedDegaTextColor = EndGameView2Page.formatingData.ChampionInfoRedDegaTextColor,
                    BansBackgroundColor = EndGameView2Page.formatingData.BansBackgroundColor,
                    BansBackgroundColorDeg = EndGameView2Page.formatingData.BansBackgroundColorDeg,
                    BansBackgroundColorColor1 = EndGameView2Page.formatingData.BansBackgroundColorColor1,
                    BansBackgroundColorPercent1 = EndGameView2Page.formatingData.BansBackgroundColorPercent1,
                    BansBackgroundColorColor2 = EndGameView2Page.formatingData.BansBackgroundColorColor2,
                    BansBackgroundColorPercent2 = EndGameView2Page.formatingData.BansBackgroundColorPercent2,
                    BansGradiant = EndGameView2Page.formatingData.BansGradiant,
                    BansBorderColor = EndGameView2Page.formatingData.BansBorderColor,
                    BansTextColor = EndGameView2Page.formatingData.BansTextColor,
                    GlobalStatsBackgroundColor = EndGameView2Page.formatingData.GlobalStatsBackgroundColor,
                    GlobalStatsBackgroundColorDeg = EndGameView2Page.formatingData.GlobalStatsBackgroundColorDeg,
                    GlobalStatsBackgroundColorColor1 = EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor1,
                    GlobalStatsBackgroundColorPercent1 = EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent1,
                    GlobalStatsBackgroundColorColor2 = EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2,
                    GlobalStatsBackgroundColorPercent2 = EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent2,
                    GlobalStatsGradiant = EndGameView2Page.formatingData.GlobalStatsGradiant,
                    GlobalStatsBorderColor = EndGameView2Page.formatingData.GlobalStatsBorderColor,
                    GlobalStatsTextColor = EndGameView2Page.formatingData.GlobalStatsTextColor,
                    GlobalStatsBlueTextColor = EndGameView2Page.formatingData.GlobalStatsBlueTextColor,
                    GlobalStatsRedTextColor = EndGameView2Page.formatingData.GlobalStatsRedTextColor,
                    GoldDiffBackgroundColor = EndGameView2Page.formatingData.GoldDiffBackgroundColor,
                    GoldDiffBackgroundColorDeg = EndGameView2Page.formatingData.GoldDiffBackgroundColorDeg,
                    GoldDiffBackgroundColorColor1 = EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1,
                    GoldDiffBackgroundColorPercent1 = EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent1,
                    GoldDiffBackgroundColorColor2 = EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2,
                    GoldDiffBackgroundColorPercent2 = EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent2,
                    GoldDiffGradiant = EndGameView2Page.formatingData.GoldDiffGradiant,
                    GoldDiffBorderColor = EndGameView2Page.formatingData.GoldDiffBorderColor,
                    GoldDiffText = EndGameView2Page.formatingData.GoldDiffText,
                    GoldDiffTextColor = EndGameView2Page.formatingData.GoldDiffTextColor,
                    GoldDiffBlueTextGoldColor = EndGameView2Page.formatingData.GoldDiffBlueTextGoldColor,
                    GoldDiffRedTextGoldColor = EndGameView2Page.formatingData.GoldDiffRedTextGoldColor,
                    GoldDiffZeroTextGoldColor = EndGameView2Page.formatingData.GoldDiffZeroTextGoldColor,
                    GoldDiffBluePointGoldColor = EndGameView2Page.formatingData.GoldDiffBluePointGoldColor,
                    GoldDiffRedPointGoldColor = EndGameView2Page.formatingData.GoldDiffRedPointGoldColor,
                    GoldDiffZeroPointGoldColor = EndGameView2Page.formatingData.GoldDiffZeroPointGoldColor,
                    GoldDiffStartEndPointGoldColor = EndGameView2Page.formatingData.GoldDiffStartEndPointGoldColor,
                    GoldDiffLinkPointGoldColor = EndGameView2Page.formatingData.GoldDiffLinkPointGoldColor,
                    GoldDiffBarColor = EndGameView2Page.formatingData.GoldDiffBarColor,
                    WinText = EndGameView2Page.formatingData.WinText,
                    LoseText = EndGameView2Page.formatingData.LoseText,
                    ASSISTS = EndGameView2Page.formatingData.ASSISTS,
                    BARRACKS_KILLED = EndGameView2Page.formatingData.BARRACKS_KILLED,
                    CHAMPIONS_KILLED = EndGameView2Page.formatingData.CHAMPIONS_KILLED,
                    GOLD_EARNED = EndGameView2Page.formatingData.GOLD_EARNED,
                    LARGEST_CRITICAL_STRIKE = EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE,
                    LARGEST_KILLING_SPREE = EndGameView2Page.formatingData.LARGEST_KILLING_SPREE,
                    LARGEST_MULTI_KILL = EndGameView2Page.formatingData.LARGEST_MULTI_KILL,
                    LEVEL = EndGameView2Page.formatingData.LEVEL,
                    MAGIC_DAMAGE_DEALT_PLAYER = EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER,
                    MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS,
                    MAGIC_DAMAGE_TAKEN = EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN,
                    MINIONS_KILLED = EndGameView2Page.formatingData.MINIONS_KILLED,
                    NUM_DEATHS = EndGameView2Page.formatingData.NUM_DEATHS,
                    PHYSICAL_DAMAGE_DEALT_PLAYER = EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER,
                    PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS,
                    PHYSICAL_DAMAGE_TAKEN = EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN,
                    TOTAL_DAMAGE_DEALT = EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT,
                    TOTAL_DAMAGE_DEALT_TO_BUILDINGS = EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS,
                    TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS,
                    TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES,
                    TOTAL_DAMAGE_DEALT_TO_TURRETS = EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS,
                    TOTAL_DAMAGE_SELF_MITIGATED = EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED,
                    TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES,
                    TOTAL_DAMAGE_TAKEN = EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN,
                    TOTAL_HEAL = EndGameView2Page.formatingData.TOTAL_HEAL,
                    TOTAL_HEAL_ON_TEAMMATES = EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES,
                    TOTAL_TIME_CROWD_CONTROL_DEALT = EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT,
                    TRUE_DAMAGE_DEALT_PLAYER = EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER,
                    TRUE_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS,
                    TRUE_DAMAGE_TAKEN = EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN,
                    TURRETS_KILLED = EndGameView2Page.formatingData.TURRETS_KILLED,
                    VISION_SCORE = EndGameView2Page.formatingData.VISION_SCORE,
                    WARD_KILLED = EndGameView2Page.formatingData.WARD_KILLED,
                    WARD_PLACED = EndGameView2Page.formatingData.WARD_PLACED,
                    TextAssist = EndGameView2Page.formatingData.TextAssist,
                    TextBarracksKilled = EndGameView2Page.formatingData.TextBarracksKilled,
                    TextChampionsKilled = EndGameView2Page.formatingData.TextChampionsKilled,
                    TextGoldEarned = EndGameView2Page.formatingData.TextGoldEarned,
                    TextLargestCriticalStrike = EndGameView2Page.formatingData.TextLargestCriticalStrike,
                    TextLargestKillingSpree = EndGameView2Page.formatingData.TextLargestKillingSpree,
                    TextLargestMultiKill = EndGameView2Page.formatingData.TextLargestMultiKill,
                    TextLevel = EndGameView2Page.formatingData.TextLevel,
                    TextMagicDamageDealtPlayer = EndGameView2Page.formatingData.TextMagicDamageDealtPlayer,
                    TextMagicDamageDealtToChampions = EndGameView2Page.formatingData.TextMagicDamageDealtToChampions,
                    TextMagicDamageTaken = EndGameView2Page.formatingData.TextMagicDamageTaken,
                    TextMinionsKilled = EndGameView2Page.formatingData.TextMinionsKilled,
                    TextNumDeaths = EndGameView2Page.formatingData.TextNumDeaths,
                    TextPhysicalDamageDealtPlayer = EndGameView2Page.formatingData.TextPhysicalDamageDealtPlayer,
                    TextPhysicalDamageDealtToChampions = EndGameView2Page.formatingData.TextPhysicalDamageDealtToChampions,
                    TextPhysicalDamageTaken = EndGameView2Page.formatingData.TextPhysicalDamageTaken,
                    TextTotalDamageDealt = EndGameView2Page.formatingData.TextTotalDamageDealt,
                    TextTotalDamageDealtToBuildings = EndGameView2Page.formatingData.TextTotalDamageDealtToBuildings,
                    TextTotalDamageDealtToChampions = EndGameView2Page.formatingData.TextTotalDamageDealtToChampions,
                    TextTotalDamageDealtToObjectives = EndGameView2Page.formatingData.TextTotalDamageDealtToObjectives,
                    TextTotalDamageDealtToTurrets = EndGameView2Page.formatingData.TextTotalDamageDealtToTurrets,
                    TextTotalDamageSelfMitigated = EndGameView2Page.formatingData.TextTotalDamageSelfMitigated,
                    TextTotalDamageShieldedOnTeammates = EndGameView2Page.formatingData.TextTotalDamageShieldedOnTeammates,
                    TextTotalDamageTaken = EndGameView2Page.formatingData.TextTotalDamageTaken,
                    TextTotalHeal = EndGameView2Page.formatingData.TextTotalHeal,
                    TextTotalHealOnTeammates = EndGameView2Page.formatingData.TextTotalHealOnTeammates,
                    TextTotalTimeCrowdControlDealt = EndGameView2Page.formatingData.TextTotalTimeCrowdControlDealt,
                    TextTrueDamageDealtPlayer = EndGameView2Page.formatingData.TextTrueDamageDealtPlayer,
                    TextTrueDamageDealtToChampions = EndGameView2Page.formatingData.TextTrueDamageDealtToChampions,
                    TextTrueDamageTaken = EndGameView2Page.formatingData.TextTrueDamageTaken,
                    TextTurretsKilled = EndGameView2Page.formatingData.TextTurretsKilled,
                    TextVisionScore = EndGameView2Page.formatingData.TextVisionScore,
                    TextWardKilled = EndGameView2Page.formatingData.TextWardKilled,
                    TextWardPlaced = EndGameView2Page.formatingData.TextWardPlaced,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/endgame/configEndGameView2.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileEndGameView2()", "Generation ok");
                return "/assets/endgame/configEndGameView2.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileEndGameView2()", "Error generation old version recive : " + e.Message);
                return "/assets/endgame/configEndGameView2.json";
            }
        }

        private string GenerateConfigFileEndGameView3()
        {
            try
            {
                var data = new EndGameView3Page.FormatingData
                {
                    DefaultPatch = EndGameView3Page.formatingData.DefaultPatch,
                    DefaultRegion = EndGameView3Page.formatingData.DefaultRegion,
                    BackgroundColor = EndGameView3Page.formatingData.BackgroundColor,
                    BackgroundColorDeg = EndGameView3Page.formatingData.BackgroundColorDeg,
                    BackgroundColorColor1 = EndGameView3Page.formatingData.BackgroundColorColor1,
                    BackgroundColorPercent1 = EndGameView3Page.formatingData.BackgroundColorPercent1,
                    BackgroundColorColor2 = EndGameView3Page.formatingData.BackgroundColorColor2,
                    BackgroundColorPercent2 = EndGameView3Page.formatingData.BackgroundColorPercent2,
                    TopBarBackgroundColor = EndGameView3Page.formatingData.TopBarBackgroundColor,
                    TopBarBackgroundColorDeg = EndGameView3Page.formatingData.TopBarBackgroundColorDeg,
                    TopBarBackgroundColorColor1 = EndGameView3Page.formatingData.TopBarBackgroundColorColor1,
                    TopBarBackgroundColorPercent1 = EndGameView3Page.formatingData.TopBarBackgroundColorPercent1,
                    TopBarBackgroundColorColor2 = EndGameView3Page.formatingData.TopBarBackgroundColorColor2,
                    TopBarBackgroundColorPercent2 = EndGameView3Page.formatingData.TopBarBackgroundColorPercent2,
                    TopBarGradiant = EndGameView3Page.formatingData.TopBarGradiant,
                    TopBarBorderColor = EndGameView3Page.formatingData.TopBarBorderColor,
                    TopBarTimerText = EndGameView3Page.formatingData.TopBarTimerText,
                    TopBarTimerTextColor = EndGameView3Page.formatingData.TopBarTimerTextColor,
                    TopBarTimerColor = EndGameView3Page.formatingData.TopBarTimerColor,
                    TopBarBlueTeamName = EndGameView3Page.formatingData.TopBarBlueTeamName,
                    TopBarBlueTeamScore = EndGameView3Page.formatingData.TopBarBlueTeamScore,
                    TopBarBlueTeamNameColor = EndGameView3Page.formatingData.TopBarBlueTeamNameColor,
                    TopBarBlueTeamScoreColor = EndGameView3Page.formatingData.TopBarBlueTeamScoreColor,
                    TopBarBlueTeamWinLossColor = EndGameView3Page.formatingData.TopBarBlueTeamWinLossColor,
                    TopBarRedTeamName = EndGameView3Page.formatingData.TopBarRedTeamName,
                    TopBarRedTeamScore = EndGameView3Page.formatingData.TopBarRedTeamScore,
                    TopBarRedTeamNameColor = EndGameView3Page.formatingData.TopBarRedTeamNameColor,
                    TopBarRedTeamScoreColor = EndGameView3Page.formatingData.TopBarRedTeamScoreColor,
                    TopBarRedTeamWinLossColor = EndGameView3Page.formatingData.TopBarRedTeamWinLossColor,
                    ChampionInfoBackgroundColor = EndGameView3Page.formatingData.ChampionInfoBackgroundColor,
                    ChampionInfoBackgroundColorDeg = EndGameView3Page.formatingData.ChampionInfoBackgroundColorDeg,
                    ChampionInfoBackgroundColorColor1 = EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1,
                    ChampionInfoBackgroundColorPercent1 = EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent1,
                    ChampionInfoBackgroundColorColor2 = EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2,
                    ChampionInfoBackgroundColorPercent2 = EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent2,
                    ChampionInfoGradiant = EndGameView3Page.formatingData.ChampionInfoGradiant,
                    ChampionInfoBorderColor = EndGameView3Page.formatingData.ChampionInfoBorderColor,
                    ChampionInfoText = EndGameView3Page.formatingData.ChampionInfoText,
                    ChampionInfoTextColor = EndGameView3Page.formatingData.ChampionInfoTextColor,
                    ChampionInfoBlueBarColor = EndGameView3Page.formatingData.ChampionInfoBlueBarColor,
                    ChampionInfoRedBarColor = EndGameView3Page.formatingData.ChampionInfoRedBarColor,
                    ChampionInfoBlueDegaTextColor = EndGameView3Page.formatingData.ChampionInfoBlueDegaTextColor,
                    ChampionInfoRedDegaTextColor = EndGameView3Page.formatingData.ChampionInfoRedDegaTextColor,
                    BansBackgroundColor = EndGameView3Page.formatingData.BansBackgroundColor,
                    BansBackgroundColorDeg = EndGameView3Page.formatingData.BansBackgroundColorDeg,
                    BansBackgroundColorColor1 = EndGameView3Page.formatingData.BansBackgroundColorColor1,
                    BansBackgroundColorPercent1 = EndGameView3Page.formatingData.BansBackgroundColorPercent1,
                    BansBackgroundColorColor2 = EndGameView3Page.formatingData.BansBackgroundColorColor2,
                    BansBackgroundColorPercent2 = EndGameView3Page.formatingData.BansBackgroundColorPercent2,
                    BansGradiant = EndGameView3Page.formatingData.BansGradiant,
                    BansBorderColor = EndGameView3Page.formatingData.BansBorderColor,
                    BansTextColor = EndGameView3Page.formatingData.BansTextColor,
                    GlobalStatsBackgroundColor = EndGameView3Page.formatingData.GlobalStatsBackgroundColor,
                    GlobalStatsBackgroundColorDeg = EndGameView3Page.formatingData.GlobalStatsBackgroundColorDeg,
                    GlobalStatsBackgroundColorColor1 = EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor1,
                    GlobalStatsBackgroundColorPercent1 = EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent1,
                    GlobalStatsBackgroundColorColor2 = EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2,
                    GlobalStatsBackgroundColorPercent2 = EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent2,
                    GlobalStatsGradiant = EndGameView3Page.formatingData.GlobalStatsGradiant,
                    GlobalStatsBorderColor = EndGameView3Page.formatingData.GlobalStatsBorderColor,
                    GlobalStatsSeparationColor = EndGameView3Page.formatingData.GlobalStatsSeparationColor,
                    GlobalStatsTextColor = EndGameView3Page.formatingData.GlobalStatsTextColor,
                    GlobalStatsBlueTextColor = EndGameView3Page.formatingData.GlobalStatsBlueTextColor,
                    GlobalStatsRedTextColor = EndGameView3Page.formatingData.GlobalStatsRedTextColor,
                    GoldDiffBackgroundColor = EndGameView3Page.formatingData.GoldDiffBackgroundColor,
                    GoldDiffBackgroundColorDeg = EndGameView3Page.formatingData.GoldDiffBackgroundColorDeg,
                    GoldDiffBackgroundColorColor1 = EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1,
                    GoldDiffBackgroundColorPercent1 = EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent1,
                    GoldDiffBackgroundColorColor2 = EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2,
                    GoldDiffBackgroundColorPercent2 = EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent2,
                    GoldDiffGradiant = EndGameView3Page.formatingData.GoldDiffGradiant,
                    GoldDiffBorderColor = EndGameView3Page.formatingData.GoldDiffBorderColor,
                    GoldDiffText = EndGameView3Page.formatingData.GoldDiffText,
                    GoldDiffTextColor = EndGameView3Page.formatingData.GoldDiffTextColor,
                    GoldDiffBlueTextGoldColor = EndGameView3Page.formatingData.GoldDiffBlueTextGoldColor,
                    GoldDiffRedTextGoldColor = EndGameView3Page.formatingData.GoldDiffRedTextGoldColor,
                    GoldDiffZeroTextGoldColor = EndGameView3Page.formatingData.GoldDiffZeroTextGoldColor,
                    GoldDiffBluePointGoldColor = EndGameView3Page.formatingData.GoldDiffBluePointGoldColor,
                    GoldDiffRedPointGoldColor = EndGameView3Page.formatingData.GoldDiffRedPointGoldColor,
                    GoldDiffZeroPointGoldColor = EndGameView3Page.formatingData.GoldDiffZeroPointGoldColor,
                    GoldDiffStartEndPointGoldColor = EndGameView3Page.formatingData.GoldDiffStartEndPointGoldColor,
                    GoldDiffLinkPointGoldColor = EndGameView3Page.formatingData.GoldDiffLinkPointGoldColor,
                    GoldDiffBarColor = EndGameView3Page.formatingData.GoldDiffBarColor,
                    WinText = EndGameView3Page.formatingData.WinText,
                    LoseText = EndGameView3Page.formatingData.LoseText,
                    ASSISTS = EndGameView3Page.formatingData.ASSISTS,
                    BARRACKS_KILLED = EndGameView3Page.formatingData.BARRACKS_KILLED,
                    CHAMPIONS_KILLED = EndGameView3Page.formatingData.CHAMPIONS_KILLED,
                    GOLD_EARNED = EndGameView3Page.formatingData.GOLD_EARNED,
                    LARGEST_CRITICAL_STRIKE = EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE,
                    LARGEST_KILLING_SPREE = EndGameView3Page.formatingData.LARGEST_KILLING_SPREE,
                    LARGEST_MULTI_KILL = EndGameView3Page.formatingData.LARGEST_MULTI_KILL,
                    LEVEL = EndGameView3Page.formatingData.LEVEL,
                    MAGIC_DAMAGE_DEALT_PLAYER = EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER,
                    MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS,
                    MAGIC_DAMAGE_TAKEN = EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN,
                    MINIONS_KILLED = EndGameView3Page.formatingData.MINIONS_KILLED,
                    NUM_DEATHS = EndGameView3Page.formatingData.NUM_DEATHS,
                    PHYSICAL_DAMAGE_DEALT_PLAYER = EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER,
                    PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS,
                    PHYSICAL_DAMAGE_TAKEN = EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN,
                    TOTAL_DAMAGE_DEALT = EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT,
                    TOTAL_DAMAGE_DEALT_TO_BUILDINGS = EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS,
                    TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS,
                    TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES,
                    TOTAL_DAMAGE_DEALT_TO_TURRETS = EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS,
                    TOTAL_DAMAGE_SELF_MITIGATED = EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED,
                    TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES,
                    TOTAL_DAMAGE_TAKEN = EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN,
                    TOTAL_HEAL = EndGameView3Page.formatingData.TOTAL_HEAL,
                    TOTAL_HEAL_ON_TEAMMATES = EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES,
                    TOTAL_TIME_CROWD_CONTROL_DEALT = EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT,
                    TRUE_DAMAGE_DEALT_PLAYER = EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER,
                    TRUE_DAMAGE_DEALT_TO_CHAMPIONS = EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS,
                    TRUE_DAMAGE_TAKEN = EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN,
                    TURRETS_KILLED = EndGameView3Page.formatingData.TURRETS_KILLED,
                    VISION_SCORE = EndGameView3Page.formatingData.VISION_SCORE,
                    WARD_KILLED = EndGameView3Page.formatingData.WARD_KILLED,
                    WARD_PLACED = EndGameView3Page.formatingData.WARD_PLACED,
                    TextAssist = EndGameView3Page.formatingData.TextAssist,
                    TextBarracksKilled = EndGameView3Page.formatingData.TextBarracksKilled,
                    TextChampionsKilled = EndGameView3Page.formatingData.TextChampionsKilled,
                    TextGoldEarned = EndGameView3Page.formatingData.TextGoldEarned,
                    TextLargestCriticalStrike = EndGameView3Page.formatingData.TextLargestCriticalStrike,
                    TextLargestKillingSpree = EndGameView3Page.formatingData.TextLargestKillingSpree,
                    TextLargestMultiKill = EndGameView3Page.formatingData.TextLargestMultiKill,
                    TextLevel = EndGameView3Page.formatingData.TextLevel,
                    TextMagicDamageDealtPlayer = EndGameView3Page.formatingData.TextMagicDamageDealtPlayer,
                    TextMagicDamageDealtToChampions = EndGameView3Page.formatingData.TextMagicDamageDealtToChampions,
                    TextMagicDamageTaken = EndGameView3Page.formatingData.TextMagicDamageTaken,
                    TextMinionsKilled = EndGameView3Page.formatingData.TextMinionsKilled,
                    TextNumDeaths = EndGameView3Page.formatingData.TextNumDeaths,
                    TextPhysicalDamageDealtPlayer = EndGameView3Page.formatingData.TextPhysicalDamageDealtPlayer,
                    TextPhysicalDamageDealtToChampions = EndGameView3Page.formatingData.TextPhysicalDamageDealtToChampions,
                    TextPhysicalDamageTaken = EndGameView3Page.formatingData.TextPhysicalDamageTaken,
                    TextTotalDamageDealt = EndGameView3Page.formatingData.TextTotalDamageDealt,
                    TextTotalDamageDealtToBuildings = EndGameView3Page.formatingData.TextTotalDamageDealtToBuildings,
                    TextTotalDamageDealtToChampions = EndGameView3Page.formatingData.TextTotalDamageDealtToChampions,
                    TextTotalDamageDealtToObjectives = EndGameView3Page.formatingData.TextTotalDamageDealtToObjectives,
                    TextTotalDamageDealtToTurrets = EndGameView3Page.formatingData.TextTotalDamageDealtToTurrets,
                    TextTotalDamageSelfMitigated = EndGameView3Page.formatingData.TextTotalDamageSelfMitigated,
                    TextTotalDamageShieldedOnTeammates = EndGameView3Page.formatingData.TextTotalDamageShieldedOnTeammates,
                    TextTotalDamageTaken = EndGameView3Page.formatingData.TextTotalDamageTaken,
                    TextTotalHeal = EndGameView3Page.formatingData.TextTotalHeal,
                    TextTotalHealOnTeammates = EndGameView3Page.formatingData.TextTotalHealOnTeammates,
                    TextTotalTimeCrowdControlDealt = EndGameView3Page.formatingData.TextTotalTimeCrowdControlDealt,
                    TextTrueDamageDealtPlayer = EndGameView3Page.formatingData.TextTrueDamageDealtPlayer,
                    TextTrueDamageDealtToChampions = EndGameView3Page.formatingData.TextTrueDamageDealtToChampions,
                    TextTrueDamageTaken = EndGameView3Page.formatingData.TextTrueDamageTaken,
                    TextTurretsKilled = EndGameView3Page.formatingData.TextTurretsKilled,
                    TextVisionScore = EndGameView3Page.formatingData.TextVisionScore,
                    TextWardKilled = EndGameView3Page.formatingData.TextWardKilled,
                    TextWardPlaced = EndGameView3Page.formatingData.TextWardPlaced,
                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/endgame/configEndGameView3.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileEndGameView3()", "Generation ok");
                return "/assets/endgame/configEndGameView3.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileEndGameView3()", "Error generation old version recive : " + e.Message);
                return "/assets/endgame/configEndGameView3.json";
            }
        }

        private string GenerateConfigFileRuneAdc()
        {
            try
            {
                var data = new RunesAdcPage.FormatingData
                {
                    DefaultPatch = RunesAdcPage.formatingData.DefaultPatch,
                    DefaultRegion = RunesAdcPage.formatingData.DefaultRegion,
                    BackgroudGradient = RunesAdcPage.formatingData.BackgroudGradient,
                    BackgroudGradientDeg = RunesAdcPage.formatingData.BackgroudGradientDeg,
                    BackgroudGradientColor1 = RunesAdcPage.formatingData.BackgroudGradientColor1,
                    BackgroudGradientPercent1 = RunesAdcPage.formatingData.BackgroudGradientPercent1,
                    BackgroudGradientColor2 = RunesAdcPage.formatingData.BackgroudGradientColor2,
                    BackgroudGradientPercent2 = RunesAdcPage.formatingData.BackgroudGradientPercent2,
                    OverlayColorBackgroudGradient = RunesAdcPage.formatingData.OverlayColorBackgroudGradient,
                    BlueSideColorTextSummoner = RunesAdcPage.formatingData.BlueSideColorTextSummoner,
                    RedSideColorTextSummoner = RunesAdcPage.formatingData.RedSideColorTextSummoner,
                    BlueSideColorBorderChampion = RunesAdcPage.formatingData.BlueSideColorBorderChampion,
                    RedSideColorBorderChampion = RunesAdcPage.formatingData.RedSideColorBorderChampion,
                    BlueSideColorSeparationBar = RunesAdcPage.formatingData.BlueSideColorSeparationBar,
                    RedSideColorSeparationBar = RunesAdcPage.formatingData.RedSideColorSeparationBar,
                    BakgroundPicture = RunesAdcPage.formatingData.BakgroundPicture,
                    LanePicture = RunesAdcPage.formatingData.LanePicture,

                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/runes/view1/configRunesAdc.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileRuneAdc()", "Generation ok");
                return "/assets/runes/view1/configRunesAdc.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileRuneAdc()", "Error generation old version recive : " + e.Message);
                return "/assets/runes/view1/configRunesAdc.json";
            }
        }

        private string GenerateConfigFileRuneAdcSupp()
        {
            try
            {
                var data = new RunesAdcSuppPage.FormatingData
                {
                    DefaultPatch = RunesAdcSuppPage.formatingData.DefaultPatch,
                    DefaultRegion = RunesAdcSuppPage.formatingData.DefaultRegion,
                    BackgroudGradient = RunesAdcSuppPage.formatingData.BackgroudGradient,
                    OverlayColorBackgroudGradient = RunesAdcSuppPage.formatingData.OverlayColorBackgroudGradient,
                    BlueSideColorTextSummoner = RunesAdcSuppPage.formatingData.BlueSideColorTextSummoner,
                    RedSideColorTextSummoner = RunesAdcSuppPage.formatingData.RedSideColorTextSummoner,
                    BlueSideColorBorderChampion = RunesAdcSuppPage.formatingData.BlueSideColorBorderChampion,
                    RedSideColorBorderChampion = RunesAdcSuppPage.formatingData.RedSideColorBorderChampion,
                    BlueSideColorSeparationBar = RunesAdcSuppPage.formatingData.BlueSideColorSeparationBar,
                    RedSideColorSeparationBar = RunesAdcSuppPage.formatingData.RedSideColorSeparationBar,
                    BakgroundPicture = RunesAdcSuppPage.formatingData.BakgroundPicture,
                    LanePictureAdc = RunesAdcSuppPage.formatingData.LanePictureAdc,
                    LanePictureSupp = RunesAdcSuppPage.formatingData.LanePictureSupp,

                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/runes/view1/configRunesAdcSupp.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileRuneAdcSupp()", "Generation ok");
                return "/assets/runes/view1/configRunesAdcSupp.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileRuneAdcSupp()", "Error generation old version recive : " + e.Message);
                return "/assets/runes/view1/configRunesAdcSupp.json";
            }
        }

        private string GenerateConfigFileRuneJungle()
        {
            try
            {
                var data = new RunesJunglePage.FormatingData
                {
                    DefaultPatch = RunesJunglePage.formatingData.DefaultPatch,
                    DefaultRegion = RunesJunglePage.formatingData.DefaultRegion,
                    BackgroudGradient = RunesJunglePage.formatingData.BackgroudGradient,
                    OverlayColorBackgroudGradient = RunesJunglePage.formatingData.OverlayColorBackgroudGradient,
                    BlueSideColorTextSummoner = RunesJunglePage.formatingData.BlueSideColorTextSummoner,
                    RedSideColorTextSummoner = RunesJunglePage.formatingData.RedSideColorTextSummoner,
                    BlueSideColorBorderChampion = RunesJunglePage.formatingData.BlueSideColorBorderChampion,
                    RedSideColorBorderChampion = RunesJunglePage.formatingData.RedSideColorBorderChampion,
                    BlueSideColorSeparationBar = RunesJunglePage.formatingData.BlueSideColorSeparationBar,
                    RedSideColorSeparationBar = RunesJunglePage.formatingData.RedSideColorSeparationBar,
                    BakgroundPicture = RunesJunglePage.formatingData.BakgroundPicture,
                    LanePicture = RunesJunglePage.formatingData.LanePicture,

                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/runes/view1/configRunesJungle.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileRuneJungle()", "Generation ok");
                return "/assets/runes/view1/configRunesJungle.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileRuneJungle()", "Error generation old version recive : " + e.Message);
                return "/assets/runes/view1/configRunesJungle.json";
            }
        }

        private string GenerateConfigFileRuneMid()
        {
            try
            {
                var data = new RunesMidPage.FormatingData
                {
                    DefaultPatch = RunesMidPage.formatingData.DefaultPatch,
                    DefaultRegion = RunesMidPage.formatingData.DefaultRegion,
                    BackgroudGradient = RunesMidPage.formatingData.BackgroudGradient,
                    OverlayColorBackgroudGradient = RunesMidPage.formatingData.OverlayColorBackgroudGradient,
                    BlueSideColorTextSummoner = RunesMidPage.formatingData.BlueSideColorTextSummoner,
                    RedSideColorTextSummoner = RunesMidPage.formatingData.RedSideColorTextSummoner,
                    BlueSideColorBorderChampion = RunesMidPage.formatingData.BlueSideColorBorderChampion,
                    RedSideColorBorderChampion = RunesMidPage.formatingData.RedSideColorBorderChampion,
                    BlueSideColorSeparationBar = RunesMidPage.formatingData.BlueSideColorSeparationBar,
                    RedSideColorSeparationBar = RunesMidPage.formatingData.RedSideColorSeparationBar,
                    BakgroundPicture = RunesMidPage.formatingData.BakgroundPicture,
                    LanePicture = RunesMidPage.formatingData.LanePicture,

                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/runes/view1/configRunesMid.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileRuneMid()", "Generation ok");
                return "/assets/runes/view1/configRunesMid.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileRuneMid()", "Error generation old version recive : " + e.Message);
                return "/assets/runes/view1/configRunesMid.json";
            }
        }

        private string GenerateConfigFileRuneSupp()
        {
            try
            {
                var data = new RunesSuppPage.FormatingData
                {
                    DefaultPatch = RunesSuppPage.formatingData.DefaultPatch,
                    DefaultRegion = RunesSuppPage.formatingData.DefaultRegion,
                    BackgroudGradient = RunesSuppPage.formatingData.BackgroudGradient,
                    OverlayColorBackgroudGradient = RunesSuppPage.formatingData.OverlayColorBackgroudGradient,
                    BlueSideColorTextSummoner = RunesSuppPage.formatingData.BlueSideColorTextSummoner,
                    RedSideColorTextSummoner = RunesSuppPage.formatingData.RedSideColorTextSummoner,
                    BlueSideColorBorderChampion = RunesSuppPage.formatingData.BlueSideColorBorderChampion,
                    RedSideColorBorderChampion = RunesSuppPage.formatingData.RedSideColorBorderChampion,
                    BlueSideColorSeparationBar = RunesSuppPage.formatingData.BlueSideColorSeparationBar,
                    RedSideColorSeparationBar = RunesSuppPage.formatingData.RedSideColorSeparationBar,
                    BakgroundPicture = RunesSuppPage.formatingData.BakgroundPicture,
                    LanePicture = RunesSuppPage.formatingData.LanePicture,

                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/runes/view1/configRunesSupp.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileRuneSupp()", "Generation ok");
                return "/assets/runes/view1/configRunesSupp.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileRuneSupp()", "Error generation old version recive : " + e.Message);
                return "/assets/runes/view1/configRunesSupp.json";
            }
        }

        private string GenerateConfigFileRuneTop()
        {
            try
            {
                var data = new RunesTopPage.FormatingData
                {
                    DefaultPatch = RunesTopPage.formatingData.DefaultPatch,
                    DefaultRegion = RunesTopPage.formatingData.DefaultRegion,
                    BackgroudGradient = RunesTopPage.formatingData.BackgroudGradient,
                    OverlayColorBackgroudGradient = RunesTopPage.formatingData.OverlayColorBackgroudGradient,
                    BlueSideColorTextSummoner = RunesTopPage.formatingData.BlueSideColorTextSummoner,
                    RedSideColorTextSummoner = RunesTopPage.formatingData.RedSideColorTextSummoner,
                    BlueSideColorBorderChampion = RunesTopPage.formatingData.BlueSideColorBorderChampion,
                    RedSideColorBorderChampion = RunesTopPage.formatingData.RedSideColorBorderChampion,
                    BlueSideColorSeparationBar = RunesTopPage.formatingData.BlueSideColorSeparationBar,
                    RedSideColorSeparationBar = RunesTopPage.formatingData.RedSideColorSeparationBar,
                    BakgroundPicture = RunesTopPage.formatingData.BakgroundPicture,
                    LanePicture = RunesTopPage.formatingData.LanePicture,

                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/runes/view1/configRunesTop.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileRuneTop()", "Generation ok");
                return "/assets/runes/view1/configRunesTop.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileRuneTop()", "Error generation old version recive : " + e.Message);
                return "/assets/runes/view1/configRunesTop.json";
            }
        }

        private string GenerateConfigFileRuneAll()
        {
            try
            {
                var data = new RunesAllPage.FormatingData
                {
                    DefaultPatch = RunesAllPage.formatingData.DefaultPatch,
                    DefaultRegion = RunesAllPage.formatingData.DefaultRegion,
                    BackgroudGradient = RunesAllPage.formatingData.BackgroudGradient,
                    OverlayColorBackgroudGradient = RunesAllPage.formatingData.OverlayColorBackgroudGradient,
                    BlueSideColorTextSummoner = RunesAllPage.formatingData.BlueSideColorTextSummoner,
                    RedSideColorTextSummoner = RunesAllPage.formatingData.RedSideColorTextSummoner,
                    BlueSideColorBorderChampion = RunesAllPage.formatingData.BlueSideColorBorderChampion,
                    RedSideColorBorderChampion = RunesAllPage.formatingData.RedSideColorBorderChampion,
                    BlueSideColorSeparationBar = RunesAllPage.formatingData.BlueSideColorSeparationBar,
                    RedSideColorSeparationBar = RunesAllPage.formatingData.RedSideColorSeparationBar,
                    BakgroundPicture = RunesAllPage.formatingData.BakgroundPicture,
                    LanePictureAdc = RunesAllPage.formatingData.LanePictureAdc,
                    LanePictureSupp = RunesAllPage.formatingData.LanePictureSupp,
                    LanePictureJungle = RunesAllPage.formatingData.LanePictureJungle,
                    LanePictureMid = RunesAllPage.formatingData.LanePictureMid,
                    LanePictureTop = RunesAllPage.formatingData.LanePictureTop,

                };
                string jsonString = JsonConvert.SerializeObject(data);
                FileManagerLocal.WriteInFile("./wwwroot/assets/runes/view1/configRunesAll.json", jsonString);
                _logger.log(LoggingLevel.INFO, "GenerateConfigFileRuneAll()", "Generation ok");
                return "/assets/runes/view1/configRunesAll.json";
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "GenerateConfigFileRuneAll()", "Error generation old version recive : " + e.Message);
                return "/assets/runes/view1/configRunesAll.json";
            }
        }
    }
}
