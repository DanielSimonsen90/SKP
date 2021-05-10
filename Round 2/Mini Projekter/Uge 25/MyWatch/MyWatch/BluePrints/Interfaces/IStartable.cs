using System.Windows.Controls;

namespace WatchProject.BluePrints.Interfaces
{
    /// <summary>
    /// If class inherits this, it means the class needs a Start(), Stop(), Reset() and StartStopClicked() handler
    /// </summary>
    interface IStartable
    {
        /// <summary>
        /// Handles when Start/Stop is clicked and should run either <see cref="Start"/> or <see cref="Stop"/>
        /// </summary>
        /// <param name="sender">Button to edit to correct content when clicking</param>
        void StartStopClicked(Button sender);
        /// <summary>
        /// Starts the running time
        /// </summary>
        void Start();
        /// <summary>
        /// Stops the running time
        /// </summary>
        void Stop();
        /// <summary>
        /// Resets the set time period
        /// </summary>
        void Reset();
    }
}
