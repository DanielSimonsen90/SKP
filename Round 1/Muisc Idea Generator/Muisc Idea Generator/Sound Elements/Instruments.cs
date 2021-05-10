using System;

namespace Muisc_Idea_Generator
{
    class Instruments
    {
        public Instruments(bool Piano, bool Guitar, bool Strings, bool Horns)
        {
            this.Piano = Piano;
            this.Guitar = Guitar;
            this.Strings = Strings;
            this.Horns = Horns;
        }

        #region Variables
        private bool Piano { get; set; }
        private bool Guitar { get; set; }
        private bool Strings { get; set; }
        private bool Horns { get; set; }
        #endregion

        /// <summary>
        /// Get which instruments are true
        /// </summary>
        /// <param name="SongName"></param>
        public void GetInstruments()
        {
            Console.WriteLine("-=: Instruments :=-");
            if (Piano)
                Console.WriteLine("It contains Piano");
            if (Guitar)
                Console.WriteLine("It contains Guitar");
            if (Strings)
                Console.WriteLine("It contains Strings");
            if (Horns)
                Console.WriteLine("It contains Horns");
        }
    }
}