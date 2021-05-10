using MIG.References;
using MIG.SQL;
using System.Collections.Generic;
using System.Linq;

namespace MIG
{
    internal static class CustomExtender
    {
        /// <summary>
        /// Returns either <paramref name="originalArray"/> or new array if <paramref name="originalArray"/> is too small
        /// </summary>
        public static string[] GetArray(string[] originalArray, string[] collection)
        {
            if (collection is null) return originalArray;
            if (originalArray.Length < collection.Length)
            {
                string[] NewArray = new string[collection.Length];
                for (int x = 0; x < NewArray.Length; x++)
                    NewArray[x] = originalArray[x];
                return NewArray;
            }
            return originalArray;
        }

        /// <summary>
        /// If Value is between ranges, returns true else false
        /// </summary>
        /// <param name="Value">If [0] < this && [1] > this</param>
        /// <returns></returns>
        public static bool CanContain(this int[] Ranges, int Value) => Ranges[0] <= Value && Value <= Ranges[1];

        /// <summary>
        /// For each index in returned list, are <paramref name="num"/> indexes
        /// </summary>
        /// <param name="num">Amount of indexes per array in returned list</param>
        /// <returns></returns>
        public static List<T[]> Split<T>(this T[] arr, int num)
        {
            if (arr.Length <= num) return new List<T[]> { arr };

            int Count = 1;
            List<T[]> Pages = new List<T[]>();
            List<T> Page = new List<T>();
            for (int x = 0; x < arr.Length; x++)
            {
                if (Count == num + 1)
                {
                    Pages.Add(Page.ToArray());
                    Page = new List<T>();
                    Count = 1;
                }
                Page.Add(arr[x]);
                Count++;
            }

            Pages.Add(Page.ToArray());
            return Pages;
        }

        public static string ValueAsString(this List<SQLData> List)
        {
            string result = string.Empty;
            foreach (SQLData element in List)
                result += $"{element.ToString()}";
            return result;
        }
    }
}
