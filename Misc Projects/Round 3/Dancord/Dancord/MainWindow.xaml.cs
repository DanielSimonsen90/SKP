using System.Windows;

namespace Dancord
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UI.Navigate(new Login());
        }
    }
}
