using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace OSL_Server.DataReciveClient.Processing.ChampSelect
{
    public class ChampSelectTimer
    {
        //public static void DecreasingTimerChapSelect()
        //{
        //    System.Timers.Timer timer = new(1000);
        //    timer.Elapsed += async (sender, e) => await HandleTimer();
        //    timer.Start();
        //    Console.Write("Press any key to exit... ");
        //    Console.ReadKey();
        //}

        //private static Task HandleTimer()
        //{
        //    Console.WriteLine("\nHandler not implemented...");
        //    throw new NotImplementedException();
        //}
        public static int gobalTimer = 0;
        public static int phaseTime = 5;
        public static int phaseTimeFast = 1750;
        public static System.Timers.Timer phaseTimer;
        public static System.Timers.Timer phaseTimerFast;
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Hello World!");
            phaseTime--;
            if (phaseTime <= 0)
            {
                phaseTime = 0;
                phaseTimer.Stop();
            }
            //Console.WriteLine(phaseTime);
        }

        private static void OnTimedEventFast(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Hello World!");
            phaseTimeFast--;
            if (phaseTimeFast <= 0)
            {
                phaseTimeFast = 0;
                phaseTimerFast.Stop();
            }
            //Console.WriteLine(phaseTimeFast);
        }

        public static void DecreasingTimerChapSelect(int time)
        {
            phaseTime = time;
            phaseTimer = new System.Timers.Timer();
            phaseTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            phaseTimer.Interval = 1000;
            phaseTimer.Enabled = true;
        }

        public static void DecreasingTimerChapSelectFast(int time, int interval)
        {
            //Pages.ChampSelectView2Page.progressValue = time;

            phaseTimeFast = time;
            phaseTimerFast = new System.Timers.Timer();
            phaseTimerFast.Elapsed += new ElapsedEventHandler(OnTimedEventFast);
            phaseTimerFast.Interval = interval;
            phaseTimerFast.Enabled = true;
        }
    }
}
