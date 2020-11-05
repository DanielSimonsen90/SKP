using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Dancord
{
    /// <summary>
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class ConsoleWindow : Window
    {
        public ConsoleWindow()
        {
            InitializeComponent();
            Log("Application started.");
        }

        public void Log(string message, params object[] args) => FormatLog(LogTypes.LOG, message, args);
        public void Warn(string message, params object[] args) => FormatLog(LogTypes.WARN, message, args);
        public void Error(string message, params object[] args) => FormatLog(LogTypes.ERROR, message, args);
        public void PopoutError(string message, string title, MessageBoxButton btnType)
        {
            Error(message);
            MessageBox.Show(message, title, btnType);
        }

        public void Clear() => Clear("Console was cleared.");
        public void Clear(string ownMessage)
        {
            TBLog.Text = string.Empty;
            Log(ownMessage);
        }

        private void FormatLog(LogTypes type, string message, params object[] args)
        {
            TBLog.Foreground = type == LogTypes.ERROR ? Brushes.Yellow : Brushes.Black;
            TBLog.Background = type == LogTypes.LOG ? Brushes.White : type == LogTypes.LOG ? Brushes.Yellow : Brushes.Red;
            TBLog.Text += FormatMessage(type, message, args);
        }
        private string FormatMessage(LogTypes type, string message, params object[] args)
        {
            StringBuilder result = new StringBuilder().Append($"{DateTime.Now.ToLocalTime()} | [{type}]: {message}");

            if (args.Length > 0)
            {
                args.ToList().ForEach(a => result.Append($"{nameof(a)}, "));
                result = new StringBuilder().Append(result.ToString().Substring(0, result.Length - 2));
            }
            return result.ToString() + "\n";
        }
        private enum LogTypes { LOG, WARN, ERROR }
    }
}
