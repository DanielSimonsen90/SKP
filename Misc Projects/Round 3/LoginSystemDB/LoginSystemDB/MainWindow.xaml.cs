using System;
using Common.Entities;
using System.Windows;
using LoginDatabase.Interfaces;
using LoginDatabase.Repositories;
using System.Data.Entity;
using LoginDatabase;
using DanhoLibrary;
using LoginDatabase.Exceptions;
using System.Windows.Input;

namespace LoginSystemDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoginContext loginContext = new LoginContext();
        private readonly ILoginRepository LoginRepository;
        public MainWindow()
        {
            InitializeComponent();
            LoginRepository = new LoginRepository(loginContext);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //insert login yes
                LoginRepository.AddLogin(LoginNullOrEmptyCheck());
                MessageBox.Show("Created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login loginCheck = LoginNullOrEmptyCheck();
                Login login = LoginRepository.GetLogin(loginCheck.Username, loginCheck.Password);

                ChatPage chat = new ChatPage(LoginRepository, login, loginContext);
                this.Content = chat;
                this.Title = "Simonsen Techs • Chat";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private Login LoginNullOrEmptyCheck()
        {
            string username = UsernameTextBlock.Text;
            if (string.IsNullOrEmpty(username)) throw new InvalidLoginException(InvalidLoginException.ExceptionTypes.InvalidUsername, "Please provide a username!");
            else if (string.IsNullOrEmpty(password)) throw new InvalidLoginException(InvalidLoginException.ExceptionTypes.InvalidPassword, "Please provide a password!");
            return new Login()
            {
                Username = username,
                Password = password
            };
        }

        #region Password Stuff
        private string password = "";
        private void PasswordTextBlock_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try { if (PasswordTextBlock.Text[PasswordTextBlock.Text.Length - 1] == '*') return; }
            catch 
            {
                if (string.IsNullOrEmpty(PasswordTextBlock.Text))
                    password = "";
                return; 
            }
            password += PasswordTextBlock.Text[PasswordTextBlock.Text.Length - 1];

            var cursorPos = PasswordTextBlock.CaretIndex;
            char[] PasswordChars = PasswordTextBlock.Text.ToCharArray();
            for (int i = 0; i < PasswordChars.Length; i++)
                PasswordChars[i] = '*';
            
            PasswordTextBlock.Text = PasswordChars.Join("");
            PasswordTextBlock.CaretIndex = cursorPos;
        }
        private void PasswordTextBlock_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Login_Click(null, null);
        }
        #endregion
    }
}
