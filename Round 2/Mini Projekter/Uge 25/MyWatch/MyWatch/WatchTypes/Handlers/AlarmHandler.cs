using System;
using WatchProject.BluePrints;

namespace WatchProject.WatchTypes.Handlers
{
    /// <summary>
    /// Class to handle my collection of <see cref="MyAlarm"/>
    /// </summary>
    class AlarmHandler : Handler<MyAlarm>
    {
        /// <summary>
        /// Checks if any alarms match the current time
        /// </summary>
        /// <returns>Alarm if one matches current time, else returns null</returns>
        public MyAlarm AlarmCheck()
        {
            //For each alarm in innerList
            foreach (MyAlarm alarm in innerList)
                //If enabled, hour & minute matches now
                if (alarm.Enabled && alarm.Time.Hour == DateTime.Now.Hour && alarm.Time.Minute == DateTime.Now.Minute)
                {
                    //If alarm is repeated - is it repeated on this day? If repeated but not today, continue
                    if (alarm.Repeated && !alarm.RepeatedOn(DateTime.Now.DayOfWeek))
                        continue;
                    //Return alarm if not repeated or repeated on this day
                    return alarm;
                }
            return null;
        }
        /// <summary>
        /// If any alarms match now, call alarm.TimesUp(), else do nothing
        /// </summary>
        public void CheckAlarms()
        {
            if (IsEmpty) return;

            MyAlarm Alarm = AlarmCheck();
            if (Alarm != null)
                Alarm.TimesUp();
        }
    }
}
