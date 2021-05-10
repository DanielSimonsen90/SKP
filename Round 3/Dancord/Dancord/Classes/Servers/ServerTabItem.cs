using System.Windows.Controls;

namespace Dancord.Classes.Servers
{
    class ServerTabItem : TabItem
    {
        private Server Server { get; }

        public ServerTabItem(Server server)
        {
            this.Server = server;
            this.DataContext = this.Server;
            this.Header = this.Server.Name;
            this.ToolTip = $"{this.Server.Name} ({this.Server.ID})";
        }
    }
}
