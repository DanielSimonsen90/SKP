using Common.Entities;
using LoginDatabase;
using LoginDatabase.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoginSystemDB
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        private readonly Login _user;
        private readonly ILoginRepository _loginRepository;
        private readonly IMessageRepository _messageRepository;

        public ChatPage(ILoginRepository loginRepository, Login user, LoginContext loginContext)
        {
            InitializeComponent();
            _user = user;
            _loginRepository = loginRepository;
            _messageRepository = new MessageRepository(loginContext);
        }

        private void DeleteLogin_Click(object sender, RoutedEventArgs e)
        {
            var response = MessageBox.Show("Are you sure you want to delete your login?", "WAAAAAIT", MessageBoxButton.YesNo);
            if (response == MessageBoxResult.No) return;

            _loginRepository.RemoveLogin(_user);
            MessageBox.Show("Your login has been removed", "Login removal executed.");
            ToLoginPage();
        }

        #region Send message
        private void Send_Click(object sender, RoutedEventArgs e) => SendMessage(ChatBox.Text);
        private void ChatBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) SendMessage(ChatBox.Text);
            else if (e.Key == Key.Escape) ToLoginPage();
        }
        private void SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            var newMessage = _messageRepository.AddMessage(new Message()
            {
                Author = _user.Username,
                Content = message
            });

            MessageContainer.Text += $"{newMessage.Timestamp}\n[{newMessage.Author}]: {newMessage.Content}\n";
            ChatBox.Text = "";
        }
        #endregion

        private void MessageContainer_Loaded(object sender, RoutedEventArgs e)
        {
            var allMessages = _messageRepository.GetAllMessages();
            MessageContainer.Text = "";
            foreach (Message message in allMessages)
                MessageContainer.Text += $"{message.Timestamp}\n[{message.Author}]: {message.Content}\n";

        }

        private void ToLoginPage()
        {
            MainWindow main = new MainWindow();
            main.Show();
            (this.Parent as Window).Close();
        }
    }
}
