using System;
using System.Collections.Generic;

namespace Pizzaria.PizzaElements
{
    public class Ingredient
    {
        #region Variables
        public string[] Choices;
        public List<string> ValueList, DefaultList;
        public string Value, Default;
        #endregion

        #region Constructors
        /// <summary>
        /// String value of Default
        /// </summary>
        /// <param name="Default">Index of Choices</param>
        /// <param name="Choices">Static choices from Elements</param>
        public Ingredient(string[] Choices, int Default)
        {
            this.Default = Choices[Default];
            this.Choices = Choices;
        }

        /// <summary>
        /// String[] value of DefaultArr
        /// </summary>
        /// <param name="DefaultArr"></param>
        /// <param name="Choices"></param>
        public Ingredient(string[] Choices, params int[] Defaults)
        {
            DefaultList = new List<string>();
            foreach (int defval in Defaults)
                DefaultList.Add(Choices[defval].ToString());
            this.Choices = Choices;
        }

        /// <summary>
        /// Initialize DefaultArr
        /// </summary>
        public Ingredient(string[] Choices, bool InitList)
            : this(Choices)
            => DefaultList = new List<string>();

        /// <summary>
        /// Set Ingredient Choices
        /// </summary>
        /// <param name="Choices"></param>
        public Ingredient(params string[] Choices) 
            => this.Choices = Choices;
        #endregion

        public override string ToString()
        {
            string Result = string.Empty;
            if (Value is null && ValueList is null)
            {
                if (DefaultList != null && DefaultList.Count > 0)
                {
                    foreach (string item in DefaultList)
                        Result += $"{item}, ";
                    return Result.Substring(0, Result.Length - 2);
                }
                return Default;
            }
            else if (ValueList != null)
            {
                foreach (string item in ValueList)
                    if (!item.Equals(string.Empty))
                        Result += $"{item}, ";
                try { return Result.Substring(0, Result.Length - 2); }
                catch (ArgumentOutOfRangeException) { return Default; }
            }
            return Value;
        }
    }
}
