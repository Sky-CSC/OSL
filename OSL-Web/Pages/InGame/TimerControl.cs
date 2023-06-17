using System.Timers;

namespace OSL_Web.Pages.InGame
{
    public class TimerControl
    {
        public static System.Timers.Timer generalTimer;
        public static int nextDrake = 300; //Spawn at 5:00, respaw 5:00
        //public static System.Timers.Timer drakeTimer;
        public static int nextHerald = 480; //8:00 to spawn respaw 6:00 (once if killed before 13:45)
        public static int nextHelder = 360; //Spawn 6:00 after team kill 4 drake, respawn 6:00
        public static int nextBaron = 1200; //Spawn 20:00, respawn 6:00
        public static int buffHerald = 240; //Duration 240
        public static int buffHelder = 150; //150 seconds for the first buff; 300 seconds for subsequent buffs 
        public static int buffBaron = 210; //3.30 min
        public static int gameTimer = 0;

        //Count down with timer of game

        //When game start run timer :
        //nextDrake
        //nextHelder
        //nextBaron

        //When drake kill run timer :
        //nextDrake

        //When herald kill run timer :
        //nextHelder
        //if timer 13.45min no respawn

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //nextDrake--;
            //nextHerald--;
            //nextHelder--;
            //nextBaron--;
            //buffHerald--;
            //buffHelder--;
            //buffBaron--;
            gameTimer++;

            if (nextDrake <= 0)
            {
                nextDrake = 0;
            }
            else
            {
                nextDrake--;
            }

            if (nextHerald <= 0)
            {
                nextHerald = 0;
            }
            else
            {
                nextHerald--;
            }

            if (nextHelder <= 0)
            {
                nextHelder = 0;
            }
            else
            {
                nextHelder--;
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

            if (buffHelder <= 0)
            {
                buffHelder = 0;
            }
            else
            {
                buffHelder--;
            }

            if (buffBaron <= 0)
            {
                buffBaron = 0;
            }
            else
            {
                buffBaron--;
            }
        }

        public static void InitTimerGameStart()
        {
            nextDrake = 300;
            nextHerald = 480;
            nextBaron = 1200;
            gameTimer = 0;
            DecreasingTimer();
        }

        public static void DecreasingTimer()
        {
            generalTimer = new System.Timers.Timer();
            generalTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
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

    }
}
