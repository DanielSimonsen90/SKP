using System;
using Common.Entities;
using System.Windows;
using LoginDatabase.Interfaces;
using LoginDatabase.Repositories;
using System.Data.Entity;
using LoginDatabase;

namespace LoginSystemDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILoginRepository LoginRepository;
        private readonly LoginContext loginContext = new LoginContext();
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
                LoginRepository.AddLogin(new Login() /*Replace me pls*/);
                MessageBox.Show("Created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login login = LoginRepository.GetLogin(_globalLogin.Username, _globalLogin.Password);
                MessageBox.Show($"[Username]: {_globalLogin.Username}\n[Password]: {_globalLogin.Password}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login login = LoginRepository.GetLogin(_globalLogin.Username, _globalLogin.Password);
                LoginRepository.RemoveLogin(login);
                MessageBox.Show("Removed Login");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }
    }
}
