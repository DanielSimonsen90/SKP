using System;
using System.Windows.Controls;
using System.Windows.Threading;
using WatchProject.BluePrints;
using WatchProject.WatchTypes;
using WatchProject.WatchTypes.Handlers;

namespace WatchProject.WatchTypes
{
    /// <summary>
    /// Watch able to tell current time, use stopwatch, use timer, or set alarm
    /// </summary>
    internal class SuperWatch : BasicWatch
    {
        #region Watch Types
        public MyStopwatch Stopwatch;
        public TimerHandler Timers;
        public AlarmHandler Alarms;
        public PrisonVisual Visual;
        #endregion

        public SuperWatch(TextBlock display, Dispatcher dispatcher, string format) 
            : base(display, dispatcher, format) 
            => CreateTime(delegate { this.display.Text = TextDisplay(); }, Timer_Tick);

        /// <summary>
        /// Updates main display with DateTime.Now, while also checking if any timers are done or if any a
        /// </summary>
        public override void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);

            Timers.UpdateTimers();
            Alarms.CheckAlarms();
        }
    }
}
