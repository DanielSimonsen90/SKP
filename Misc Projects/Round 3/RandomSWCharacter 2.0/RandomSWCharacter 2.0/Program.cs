using System;

namespace RandomSWCharacter_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(new Character().GetInfo());
                Console.ReadKey(true);
            }
        }
    }
}
