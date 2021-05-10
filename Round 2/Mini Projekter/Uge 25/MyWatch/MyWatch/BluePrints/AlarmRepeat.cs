using MyWatch;
using System;
using System.Linq;

namespace WatchProject.BluePrints
{
    class AlarmRepeat
    {
        /// <summary>
        /// Repeated days
        /// </summary>
        public DayOfWeek[] RepeatedDays;
        /// <summary>
        /// Wait variable to avoid MessageBox spam
        /// </summary>
        public bool Wait = false;

        public AlarmRepeat(DayOfWeek[] repeatedDays) => RepeatedDays = repeatedDays;

        /// <summary>
        /// If <see cref="RepeatedDays"/> contains Mon, Tue, Wed, Thu, Fri and not Sat & Sun, true else false
        /// </summary>
        private bool WeekDaysOnly() => RepeatedDays.Contains(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday) && !RepeatedDays.Contains(DayOfWeek.Saturday, DayOfWeek.Sunday);
        /// <summary>
        /// If <see cref="RepeatedDays"/> contains Sat & Sun, and not Mon, Tue, Wed, Thu & Fri
        /// </summary>
        private bool WeekendsOnly() => RepeatedDays.Contains(DayOfWeek.Saturday, DayOfWeek.Sunday) && !RepeatedDays.Contains(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday);
        /// <summary>
        /// If <see cref="RepeatedDays"/> contains all days of week
        /// </summary>
        private bool AllDays() => RepeatedDays.Contains(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday);

        /// <summary>
        /// Returns "Repeated every" + "weekday" | "weekend" | "day" | [specific day(s)]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "Repeated every ";
            //Return if no specific day(s)
            try { return result += AllDays() ? "day" : WeekDaysOnly() ? "weekday" : WeekendsOnly() ? "weekend" : throw new Exception("Specific days"); }
            //If specific day(s)
            catch (Exception e)
            {
                //If something messed up somehow, throw error
                if (e.Message != "Specific days") throw e;

                //Cycle through RepeatedDays and add ", " to end of string
                foreach (DayOfWeek day in RepeatedDays) result += day + ", ";
                //return specific day(s)
                return result.Substring(0, result.Length - 2);
            }
        }
    }
}
