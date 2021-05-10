using System.Drawing;

namespace Pizzaria
{
    class Location
    {
        public readonly Point Position;
        public bool IsUsed = true;
        public Location(int x, int y) => Position = new Point(x, y);
    }
}
