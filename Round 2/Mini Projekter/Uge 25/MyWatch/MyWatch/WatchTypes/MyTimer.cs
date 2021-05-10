using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WatchProject.BluePrints.Interfaces;

namespace WatchProject.WatchTypes
{
    internal class MyTimer : BasicWatch, IStartable, IAddable<ListBox>
    {
        /// <summary>
        /// The timespan left of the timer
        /// </summary>
        private TimeSpan timeSpan;
        /// <summary>
        /// Stopwatch to keep track of <see cref="timeSpan"/>
        /// </summary>
        private readonly Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// Button that either says "Start" or "Stop" from main UI
        /// </summary>
        private readonly Button StartStopButton;
        /// <summary>
        /// Returns stopwatch.IsRunning
        /// </summary>
        public bool IsRunning => stopwatch.IsRunning;
        /// <summary>
        /// Value to display when using <see cref="ToString"/>
        /// </summary>
        public string Value;

        public MyTimer(TextBlock display, Dispatcher dispatcher, string format, Button startStopButton) : base(display, dispatcher, format)
        {
            CreateTime(delegate { Value = TextDisplay(); }, Timer_Tick);
            StartStopButton = startStopButton;
        }

        #region IAddable
        public void Add(params ListBox[] addedValues)
        {
            //Converts addedValues to a TimeSpan variable; temp
            TimeSpan temp = new TimeSpan(ValueConverter(addedValues[0]), ValueConverter(addedValues[1]), ValueConverter(addedValues[2]));

            //If timeSpan "is null", timeSpan = temp, else add temp to timeSpan
            timeSpan = timeSpan == new TimeSpan(0) ? temp : timeSpan.Add(temp);
        }
        public void Remove(params ListBox[] removedValues)
        {
            //If timeSpan "is not null", subtract removedValues from timeSpan
            if (timeSpan != new TimeSpan(0))
                timeSpan = timeSpan.Subtract(new TimeSpan(ValueConverter(removedValues[0]), ValueConverter(removedValues[1]), ValueConverter(removedValues[2])));
        }
        #endregion

        /// <summary>
        /// Converts <paramref name="box"/> into its contained number
        /// </summary>
        /// <param name="box"></param>
        /// <returns>int value of box.SelectedItem</returns>
        private int ValueConverter(ListBox box) => int.Parse(box.SelectedItem.ToString());

        #region IStartable
        public void StartStopClicked(Button sender)
        {
            //If no time specified, timer can't start
            if (timeSpan.Seconds is 0 && timeSpan.Minutes is 0 && timeSpan.Hours is 0) return;

            //Starts/Stops depending on stopwatch.IsRunning - also updates StartStopButton to Start or Stop, again depending on stopwatch.IsRunning
            switch (!stopwatch.IsRunning)
            {
                case true: Start(); sender.Content = "Stop"; return;
                case false: Stop(); sender.Content = "Start"; return;
            }
        }
        /// <summary>
        /// Runs <see cref="stopwatch"/>.Start()
        /// </summary>
        public void Start() => stopwatch.Start();
        /// <summary>
        /// Runs <see cref="stopwatch"/>.Stop()
        /// </summary>
        public void Stop() => stopwatch.Stop();
        /// <summary>
        /// Resets <see cref="timeSpan"/>, <see cref="stopwatch"/> & <see cref="StartStopButton"/>
        /// </summary>
        public void Reset()
        {
            timeSpan = new TimeSpan(0);
            stopwatch.Reset();
            StartStopButton.Content = "Start";
        }
        #endregion
        
        /// <summary>
        /// Resets display.Text, calls <see cref="Reset"/> and calls MessageBox.Show() telling user timer has ended
        /// </summary>
        private void AutoReset()
        {
            display.Text = "00:00:00";
            Reset();
            MessageBox.Show("Timer ended");
        }

        #region Overrides
        public override string ToString() => TextDisplay();
        /// <summary>
        /// Runs every tick from Time -- Autoresets if display contains a "-" -- <see cref="Value"/> is set to <see cref="TextDisplay"/>
        /// </summary>
        public override void Timer_Tick(object sender, EventArgs e)
        {
            if (display.Text.Contains("-"))
                AutoReset();
            Value = TextDisplay();
        }
        /// <summary>
        /// Returns the time left on timer as HH:mm:ss
        /// </summary>
        public override string TextDisplay()
        {
            TimeSpan Span = timeSpan - stopwatch.Elapsed;
            return string.Format("{0:00}:{1:00}:{2:00}", Span.Hours, Span.Minutes, Span.Seconds);
        }
        #endregion

    }
}
