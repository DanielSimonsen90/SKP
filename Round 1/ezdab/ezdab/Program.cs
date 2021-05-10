using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ezdab
{
    class Program
    {
        public static void Dab(string dab)
        {
            Console.WriteLine(dab.PadLeft(121));
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Dab(".o.");
                Dab("_o_");
                Dab("_o/");
                Dab("<o/");
                Dab("\\o/");
                Dab("\\o>");
                Dab("\\o/");
                Dab("_o_");
            }
        }
    }
}
