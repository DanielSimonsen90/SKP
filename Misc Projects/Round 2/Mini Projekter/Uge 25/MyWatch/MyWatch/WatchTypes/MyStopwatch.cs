using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Threading;
using WatchProject.BluePrints.Interfaces;

namespace WatchProject.WatchTypes
{
    /// <summary>
    /// Stopwatch how you'd expect it to work
    /// </summary>
    internal class MyStopwatch : BasicWatch, IStartable
    {
        /// <summary>
        /// Stopwatch to keep track of... the stopwatch..
        /// </summary>
        private readonly Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// Last lap time
        /// </summary>
        private TimeSpan lastLap;

        public MyStopwatch(TextBlock display, Dispatcher dispatcher) : base(display, dispatcher, "HH.mm.ss,ff")
        {
            format = "HH.mm.ss,ff";
            CreateTime(delegate { display.Text = TextDisplay(); }, Timer_Tick);
            Time.Interval = TimeSpan.FromMilliseconds(1);
        }

        #region IStartable
        /// <summary>
        /// Determines whether stopwatch starts or stops
        /// </summary>
        public void StartStopClicked(Button button)
        {
            //Starts/Stops depending on stopwatch.IsRunning - also updates StartStopButton to Start or Stop, again depending on stopwatch.IsRunning
            switch (!stopwatch.IsRunning)
            {
                case true: Start(); button.Content = "Stop"; return;
                case false: Stop(); button.Content = "Start"; return;
            }
        }
        /// <summary>
        /// Starts the Stopwatch
        /// </summary>
        public void Start() => stopwatch.Start();
        /// <summary>
        /// Laps from when last <see cref="endTime"/> was set
        /// </summary>
        /// <returns>Timespan between <see cref="DateTime.Now"/> - <see cref="endTime"/></returns>
        public string Lap()
        {
            //If display text is default, return nothing
            if (display.Text == "00.00.00") return null;

            //If lastLap is not set
            if (lastLap == new TimeSpan(0))
                lastLap = stopwatch.Elapsed + stopwatch.Elapsed;

            //Define result
            string result = ToTextDisplay((stopwatch.Elapsed - lastLap).ToString());

            //Update lastLap to new lap
            lastLap = stopwatch.Elapsed;

            //Replace the first - with nothing cus I can't math 
            return result.Contains("-") ? result.Replace("-", "") : result;
        }
        /// <summary>
        /// Stops the stopwatch
        /// </summary>
        /// <returns>Returns timespan between <see cref="DateTime.Now"/> and <see cref="startTime"/></returns>
        public void Stop() => stopwatch.Stop();
        /// <summary>
        /// Resets the stopwatch
        /// </summary>
        public void Reset()
        {
            //If stopwatch isn't running, it shouldn't reset
            if (!stopwatch.IsRunning && display.Text == "00.00.00,000") return;

            //Remeber if it's running or not
            bool Running = stopwatch.IsRunning;

            //Reset variables
            stopwatch.Reset();
            lastLap = new TimeSpan(0);

            //If stopwatch was running before .Reset() was called, start it again
            if (Running)
                stopwatch.Start();
        }
        #endregion

        #region Overrides
        public override void Timer_Tick(object sender, EventArgs e) => display.Text = TextDisplay();
        /// <summary>
        /// Time elapsed since start
        /// </summary>
        /// <returns></returns>
        public override string TextDisplay() => ToTextDisplay(stopwatch.Elapsed.ToString());
        /// <summary>
        /// Fixes formatting to display for <see cref="display"/>.Text
        /// </summary>
        /// <param name="value">value to substring and replace</param>
        /// <returns></returns>
        public string ToTextDisplay(string value)
        {
            try { return value.Substring(0, 12).Replace('.', ',').Replace(':', '.'); }
            catch { return value.Replace(':', '.') == "00.00.00" ? "00.00.00,000" : value.Replace(':', '.'); }
        }
        #endregion
    }
}
