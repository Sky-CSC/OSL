
using OSL_Common.System.Logging;

namespace OSL_Web.Pages.InGame
{
    public partial class InGameView1_1Page
    {
        private static Logger _logger = new("InGameView1_1Page");

        public static FormatingData formatingData = new();

        /// <summary>
        /// Formating Data
        /// </summary>
        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string BluePlayerFrame { get; set; }
            public bool DisplayBluePlayerFrame { get; set; }
            public string RedPlayerFrame { get; set; }
            public bool DisplayRedPlayerFrame { get; set; }
            public string DragonTimerFrame { get; set; }
            public bool DisplayDragonTimer { get; set; }
            public string HeraldBaronTimerFrame { get; set; }
            public bool DisplayHeraldBaronTimer { get; set; }
            public string LeftInfoFrame { get; set; }
            public bool DisplayLeftInfo { get; set; }
            public string RightInfoFrame { get; set; }
            public bool DisplayRightInfo { get; set; }
            public string TeamBanner { get; set; }
            public string TeamScoreBanner { get; set; }
            public string BlueTeamText { get; set; }
            public string BlueTeamScoreText { get; set; }
            public string RedTeamText { get; set; }
            public string RedTeamScoreText { get; set; }
            public bool DisplayBlueTeam { get; set; }
            public bool DisplayBlueTeamScore { get; set; }
            public bool DisplayBlueTeamText { get; set; }
            public bool DisplayRedTeam { get; set; }
            public bool DisplayRedTeamScore { get; set; }
            public bool DisplayRedTeamText { get; set; }
            public string ColorBlueTeamScoreText { get; set; }
            public string ColorBlueTeamText { get; set; }
            public string ColorRedTeamScoreText { get; set; }
            public string ColorRedTeamText { get; set; }

            //New
            public bool DisplayItems { get; set; }
            public bool DisplayLevels { get; set; }
            public bool DisplayDragonKill { get; set; }
            public bool DisplayInhibKill { get; set; }
            public bool DisplayBaronElderBuff { get; set; }
        }

        /// <summary>
        /// Load default data in game
        /// </summary>
        public static void ResetColor()
        {
            Configuration.Overlay.InGame.View1.Config.LoadFormatingDataConfig();
        }

        public static bool ItemToDisplay(int idItem)
        {
            var itemsNotDisplay = new List<int> { 1001, 1004, 1006, 1011, 1018, 1026, 1027, 1028, 1029, 1031, 1033, 1035, 1036, 1037, 1038, 1039, 1040, 1042, 1043, 1052, 1053, 1054, 1055, 1056, 1057, 1058, 1082, 1083, 1104, 1500, 1501, 1502, 1503, 1504, 1506, 1507, 1508, 1509, 1540, 1511, 1512, 1515, 1516, 1516, 1517, 1518, 15119, 1520, 1521, 1522, 2001, 2003, 2007, 2008, 2010, 2015, 2019, 2031, 2033, 2049, 2050, 2051, 2052, 2055, 2141, 2142, 2143, 2144, 2403, 2421, 2422, 2424, 3012, 3023, 3024, 3035, 3039, 3051, 3057, 3067, 3070, 3076, 3077, 3082, 3086, 3105, 3108, 3112, 3113, 3114, 3123, 3128, 3133, 3134, 3140, 3145, 3155, 3177, 3184, 3191, 3211, 3330, 3340, 3348, 3349, 3363, 3364, 3400, 3130, 3599, 3600, 3801, 3802, 3803, 3850, 3851, 3853, 3854, 3855, 3858, 3859, 3860, 3862, 3863, 3864, 3901, 3902, 3903, 3916, 4004, 4010, 4403, 4630, 4632, 4635, 4638, 4641, 6029, 6670, 6677, 222051, 223112, 223177, 223184, 223185, 224403 };
            //var starterItems = new List<int> { 1101, 1102, 1103 };
            //var potionsConsumables = new List<int> { 2138, 2139, 2140 };
            //var distributedItems = new List<int> { 3513 };
            //var boots = new List<int> { 3006,3009,3047,3020,3111,3117, 3158};
            //var legendaryItems = new List<int> { 2065, 3001, 3003, 3004 , 3011 , 3026 , 3031 ,30033,3035,3036,3040,3041,3042,3044,3046,3050,3053,3057,3065,3066,3068,3071,3072,3074,3075,3078,3082,3083,3084,3085,3087,3089,3091,3094,3095,3100,3102,3124,3135,3139,3142,3143,3146,3152,3153,3156,3157,3161,3165,3172,3179,3181,3190,3193,3222,3504,3508,3742,3748,3814,3853,4005,4401,4628,4629,4633,4636,4637,4642,4643,4644,4645,6029,6035,6333,6609,6616,6617,6630,6631,6632,6653,6655,6656,6657,6662,6664,6665,6667,6670,6671,6672,6673,6675,6676,6691,6692,6693,6694,6695,6696,7000,7001,7002,7005,7006,7009,7010,7011,7012,7013,7014,7015,7016,7017,7018,1019,7020,7021,7023,7024,7025,7026,7027,7028,7029,7030,7031,7032,7033,8001,8020,222065};
            if (itemsNotDisplay.Contains(idItem))
            {
                return false;
            }
            return true;
        }

        public static string GetDragonPath(string dragon)
        {
            if (dragon.Equals("SRU_Dragon_Fire"))
            {
                return "/assets/ingame/dragon/infernal_dragon_icon.png";
            }
            else if (dragon.Equals("SRU_Dragon_Chemtech"))
            {
                return "/assets/ingame/dragon/chemtech_dragon_icon.png";
            }
            else if (dragon.Equals("SRU_Dragon_Air"))
            {
                return "/assets/ingame/dragon/cloud_dragon_icon.png";
            }
            else if (dragon.Equals("SRU_Dragon_Hextech"))
            {
                return "/assets/ingame/dragon/hextech_dragon_icon.png";
            }
            else if (dragon.Equals("SRU_Dragon_Earth"))
            {
                return "/assets/ingame/dragon/mountain_dragon_icon.png";
            }
            else if (dragon.Equals("SRU_Dragon_Water"))
            {
                return "/assets/ingame/dragon/ocean_dragon_icon.png";
            }
            else
            {
                return "/assets/ingame/dragon/no_dragon.png";
            }
        }
    }
}
