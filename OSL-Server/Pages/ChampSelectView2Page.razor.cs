using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

namespace OSL_Server.Pages
{
    public partial class ChampSelectView2Page
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectView1Page");

        public static bool overlayType2Loaded = true;

        //Personalisation Patch and Region
        public static string DefaultPatch = "latest";
        public static string DefaultRegion = "fr_fr";

        //Personalisation Blue side
        public static string BlueTeamName = "";
        public static string BlueTeamSubtext = "";
        public static string ColorBlueTeamName = "white";
        public static string ColorBlueTeamSubtext = "white";
        public static string BlueLogo = "";
        public static string ColorBlueSideTexte = "white";
        public static string ColorBlueSideBackgroud = "#0b849e";
        public static string ColorBlueSideBorder = "5px solid yellow";
        public static string ColorBlueSideTimerBackgroud = "#0b849e";
        public static string ColorBlueSideTimerBorder = "5px solid blue";
        public static string ColorBlueSideTimerTexte = "white";

        //Personalisation Red side
        public static string RedTeamName = "";
        public static string RedTeamSubtext = "";
        public static string ColorRedTeamName = "white";
        public static string ColorRedTeamSubtext = "white";
        public static string RedLogo = "";
        public static string ColorRedSideTexte = "white";
        public static string ColorRedSideBackgroud = "#be1e37";
        public static string ColorRedSideBorder = "5px solid yellow";
        public static string ColorRedSideTimerBackgroud = "#be1e37";
        public static string ColorRedSideTimerBorder = "5px solid red";
        public static string ColorRedSideTimerTexte = "white";

        //Personalisation Ban
        public static string BanBackgroundPicture = "../assets/champselect/banning-1.png";
        public static string BanOverlayPicture = "../assets/champselect/ban-completed-2.png";
        public static string BanBackgroundColor = "#010a13";

        //Personalisation Background
        public static string OverlayBackground = "../assets/champselect/backgroud-view-1.png";

        public class ChampSelect
        {
            public string BlueTeamName { get; set; }
            public string BlueTeamSubtext { get; set; }
            public string ColorBlueTeamName { get; set; }
            public string ColorBlueTeamSubtext { get; set; }
            public string BlueLogo { get; set; }
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string ColorBlueSideTexte { get; set; }
            public string ColorBlueSideBackgroud { get; set; }
            public string ColorBlueSideBorder { get; set; }
            public string ColorBlueSideTimerBackgroud { get; set; }
            public string ColorBlueSideTimerBorder { get; set; }
            public string ColorBlueSideTimerTexte { get; set; }
            public string RedTeamName { get; set; }
            public string RedTeamSubtext { get; set; }
            public string ColorRedTeamName { get; set; }
            public string ColorRedTeamSubtext { get; set; }
            public string RedLogo { get; set; }
            public string ColorRedSideTexte { get; set; }
            public string ColorRedSideBackgroud { get; set; }
            public string ColorRedSideBorder { get; set; }
            public string ColorRedSideTimerBackgroud { get; set; }
            public string ColorRedSideTimerBorder { get; set; }
            public string ColorRedSideTimerTexte { get; set; }
            public string BanBackgroundPicture { get; set; }
            public string BanOverlayPicture { get; set; }
            public string BanBackgroundColor { get; set; }
            public string OverlayBackground { get; set; }
        }

        private string getLaneId(int laneId)
        {
            if(laneId == 0)
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

        private string sizeTimer(double multiCurentCount)
        {   
            int size = 1750 - ((int)(currentCount*multiCurentCount) + timePhase);
            Console.WriteLine("size : " + size);
            if (size <= 0)
            {
                size = 0;
            }
            return size.ToString() + "px";
        }

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
                return $"../assets/12.12/fr_fr/Champions/{ChampSelectInfo.session.Bans.MyTeamBans[index]}/default-square.png";
            }
            else
            {
                return $"../assets/12.12/fr_fr/Champions/{ChampSelectInfo.session.Bans.TheirTeamBans[index]}/default-square.png";
            }
        }

        private int champDefaultSkinNumber(int index, int team)
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

        private string getCurentAction(int index, int team)
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

        private string getSummonerName(int index, int team)
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

        private string getSpell(int index, int team, int numSpell)
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
                return "../assets/12.12/fr_fr/SummonerSpells/54.png";
            }
            return $"../assets/12.12/fr_fr/SummonerSpells/{spellId}.png";
        }

        private string getChampId(int index, int team)
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
            return $"../assets/12.12/fr_fr/Champions/{champId}/Skins/{champId * 1000}/{champId * 1000}_Splashe.jpg";
        }
    }
}
