using Pizzaria.PizzaElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pizzaria.SubApps
{
    public class SubApp : Form
    {
        /// <summary>
        /// Final stuffing from private list
        /// </summary>
        public string[] Stuffing { get => List.ToArray(); }
        /// <summary>
        /// Stuffing limit provided by assignment
        /// </summary>
        public readonly int StuffingLimit = 4;
        /// <summary>
        /// Refer to this when messing with stuffing items inside <see cref="SubApp"/>!
        /// </summary>
        private readonly List<string> List = new List<string>();
        private readonly Ingredient Ingredient;

        /// <summary>
        /// If true, run <see cref="HandleChecked(CheckBox)"/> else skip it (used in <see cref="RemoveFromArr(string)"/>)
        /// </summary>
        private bool HandleCheckedCalled = true;

        public SubApp(Ingredient Ingredient) => this.Ingredient = Ingredient;

        /// <summary>
        /// Used in InitializeComponents() to check checkboxes which are in App's Dropdowns
        /// </summary>
        public void LoadCheckBoxes()
        {
            if (Ingredient is null) return;

            if (Ingredient.Value is null && Ingredient.ValueList is null)
            {
                if (Ingredient.Default is null)
                    SwitchCheck(Ingredient.DefaultList, true);
                else SwitchCheck(Ingredient.Default, true);
            }
            else
            {
                if (Ingredient.Value is null)
                    SwitchCheck(Ingredient.ValueList, true);
                else
                {
                    if (Ingredient.Value.Contains(','))
                    {
                        var TempList = Ingredient.Value.Split(',');
                        for (int x = 0; x < TempList.Length; x++)
                            if (TempList[x][0].Equals(' '))
                                TempList[x] = TempList[x].Substring(1, TempList[x].Length - 1);
                        SwitchCheck(TempList.ToList(), true);
                    }
                    else SwitchCheck(Ingredient.Value, true);
                }
            }
        }
        protected void SelectClicked()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #region Handlers
        public void HandleChecked(CheckBox Box)
        {
            if (!HandleCheckedCalled) return;

            if (AllChecked() && Box.Checked) //If all checked and another one is checked
                RemoveFromArr(List[0]);
            else if (!Box.Checked && Stuffing.Contains(Box.Text)) //If uncheck a checked, remove from arr
            { 
                RemoveFromArr(Box.Text); 
                return; 
            }

            List.Add(Box.Text);
        }
        private void RemoveFromArr(string text)
        {
            for (int x = 0; x < Stuffing.Length; x++)
                if (List[x].Equals(text))
                {
                    SwitchCheck(text, false);
                    List.Remove(List[x]);
                    return;
                }
        }

        /// <summary>
        /// Unchecks checkbox, matching its .Text with <paramref name="text"/>
        /// </summary>
        /// <param name="text">Text of Checkbox</param>
        private void SwitchCheck(string text, bool ToChecked)
        {
            HandleCheckedCalled = false;
            foreach (Control ctrl in Controls)
                if (ctrl is CheckBox && ctrl.Text.Equals(text))
                {
                    (ctrl as CheckBox).Checked = ToChecked;
                    if (!List.Contains(text)) List.Add(text);
                }
            HandleCheckedCalled = true;
        }
        private void SwitchCheck(List<string> arr, bool ToChecked)
        {
            HandleCheckedCalled = false;
            foreach (Control ctrl in Controls)
                if (ctrl is CheckBox && arr.Contains(ctrl.Text))
                {
                    (ctrl as CheckBox).Checked = ToChecked;
                    List.Add(ctrl.Text);
                }
            HandleCheckedCalled = true;
        }

        /// <summary>
        /// Goes through <see cref="List"/> and compares if all items are checked
        /// </summary>
        /// <returns>true if checked, false if there's enough space for more</returns>
        private bool AllChecked()
        {
            try
            {
                for (int x = 0; x < StuffingLimit; x++)
                    if (List[x] == string.Empty)
                        return false;
                return true;
            }
            catch (ArgumentOutOfRangeException) { return false; }
        }
        #endregion
    }
}
