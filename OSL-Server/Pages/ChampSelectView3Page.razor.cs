using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

namespace OSL_Server.Pages
{
    /// <summary>
    /// Champ Select View3 Page
    /// </summary>
    public partial class ChampSelectView3Page
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectView2Page");

        public static bool overlayLoaded = false;

        //Personalisation Patch and Region
        public static string DefaultPatch = "latest";
        public static string DefaultRegion = "fr_fr";

        //Personalisation Timer 
        public static string TimerBackground = "#010a13";
        public static string TimerBackgroundSaved = "#010a13";
        public static string TimerBlue = "#0b849e";
        public static string TimerBlueSaved = "#0b849e";
        public static string TimerRed = "#be1e37";
        public static string TimerRedSaved = "#be1e37";
        public static string TimerEnd = "linear-gradient(90deg, rgba(11,132,158,1) 0%, rgba(190,30,55,1) 100%)";

        //Personalisation Blue Side
        public static string BlueSideBackgroud = "#0b849e";
        public static string BlueSideBackgroudSaved = "#0b849e";
        public static string BlueSideSummoner = "#ffffff";
        public static string BlueSideSummonerSaved = "#ffffff";
        public static string BlueSideBackgroudSummonerPick = "#0b849e";
        public static string BlueSideBackgroudSummonerPickSaved = "#0b849e";
        public static string BlueSideBlink = "radial-gradient(ellipse, rgba(0, 0, 0, 0) 25%, #0b849e)";
        public static string BlueSideBackgroudSummonerPickEnd = "#010a13";
        public static string BlueSideBackgroudSummonerPickEndSaved = "#010a13";
        public static string BlueSideTeamName = "";
        public static string BlueSideTeamNameSave = "";
        public static string BlueSideTeamNameColor = "#ffffff";
        public static string BlueSideTeamNameColorSaved = "#ffffff";
        public static string BlueSideTeamNameSize = "20px";

        //Personalisation Keystone
        public static string KeystonePickColor = "linear-gradient(150deg, #0b849e 0%, #be1e37 100%)";
        public static string KeystonePickColorDeg = "150";
        public static string KeystonePickColor1 = "#0b849e";
        public static string KeystonePickColorPercent1 = "0";
        public static string KeystonePickColor2 = "#be1e37";
        public static string KeystonePickColorPercent2 = "100";

        public static string KeystonePickColorSave = "linear-gradient(150deg, #0b849e 0%, #be1e37 100%)";
        public static string KeystonePickColorDegSave = "150";
        public static string KeystonePickColor1Save = "#0b849e";
        public static string KeystonePickColorPercent1Save = "0";
        public static string KeystonePickColor2Save = "#be1e37";
        public static string KeystonePickColorPercent2Save = "100";

        //Personalisation Red Side
        public static string RedSideBackgroud = "#be1e37";
        public static string RedSideBackgroudSaved = "#be1e37";
        public static string RedSideSummoner = "#ffffff";
        public static string RedSideSummonerSaved = "#ffffff";
        public static string RedSideBackgroudSummonerPick = "#be1e37";
        public static string RedSideBackgroudSummonerPickSaved = "#be1e37";
        public static string RedSideBlink = "radial - gradient(ellipse, rgba(0, 0, 0, 0) 25 %, #be1e37)";
        public static string RedSideBackgroudSummonerPickEnd = "#010a13";
        public static string RedSideBackgroudSummonerPickEndSaved = "#010a13";
        public static string RedSideTeamName = "";
        public static string RedSideTeamNameSave = "";
        public static string RedSideTeamNameColor = "#ffffff";
        public static string RedSideTeamNameColorSaved = "#ffffff";
        public static string RedSideTeamNameSize = "20px";

        //Personalisation Ban
        public static string BanBackgroundPicture = "../assets/champselect/banning-1.png";
        public static string BanOverlayPicture = "../assets/champselect/ban-completed-2.png";
        public static string BanBackgroundColor = "#010a13";
        public static string BanBackgroundColorSave = "#010a13";

