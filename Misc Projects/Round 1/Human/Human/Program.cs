using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Kvinde kvinde = new Kvinde("kvinde");
            Console.WriteLine("Hello, my name is " + kvinde.Name);
            Console.WriteLine("I am object :)");
            Console.WriteLine("My one true purpose, is to stay in the kitchen and serve my master sandwiches.");
            Console.ReadKey();
        }
    }
}
