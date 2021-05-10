using System;
using System.Linq;
using System.Windows.Controls;

namespace MyWatch
{
    public static class CustomExtender
    {
        /// <summary>
        /// Checks if <paramref name="caller"/> can contain the items of <paramref name="arr"/>
        /// </summary>
        /// <param name="caller">DayOfWeek[] that called this method</param>
        /// <param name="arr">Array to compare to caller</param>
        /// <returns>If <paramref name="arr"/> has an item <paramref name="caller"/> doesn't have, returns false, else true</returns>
        public static bool Contains(this DayOfWeek[] caller, params DayOfWeek[] arr)
        {
            foreach (DayOfWeek day in arr)
                if (!caller.Contains(day.ToString()))
                    return false;
            return true;
        }

        /// <summary>
        /// Checks if <paramref name="caller"/> contains <paramref name="value"/> in array
        /// </summary>
        /// <param name="caller">DayOfWeek[] that called this method</param>
        /// <param name="value">string value to use .Contains</param>
        /// <returns>If <paramref name="caller"/> contains <paramref name="value"/> return true, else false</returns>
        public static bool Contains(this DayOfWeek[] caller, string value) =>
            (from DayOfWeek day in caller select day.ToString()).ToList().Contains(value);

        /// <summary>
        /// If <paramref name="caller"/> contains any checked checkboxes, returns true else false
        /// </summary>
        public static bool AnyChecked(this CheckBox[] caller)
        {
            foreach (var item in caller)
                if (item.IsChecked.Value)
                    return true;
            return false;
        }
    }
}
