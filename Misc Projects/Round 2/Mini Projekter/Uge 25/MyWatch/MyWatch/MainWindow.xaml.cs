using System;
using System.Windows;
using System.Windows.Controls;
using WatchProject.BluePrints;
using WatchProject.WatchTypes;
using WatchProject.WatchTypes.Handlers;

namespace WatchProject
{
    public partial class MainWindow : Window
    {
        private readonly SuperWatch watch;
        public MainWindow()
        {
            InitializeComponent();
            watch = new SuperWatch(MainWatchDisplay, Dispatcher, "HH:mm:ss");
            MainWatchDisplay.Text = DateTime.Now.ToString(watch.format);
        }

        #region Stopwatch
        private void StopwatchTab_Loaded(object sender, RoutedEventArgs e) => 
            watch.Stopwatch = new MyStopwatch(StopwatchDisplay, Dispatcher);

        #region StartStop / Reset
        private void Stopwatch_StartStopButton_Click(object sender, RoutedEventArgs e) => watch.Stopwatch.StartStopClicked(sender as Button);
        private void Stopwatch_ResetButton_Click(object sender, RoutedEventArgs e)
        {
            watch.Stopwatch.Reset();
            LapContainer.Items.Clear();
        }
        #endregion

        private void Stopwatch_LapButton_Click(object sender, RoutedEventArgs e)
        {
            string LapTime = watch.Stopwatch.Lap();
            if (LapTime != null)
                LapContainer.Items.Add($"Lap {LapContainer.Items.Count + 1}: " + LapTime);
        }
        #endregion

        #region Timer
        private void TimerTab_Loaded(object sender, RoutedEventArgs e)
        {
            watch.Timers = new TimerHandler(Timer_Container, TimerDisplay);
            Timer_InternalAdd();
            //Set Minutes & Seconds ListBoxes
            for (int x = 0; x < 60; x++)
            {
                TimerMinutesInput.Items.Add(x.ToString());
                TimerSecondsInput.Items.Add(x.ToString());
            }
            //Set Hours ListBox
            for (int x = 0; x < 24; x++)
                TimerHoursInput.Items.Add(x.ToString());
            //Reset Indexes
            Timer_ResetSelectedIndexes();
            //Put Container Index at 0 for default row
            Timer_Container.SelectedIndex = 0;
        }

        #region Add/Remove
        #region Individual Timer
        private void Timer_AddButton_Click(object sender, RoutedEventArgs e) => Timer_AddOrRemove('a');
        private void Timer_RemoveButton_Click(object sender, RoutedEventArgs e) => Timer_AddOrRemove('r');
        /// <summary>
        /// Adds or removes user input from Timer
        /// </summary>
        /// <param name="c">Determines whether to add or remove to Timer - [a | r] expected</param>
        private void Timer_AddOrRemove(char c)
        {
            try
            {
                //Depending on c, add or remove SelectedIndex with UI values
                switch (c)
                {
                    case 'a': watch.Timers[Timer_Container.SelectedIndex].Add(TimerHoursInput, TimerMinutesInput, TimerSecondsInput); break;
                    case 'r': watch.Timers[Timer_Container.SelectedIndex].Remove(TimerHoursInput, TimerMinutesInput, TimerSecondsInput); break;
                }
                //Reset SelectedIndexes
                Timer_ResetSelectedIndexes();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        #endregion

        #region Timer list
        private void Timers_AddRemoveResetButton_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Content)
            {
                //Adds new Timer to rows
                case "New Row": Timer_InternalAdd(); break;

                //Removes selected row from watch.Timers & Timer_Container.Items
                case "Remove Selected Row": 
                    watch.Timers.Remove(watch.Timers[Timer_Container.SelectedIndex]);
                    Timer_Container.Items.RemoveAt(Timer_Container.SelectedIndex);
                    break;

                //Clears watch.Timers & Timer_Container.Items - then adds a new row
                case "Reset List":
                    watch.Timers.Clear();
                    Timer_Container.Items.Clear();
                    Timer_InternalAdd();
                    break;
            }
        }
        /// <summary>
        /// Adds new Timer to watch.Timers & Timer_Container.Items
        /// </summary>
        private void Timer_InternalAdd()
        {
            watch.Timers.Add(new MyTimer(TimerDisplay, Dispatcher, "HH:mm:ss", Timer_StartStopButton));
            Timer_Container.Items.Add(watch.Timers[watch.Timers.Length - 1]);
        }
        #endregion

        #endregion

        #region StartStop / Reset
        /// <summary>
        /// Run inner StartStopClicked
        /// </summary>
        private void Timer_StartStopButton_Click(object sender, RoutedEventArgs e) => 
            watch.Timers[Timer_Container.SelectedIndex].StartStopClicked(sender as Button);
        /// <summary>
        /// Resets selected Timer
        /// </summary>
        private void Timer_ResetButton_Click(object sender, RoutedEventArgs e) => watch.Timers[Timer_Container.SelectedIndex].Reset();
        #endregion

        /// <summary>
        /// Sets H|M|S.SelectedIndex to 0
        /// </summary>
        private void Timer_ResetSelectedIndexes() =>
            TimerHoursInput.SelectedIndex = 
                TimerMinutesInput.SelectedIndex = 
                    TimerSecondsInput.SelectedIndex = 0;
        private void Timer_Container_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Remember SelectedIndex
            if (Timer_Container.SelectedIndex == -1)
                Timer_Container.SelectedIndex = watch.Timers.CurrentIndex;
            watch.Timers.CurrentIndex = Timer_Container.SelectedIndex;

