using DanhoLibrary;
using MIG.Ideas;
using MIG.Ideas.LookingFor;
using MIG.References.Reference;
using MIG.SQL;
using System;

namespace MIG
{
    class Program
    {
        public static LFIdea LFIdea = new LFIdea();
        private static int Key = 1;

        static void Main()
        {
            while (true)
            {
                Console.Clear();

                if (!Menu.UI(ref LFIdea))
                    continue;

                Idea idea = LFIdea.Used.AnyTrue() ? LFIdea : new Idea();

                while (Key != 0)
                    Key = SQLData.SaveIdea(idea);
            }
        }
    }
}
