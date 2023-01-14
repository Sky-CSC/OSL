using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace OSL_Server.DataReciveClient.Processing.ChampSelect
{
    /// <summary>
    /// Champ Select Timer
    /// </summary>
    public class ChampSelectTimer
    {
        public static int gobalTimer = 0;
        public static int phaseTime = 5;
        public static int phaseTimeFast = 1750;
        public static System.Timers.Timer phaseTimer;
        public static System.Timers.Timer phaseTimerFast;
        /// <summary>
        /// Update timer (second display)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            phaseTime--;
            if (phaseTime <= 0)
            {
                phaseTime = 0;
                phaseTimer.Stop();
            }
        }

        /// <summary>
        /// Update timer (pixel display)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEventFast(object source, ElapsedEventArgs e)
        {
            phaseTimeFast--;
            if (phaseTimeFast <= 0)
            {
                phaseTimeFast = 0;
                phaseTimerFast.Stop();
            }
        }

        /// <summary>
        /// Decreasing timer function (second display)
        /// </summary>
        /// <param name="time"></param>
        public static void DecreasingTimerChapSelect(int time)
        {
            phaseTime = time;
            phaseTimer = new System.Timers.Timer();
            phaseTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            phaseTimer.Interval = 1000;
            phaseTimer.Enabled = true;
        }

        /// <summary>
        /// Decreasing timer function (pixel display)
        /// </summary>
        /// <param name="time"></param>
        /// <param name="interval"></param>
        public static void DecreasingTimerChapSelectFast(int time, int interval)
        {
            phaseTimeFast = time;
            phaseTimerFast = new System.Timers.Timer();
            phaseTimerFast.Elapsed += new ElapsedEventHandler(OnTimedEventFast);
            phaseTimerFast.Interval = interval;
            phaseTimerFast.Enabled = true;
        }
    }
}
