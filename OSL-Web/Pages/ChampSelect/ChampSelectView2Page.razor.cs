using OSL_Common.System.Logging;

namespace OSL_Web.Pages.ChampSelect
{
    /// <summary>
    /// Champ Select View2 Page
    /// </summary>
    public partial class ChampSelectView2Page
    {
        private static Logger _logger = new("ChampSelectView2Page");

        public static bool overlayLoaded = false;

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string TimerBackground { get; set; }
            public string TimerBlue { get; set; }
            public string TimerRed { get; set; }
            public string TimerEnd { get; set; }
            public string BlueSideBackgroud { get; set; }
            public string BlueSideSummoner { get; set; }
            public string BlueSideBackgroudSummonerPick { get; set; }
            public string BlueSideBlink { get; set; }
            public string BlueSideBackgroudSummonerPickEnd { get; set; }
            public string BlueSideTeamName { get; set; }
            public string BlueSideTeamNameColor { get; set; }
            public string BlueSideTeamNameSize { get; set; }
            public string KeystonePickColor { get; set; }
            public string KeystonePickColorDeg { get; set; }
            public string KeystonePickColor1 { get; set; }
            public string KeystonePickColorPercent1 { get; set; }
            public string KeystonePickColor2 { get; set; }
            public string KeystonePickColorPercent2 { get; set; }
            public string RedSideBackgroud { get; set; }
            public string RedSideSummoner { get; set; }
            public string RedSideBackgroudSummonerPick { get; set; }
            public string RedSideBlink { get; set; }
            public string RedSideBackgroudSummonerPickEnd { get; set; }
            public string RedSideTeamName { get; set; }
            public string RedSideTeamNameColor { get; set; }
            public string RedSideTeamNameSize { get; set; }
            public string BanBackgroundPicture { get; set; }
            public string BanOverlayPicture { get; set; }
            public string BanBackgroundColor { get; set; }
            public string BanBackgroundColorSave { get; set; }

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
            Configuration.Overlay.ChampSelect.View2.Config.LoadFormatingDataConfig();
        }

        /// <summary>
        /// Get picture of line
        /// </summary>
        /// <param name="laneId"></param>
        /// <returns></returns>
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
            foreach (var action in DataProcessing.ChampSelect.session.Actions)
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
                return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{DataProcessing.ChampSelect.session.Bans.MyTeamBans[index]}/default-square.png";
            }
            else
            {
                return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{DataProcessing.ChampSelect.session.Bans.TheirTeamBans[index]}/default-square.png";
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
                return DataProcessing.ChampSelect.session.Bans.MyTeamBans[index] * 1000;
            }
            else
            {
                return DataProcessing.ChampSelect.session.Bans.TheirTeamBans[index] * 1000;
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
            int cellId;
            if (team == 1)
            {
                cellId = DataProcessing.ChampSelect.session.MyTeam[index].CellId;
            }
            else
            {
                cellId = DataProcessing.ChampSelect.session.TheirTeam[index].CellId;
            }
            foreach (var action in DataProcessing.ChampSelect.session.Actions)
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
                return DataProcessing.ChampSelect.session.MyTeam[index].SummonerName;
            }
            else
            {
                return DataProcessing.ChampSelect.session.TheirTeam[index].SummonerName;
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
                    spellId = DataProcessing.ChampSelect.session.MyTeam[index].Spell1Id;
                }
                else
                {
                    spellId = DataProcessing.ChampSelect.session.TheirTeam[index].Spell1Id;
                }
            }
            else
            {
                if (team == 1)
                {
                    spellId = DataProcessing.ChampSelect.session.MyTeam[index].Spell2Id;
                }
                else
                {
                    spellId = DataProcessing.ChampSelect.session.TheirTeam[index].Spell2Id;
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
                champId = DataProcessing.ChampSelect.session.MyTeam[index].ChampionId;
                cellId = DataProcessing.ChampSelect.session.MyTeam[index].CellId;
            }
            else
            {
                champId = DataProcessing.ChampSelect.session.TheirTeam[index].ChampionId;
                cellId = DataProcessing.ChampSelect.session.TheirTeam[index].CellId;
            }

            if (champId == 0)
            {
                foreach (var action in DataProcessing.ChampSelect.session.Actions)
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
