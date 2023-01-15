using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using System.ComponentModel.DataAnnotations;

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
                    ChampSelectView1Page.DefaultPatch = jsonContent.DefaultPatch;
                    ChampSelectView1Page.DefaultRegion = jsonContent.DefaultRegion;
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
                    ChampSelectView2Page.DefaultPatch = jsonContent.DefaultPatch;
                    ChampSelectView2Page.DefaultRegion = jsonContent.DefaultRegion;
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
                    ChampSelectView3Page.DefaultPatch = jsonContent.DefaultPatch;
                    ChampSelectView3Page.DefaultRegion = jsonContent.DefaultRegion;
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

        private void GenerateConfigFileView1()
        {

        }
        private void GenerateConfigFileView2()
        {

        }
        private void GenerateConfigFileView3()
        {

        }
    }
}
