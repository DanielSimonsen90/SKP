using System;
using System.Windows.Controls;
using System.Windows.Threading;
using WatchProject.BluePrints;

namespace WatchProject.WatchTypes
{
    /// <summary>
    /// Basica watch - used as template for other watch types
    /// </summary>
    internal abstract class BasicWatch : WatchFormatting
    {
        /// <summary>
        /// Dispatcher to create <see cref="Time"/>
        /// </summary>
        protected Dispatcher dispatcher;
        /// <summary>
        /// Variable to keep track of time
        /// </summary>
        public DispatcherTimer Time;

        public BasicWatch(TextBlock display, Dispatcher dispatcher, string format)
        {
            this.display = display;
            this.format = format;
            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// Creates the DispatcherTimer
        /// </summary>
        /// <param name="handler">Eventhandler as callback</param>
        protected void CreateTime(EventHandler handler, EventHandler Timer_Tick)
        {
            //Initialize Time
            Time = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, handler, dispatcher);
            //If Timer_Tick is specified, Time.Tick should run that, else go by default Timer_Tick
            Time.Tick += Timer_Tick is null ? this.Timer_Tick : Timer_Tick;
        }

        public override string ToString() => TextDisplay();
        /// <summary>
        /// Converts DateTime.Now to specified format
        /// </summary>
        /// <returns>DateTime.Now to specified format as string</returns>
        public override string TextDisplay() => DateTime.Now.ToString(format);
    }
}
