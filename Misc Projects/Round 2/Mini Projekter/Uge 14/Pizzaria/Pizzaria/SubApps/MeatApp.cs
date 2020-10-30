using System;
using System.Windows.Forms;
using Pizzaria.PizzaElements;

namespace Pizzaria.SubApps
{
    public partial class MeatApp : SubApp
    {
        public MeatApp(Ingredient ingredient) 
            : base(ingredient)
            => InitializeComponent();

        #region CheckChanged Events
        private void CheckPepperoni_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckSkinke_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckBacon_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckKylling_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckOksekød_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckCotailPølser_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckKebab_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        private void CheckTun_CheckedChanged(object sender, EventArgs e) => HandleChecked(sender as CheckBox);
        #endregion

        private void ButtonSelect_Click(object sender, EventArgs e) => SelectClicked();
    }
}
