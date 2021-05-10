using Dancord.Classes.Misc;
using System;
using System.IO;
using System.Windows;

namespace Dancord
{
    public partial class MainWindow : Window
    {
        private readonly object x = new object();
        public ConsoleWindow DancordConsole;

        public MainWindow()
        {
            InitializeComponent();
            DancordConsole = new ConsoleWindow();
            DancordConsole.Hide();

            MakeDatabases();
            UI.Navigate(new LoginPage(this));
        }

        private void MakeDatabases()
        {
            DancordFileManager.Create("servers", DancordConsole);
            DancordFileManager.Create("logins", DancordConsole);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F12)
                if (DancordConsole.IsVisible) DancordConsole.Hide();
                else DancordConsole.Show();
        }
    }
}
