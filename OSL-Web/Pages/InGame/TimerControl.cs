using System.Timers;

namespace OSL_Web.Pages.InGame
{
    public class TimerControl
    {
        public static System.Timers.Timer generalTimer;
        public static int nextDrake = 300; //Spawn at 5:00, respaw 5:00
        //public static System.Timers.Timer drakeTimer;
        public static int nextHerald = 480; //8:00 to spawn respaw 6:00 (once if killed before 13:45)
        public static int nextElder = 360; //Spawn 6:00 after team kill 4 drake, respawn 6:00
        public static int nextBaron = 1200; //Spawn 20:00, respawn 6:00
        public static int buffHerald = 240; //Duration 240
        public static int buffElder = 150; //150 seconds for the first buff; 300 seconds for subsequent buffs 
        public static int buffBaron = 180; //3 min
        public static int inhibOrderTop = 0; //5 min respawn
        public static int inhibOrderMid = 0; //5 min respawn
        public static int inhibOrderBot = 0; //5 min respawn
        public static int inhibChaosTop = 0; //5 min respawn
        public static int inhibChaosMid = 0; //5 min respawn
        public static int inhibChaosBot = 0; //5 min respawn
        public static int gameTimer = 0;
        //Count down with timer of game

        //When game start run timer :
        //nextDrake
        //nextElder
        //nextBaron

        //When drake kill run timer :
        //nextDrake

        //When herald kill run timer :
        //nextElder
        //if timer 13.45min no respawn

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            gameTimer++;

            if (nextDrake <= 0)
            {
                nextDrake = 0;
            }
            else
            {
                nextDrake--;
            }

            if (nextHerald == -1)
            {
                nextHerald = -1;
            }
            else if (nextHerald <= 0)
            {
                nextHerald = 0;
            }
            else
            {
                nextHerald--;
            }

            if (nextElder <= 0)
            {
                nextElder = 0;
            }
            else
            {
                nextElder--;
            }

            if (nextBaron <= 0)
            {
                nextBaron = 0;
            }
            else
            {
                nextBaron--;
            }

            if (buffHerald <= 0)
            {
                buffHerald = 0;
            }
            else
            {
                buffHerald--;
            }

            if (buffElder <= 0)
            {
                buffElder = 0;
                foreach (var summoner in DataProcessing.InGame.gameInformation.Order.Summoners)
                {
                    summoner.ElderBuff = false;
                }
                foreach (var summoner in DataProcessing.InGame.gameInformation.Chaos.Summoners)
                {
                    summoner.ElderBuff = false;
                }
            }
            else
            {
                buffElder--;
            }

            if (buffBaron <= 0)
            {
                buffBaron = 0;
                foreach (var summoner in DataProcessing.InGame.gameInformation.Order.Summoners)
                {
                    summoner.BaronBuff = false;
                }
                foreach (var summoner in DataProcessing.InGame.gameInformation.Chaos.Summoners)
                {
                    summoner.BaronBuff = false;
                }
            }
            else
            {
                buffBaron--;
            }

            if (inhibOrderTop <= 0)
            {
                inhibOrderTop = 0;
            }
            else
            {
                inhibOrderTop--;
            }
            if (inhibOrderMid <= 0)
            {
                inhibOrderMid = 0;
            }
            else
            {
                inhibOrderMid--;
            }
            if (inhibOrderBot <= 0)
            {
                inhibOrderBot = 0;
            }
            else
            {
                inhibOrderBot--;
            }
            if (inhibChaosTop <= 0)
            {
                inhibChaosTop = 0;
            }
            else
            {
                inhibChaosTop--;
            }
            if (inhibChaosMid <= 0)
            {
                inhibChaosMid = 0;
            }
            else
            {
                inhibChaosMid--;
            }
            if (inhibChaosBot <= 0)
            {
                inhibChaosBot = 0;
            }
            else
            {
                inhibChaosBot--;
            }
        }

        public static void InitTimerGameStart()
        {
            nextDrake = 300;
            nextHerald = 480;
            nextBaron = 1200;
            gameTimer = 0;
            //DecreasingTimer();
            //Thread RunDecreasingTimer = new Thread(() => DecreasingTimer());
            //RunDecreasingTimer.Start();

        }

        public static void DecreasingTimer()
        {
            generalTimer = new System.Timers.Timer();
            generalTimer.Elapsed += OnTimedEvent;
            generalTimer.Interval = 1000;
            generalTimer.Enabled = true;
        }

        public static void Pause()
        {
            generalTimer.Stop();
        }

        public static void Start()
        {
            generalTimer.Start();
        }

        public static bool Enabled()
        {
            return generalTimer.Enabled;
        }

        public static void Interval(double interval)
        {
            generalTimer.Interval = interval;
        }

        public static string ConvertToMinute(int timer)
        {
            TimeSpan result = TimeSpan.FromSeconds(timer);
            string fromTimeString = result.ToString(@"m\:ss");
            return fromTimeString;
        }

        public static void SyncTimers(int min, int sec)
        {
            int second = min * 60 + sec;
            nextHerald -= second;
            nextElder -= second;
            nextBaron -= second;
            buffHerald -= second;
            buffElder -= second;
            buffBaron -= second;
            inhibOrderTop -= second;
            inhibOrderMid -= second;
            inhibOrderBot -= second;
            inhibChaosTop -= second;
            inhibChaosMid -= second;
            inhibChaosBot -= second;
            gameTimer -= second;
        }

    }
}
