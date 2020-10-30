using System;
using System.Windows.Controls;

namespace WatchProject.BluePrints
{
    /// <summary>
    /// Base class to help formatting watches that inherits this
    /// </summary>
    internal abstract class WatchFormatting
    {
        /// <summary>
        /// Format string to format the time
        /// </summary>
        public string format = "HH:mm:ss";
        /// <summary>
        /// Textblock display - shows <see cref="TextDisplay"/> information
        /// </summary>
        protected TextBlock display;
        /// <summary>
        /// What to display on <see cref="display"/>.Text
        /// </summary>
        /// <returns></returns>
        public abstract string TextDisplay();
        /// <summary>
        /// Code to run every time the timer ticks
        /// </summary>
        public virtual void Timer_Tick(object sender, EventArgs e) => display.Text = TextDisplay();
    }
}