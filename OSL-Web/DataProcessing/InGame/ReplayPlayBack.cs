using Newtonsoft.Json;
using OSL_Common.System.Logging;

namespace OSL_Web.DataProcessing
{
    public partial class InGame
    {
        public static bool ReplayPlayBack(string content)
        {
            try
            {
                if (content.Contains("length") && content.Contains("paused") && content.Contains("seeking") && content.Contains("speed") && content.Contains("time")) //is playBack 
                {
                    _logger.log(LoggingLevel.INFO, "ReplayPlayBack()", "In ReplayPlayBack");

                    if (initTimerGame)
                    {
                        //Init timer game start
                        Pages.InGame.TimerControl.InitTimerGameStart();
                        initTimerGame = false;
                    }
                    playBack = JsonConvert.DeserializeObject(content);
                    bool paused = (bool)playBack.paused;
                    if (paused)
                    {
                        Pages.InGame.TimerControl.Pause();
                    }
                    else
                    {
                        if (!Pages.InGame.TimerControl.Enabled())
                        {
                            Pages.InGame.TimerControl.Start();
                        }
                    }

                    double speed = (double)playBack.speed;
                    if (Pages.InGame.TimerControl.generalTimer.Interval != speed * 1000)
                    {
                        Pages.InGame.TimerControl.Interval(1000 / speed);
                    }

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "ReplayPlayBack()", "Error deserialize ReplayPlayBack, possible not ReplayPlayBack" + e);
                return false;
            }
        }
    }
}