        public static void ResetColor()
        {
            TimerBackground = TimerBackgroundSaved;
            TimerBlue = TimerBlueSaved;
            TimerRed = TimerRedSaved;

            BlueSideBackgroud = BlueSideBackgroudSaved;
            BlueSideSummoner = BlueSideSummonerSaved;
            BlueSideBackgroudSummonerPick = BlueSideBackgroudSummonerPickSaved;
            BlueSideBackgroudSummonerPickEnd = BlueSideBackgroudSummonerPickEndSaved;
            BlueSideTeamNameColor = BlueSideTeamNameColorSaved;

            KeystonePickColor = KeystonePickColorSave;

            KeystonePickColorDeg = KeystonePickColorDegSave;
            KeystonePickColor1 = KeystonePickColor1Save;
            KeystonePickColorPercent1 = KeystonePickColorPercent1Save;
            KeystonePickColor2 = KeystonePickColor2Save;
            KeystonePickColorPercent2 = KeystonePickColorPercent2Save;

            RedSideBackgroud = RedSideBackgroudSaved;
            RedSideSummoner = RedSideSummonerSaved;
            RedSideBackgroudSummonerPick = RedSideBackgroudSummonerPickSaved;
            RedSideBackgroudSummonerPickEnd = RedSideBackgroudSummonerPickEndSaved;
            RedSideTeamNameColor = RedSideTeamNameColorSaved;
            BanBackgroundColor = BanBackgroundColorSave;
            BlueSideTeamName = BlueSideTeamNameSave;
            RedSideTeamName = RedSideTeamNameSave;
        }
        public static void SetTimerBackground()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = TimerBackground;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                TimerBackground = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetTimerBlue()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = TimerBlue;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                TimerBlue = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetTimerRed()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = TimerRed;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                TimerRed = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetBlueSideBackgroud()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = BlueSideBackgroud;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                BlueSideBackgroud = ChampSelectPage.colorValue;
            }
        }
        public static void SetBlueSideSummoner()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = BlueSideSummoner;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                BlueSideSummoner = ChampSelectPage.colorValue;
            }
        }
        public static void SetBlueSideBackgroudSummonerPick()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = BlueSideBackgroudSummonerPick;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                BlueSideBackgroudSummonerPick = ChampSelectPage.colorValue;
            }
        }
        public static void SetBlueSideBackgroudSummonerPickEnd()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = BlueSideBackgroudSummonerPickEnd;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                BlueSideBackgroudSummonerPickEnd = ChampSelectPage.colorValue;
            }
        }

        public static void SetBlueSideTeamNameColor()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = BlueSideTeamNameColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                BlueSideTeamNameColor = ChampSelectPage.colorValue;
            }
        }

        public static void SetKeystoneColor1()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = KeystonePickColor1;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                KeystonePickColor1 = ChampSelectPage.colorValue;
                KeystonePickColor = $"linear-gradient({KeystonePickColorDeg}deg, {KeystonePickColor1} {KeystonePickColorPercent1}%, {KeystonePickColor2} {KeystonePickColorPercent2}%)";
            }
        }

        public static void SetKeystoneColor2()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = KeystonePickColor2;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                KeystonePickColor2 = ChampSelectPage.colorValue;
                KeystonePickColor = $"linear-gradient({KeystonePickColorDeg}deg, {KeystonePickColor1} {KeystonePickColorPercent1}%, {KeystonePickColor2} {KeystonePickColorPercent2}%)";
            }
        }

        public static void SetRedSideBackgroud()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = RedSideBackgroud;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                RedSideBackgroud = ChampSelectPage.colorValue;
            }
        }
        public static void SetRedSideSummoner()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = RedSideSummoner;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                RedSideSummoner = ChampSelectPage.colorValue;
            }
        }
        public static void SetRedSideBackgroudSummonerPick()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = RedSideBackgroudSummonerPick;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                RedSideBackgroudSummonerPick = ChampSelectPage.colorValue;
            }
        }
        public static void SetRedSideBackgroudSummonerPickEnd()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = RedSideBackgroudSummonerPickEnd;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                RedSideBackgroudSummonerPickEnd = ChampSelectPage.colorValue;
            }
        }
        public static void SetRedSideTeamNameColor()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = RedSideTeamNameColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                RedSideTeamNameColor = ChampSelectPage.colorValue;
            }
        }
        public static void SetBanBackgroundColor()
        {
            if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay3 = "visible";
                ChampSelectPage.colorValue = BanBackgroundColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay3 = "hidden";
                BanBackgroundColor = ChampSelectPage.colorValue;
            }
        }

        private string GetLaneId(int laneId)
        {
            if (laneId == 0)
            {
                return "../assets/champselect/position_top.png";
            }
            else if (laneId == 1)
            {
                return "../assets/champselect/position_jungle.png";
            }
            else if (laneId == 2)
            {
                return "../assets/champselect/position_mid.png";
            }
            else if (laneId == 3)
            {
                return "../assets/champselect/position_bottom.png";
            }
            else
            {
                return "../assets/champselect/position_support.png";
            }
        }

        //private string SizeTimer(double multiCurentCount)
        //{
        //    int size = 1750 - ((int)(currentCount * multiCurentCount) + timePhase);
        //    //Console.WriteLine("size : " + size);
        //    if (size <= 0)
        //    {
        //        size = 0;
        //    }
        //    return size.ToString() + "px";
        //}

        private string PictureExist(string picture)
        {
            if (File.Exists(picture))
            {
                return "visible";
            }
            else
            {
                return "hidden";
            }
        }

        private int SideInProgress()
        {
            foreach (var action in ChampSelectInfo.session.Actions)
            {
                foreach (var inaction in action)
                {
                    if (inaction.IsInProgress == true)
                    {
                        if (inaction.ActorCellId == 0 || inaction.ActorCellId == 1 || inaction.ActorCellId == 2 || inaction.ActorCellId == 3 || inaction.ActorCellId == 4)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }

        private string DefaultSquare(int index, int team)
        {
            if (team == 1)
            {
                //return $"../assets/12.12/fr_fr/Champions/{ChampSelectInfo.session.Bans.MyTeamBans[index]}/default-square.png";
                return $"../assets/{DefaultPatch}/{DefaultRegion}/Champions/{ChampSelectInfo.session.Bans.MyTeamBans[index]}/default-square.png";
            }
            else
            {
                //return $"../assets/12.12/fr_fr/Champions/{ChampSelectInfo.session.Bans.TheirTeamBans[index]}/default-square.png";
                return $"../assets/{DefaultPatch}/{DefaultRegion}/Champions/{ChampSelectInfo.session.Bans.TheirTeamBans[index]}/default-square.png";
            }
        }

        private int ChampDefaultSkinNumber(int index, int team)
        {
            if (team == 1)
            {
                return ChampSelectInfo.session.Bans.MyTeamBans[index] * 1000;
            }
            else
            {
                return ChampSelectInfo.session.Bans.TheirTeamBans[index] * 1000;
            }
        }

        private string GetCurentAction(int index, int team)
        {
            int cellId;
            if (team == 1)
            {
                cellId = ChampSelectInfo.session.MyTeam[index].CellId;
            }
            else
            {
                cellId = ChampSelectInfo.session.TheirTeam[index].CellId;
            }
            foreach (var action in ChampSelectInfo.session.Actions)
            {
                foreach (var inaction in action)
                {
                    if (inaction.ActorCellId == cellId)
                    {
                        if (inaction.Completed == false && inaction.IsInProgress == true)
                        {
                            if (inaction.Type.Equals("pick"))
                            {
                                return "Picking";
                            }
                            else if (inaction.Type.Equals("ban"))
                            {
                                return "Banning";
                            }
                        }
                    }
                }
            }
            return "";
        }

        private string GetSummonerName(int index, int team)
        {
            if (team == 1)
            {
                return ChampSelectInfo.session.MyTeam[index].SummonerName;
            }
            else
            {
                return ChampSelectInfo.session.TheirTeam[index].SummonerName;
            }
        }

        private string GetSpell(int index, int team, int numSpell)
        {
            ulong spellId;
            if (numSpell == 1)
            {
                if (team == 1)
                {
                    spellId = ChampSelectInfo.session.MyTeam[index].Spell1Id;
                }
                else
                {
                    spellId = ChampSelectInfo.session.TheirTeam[index].Spell1Id;
                }
            }
            else
            {
                if (team == 1)
                {
                    spellId = ChampSelectInfo.session.MyTeam[index].Spell2Id;
                }
                else
                {
                    spellId = ChampSelectInfo.session.TheirTeam[index].Spell2Id;
                }
            }
            if (spellId > 100 || spellId == 0)
            {
                //return "../assets/12.12/fr_fr/SummonerSpells/54.png";
                return $"../assets/{DefaultPatch}/{DefaultRegion}/SummonerSpells/54.png";
            }
            //return $"../assets/12.12/fr_fr/SummonerSpells/{spellId}.png";
            return $"../assets/{DefaultPatch}/{DefaultRegion}/SummonerSpells/{spellId}.png";
        }

        private string GetChampId(int index, int team)
        {
            int champId, cellId;
            if (team == 1)
            {
                champId = ChampSelectInfo.session.MyTeam[index].ChampionId;
                cellId = ChampSelectInfo.session.MyTeam[index].CellId;
            }
            else
            {
                champId = ChampSelectInfo.session.TheirTeam[index].ChampionId;
                cellId = ChampSelectInfo.session.TheirTeam[index].CellId;
            }

            if (champId == 0)
            {
                foreach (var action in ChampSelectInfo.session.Actions)
                {
                    foreach (var inaction in action)
                    {
                        if (inaction.ActorCellId == cellId)
                        {
                            if (inaction.Type.Equals("pick"))
                            {
                                if (inaction.Completed == false)
                                {
                                    champId = inaction.ChampionId;
                                }
                            }
                        }
                    }
                }
            }
            //return $"../assets/12.12/fr_fr/Champions/{champId}/Skins/{champId * 1000}/{champId * 1000}_Splashe.jpg";
            return $"../assets/{DefaultPatch}/{DefaultRegion}/Champions/{champId}/Skins/{champId * 1000}/{champId * 1000}_Splashe.jpg";
        }
    }
}
