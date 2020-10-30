using MyWatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WatchProject.BluePrints
{
    class MyAlarm
    {
        /// <summary>
        /// The time the alarm is set to
        /// </summary>
        public DateTime Time { get; private set; }
        /// <summary>
        /// Note to display when alarm goes off
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Whether this alarm will go off or not
        /// </summary>
        public bool Enabled = true;
        /// <summary>
        /// If this alarm will repeat going off on specific days
        /// </summary>
        public bool Repeated { get => repeat is null ? false : true; }
        private AlarmRepeat repeat;

        public MyAlarm(DateTime value) => Time = value;

        /// <summary> Displays alarm to UI </summary>
        /// <param name="onOffButtons">On/Off button from UI</param>
        /// <param name="repeatCheckBoxes">Repeat checkboxes from UI</param>
        /// <param name="hoursMinutesListBoxes">Hours & Minutes ListBoxes from UI</param>
        /// <param name="noteTextBox">Note TextBlock from UI</param>
        public void Display(Button[] onOffButtons, CheckBox[] repeatCheckBoxes, ListBox[] hoursMinutesListBoxes, TextBox noteTextBox)
        {
            //If button 0 is On, button 1 is off and vise versa
            onOffButtons[Enabled ? 0 : 1].IsEnabled = false;
            onOffButtons[Enabled ? 1 : 0].IsEnabled = true;
            //Listboxes are updated with Time values
            hoursMinutesListBoxes[0].SelectedItem = Time.Hour;
            hoursMinutesListBoxes[1].SelectedItem = Time.Minute;
            //noteTextBox's text = note
            noteTextBox.Text = Note;

            //If alarm is repeated
            if (Repeated)
                //Go through all repeat boxes
                foreach (CheckBox box in repeatCheckBoxes)
                    //If current box's day matches repeat.RepeatedDays
                    if (repeat.RepeatedDays.Contains(box.Content.ToString()))
                        //Turn its check on
                        box.IsChecked = true;
        }

        #region Repeat
        /// <summary>
        /// Sets alarm to repeat itself on specified days
        /// </summary>
        /// <param name="days">Specified days to repeat on</param>
        public void Repeat(params DayOfWeek[] days) => repeat = new AlarmRepeat(days);
        /// <summary>
        /// Goes through <paramref name="repeatBoxes"/> and sorts into <see cref="DayOfWeek"/> objects to repeat
        /// </summary>
        /// <param name="repeatBoxes">Boxes from UI</param>
        public void Repeat(CheckBox[] repeatBoxes)
        {
            List<DayOfWeek> Days = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday },
                Result = new List<DayOfWeek>();

            //Go through all repeatBoxes
            for (int x = 0; x < repeatBoxes.Length; x++)
                //If box is true
                if (repeatBoxes[x].IsChecked.Value)
                    //Add day to result
                    Result.Add(Days[x]);
            //Set repeat to result's elements
            Repeat(Result.ToArray());
        }
        /// <summary>
        /// If alarm is repeated on <paramref name="day"/>, returns true, else false
        /// </summary>
        /// <param name="day">Day alarm might be repeated on</param>
        /// <returns></returns>
        public bool RepeatedOn(DayOfWeek day) => repeat.RepeatedDays.Contains(day);
        #endregion

        #region Snooze
        /// <summary>
        /// Used when alarm's set time is now
        /// </summary>
        public void TimesUp()
        {
            //If alarm is repeated and user has yet to click "Yes" or "No", return to avoid MessageBox spam
            if (Repeated && repeat.Wait) return;

            //Call MessageBox to tell user time is up - Alarm time + (repeated days +) note
            switch (MessageBox.Show(ToString() + "\n\nSnooze?", Note is null ? $"Alarm for {Time.Hour}:{Time.Minute}" : Note, MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes: Snooze(); return;
                default: Enabled = Repeated; repeat.Wait = false; break;
            }
            //If repeated is true, wait until user No
            if (Repeated) repeat.Wait = true;
        }
        /// <summary>
        /// Adds 5 minutes to <see cref="Time"/> for snoozing
        /// </summary>
        private void Snooze() => Time = Time.AddMinutes(5);
        #endregion

        #region ToString()
        /// <summary>
        /// {Hour}:{Minute}
        /// (Repeated every {day | week | weekend})
        /// {Note}
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{GetTimeString()}{GetRepeated()}\n{Note}";
        /// <summary>
        /// Formats <see cref="Time"/> into double digits
        /// </summary>
        /// <returns></returns>
        private string GetTimeString() => string.Format("{0:00}:{1:00}", Time.Hour, Time.Minute);
        /// <summary>
        /// If <see cref="Repeated"/> is true, return <see cref="repeat.ToString"/> else string.Empty
        /// </summary>
        /// <returns>repeat.ToString or string.Empty</returns>
        private string GetRepeated() => !Repeated ? string.Empty : "\n" + repeat.ToString();
        #endregion

        #region Statics
        /// <summary>
        /// Converts specified ListBoxes into DateTime
        /// </summary>
        /// <param name="alarm_HoursListBox">Hours</param>
        /// <param name="alarm_MinutesListBox">Minutes</param>
        /// <returns>Returns DateTime object needed for MyAlarm.Time</returns>
        internal static DateTime GetDateTime(ListBox alarm_HoursListBox, ListBox alarm_MinutesListBox)
            => new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                int.Parse(alarm_HoursListBox.SelectedItem.ToString()),
                int.Parse(alarm_MinutesListBox.SelectedItem.ToString()), 0);
        /// <summary>
        /// Replaces <paramref name="template"/>'s Note & Repeated with selected UI elements
        /// </summary>
        /// <param name="template">MyAlarm object to base of</param>
        /// <param name="note">UI Note</param>
        /// <param name="repeats">UI Repeat Checkboxes</param>
        /// <returns>Modified template with new (Note) and/or new (Repeat)</returns>
        internal static MyAlarm GetAlarm(MyAlarm template, DateTime UITtime, TextBox note, CheckBox[] repeats)
        {
            //If Time changed
            if (template.Time.Hour != UITtime.Hour || template.Time.Minute != UITtime.Minute)
                template.Time = UITtime;

            //Note exists
            if (note.Text != "Insert an alarm note...")
                template.Note = note.Text;

            //Repeated
            if (repeats.AnyChecked())
                template.Repeat(repeats);
            return template;
        }
        #endregion
    }
}