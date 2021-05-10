using System;
using System.Collections.Generic;

namespace Idea_Generator
{
    class Idea
    {
        public Idea()
        {
            SetVariables();
        }

        #region Variables
        #region Constructor Values
        public string[][] Genres { get; set; }
        public string[] AllArtists { get; set; }

        static int[,] Tempo { get; set; }
        static string[,] Drums { get; set; }
        static string[] Synths { get; set; }
        static string[] SynthEffects { get; set; }
        static string[] Instruments { get; set; }
        static bool SynthsInGenre = true;
        #endregion

        #region Global Variables
        private Random rand;
        private static int RandomOne, RandomTwo, RandomThree;
        #endregion

        #region Idea Variables
        private string IdeaGenre;
        private int IdeaTempo;
        private string ReferenceArtist;
        private string IdeaDuration;
        #endregion

        #region Wanted Variables
        public string WholeName;
        public string[] SongName;
        public string[] WantedItem { get; set; }
        public bool[] WantedItems { get; set; }
        #endregion
        #endregion

        #region Set stuff
        void SetVariables()
        {
            #region Genres
            string[] BigRoom = { "Big Room", "Spinnin' Records" };
            string[] Bounce = { "Bootleg", "Bounce", "Melbourne Bounce" };
            string[] DrumNStuff = { "Drumstep", "Drum n' Bass" };
            string[] Dubstep = { "Dubstep", "Melodic Dubstep" };
            string[] Future = { "Future Bass", "Future Funk", "Future House", "Future Bounce" };
            string[] Electro = { "Electro", "Electroswing", "Pre-Teen" };
            string[] General = { "General EDM", "EDM Trap", "Electrio", "Pop", "Psytrance", "Trap/Hip-Hop" };
            string[] Hype = { "Eurodance", "Hands Up", "Hardcore", "Hardstyle" };
            string[] House = { "Deep House", "House", "Melodic House", "Tropical House" };
            string[] ProgressiveHouse = { "Progressive House", "Progressive Dream", "Progressive Pop", "NCS Style" };
            string[] ElectroHouse = { "Electro-House", "Taking Electro literal", "Dudu dudu" };
            string[] OldSchool = { "Downtempo", "Synthwave" };
            string[] ClassicGenres = { "Acoustic", "Country", "Rock, Metal, etc", "Lo-Fi" };

            string[][] TempGenre = { BigRoom, Bounce, DrumNStuff, Dubstep, Future, Electro, General,
                Hype, House, ProgressiveHouse, ElectroHouse, OldSchool, ClassicGenres };
            Genres = TempGenre;
            #endregion

            #region Tempo
            int[,] TempTempo =
            {
                //Bootleg    Bounce    Melbourne   Big Room   Spinnin'   Drumstep      DnB       Dubstep     Mel. Dub.   Fut. Bass  Fut. Funk
                {128,140}, {125, 175}, {126,128}, {126,150}, {125,131}, {110, 175}, {160, 180}, {125, 174}, {105, 174}, {140, 170}, {90, 132},
                //Fut. Haus Fut. Bounce  Electro   Elec-swing   Pre-teen   General EDM  EDM Trap   Electrio   Eurodance    Hands Up    Hardcore
                {120, 160}, {125, 128}, {100, 130}, {90, 128}, {110, 140}, {110, 140}, {95, 170}, {100, 175}, {126, 155}, {128, 170}, {150, 180},
                //Hardstyle Deep House    House     Prog. House Prog. Dream  Prog. Pop   NCS Style  Elec-Haus  Lit. Elec.   Dudu dudu   Mel. House
                {150, 170}, {120, 130}, {120, 130}, {120, 135}, {110, 130}, {125, 130}, {128, 128}, {90, 175}, {128, 130}, {100, 130}, {128, 140},
                //Trop. Haus Downtempo  Synthwave     Pop     Psytrance   Acoustic    Country   Rock/Metal  Trap/Hip Hop Lo-Fi
                {100, 128}, {100, 130}, {90, 133}, {75, 140}, {138, 145}, {80, 130}, {70, 120}, {80, 180}, {135, 145}, {70, 100}
            };

            Tempo = TempTempo;
            #endregion

            #region Artist
            //Big room: DVBBS, Martin Garrix, Matt Watkins, R3HAB
            //Spinnin: Bassjackers, DVBBS, Vicetone
            //Bounce: Ude af Kontrol
            //Drumstep: Krewella
            //Dubstep: Knife Party, Krewella, Pegboard Nerds, Skrillex, Zomboy
            //Mel. Dubstep: Krewella, OMFG, Panda Eyes, Pegboard Nerds, Tristam
            //Electro: Stephen Walking, Stonebank
            //Electro-Swing: Proleter
            //Pre-Teen: Tristam
            //EDM Trap: Marshmello
            //Electrio: Krewella, Skrillex
            //Eurodance: Basshunter, Mikkel Christiansen
            //Hands Up: DJ Gollum, Italobrothers, Joey Moe
            //Hardcore: AI Storm, Daniel Simonsen, Nightcore, S3RL, Scott Brown, Stonebank, Technikore
            //Hardstyle: Da Tweekaz, Stonebank
            //House: Zedd
            //Progressive House: Ahrix, Atef, Avicii, Daniel Simonsen, Marcus Mouya, Vicetone
            //Progressive Dream: 3LAU, Ahrix, Daniel Simonsen, Mako, Vicetone
            //Progressive Pop: Avicii, Calvin Harris
            //Electro-House: Ahrix, Alan Walker, Daniel Simonsen, Lensko
            //Dudu dudu: Ahrix, Alan Walker, K-391
            //Melodic House: Tobu
            //Topical House: Kygo
            //Synthwave: FM-84, SelloRekt/LA Dreams
            //Pop: Flo Rida, Lukas Graham, NerdOut, Panic!, SIO, TØP
            //Rock: After Forever, Brian Tuey, FOB, MCR, Panic!, SIO, The Material

            AllArtists = new string[] {"3LAU", "After Forever", "Ahrix", "Al Storm", "Alan Walker", "Atef", "Avicii", "Basshunter", "Bassjackers", "Brian Tuey", "Calvin Harris", "Da Tweekaz", "Daniel Simonsen",
            "DJ Gollum", "DVBBS", "Fall Out Boy", "Flo Rida", "FM-84", "Italobrothers", "Jochen Miller", "Joey Moe", "K-391", "Knife Party", "Krewella", "Kygo", "Lensko", "Lukas Graham", "Mako", "Marcus Mouya",
            "Mikkel Christiansen", "My Chemical Romance", "NerdOut", "Nightcore", "OMFG", "Panda Eyes", "Panic! At The Disco", "Pegboard Nerds", "Proleter", "R3HAB", "S3RL", "Scott Brown", "SelloRekt / LA Dreams",
            "Set It Off", "Skrillex", "Stephen Walking", "Stonebank", "Technikore", "The Material", "Tobu", "Tristam", "Twenty One Pilots", "Ude af Kontrol", "Vicetone", "Zedd", "Zomboy"};

            #endregion

            #region Drums
            string[,] TempDrums = new string[5, 6];

            #region Kick[0]
            TempDrums[0, 0] = "Acoustic";
            TempDrums[0, 1] = "Punchy";
            TempDrums[0, 2] = "Lo-Fi";
            TempDrums[0, 3] = "Distorted";
            TempDrums[0, 4] = "Trance";
            TempDrums[0, 5] = "Clubby";
            #endregion

            #region Clap[1]
            TempDrums[1, 0] = "Tight";
            TempDrums[1, 1] = "Main";
            TempDrums[1, 2] = "Huge";
            #endregion

            #region Hi Hat[2]
            TempDrums[2, 0] = "Acoustic";
            TempDrums[2, 1] = "Tick";
            TempDrums[2, 2] = "Lo-Fi";
            TempDrums[2, 3] = "With low-end";
            #endregion

            #region Open Hat[3]
            TempDrums[3, 0] = "Acoustic";
            TempDrums[3, 1] = "House";
            TempDrums[3, 2] = "Club";
            #endregion

            #region Snare[4]
            TempDrums[4, 0] = "Acoustic";
            TempDrums[4, 1] = "House";
            TempDrums[4, 2] = "Lo-Fi";
            TempDrums[4, 3] = "Future Bass";
            TempDrums[4, 4] = "Trap";
            TempDrums[4, 5] = "Clubby";
            #endregion

            //Ride/Crash, Toms, Percussions

            Drums = TempDrums;
            #endregion

            #region Synths
            string[] TempSynths = { "Sine", "Saw", "Square", "Pulse", "HPulse", "Triangle", "Short", "Rhythmic", "Long" };
            Synths = TempSynths;
            #endregion

            #region Synth Effects
            //Reverb, Delay, LFO Automations
            string[] TempSynthEffects = { "Reverb", "Delay", "LFO Automation" };
            SynthEffects = TempSynthEffects;
            #endregion

            #region Instruments
            //Piano, Guitar, Strings, Horns
            string[] TempInstruments = { "Piano", "Guitar", "Strings", "Horns" };
            Instruments = TempInstruments;
            #endregion
        }

