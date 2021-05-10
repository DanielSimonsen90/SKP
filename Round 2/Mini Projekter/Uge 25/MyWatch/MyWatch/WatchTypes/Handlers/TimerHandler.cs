using System.Windows.Controls;
using WatchProject.BluePrints;

namespace WatchProject.WatchTypes.Handlers
{
    /// <summary>
    /// Class to handle Collection of <see cref="MyTimer"/>
    /// </summary>
    internal class TimerHandler : Handler<MyTimer>
    {
        /// <summary>
        /// ListBox container of Timers
        /// </summary>
        private readonly ListBox Container;
        /// <summary>
        /// Selected timer displays here
        /// </summary>
        private readonly TextBlock SelectedDisplay;
        /// <summary>
        /// Current index selected
        /// </summary>
        public int CurrentIndex;

        public TimerHandler(ListBox Container, TextBlock SelectedDisplay)
        {
            this.Container = Container;
            this.SelectedDisplay = SelectedDisplay;
        }

        /// <summary>
        /// Updates all the timers to display the new time left
        /// </summary>
        public void UpdateTimers()
        {
            //Remember SelectedIndex, as it resets every time Time_Tick() has run
            Container.SelectedIndex = (CurrentIndex == -1) ? 0 : CurrentIndex;
            //SelectedDisplay.Text updates depending on which timer is selected
            SelectedDisplay.Text = this[Container.SelectedIndex].ToString();
            //Update the other times
            for (int x = 0; x < Container.Items.Count; x++)
                Container.Items[x] = this[x].ToString();
            //Remember CurrentIndex
            Container.SelectedIndex = CurrentIndex;
        }
    }
}
