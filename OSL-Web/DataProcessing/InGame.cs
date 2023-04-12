using OSL_Common.System.Logging;

namespace OSL_Web.DataProcessing
{
    public class InGame
    {
        private static Logger _logger = new("InGame");
        public static bool firstCallPerks = false;
        public static void ReadData(string content)
        {
            if (firstCallPerks)
            {
                Runes.CreateSummonerPerksList(content);
                firstCallPerks = false;
            }
        }
    }
}
