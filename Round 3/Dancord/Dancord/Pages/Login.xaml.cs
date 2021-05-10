using Dancord.Classes;
using Dancord.Classes.Base;
using Dancord.Classes.Misc;
using Dancord.Pages;
using DanhoLibrary;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Dancord
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private static readonly BasicList<Login> Logins = new BasicList<Login>
        {
            new Login("admin", "admin")
        };
        public static int NextID => Logins != null ? Logins.Count : 0;

        private ConsoleWindow DancordConsole { get; }
        private MainWindow Main { get; }

        public LoginPage(MainWindow main)
        {
            InitializeComponent();
            this.Main = main;
            this.DancordConsole = this.Main.DancordConsole;
        }

        #region Event Handlers
        private void Login_Pressed(object sender, RoutedEventArgs e)
        {
            Login user = Logins.Find(login => login.CheckUsername(UsernameBox.Text));

            if (user != null && user.CheckPassword(PasswordBox.Text))
            {
                this.Main.UI.Navigate(new DancordPage(this.Main, user.User));
                this.Main.DancordConsole.Log($"\"{user.User.Name}\" ({user.User.ID}), successfully logged on.");
                return;
            }

            this.Main.DancordConsole.PopoutError(
                $"Unable to login: Incorrect {(user is null ? "username" : "password")}", 
                "Failed to login!", MessageBoxButton.OK
            );
            
            return;
        }
        private void CreateLogin_Pressed(object sender, RoutedEventArgs e)
        {
            string Unable = "Unable to create Login: ";

            if (UsernameBox.Text == string.Empty || PasswordBox.Text == string.Empty)
                DancordConsole.PopoutError(Unable + $"{(UsernameBox.Text == string.Empty ? "Username" : "Password")} is blank!", Unable.Substring(0, Unable.Length - 2), MessageBoxButton.OK);
            else if (Logins.Find(login => login.CheckUsername(UsernameBox.Text)) != null)
                DancordConsole.PopoutError(Unable + "Someone already has this username!", Unable.Substring(0, Unable.Length - 2), MessageBoxButton.OK);
            else 
            {
                Login newUser = new Login(UsernameBox.Text, PasswordBox.Text);
                Logins.Add(newUser);
                DancordConsole.Log($"Successfully created user \"{newUser.User.Name}\" ({newUser.User.ID})");
                DancordFileManager.Update("../../../Databases/logins.txt", newUser.ToJSON(), DancordConsole);
                Login_Pressed(sender, e);
            }
            return;
        }
        #endregion
    }
}