            //Update StartStopButton
            try { Timer_StartStopButton.Content = watch.Timers[Timer_Container.SelectedIndex].IsRunning ? "Stop" : "Start"; }
            catch { }
            
        }
        /// <summary>
        /// Pointless button looks good but does nothing so don't click it
        /// </summary>
        private void PointlessButton_Click(object sender, RoutedEventArgs e) => 
            MessageBox.Show("Excuse me why do you click me..? I'M POINTLESS", "Pointless Button", MessageBoxButton.OK);
        #endregion

        #region Alarm
        private CheckBox[] RepeatBoxes;

        private void Alam_Loaded(object sender, RoutedEventArgs e)
        {
            //New handler
            watch.Alarms = new AlarmHandler();
            //Set Hours listbox items
            for (int x = 0; x < 24; x++)
                Alarm_HoursListBox.Items.Add(x);
            //Set Minutes listbox items
            for (int x = 0; x < 60; x++)
                Alarm_MinutesListBox.Items.Add(x);

            //Create RepeatBoxes containing Mon, Tue, Wed etc CheckBoxes
            RepeatBoxes = new CheckBox[]
            {
                Alarm_MondayCheckBox,
                Alarm_TuesdayCheckBox,
                Alarm_WednesdayCheckBox,
                Alarm_ThursdayCheckBox,
                Alarm_FridayCheckBox,
                Alarm_SaturdayCheckBox,
                Alarm_SundayCheckBox
            };

            //Reset UI
            Alarm_ResetUI();
        }

        #region Add/Save/Delete
        private void Alarm_HandleAddSaveDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as Button).Content.ToString())
                {
                    case "Add":
                        //Make a new alarm using UI values
                        MyAlarm newAlarm = MyAlarm.GetAlarm(
                            new MyAlarm(MyAlarm.GetDateTime(Alarm_HoursListBox, Alarm_MinutesListBox)),
                            MyAlarm.GetDateTime(Alarm_HoursListBox, Alarm_MinutesListBox),
                            Alarm_NoteTextBox,
                            RepeatBoxes
                        );

                        //Add alarm to inner list & to container list
                        Alarm_Container.Items.Add(newAlarm);
                        watch.Alarms.Add(newAlarm);
                        break;

                    case "Save":
                        //Get the selected alarm and update its values with UI values
                        MyAlarm editAlarm = MyAlarm.GetAlarm(
                            watch.Alarms[Alarm_Container.SelectedIndex],
                            MyAlarm.GetDateTime(Alarm_HoursListBox, Alarm_MinutesListBox),
                            Alarm_NoteTextBox,
                            RepeatBoxes
                        );

                        //Replace old values with new values
                        watch.Alarms[Alarm_Container.SelectedIndex] = editAlarm;
                        Alarm_Container.Items[Alarm_Container.SelectedIndex] = editAlarm.ToString();
                        break;

                    case "Delete":
                        //Find alarm to remove
                        MyAlarm removeAlarm = watch.Alarms[Alarm_Container.SelectedIndex];

                        //Remove alarm from inner list & container list
                        watch.Alarms.Remove(removeAlarm);
                        Alarm_Container.Items.Remove(removeAlarm);
                        break;
                }
            }
            //Somehow inner array doesn't have items, but Container does - clear container
            catch { Alarm_Container.Items.Clear(); }

            //Reset UI, as selected alarm was modified
            Alarm_ResetUI();
        }
        /// <summary>
        /// Resets UI to default values
        /// </summary>
        private void Alarm_ResetUI()
        {
            //Reset Container, Hours & Minutes
            Alarm_Container.SelectedIndex = -1;
            Alarm_HoursListBox.SelectedIndex = DateTime.Now.Hour;
            Alarm_MinutesListBox.SelectedIndex = DateTime.Now.Minute;

            //Reset RepeatBoxes
            foreach (CheckBox box in RepeatBoxes)
                box.IsChecked = false;

            //Reset note
            Alarm_NoteTextBox.Text = "Insert an alarm note...";

            //Reset On/Off button
            Alarm_OnButton.IsEnabled = Alarm_OffButton.IsEnabled = false;
        }
        #endregion

        /// <summary>
        /// Updates On/Off, modifies Alarm.Enabled depending if <paramref name="sender"/>'s content is On or Off
        /// </summary>
        /// <param name="sender">On/Off Button that called this</param>
        private void Alarm_OnOffButton_Click(object sender, RoutedEventArgs e) =>
            Alarm_OnButton.IsEnabled = 
                !(Alarm_OffButton.IsEnabled = 
                    watch.Alarms[Alarm_Container.SelectedIndex].Enabled = 
                        (sender as Button).Content.ToString() == "On" ? true : false);
        private void Alarm_Container_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Display selected alarm
                watch.Alarms[Alarm_Container.SelectedIndex]
                    .Display(
                        new Button[] { Alarm_OnButton, Alarm_OffButton },
                        RepeatBoxes, 
                        new ListBox[] { Alarm_HoursListBox, Alarm_MinutesListBox }, 
                        Alarm_NoteTextBox
                    );
                //Runs catch if no alarm selected
            } catch {}
        }
        #endregion

        #region Visual
        private void Visual_Loaded(object sender, RoutedEventArgs e) => 
            watch.Visual = new PrisonVisual(null, Dispatcher, string.Empty, Visual_Paper);
        #endregion
    }
}
