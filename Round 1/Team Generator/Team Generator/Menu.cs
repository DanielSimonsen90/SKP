using System;
using System.Windows.Forms;

namespace Team_Generator
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ChoiceOWButton_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Overwatch OWForm = new Overwatch();
            OWForm.Show();
        }

        private void ChoicePKMNButton_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Pokémon PKMNForm = new Pokémon();
            PKMNForm.Show();
        }
    }
}
