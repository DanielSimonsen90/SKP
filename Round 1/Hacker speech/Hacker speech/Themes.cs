using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Translator
{
    class Themes
    {
        public Themes(Color buttonFore, Color buttonBack, Color BoxFore, Color BoxBack)
        {
            DropdownForeground = buttonFore;
            DropdownBackground = buttonBack;
            BoxForeground = BoxFore;
            BoxBackground = BoxBack;
        }

        #region Public properties
        public Color DropdownForeground { get; }
        public Color DropdownBackground { get; }
        public string ButtonText { get; }
        public Color BoxForeground { get; }
        public Color BoxBackground { get; }
        #endregion

        #region Public methods

        #endregion

    }
}
