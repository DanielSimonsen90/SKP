using System;
using System.Windows.Forms;
using Pizzaria.PizzaElements;

namespace Pizzaria.SubApps
{
    public partial class SpiceApp : SubApp
    {
        public SpiceApp(Ingredient ingredient) 
            : base(ingredient)
            => InitializeComponent();

        #region Checked Changed
        private void CheckKarry_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckKanel_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckSalt_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckPepper_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        #endregion

        private void ButtonSelect_Click(object sender, EventArgs e) => SelectClicked();
    }
}
