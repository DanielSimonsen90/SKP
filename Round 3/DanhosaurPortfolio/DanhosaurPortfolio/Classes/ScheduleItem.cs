using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanhoLibrary;

namespace DanhosaurPortfolio.Classes
{
    public struct ScheduleItem
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public string Course { get; }

        public ScheduleItem(DateTime start, DateTime end, string course)
        {
            Start = start;
            End = end;
            Course = course;
        }
    }
    public struct Schedules
    {
        private static ScheduleItem[] Schedule => new ScheduleItem[]
        {
            new ScheduleItem(new DateTime(2007, 8, 8), new DateTime(2017, 6, 15), "Folkeskole"),
            new ScheduleItem(new DateTime(2017, 8, 8), new DateTime(2018, 6, 15), "10. klasse"),
            new ScheduleItem(new DateTime(2018, 8, 8), new DateTime(2019, 6, 28), "Grundforløb 1 & 2"),
            new ScheduleItem(new DateTime(2020, 1, 6), new DateTime(2020, 3, 13), "Hovedforløb 1"),
            new ScheduleItem(new DateTime(2020, 8, 3), new DateTime(2020, 10, 9), "Hovedforløb 2"),
            new ScheduleItem(new DateTime(2021, 4, 6), new DateTime(2021, 6, 18), "Hovedforløb 3"),
            new ScheduleItem(new DateTime(2021, 10, 11), new DateTime(2022, 12, 17), "Hovedforløb 4"),
            new ScheduleItem(new DateTime(2022, 9, 19), new DateTime(2022, 11, 25), "Hovedforløb 5"),
            new ScheduleItem(new DateTime(2023, 11, 6), new DateTime(2023, 12, 8), "Hovedforløb 6")
        };
        public static ScheduleItem WhereAmI()
        {
            //At hovedforløb
            foreach (ScheduleItem plan in Schedule)
            {
                //After start, before end
                if (plan.Start < DateTime.Now && DateTime.Now < plan.End)
                    return plan;
            }

            //At SKP
            for (int i = 1; i < Schedule.Length; i++)
            {
                //After end but before next start
                if (Schedule[i - 1].End < DateTime.Now && Schedule[i].Start > DateTime.Now)
                    return new ScheduleItem(
                        Schedule[i - 1].End.AddDays(1),
                        new DateTime(Schedule[i].Start.Year, Schedule[i].Start.Month, Schedule[i].Start.Day - 1),
                        "Skolepraktik"
                    );
            }
            //After Hovedforløb 6
            return new ScheduleItem(Schedule[^1].End, DateTime.Now.AddYears(10), "Educated and workin on Discord Bots");
        }
        public static string WhereAmI(Func<ScheduleItem, string> formatted) => formatted(WhereAmI());
        public static ScheduleItem[] Future => (from ScheduleItem item in Schedule
                                                where item.End > DateTime.Now
                                                select item).ToArray();
    }
    public static class DanhoExtender
    {
        public static string ToMyTime(this DateTime date) => $"{date.Day}/{date.Month}/{date.Year}";
    }
}