        void SetName(int p, string PreviousElement, string[] Main)
        {
            try
            {
                for (; p <= RandomThree; p++)
                {
                    RandomOne = rand.Next(100);
                    RandomTwo = rand.Next(Main.Length);
                    if (PreviousElement.ToLower() == Main[RandomTwo].ToLower())
                        SongName[p] = "";
                    else if (RandomOne >= 10)
                    {
                        PreviousElement = Main[RandomTwo];
                        SongName[p] = Main[RandomTwo] + " ";
                    }
                }
            }
            catch
            {

            }
        }
        void SetSongName()
        {
            string[] Main = {"Big", "Chunky", "Small", "Little", "The", "Black", "Blue", "Red", "White", "Winter", "Spring", "Summer", "Fall", "Addicted", "Adventure", "Admit", "After", "Alive",
            "All", "Alone", "You", "Back", "Bad", "Be", "Beautiful", "Better", "End", "Cold", "Cloud", "Color", "Come", "Death", "Different", "Don't", "Falling", "Far", "Feel", "Fire",
            "First", "Free", "Freak", "Ghost", "Girl", "Go", "God", "Gold", "Happy", "Hard", "Heart", "Heaven", "Hentai", "Heat", "Hero", "Home", "Empty", "Hope", "How", "I", "I'm",
            "In", "Illuminated", "Infinity", "It", "Kill", "Let", "Life", "Lonely", "Lost", "Love", "Memories", "Sun", "Moon", "Sword", "Shield", "My", "New", "Never", "No", "Old", "On",
            "Our", "Power", "Bussy", "Rain", "Run", "Running", "Round", "Square", "Sing", "Slow", "Stay", "Still", "Sweet", "Take", "This", "Time", "Together", "Untitled", "Waiting", "We",
                "Young", "Cum", "Experience", "Song"};

            RandomOne = 0;
            RandomTwo = 0;
            RandomThree = rand.Next(1, 5);
            int p = 0;
            SongName = new string[RandomThree];
            string PreviousElement = "monkey";
            try
            {
                SetName(p, PreviousElement, Main);
            }
            catch
            {
                SetName(p, PreviousElement, Main);
            }

            Console.Write("Name of song: ");
            for (int x = 0; x < SongName.Length; x++)
                WholeName += SongName[x];
            Console.WriteLine(WholeName);

        }
        void SetSongGenre()
        {
            RandomOne = rand.Next(Genres.Length);
            RandomTwo = rand.Next(Genres[RandomOne].Length);
            IdeaGenre = Genres[RandomOne][RandomTwo];
            Console.WriteLine($"Genre: {IdeaGenre}");

            if (RandomOne == 12)
                SynthsInGenre = false;
            else
                SynthsInGenre = true;
        }
        void SetSongTempo()
        {
            switch (IdeaGenre)
            {
                #region Bounce
                case "Bootleg":
                    IdeaTempo = rand.Next(Tempo[0, 0], Tempo[0, 1]);
                    break;
                case "Bounce":
                    IdeaTempo = rand.Next(Tempo[1, 0], Tempo[1, 1]);
                    break;
                case "Melbourne Bounce":
                    IdeaTempo = rand.Next(Tempo[2, 0], Tempo[2, 1]);
                    break;
                #endregion
                #region Big Room
                case "Big Room":
                    IdeaTempo = rand.Next(Tempo[3, 0], Tempo[3, 1]);
                    break;
                case "Spinnin' Records":
                    IdeaTempo = rand.Next(Tempo[4, 0], Tempo[4, 1]);
                    break;
                #endregion
                #region Drum n Stuff
                case "Drumstep":
                    IdeaTempo = rand.Next(Tempo[5, 0], Tempo[5, 1]);
                    break;
                case "Drum n' Bass":
                    IdeaTempo = rand.Next(Tempo[6, 0], Tempo[6, 1]);
                    break;
                #endregion
                #region Dubstep
                case "Dubstep":
                    IdeaTempo = rand.Next(Tempo[7, 0], Tempo[7, 1]);
                    break;
                case "Melodic Dubstep":
                    IdeaTempo = rand.Next(Tempo[8, 0], Tempo[8, 1]);
                    break;
                #endregion
                #region Future
                case "Future Bass":
                    IdeaTempo = rand.Next(Tempo[9, 0], Tempo[9, 1]);
                    break;
                case "Future Funk":
                    IdeaTempo = rand.Next(Tempo[10, 0], Tempo[10, 1]);
                    break;
                case "Future House":
                    IdeaTempo = rand.Next(Tempo[11, 0], Tempo[11, 1]);
                    break;
                case "Future Bounce":
                    IdeaTempo = rand.Next(Tempo[12, 0], Tempo[12, 1]);
                    break;
                #endregion
                #region Electro
                case "Electro":
                    IdeaTempo = rand.Next(Tempo[13, 0], Tempo[13, 1]);
                    break;
                case "Electroswing":
                    IdeaTempo = rand.Next(Tempo[14, 0], Tempo[14, 1]);
                    break;
                case "Pre-Teen":
                    IdeaTempo = rand.Next(Tempo[15, 0], Tempo[15, 1]);
                    break;
                #endregion
                #region General
                case "General EDM":
                    IdeaTempo = rand.Next(Tempo[16, 0], Tempo[16, 1]);
                    break;
                case "EDM Trap":
                    IdeaTempo = rand.Next(Tempo[17, 0], Tempo[17, 1]);
                    break;
                case "Electrio":
                    IdeaTempo = rand.Next(Tempo[18, 0], Tempo[18, 1]);
                    break;
                case "Pop":
                    IdeaTempo = rand.Next(Tempo[36, 0], Tempo[36, 1]);
                    break;
                case "Psytrance":
                    IdeaTempo = rand.Next(Tempo[37, 0], Tempo[37, 1]);
                    break;
                #endregion
                #region Hype
                case "Eurodance":
                    IdeaTempo = rand.Next(Tempo[19, 0], Tempo[19, 1]);
                    break;
                case "Hands Up":
                    IdeaTempo = rand.Next(Tempo[20, 0], Tempo[20, 1]);
                    break;
                case "Hardcore":
                    IdeaTempo = rand.Next(Tempo[21, 0], Tempo[21, 1]);
                    break;
                case "Hardstyle":
                    IdeaTempo = rand.Next(Tempo[22, 0], Tempo[22, 1]);
                    break;
                #endregion
                #region House
                case "Deep House":
                    IdeaTempo = rand.Next(Tempo[23, 0], Tempo[23, 1]);
                    break;
                case "House":
                    IdeaTempo = rand.Next(Tempo[24, 0], Tempo[24, 1]);
                    break;
                case "Melodic House":
                    IdeaTempo = rand.Next(Tempo[25, 0], Tempo[25, 1]);
                    break;
                case "Tropical House":
                    IdeaTempo = rand.Next(Tempo[26, 0], Tempo[26, 1]);
                    break;
                #endregion
                #region Progressive House
                case "Progressive House":
                    IdeaTempo = rand.Next(Tempo[27, 0], Tempo[27, 1]);
                    break;
                case "Progressive Dream":
                    IdeaTempo = rand.Next(Tempo[28, 0], Tempo[28, 1]);
                    break;
                case "Progressive Pop":
                    IdeaTempo = rand.Next(Tempo[29, 0], Tempo[29, 1]);
                    break;
                case "NCS Style":
                    IdeaTempo = rand.Next(Tempo[30, 0], Tempo[30, 1]);
                    break;
                #endregion
                #region Electro House
                case "Electro-House":
                    IdeaTempo = rand.Next(Tempo[31, 0], Tempo[31, 1]);
                    break;
                case "Taking Electro literal":
                    IdeaTempo = rand.Next(Tempo[32, 0], Tempo[32, 1]);
                    break;
                case "Dudu dudu":
                    IdeaTempo = rand.Next(Tempo[33, 0], Tempo[33, 1]);
                    break;
                #endregion
                #region Old School
                case "Downtempo":
                    IdeaTempo = rand.Next(Tempo[34, 0], Tempo[34, 1]);
                    break;
                case "Synthwave":
                    IdeaTempo = rand.Next(Tempo[35, 0], Tempo[35, 1]);
                    break;
                #endregion
                #region Classic Genres
                case "Acoustic":
                    IdeaTempo = rand.Next(Tempo[38, 0], Tempo[38, 1]);
                    break;
                case "Country":
                    IdeaTempo = rand.Next(Tempo[39, 0], Tempo[39, 1]);
                    break;
                case "Rock, Metal, etc":
                    IdeaTempo = rand.Next(Tempo[40, 0], Tempo[40, 1]);
                    break;
                case "Trap/Hip-Hop":
                    IdeaTempo = rand.Next(Tempo[41, 0], Tempo[41, 1]);
                    break;
                case "Lo-Fi":
                    IdeaTempo = rand.Next(Tempo[42, 0], Tempo[42, 1]);
                    break;
                default:
                    IdeaTempo = 420;
                    break;
                    #endregion
            }
            Console.WriteLine($"BPM: {IdeaTempo}");
        }
        void SetSongArtist(string Genre)
        {
            RandomOne = rand.Next(100);
            string[] ReferenceTracks;
            string ReferenceTrack = "Song";
            ReferenceArtist = "";
            if (RandomOne <= 40)
            {
                switch (Genre)
                {
                    #region Big Room
                    case "Bounce":
                        ReferenceArtist = "Ude af Kontrol";
                        ReferenceTracks = new string[]{ "Fuckboi", "Det Halve Ku' Være Nok", "Ta' Dine Sko Af", "Jantelov", "Næ", "Jumanji", "O.M.G", "Op A", "Snehvide med de 7 små poser", "ikk giv op",
                        "Fejre det hele", "Ku Godt", "Velsignet - Har det godt pt.2", "Den bedste Julesang Ever", "Douchebag", "Lækker Krop Grimt Fjæs", "Hælder op",
                            "Skru op", "Spiller Dum", "Moshpit", "3xK"};
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    case "Big Room":
                        RandomTwo = rand.Next(4);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Bassjackers";
                                ReferenceTracks = new string[] { "Derp", "Savior", "Wave Your Hands" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "R3HAB";
                                ReferenceTracks = new string[] { "Flashlight", "Tiger", "Won't Stop Rocking" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTrack.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Jochen Miller";
                                ReferenceTracks = new string[] { "Scope", "Turn It Up", "United" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTrack.Length)];
                                break;
                            default:
                                ReferenceArtist = "DVBBS";
                                ReferenceTracks = new string[] { "Immortal", "Pyramids", "This Is Dirty" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Spinnin Records":
                        RandomTwo = rand.Next(3);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "DVBBS";
                                ReferenceTracks = new string[] { "Immortal", "Pyramids", "This Is Dirty" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTrack.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Vicetone";
                                ReferenceTracks = new string[] { "Heartbeat", "I'm On Fire", "Pitch Black" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Bassjackers";
                                ReferenceTracks = new string[] { "Derp", "Savior", "Wave Your Hands" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    #endregion
                    #region Drum n Stuff
                    case "Drumstep":
                        ReferenceArtist = "Krewella";
                        ReferenceTracks = new string[] { "Surrender The Throne", "Come & Get It", "Say Goodbye" };
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    #endregion
                    #region Dubstep
                    case "Dubstep":
                        RandomTwo = rand.Next(5);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Knife Party";
                                ReferenceTracks = new string[] { "Power Glove", "Internet Friends", "Bonfire" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Krewella";
                                ReferenceTracks = new string[] { "This Is Not The End", "Play Hard", "Killin' It", "Can't Control Myself", "One Minute", "Feel Me", "One Minute (DotEXE Remix)" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Pegboard Nerds";
                                ReferenceTracks = new string[] { "This Is Not The End", "Gunpoint / 2012 (Det Derfor)", "Hero", "Self Destruct", "End Is Near", "We Are One" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '4':
                                ReferenceArtist = "Skrillex";
                                ReferenceTracks = new string[] {"Levels - Avicii (Skrillex Remix)", "Cinema - Benny Benassi (Skrillex Remix)", "Holdin' On - I See MONSTAS (Skrillex Remix)",
                                "Right In", "Bangarang", "Kyoto", "Summit", "First of the Year", "Rock N' Roll", "Kill EVERYBODY"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Zomboy";
                                ReferenceTracks = new string[] { "Here to Stay", "Nuclear", "City 2 City" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Melodic Dubstep":
                        RandomTwo = rand.Next(5);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Krewella";
                                ReferenceTracks = new string[] { "We Go Down", "Human" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "OMFG";
                                ReferenceTracks = new string[] { "Hello", "Ice Cream", "Yeah" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Panda Eyes";
                                ReferenceTracks = new string[] { "Galaxcia", "Immortal Flames", "Highscore", "KIKO", "Colorblind", "Lonely Island", "Opposite Side" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '4':
                                ReferenceArtist = "Pegboard Nerds";
                                ReferenceTracks = new string[] {"Far Too Close - Pegboard Nerds Remix", "Live for the Night - Pegboard Nerds Remix", "Bassline Kickin", "Emergency",
                                "Here It Comes", "Pressure Cooker", "Razor Sharp"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Tristam";
                                ReferenceTracks = new string[] { "Crave", "Far Away", "Extermination", "The Vine", "Till it's Over", "I Remember", "Too Simple", "Truth", "Razor Sharp" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    #endregion
                    #region Electro
                    case "Electro":
                        RandomTwo = rand.Next(2);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Stephen Walking";
                                ReferenceTracks = new string[] { "Ampersand", "Birthday Cake", "Full Grizzly", "It Came from Planet Earth", "One Man Moon Band", "Pizza Planet", "Top of the World" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Stonebank";
                                ReferenceTracks = new string[] { "Blast from the Past", "Step up", "The Entity" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Electro-Swing":
                        ReferenceArtist = "Proleter";
                        ReferenceTracks = new string[] { "April Showers", "Faidherbe Square", "It Don't Mean a Thing", "Can't Stop Me", "Throw It Back" };
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    case "Pre-Teen":
                        ReferenceArtist = "Tristam";
                        ReferenceTracks = new string[] { "I Remember", "Too Simple" };
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    #endregion
                    #region General EDM
                    case "EDM Trap":
                        ReferenceArtist = "Marshmello";
                        ReferenceTracks = new string[] { "Everyday", "Alone", "FRIENDS", "Happier", "Here With Me", "Summer", "Blocks", "Moving On", "Silence", "Keep It Mello", "Wolves" };
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    case "Electrio":
                        RandomTwo = rand.Next(2);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Krewella";
                                ReferenceTracks = new string[] { "Ring of Fire", "Live for the Night" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Skrillex";
                                ReferenceTracks = new string[] {"Cinema - Benny Benassi (Skrillex Remix)", "Holdin' On - I See MONSTAS (Skrillex Remix)",
                                "Right In", "Bangarang", "Kyoto", "Summit", "First of the Year", "Rock N' Roll", "Kill EVERYBODY"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    #endregion
                    #region Hype
                    case "Eurodance":
                        RandomTwo = rand.Next(2);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Basshunter";
                                ReferenceTracks = new string[] { "When You Leave [Numa Numa] (Basshunter Remix)", "DotA", "Now You're Gone", "All I ever Wanted", "I Can Walk On Water", "Boten Anna" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Mikkel Christiansen";
                                ReferenceTracks = new string[] { "Gøy På Landet", "Limited Edition", "Megos Alexandros", "Navy Seals", "Sains of Barthélemy", "StoreSlem", "Willy Nikkersen" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Hands Up":
                        RandomTwo = rand.Next(3);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "DJ Gollum";
                                ReferenceTracks = new string[] { "Handzup Isn't Dead", "Historisk (DJ Gollum Radio Edit)", "I'm a Passenger", "Poison", "Rockstar", "The Promiseland" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Italobrothers";
                                ReferenceTracks = new string[] {"Boom", "Colours Of The Rainbow", "Counting Down The Days", "Cryin' In The Rain", "Hasselhoff", "Heaven", "It Must Have Been Love", "Love Is On Fire",
                                "Moonlight Shadow", "Pandora", "Put Your Hands Up In The Air", "Radio Hardcore", "Sleep When We're Dead", "So Small", "Stamp On The Ground", "The Moon", "This Is Nightlife",
                                "Underwater World", "Upside Down", "Where Are You Now"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Joey Moe";
                                ReferenceTracks = new string[] { "Dobbeltslag", "Jorden Er Giftig", "Yo-Yo" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Hardcore":
                        RandomTwo = rand.Next(7);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Al Storm";
                                ReferenceTracks = new string[] { "Crash", "I Created A Monster!", "Cannibalism!", "Here 2 Invade" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Daniel Simonsen";
                                ReferenceTracks = new string[] { "Take Off", "Præsentation", "Abe-katten Carl" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Nightcore";
                                ReferenceTracks = new string[] { "Everytime We Touch - Nightcore Edit", "Fireworks", "Dreamers", "We Own The Night", "Rising - Nightcore Edit" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '4':
                                ReferenceArtist = "S3RL";
                                ReferenceTracks = new string[] {"Never Let You Go", "Take My Heart", "River Flows In You - S3RL Mix", "Neko Nation", "Adrenalized", "Again", "Al Capone", "All That I Need",
                                "And I'm Like", "Avaline", "Bass Slut", "Beat All the Odds", "Berserk", "Bff", "Candy", "Casual N00b", "Catchit", "Cherry Pop", "Chillcore", "Click Bait", "Crazy Ass Bitch",
                                "Da De da", "Eearth B", "Electric Sky", "Escape", "Feel the Melody", "Forbidden", "Forever", "Fugazi", "Galleriet", "Generic Holiday", "Genre Police", "Hentai", "I'll See You Again",
                                "Hypnotoad", "Inspiration", "It's This Again", "I Wanna Stay", "I Will Pick You up", "Jaded Af", "JP", "LA", "Let The Beat Go", "Like This", "Little Kandi Raver", "Misleading Title",
                                "Mr. Vain", "Mtc2", "Mtc Saga", "Mtc", "Music Is My Savior", "Mysten", "Next Time", "Nightcore This", "Nostalgic", "Now That I've Found You", "Old Stuff", "Operation Doomsday",
                                "Over the Rainbow", "Pika Girl", "Planet Rave", "Pretty Rave Girl", "Princess Bubbelgum", "Public Service Announcement", "Put Your Phones up", "Quack Pack", "R4v3 BOy", "Ravers Mashup",
                                "Can't Bring Me Down", "Rainbow Girl", "Request", "Nostalgic", "Scary Movie", "Self Titled", "Shoom", "Shoulder Boulders", "Silicon XX", "Sorority House", "Space Invader", "Space-Time",
                                "Speechless", "Spoiler Alert", "Starlight Starbright", "Summerbass", "Tell Me What You Want", "The Flying Dutchman", "The Perfect Rave", "The Power of Love of Power",
                                "Through the Years", "To My Dream", "Toxic", "Transformers", "Trillium", "Upper Hand", "Well, That Was Awkward", "What Is a DJ?", "When I Die", "When I'm There",
                                "Where DId You Go", "Whirlwind", "Yeah Science", "You're My SUperhero", "Press Play Walk Away", "My Girlfriend Is a Raver", "Blow The House", "Let It Go - S3RL Remix"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '5':
                                ReferenceArtist = "Scott Brown";
                                ReferenceTracks = new string[] { "Neckbreaker", "All About You", "Because of You", "Energized", "Taking Drug?", "Fly With You", "How Many Sukkas?", "Put Them Up", "The Spark", "To The Beat" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '6':
                                ReferenceArtist = "Stonebank";
                                ReferenceTracks = new string[] {"Cold Skin - Stonebank Remix", "All Night", "Be Alright", "By Your Side", "Lift You Up", "Moving On", "Ripped to Pieces", "Stronger", "The Only One",
                                "The Pressure", "Who's Got Your Love"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Technikore";
                                ReferenceTracks = new string[] { "Superhuman - Technikore & JTS Remix", "Pretty Rave Girl (Suae X Technikore Remix)", "Gang Beasts", "Worlds Collide", "Nervous", "Siren" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Hardstyle":
                        RandomTwo = rand.Next(2);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Da Tweekaz";
                                ReferenceTracks = new string[] { "On My Way - Da Tweekaz Remix", "Bring Me To Life", "How Far I'll Go", "Keep On Rockin'", "Letting Go", "Bad Habbit", "The Calling (Da Tweekaz Remix)" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Stonebank";
                                ReferenceTracks = new string[] { "The Only One", "Who's Got Your Love" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    #endregion
                    #region House
                    case "House":
                        ReferenceArtist = "Zedd";
                        ReferenceTracks = new string[] { "Break Free", "Good Thing", "I Want You To Know", "Beautiful Now" };
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    case "Progressive House":
                        RandomTwo = rand.Next(6);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Ahrix";
                                ReferenceTracks = new string[] { "A New Start", "Daydream", "Hope", "New Era", "Raising" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Atef";
                                ReferenceTracks = new string[] { "Abyss", "Away", "Promises", "Spectrum" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Avicii";
                                ReferenceTracks = new string[] { "Hey Brother", "I Could Be The One", "Levels", "Lonely Together", "The Nights", "Waiting For Love", "Wake Me Up", "Without You" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '4':
                                ReferenceArtist = "Daniel Simonsen";
                                ReferenceTracks = new string[] { "Exploring Beyond Limits", "Haunted", "Summer", "Toxicore", "What Mom Requested" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '5':
                                ReferenceArtist = "Marcus Mouya";
                                ReferenceTracks = new string[] { "Despair", "Stay With Me", "The Colors In Your Eyes" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Vicetone";
                                ReferenceTracks = new string[] { "Angels", "Catch Me", "Heat", "Hope", "I'm On Fire", "No Way Out", "Pitch Black", "What I've Waited for" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Progressive Dream":
                        RandomTwo = rand.Next(5);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "3LAU";
                                ReferenceTracks = new string[] { "How You Love Me", "Touch" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Ahrix";
                                ReferenceTracks = new string[] { "Daydream", "Dreams", "Evolving", "Pure", "New Era", "Relief", "Serenity", "Carpe Diem", "The Dreamer" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Daniel Simonsen";
                                ReferenceTracks = new string[] { "Next Level", "Awaiting", "Nearing the Ending", "Dreams" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '4':
                                ReferenceArtist = "Mako";
                                ReferenceTracks = new string[] { "I Won't Let You Walk Away", "Not Alone", "Smoke Filled Room" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Vicetone";
                                ReferenceTracks = new string[] { "Heartbeat", "Nothing Stopping Me", "United We Dance" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Progressive Pop":
                        RandomTwo = rand.Next(2);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Avicii";
                                ReferenceTracks = new string[] { "The Days", "The Nights", "Waiting For Love" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Calvin Harris";
                                ReferenceTracks = new string[] { "We'll Be Coming Back", "Drinking from the Bottle", "Let's Go", "Blame", "Outside", "Together", "Summer" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    #endregion
                    #region Electro-House
                    case "Electro-House":
                        RandomTwo = rand.Next(4);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Ahrix";
                                ReferenceTracks = new string[] { "Nova", "Euphoria", "Left Behind", "Forgiven", "Courage", "Ignite - Ahrix Remix" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Alan Walker";
                                ReferenceTracks = new string[] {"Different World", "Faded", "Ignite", "Sky", "On My Way", "Sing Me To Sleep", "The Spectre", "This Is Me - Alan Walker Relift",
                                "Stranger Things - Alan Walker Remix", "Legends Never Die - Alan Walker Remix", "Are You Lonely"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Daniel Simonsen";
                                ReferenceTracks = new string[] { "Worried", "Amplified", "Miracle" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Lensko";
                                ReferenceTracks = new string[] { "Cetus", "Circles", "Titsepoken" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Dudu dudu":
                        RandomTwo = rand.Next(3);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Ahrix";
                                ReferenceTracks = new string[] { "Moments", "Reborn", "Nova", "Never Alone" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Alan Walker";
                                ReferenceTracks = new string[] { "Fade", "Faded", "Force", "Spectre", "Play" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "K-391";
                                ReferenceTracks = new string[] { "Story Of Envy", "Electrode", "Electro House 2012", "Dream Of Something Sweet", "Play", "Summertime", "This Is Felicitas" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    #endregion
                    #region Other Houses
                    case "Melodic House":
                        ReferenceArtist = "Tobu";
                        ReferenceTracks = new string[] {"Tired - Steerner & Tobu Remix", "Blessing", "Candyland", "Climb", "Cloud 9", "Colors", "Floating", "Good Times", "Happy Ending", "Higher",
                        "Hope", "Infectious", "Life", "Magic", "Mesmerize", "Running Away", "Seven", "Sprinkles", "Sunburst", "Swweet Story", "You & I"};
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    case "Tropical House":
                        ReferenceArtist = "Kygo";
                        ReferenceTracks = new string[] { "Firestone", "Here For You", "Stay", "Stole the Show", "Younger - Kygo Remix" };
                        ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                        break;
                    #endregion
                    #region Remaining Genres
                    case "Synthwave":
                        RandomTwo = rand.Next(2);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "FM-84";
                                ReferenceTracks = new string[] { "Running in the Night", "Never Stop", "Neon Sunrise", "Outatime" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "SelloRekt / LA Dreams";
                                ReferenceTracks = new string[] { "Waves on the Pacific Coast", "Remnant", "A Dystopian Fixation" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Pop":
                        RandomTwo = rand.Next(6);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "Flo Rida";
                                ReferenceTracks = new string[] { "My House", "Whistle", "I Cry" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Lukas Graham";
                                ReferenceTracks = new string[] { "Lie", "7 Years", "The The World By Storm" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "NerdOut";
                                ReferenceTracks = new string[] { "Born for This", "I Need a Healer", "Shadow Finds You", "The Dragonblade" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '4':
                                ReferenceArtist = "Panic! At The Disco";
                                ReferenceTracks = new string[] {"Victorious", "Don't Threaten Me with a Good Time", "Emperor's New Clothes", "Crazy = Genius", "LA Devotee", "The Good, the Bad and the Dirty",
                                "House of Memories", "Say Amen (Saturday Night)", "Hey Look Ma, I Made It", "High Hopes", "Roaring 20s", "Dancing's Not a Crime", "Dying in LA", "Miss Jackson", "Vegas Lights"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '5':
                                ReferenceArtist = "Set It Off";
                                ReferenceTracks = new string[] {"Dad's Song", "Forever Stuck in Our Youth", "Why Worry", "Ancient History", "Duality", "Wolf in Sheep's Clothing", "Bad Guy", "Life Afraid", "Something New",
                                "Uncontainable", "Upside Down", "Diamond Girl", "Tug of War", "Admit it", "Hypnotized"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "Twenty One Pilots";
                                ReferenceTracks = new string[] { "Stressed Out", "Ride", "Heathens" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                    case "Rock":
                        RandomTwo = rand.Next(7);
                        switch (RandomTwo)
                        {
                            case '1':
                                ReferenceArtist = "After Forever";
                                ReferenceTracks = new string[] { "Discord", "Come", "Boundaries Are Open", "Living Shields", "Being Everyone", "Only Everything" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '2':
                                ReferenceArtist = "Brian Tuey";
                                ReferenceTracks = new string[] { "Lullaby Of A Deadman", "The One", "Beauty Of Annihialation", "Twilight", "Undone" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '3':
                                ReferenceArtist = "Fall Out Boy";
                                ReferenceTracks = new string[] {"Centuries", "Uma Thurman", "Immortals", "The Carpal Tunnel Of Love", "Thnks fr th Mmrs", "The Last Of The Real Ones", "The Pheonix",
                                "My Songs Know What You Did In The Dark", "Alone Together"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '4':
                                ReferenceArtist = "My Chemical Romance";
                                ReferenceTracks = new string[] { "Na Na Na", "Bulletproof Heart", "Planetary (GO!)", "The Only Hope For Me Is You", "Party Poison", "Welcome to the Black Parade", "Teenagers" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '5':
                                ReferenceArtist = "Panic! At The Disco";
                                ReferenceTracks = new string[] { "I Write Sins Not Tradgedies", "Death of a Bachelor", "Dancing's Not a Crime", "This Is Gospel", "Nicotine", "Girls / Girls / Boys", "The Ballad of Mona Lisa" };
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            case '6':
                                ReferenceArtist = "Set It Off";
                                ReferenceTracks = new string[] {"I'll Sleep When I'm Dead", "Nightmare", "Swan Song", "Plastic Promises", "Dream Catcher", "Freak Show", "Dad's Song", "I'd Rather Drown",
                                "Parters in Crime", "Kill the Lights", "Dancing With The Devil", "The Haunting", "N.M.E.", "Why Worry", "Ancient History", "Bleak December", "WWolf in Sheep's Clothing",
                                "For You Forever", "Killer In The Mirror", "Lonely Dance", "Hourglass", "Different Songs", "Go To Bed Angry", "Criminal Minds", "No Disrespect", "Stich Me Up", "Raose No Fool",
                                "I Want You (Gone)", "Midnight Thoughts"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                            default:
                                ReferenceArtist = "The Material";
                                ReferenceTracks = new string[] {"Life Vest", "Born to Make a Sound", "Tonight I'm Letting Go", "Bottles", "Gasoline", "Mistakes", "The One That Got Away", "Appearances",
                                "Let You Down", "What We Are", "The Only One"};
                                ReferenceTrack = ReferenceTracks[rand.Next(ReferenceTracks.Length)];
                                break;
                        }
                        break;
                        #endregion
                }
                if (ReferenceArtist != "")
                {
                    Console.WriteLine($"Try make it like {ReferenceArtist} would.");
                    Console.WriteLine($"You can take {ReferenceArtist}'s \"{ReferenceTrack}\" as an example.");
                    Console.WriteLine();
                }
            }
        }
        void SetSongDuration()
        {
            RandomOne = rand.Next(2, 5);
            RandomTwo = rand.Next(59);
            if (RandomTwo <= 9)
                IdeaDuration = RandomOne + ":0" + RandomTwo;
            else
                IdeaDuration = RandomOne + ":" + RandomTwo;
            Console.WriteLine($"The song needs to be around {IdeaDuration}");
        }
        void SetSongKey(out string Scale)
        {
            string[] Keys = { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
            RandomOne = rand.Next(Keys.Length);

            RandomTwo = rand.Next(2);
            if (RandomTwo == 1)
                Scale = "Major";
            else
                Scale = "Minor";

            Scale = Keys[RandomOne] + " " + Scale;
            Console.WriteLine($"The song should be in {Scale}.");
        }
        void SetSongDrums()
        {
            Console.WriteLine("-=: Drum layout :=-");
            string Kick, Clap, HiHat, OpenHat, Snare;
            Kick = Drums[0, rand.Next(5)];
            Clap = Drums[1, rand.Next(2)];
            HiHat = Drums[2, rand.Next(3)];
            OpenHat = Drums[3, rand.Next(2)];
            Snare = Drums[4, rand.Next(5)];

            Console.WriteLine("Kick: " + Kick);
            Console.WriteLine("Clap: " + Clap);
            Console.WriteLine("Hi Hat: " + HiHat);
            Console.WriteLine("Open Hat: " + OpenHat);
            Console.WriteLine("Snare: " + Snare);

            RandomOne = rand.Next(10);
            RandomTwo = rand.Next(10);
            if (RandomOne <= 2)
                Console.WriteLine("It needs Rides");
            if (RandomTwo <= 2)
                Console.WriteLine("It needs Crashes");
            if (RandomOne <= 7)
                Console.WriteLine("It needs Toms");
            if (RandomTwo <= 7)
                Console.WriteLine("It needs Percussions");
        }
        void SetSongSynths()
        {
            if (SynthsInGenre)
            {
                Console.WriteLine("-=: Synth Layout :=-");
                string[] SynthTypes = { "Chords", "Leads", "Arpeggios", "Bass" };

                for (int x = 0; x < SynthTypes.Length; x++)
                {
                    RandomOne = rand.Next(5);
                    RandomTwo = rand.Next(10);

                    Console.Write($"{SynthTypes[x]} should be a {Synths[RandomOne]} wave");
                    if (RandomTwo >= 7)
                    {
                        RandomTwo = rand.Next(5);
                        Console.WriteLine($", and mixed with a {Synths[RandomTwo]} wave.");
                    }
                    else
                        Console.WriteLine();

                    for (int y = 0; y < SynthEffects.Length; y++)
                    {
                        RandomOne = rand.Next(2);
                        if (RandomOne == 1)
                            Console.WriteLine($"The {SynthTypes[x]} should have the {SynthEffects[y]} effect.");
                    }
                    Console.WriteLine();
                }
            }
        }
        void SetSongInstruments()
        {
            Console.WriteLine("-=: Instruments :=-");
            for (int x = 0; x < Instruments.Length; x++)
            {
                RandomOne = rand.Next(2);
                if (RandomOne == 1)
                    Console.WriteLine($"It should have {Instruments[x]}");
            }
        }
        #endregion

        public Idea GenerateMoarMusic()
        {
            Idea Idea = new Idea();
            rand = new Random();

            #region SetSongMethods
            SetSongName();

            Console.WriteLine();

            SetSongGenre();

            SetSongTempo();

            SetSongArtist(IdeaGenre);

            SetSongDuration();

            SetSongKey(out string Scale);

            Console.WriteLine();

            SetSongDrums();

            Console.WriteLine();

            SetSongSynths();

            SetSongInstruments();

            Console.WriteLine();

            #endregion

            #region Wanted Items
            WantedItem = new string[] { IdeaGenre, ReferenceArtist, IdeaTempo.ToString(), Scale, WholeName };
            if (ReferenceArtist != "")
                WantedItems = new bool[] { true, true, true, true, true };
            else
                WantedItems = new bool[] { true, false, true, true, true };
            #endregion

            return Idea;
        }
    }
    class Program
    {
        #region Variables
        static ConsoleKey Choice;
        static bool Generate = false, LookingFor = false;

        static bool[] WantedItems = { false, false, false, false, false };
        static bool[] WantedWords;
        static string[] WantedItem = { "", "", "", "", "" };
        static List<string> WantedText = new List<string>();
        #endregion

        #region Methods
        
        #region Set WantedItem
        static string SetWantedItem(string item, int Index)
        {
            #region Variabels
            LookingFor = true;
            int InIndex = Index - 1;
            WantedItems[InIndex] = true;
            string Chose = "N/A";
            string[] HeadGenres = { "Big Room", "Bounce", "Drum n Stuff", "Dubstep", "Future", "Electro", "General", "Hype", "House", "Progressive House", "Electro-House", "Old School", "Classic Genres" };
            string[] Keys = { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
            Idea Template = new Idea();
            #endregion

            switch (Index)
            {
                #region Genre
                case 1:
                    Console.WriteLine($"Which of the following {item}s would you like to find?");
                    for (int x = 0; x < Template.Genres.Length; x++)
                        Console.WriteLine($"[{x + 1}]: {HeadGenres[x]}");
                    break;
                #endregion

                #region Artist
                case 2:
                    if (!WantedItems[0])
                        return SetArtist(Template, item, Index);
                    else
                    {
                        string[][][] Artists = ArtistsForGenre();
                        int IndexTwo = 0;
                        for (int x = 0; x < Template.Genres.Length; x++)
                        {
                            for (int y = 0; y < Template.Genres[x].Length; y++)
                            {
                                if (Template.Genres[x][y] == WantedItem[0])
                                {
                                    Index = x;
                                    IndexTwo = y;
                                }
                            }
                        }
                        return SetArtistWithGenre(item, Index, IndexTwo, Artists);
                    }
                #endregion

                #region BPM
                case 3:
                    Console.WriteLine("Write a number between 70 & 180");
                    Console.WriteLine();
                    return WantedItem[2] = Console.ReadLine();
                #endregion

                #region Scale
                case 4:
                    Console.WriteLine("Which Key would you like?");
                    for (int x = 0; x < Keys.Length; x++)
                        Console.WriteLine($"[{x + 1}]: {Keys[x]}");
                    break;
                    #endregion
            }

            Console.WriteLine();
            Index = System.Convert.ToInt32(Console.ReadLine()) - 1;

            if (item == "Genre")
                Chose = HeadGenres[Index];
            else if (item == "Scale")
                Chose = Keys[Index];

            Console.Clear();

            return WantedItem[InIndex] = SetSecondWantedItem(item, Index, Template, InIndex, Chose);
        }
        static void SetWantedItem(string item, List<string> list)
        {
            Console.WriteLine($"What {item} would you like to find?");
            string Word = Console.ReadLine();
            list.Add(Word);
            WantedWords = new bool[WantedText.Count];
            for (int x = 0; x < WantedWords.Length; x++)
                WantedWords[x] = false;
            LookingFor = true;
            if (WantedItems[4])
                WantedItem[4] += ", " + Word;
            else
                WantedItem[4] = Word;
            WantedItems[4] = true;
        }
        static string SetSecondWantedItem(string item, int Index, Idea Template, int InIndex, string Chose)
        {
            Console.WriteLine($"You chose \"{Chose}\"");
            Console.WriteLine("Choose an item of the following:");
            switch (item)
            {
                case "Genre":
                    for (int x = 0; x < Template.Genres[Index].Length; x++)
                        Console.WriteLine($"[{x + 1}]: {Template.Genres[Index][x]}");
                    WantedItem[InIndex] = Template.Genres[Index][System.Convert.ToInt32(Console.ReadLine()) - 1];
                    break;
                case "Scale":
                    Console.WriteLine("[1]: Major");
                    Console.WriteLine("[2]: Minor");
                    string Final = Console.ReadLine().ToLower();

                    if (Final == "Major" || Final == "1")
                        WantedItem[InIndex] = Chose + " Major";
                    else if (Final == "Minor" || Final == "2")
                        WantedItem[InIndex] = Chose + " Minor";
                    break;
            }
            return WantedItem[InIndex];
        }
        #endregion

        #region SetArtists
        static string SetArtist(Idea Template, string item, int Index)
        {
            Console.WriteLine($"Which of the following {item}s would you like to find?");
            for (int x = 0; x < Template.AllArtists.Length; x++)
                if (x < 9)
                    Console.WriteLine($"[0{x + 1}]: {Template.AllArtists[x]}");
                else
                    Console.WriteLine($"[{x + 1}]: {Template.AllArtists[x]}");
            Console.WriteLine();
            return WantedItem[Index - 1] = Template.AllArtists[System.Convert.ToInt32(Console.ReadLine()) - 1];
        }
        static string SetArtistWithGenre(string item, int Index, int IndexTwo, string[][][] Artists)
        {
            if (Artists[Index] == null)
                return "";

            Console.WriteLine($"Which of the following {item}s would you like to find?");

            for (int x = 0; x < Artists[Index][IndexTwo].Length; x++)
                if (x < 9)
                    Console.WriteLine($"[0{x + 1}]: {Artists[Index][IndexTwo][x]}");
                else
                    Console.WriteLine($"[{x + 1}]: {Artists[Index][IndexTwo][x]}");

            Console.WriteLine();

            return WantedItem[1] = Artists[Index][IndexTwo][System.Convert.ToInt32(Console.ReadLine()) - 1];
        }
        static string[][][] ArtistsForGenre()
        {
            #region Comments
            //Bounce: Ude af Kontrol
            //Big room: DVBBS, Martin Garrix, Matt Watkins, R3HAB
            //Spinnin: Bassjackers, DVBBS, Vicetone
            //Drumstep: Krewella
            //Dubstep: Knife Party, Krewella, Pegboard Nerds, Skrillex, Zomboy
            //Mel. Dubstep: Krewella, OMFG, Panda Eyes, Pegboard Nerds, Tristam
            //Electro: Stephen Walking, Stonebank
            //Electro-Swing: Proleter
            //Pre-Teen: Tristam
            //EDM Trap: Marshmello
            //Electrio: Krewella, Skrillex
            //Eurodance: Basshunter, Mikkel Christiansen
            //Hands Up: DJ Gollum, Italobrothers, Joey Moe
            //Hardcore: Al Storm, Daniel Simonsen, Nightcore, S3RL, Scott Brown, Stonebank, Technikore
            //Hardstyle: Da Tweekaz, Stonebank
            //House: Zedd
            //Progressive House: Ahrix, Atef, Avicii, Daniel Simonsen, Marcus Mouya, Vicetone
            //Progressive Dream: 3LAU, Ahrix, Daniel Simonsen, Mako, Vicetone
            //Progressive Pop: Avicii, Calvin Harris
            //Electro-House: Ahrix, Alan Walker, Daniel Simonsen, Lensko
            //Dudu dudu: Ahrix, Alan Walker, K-391
            //Melodic House: Tobu
            //Topical House: Kygo
            //Synthwave: FM-84, SelloRekt/LA Dreams
            //Pop: Flo Rida, Lukas Graham, NerdOut, Panic!, SIO, TØP
            //Rock: After Forever, Brian Tuey, FOB, MCR, Panic!, SIO, The Material
            #endregion
            string[] None = { "" };
            #region Definitions
            #region Big Room
            string[] BigRoom = { "DVBBS", "Martin Garrix", "Matt Watkins", "R3HAB" };
            string[] Spinnin = { "Bassjackers", "DVBBS", "Vicetone" };
            string[][] Category1 = { BigRoom, Spinnin };
            #endregion
            #region Bounce
            string[] Bootleg = None;
            string[] Bounce = { "Ude Af Kontrol" };
            string[] MelbourneBounce = None;
            string[][] Category2 = { Bootleg, Bounce, MelbourneBounce };
            #endregion
            #region Drum n' Stuff
            string[] Drumstep = { "Krewella" };
            string[] DnB = null;
            string[][] Category3 = { Drumstep, DnB };
            #endregion
            #region Dubstep
            string[] Dubstep = { "Knife Party", "Krewella", "Pegboard Nerds", "Skrillex", "Zomboy" };
            string[] MelDubstep = { "Krewella", "OMFG", "Panda Eyes", "Pegboard Nerds", "Tristam" };
            string[][] Category4 = { Dubstep, MelDubstep };
            #endregion
            #region Future Stuff
            string[] FutBass = None;
            string[] FutFunk = None;
            string[] FutHouse = None;
            string[] FutBounce = None;
            string[][] Category5 = { FutBass, FutFunk, FutHouse, FutBounce };
            #endregion
            #region Electro
            string[] Electro = { "Stephen Walking", "Stonebank" };
            string[] ElectroSwing = { "Proleter" };
            string[] PreTeen = { "Tristam" };
            string[][] Category6 = { Electro, ElectroSwing, PreTeen };
            #endregion
            #region General
            string[] GeneralEDM = None;
            string[] EDMTrap = { "Marshmello" };
            string[] Electrio = { "Krewella", "Skrillex" };
            string[] Pop = { "Flo Rida", "Lukas Graham", "NerdOut", "Panic! At The Disco", "Set It Off", "Twenty One Pilots" };
            string[] Psytrance = None;
            string[] TrapHipHop = None;
            string[][] Category7 = { GeneralEDM, EDMTrap, Electrio, Pop, Psytrance, TrapHipHop };
            #endregion
            #region Hype
            string[] Eurodance = { "Basshunter", "Mikkel Christiansen" };
            string[] HandsUp = { "DJ Gollum", "Italobrothers", "Joey Moe" };
            string[] Hardcore = { "Al Storm", "Daniel Simonsen", "Nightcore", "S3RL", "Scott Brown", "Stonebank", "Technikore" };
            string[] Hardstyle = { "Da Tweekaz", "Stonebank" };
            string[][] Category8 = { Eurodance, HandsUp, Hardcore, Hardstyle };
            #endregion
            #region House
            string[] DeepHouse = None;
            string[] House = { "Zedd" };
            string[] MelodicHouse = { "Tobu" };
            string[] TropicalHouse = { "Kygo" };
            string[][] Category9 = { DeepHouse, House, MelodicHouse, TropicalHouse };
            #endregion
            #region Progressive House
            string[] ProgressiveHouse = { "Ahrix", "Atef", "Avicii", "Daniel Simonsen", "Marcus Mouya", "Vicetone" };
            string[] ProgressiveDream = { "3LAU", "Ahrix", "Daniel Simonsen", "Mako", "Vicetone" };
            string[] ProgressivePop = { "Avicii", "Calvin Harris" };
            string[] NCSStyle = None;
            string[][] Category10 = { ProgressiveHouse, ProgressiveDream, ProgressivePop, NCSStyle };
            #endregion
            #region Electro-House
            string[] ElectroHouse = { "Ahrix", "Alan Walker", "Daniel Simonsen", "Lensko" };
            string[] LiteralElectro = None;
            string[] Dudududu = { "Ahrix", "Alan Walker", "K-391" };
            string[][] Category11 = { ElectroHouse, LiteralElectro, Dudududu };
            #endregion
            #region Old School
            string[] Downtempo = None;
            string[] Synthwave = { "FM-84", "SelloRekt / LA Dreams" };
            string[][] Category12 = { Downtempo, Synthwave };
            #endregion
            #region Classic
            string[] Acoustic = None;
            string[] Country = None;
            string[] Rock = { "After Forever", "Brian Tuey", "Fall Out Boy", "My Chemical Romance", "Panic! At The Disco", "Set It Off", "The Material" };
            string[] LoFi = None;
            string[][] Category13 = { Acoustic, Country, Rock, LoFi };
            #endregion
            #endregion

            string[][][] Artists = { Category1, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9, Category10, Category11, Category12, Category13 };
            return Artists;
        }
        #endregion

        #region Main Methods
        static void ResetSpecifications()
        {
            LookingFor = false;
            WantedItems = new bool[]{ false, false, false, false, false };
            WantedWords = new bool[5];
            WantedItem = new string[]{ "", "", "", "", "" };
            WantedText = new List<string>();
        }
        static void TellSpecifications()
        {
            Console.WriteLine("-=: Specifications :=-");
            string[] Options = { "Genre", "Artist", "BPM", "Scale", "Title item" };
            for (int x = 0; x < WantedItem.Length; x++)
                if(WantedItems[x])
                    Console.WriteLine($"{Options[x]}: {WantedItem[x]}");
        }
        static void GenerateMusic()
        {
            bool[] SongFound;
            bool ActuallyFound = true;
            Idea idea = new Idea();
            idea.GenerateMoarMusic();

            //Console.WriteLine($"\"{idea.WholeName}\"");

            if(idea.WantedItem[1] == "Tristam")
                Console.WriteLine();

            if (LookingFor)
            {
                try
                {
                    SongFound = new bool[] { false, false, false, false, false };
                    for (int x = 0; x < idea.WantedItem.Length; x++)
                    {
                        if (idea.WantedItem[x].ToLower() == WantedItem[x].ToLower() && WantedItems[x])
                            SongFound[x] = true;
                        else if (!WantedItems[x])
                            SongFound[x] = true;
                        else if (x == 4)
                        {
                            int y = 0;
                            foreach (string word in WantedText)
                            {
                                if (idea.WholeName.Contains(word))
                                    WantedWords[y] = true;
                                else
                                    SongFound[x] = false;
                                y++;
                            }
                            for (y = 0; y < WantedWords.Length; y++)
                            {
                                if (WantedWords[y])
                                    SongFound[x] = true;
                                else
                                {
                                    SongFound[x] = false;
                                    y = WantedWords.Length - 1;
                                }
                            }
                        }
                        else
                            SongFound[x] = false;
                    }
                }
                catch
                {
                    SongFound = new bool[] { false, false, false, false, false };
                }

                ActuallyFound = false;
                for (int x = 0; x < SongFound.Length; x++)
                {
                    if (SongFound[x])
                        ActuallyFound = true;
                    else
                    {
                        ActuallyFound = false;
                        x = SongFound.Length - 1;
                    }
                }
                TellSpecifications();
            }

            if (idea.WholeName == "")
            {
                Console.Clear();
                idea.GenerateMoarMusic();
                ActuallyFound = false;
            }

            if (WantedWords != null)
                for (int x = 0; x < WantedWords.Length; x++)
                    WantedWords[x] = false;

            if (ActuallyFound)
            {
                Choice = Console.ReadKey().Key;

                if (Choice != ConsoleKey.Enter)
                    Generate = false;
            }

            Console.Clear();
        }
        static void Main()
        {
            while (true)
            {
                string[] Options = { "Genre", "Artist", "BPM", "Scale", "Title item"};

                do
                {
                    #region Actual Menu
                    Console.Clear();

                    Console.WriteLine("-=: Music Idea Generator :=-");

                    Console.WriteLine();

                    for (int x = 0; x < Options.Length; x++)
                        Console.WriteLine($"[{x + 1}]: {Options[x]}");

                    if(LookingFor)
                    {
                        Console.WriteLine("[6]: Reset Specifications");
                        Console.WriteLine();
                        TellSpecifications();
                    }

                    for (int x = 0; x < 2; x++)
                        Console.WriteLine();

                    Choice = Console.ReadKey().Key;

                    Console.Clear();
                    #endregion

                    #region Find User's Choice
                    switch (Choice)
                    {
                        case ConsoleKey.Enter:
                            Generate = true;
                            break;
                        case ConsoleKey.D1:
                            SetWantedItem("Genre", 1);
                            break;
                        case ConsoleKey.D2:
                            SetWantedItem("Artist", 2);
                            break;
                        case ConsoleKey.D3:
                            SetWantedItem("BPM", 3);
                            break;
                        case ConsoleKey.D4:
                            SetWantedItem("Scale", 4);
                            break;
                        case ConsoleKey.D5:
                            SetWantedItem("Title", WantedText);
                            break;
                        case ConsoleKey.D6:
                            ResetSpecifications();
                            break;
                    }
                    #endregion

                } while (!Generate);

                while (Generate)
                    GenerateMusic();
            }
        }
        #endregion

        #endregion
    }
}