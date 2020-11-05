using Dancord.Classes.Servers;
using Dancord.Classes.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Dancord.Pages
{
    /// <summary>
    /// Interaction logic for Dancord.xaml
    /// </summary>
    public partial class DancordPage : Page
    {
        private MainWindow Main { get; }
        private User User { get; }

        public DancordPage(MainWindow main, User user)
        {
            InitializeComponent();

            this.Main = main;
            this.User = user;
            this.Main.Title = "[Hub] - Dancord";
            this.DataContext = this.User;

            LoadServers();
        }

        private void LoadServers() => this.User.Servers.All.Servers.ToList().ForEach(server =>
            ServersTabPanel.Children.Add(new ServerTabItem(server)));
    }
}
