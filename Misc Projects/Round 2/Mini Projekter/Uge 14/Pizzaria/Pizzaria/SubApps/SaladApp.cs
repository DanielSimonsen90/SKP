using System;
using System.Windows.Forms;
using Pizzaria.PizzaElements;


namespace Pizzaria.SubApps
{
    public partial class SaladApp : SubApp
    {
        public SaladApp(Ingredient ingredient) 
            : base(ingredient)
            => InitializeComponent();

        #region Checked Changed
        private void CheckSalat_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckTomat_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckAgurk_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckPepperfrugt_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckAnanas_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        #endregion

        private void ButtonSelect_Click(object sender, EventArgs e) => SelectClicked();
    }
}
