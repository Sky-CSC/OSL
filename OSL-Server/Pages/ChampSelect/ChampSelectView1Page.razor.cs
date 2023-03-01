using OSL_Server.DataReciveClient.Processing.ChampSelect;
using OSL_Server.Configuration;

namespace OSL_Server.Pages.ChampSelect
{
    /// <summary>
    /// Champ Select View1 Page
    /// </summary>
    public partial class ChampSelectView1Page
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectView1Page");

        public static bool overlayLoaded = false;

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

        /// <summary>
        /// Formating Data
        /// </summary>
        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string BlueSideTeamName { get; set; }
            public string BlueTeamSubtext { get; set; }
            public string BlueTeamNameColor { get; set; }
            public string BlueTeamSubtextColor { get; set; }
            public string BlueLogo { get; set; }
            public string BlueSideTexteColor { get; set; }
            public string BlueSideBackgroudColor { get; set; }
            public string BlueSideBorderColor { get; set; }
            public string BlueSideTimerBackgroudColor { get; set; }
            public string BlueSideTimerBorderColor { get; set; }
            public string BlueSideTimerTexteColor { get; set; }
            public string RedSideTeamName { get; set; }
            public string RedTeamSubtext { get; set; }
            public string RedTeamNameColor { get; set; }
            public string RedTeamSubtextColor { get; set; }
            public string RedLogo { get; set; }
            public string RedSideTexteColor { get; set; }
            public string RedSideBackgroudColor { get; set; }
            public string RedSideBorderColor { get; set; }
            public string RedSideTimerBackgroudColor { get; set; }
            public string RedSideTimerBorderColor { get; set; }
            public string RedSideTimerTexteColor { get; set; }
            public string BanBackgroundPicture { get; set; }
            public string BanOverlayPicture { get; set; }
            public string BanBackgroundColor { get; set; }
            public string OverlayBackground { get; set; }
        }


        /// <summary>
        /// Enable or disable overlay view
        /// </summary>
        public static void EnableOrDisableOverlayView()
        {
            if (overlayLoaded == false)
            {
                overlayLoaded = true;
            }
            else
            {
                overlayLoaded = false;
            }
        }

        /// <summary>
        /// Load default datat champ select
        /// </summary>
        public static void ResetColor()
        {
            Config.LoadFormatingDataConfigChampSelectView1(); 
        }

        /// <summary>
        /// Return if picture exist
        /// </summary>
        /// <param name="picture">visible or hidden for css display</param>
        /// <returns></returns>
        private static string PictureExist(string picture)
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

        /// <summary>
        /// Which team is in progress
        /// </summary>
        /// <returns>Side in progress, 1 is MyTeam, 2 is TheirTeam, 0 if no team in progress</returns>
        private static int SideInProgress()
        {
            foreach (var action in ChampSelectInfo.session.Actions)
            {
                foreach (var inaction in action)
                {
                    if (inaction.IsInProgress == true)
                    {
                        foreach (var inmyTeam in ChampSelectInfo.session.MyTeam)
                        {
                            if (inaction.ActorCellId == inmyTeam.CellId && inmyTeam.TeamNum == 1)
                            {
                                return 1;
                            }
                        }
                        return 2;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Url default square of champion
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <returns></returns>
        private static string DefaultSquare(int index, int team)
        {
            if (team == 1)
            {
                return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{ChampSelectInfo.session.Bans.MyTeamBans[index]}/default-square.png";
            }
            else
            {
                return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{ChampSelectInfo.session.Bans.TheirTeamBans[index]}/default-square.png";
            }
        }

        /// <summary>
        /// Url square of champion skin
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <returns></returns>
        private static int ChampDefaultSkinNumber(int index, int team)
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

        /// <summary>
        /// If curent action is pink or ban champion
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <returns></returns>
        private static string GetCurentAction(int index, int team)
        {
            string curentAction = "";
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
                                curentAction = "Picking";
                            }
                            else if (inaction.Type.Equals("ban"))
                            {
                                curentAction = "Banning";
                            }
                        }
                    }
                }
            }
            return curentAction;
        }

        /// <summary>
        /// Summoner name
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <returns></returns>
        private static string GetSummonerName(int index, int team)
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

        /// <summary>
        /// Get summoners spell
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <param name="numSpell">num of summoner spell</param>
        /// <returns></returns>
        private static string GetSpell(int index, int team, int numSpell)
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
                return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/SummonerSpells/54.png";
            }
            return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/SummonerSpells/{spellId}.png";
        }

        /// <summary>
        /// Champion ID
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <returns></returns>
        private static string GetChampId(int index, int team)
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
            return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{champId}/Skins/{champId * 1000}/{champId * 1000}_Splashe.jpg";
        }
    }
}
