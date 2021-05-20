using DanhosaurPortfolio.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using DanhoLibrary.Extensions;

namespace DanhosaurPortfolio.Pages
{
    public class PlanModel : PageModel
    {
        public Me Me = new Me();

        public void OnGet()
        {
        }

        public ScheduleItem[] Plan
        {
            get
            {
                List<ScheduleItem> SKP = new List<ScheduleItem>();
                for (int i = 1; i < Schedules.Future.Length; i++)
                {
                    ScheduleItem before = Schedules.Future[i - 1];
                    ScheduleItem after = Schedules.Future[i];

                    SKP.Add(new ScheduleItem(
                        before.End.AddDays(1),
                        new DateTime(after.Start.Year, after.Start.Month, after.Start.Day - 1),
                        "Skolepraktik"
                    ));
                }

                ScheduleItem whereAmI = Schedules.WhereAmI();
                IList<ScheduleItem> range = whereAmI.Course == Schedules.Future[0].Course ? 
                    new List<ScheduleItem>().AddRange(Schedules.Future, SKP) : 
                    new List<ScheduleItem>()
                        .AddRange<ScheduleItem>(new List<ScheduleItem>() { whereAmI })
                        .AddRange(Schedules.Future, SKP);

                return range
                    .OrderBy(a => a.Start.Ticks)
                    .ToArray();
            }
        }
    }
}
