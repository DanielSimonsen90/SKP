using MIG.SongElements.Drums;
using System.Collections.Generic;

namespace MIG.References.Data
{
    public abstract class Names
    {
        #region Genres
        public static string
            Lofi = "Lofi", Acoustic = "Acoustic", Country = "Country", RockMetal = "Rock/Metal", Trap = "Trap/Rap/Hip Hop",
            Pop = "Pop", Psytrance = "Psytrance",
            BigRoom = "Big Room", Spinnin = "Spinnin' Records", Bootleg = "Bootleg", Bounce = "Bounce", Melbourne = "Melbourne Bounce",
            Drumstep = "Drumstep", DnB = "Drum n Bass",
            Dubstep = "Dubstep", MelDubstep = "Melodic Dubstep",
            FutBass = "Future Bass", FutFunk = "Future Funk", FutHouse = "Future House", FutBounce = "Future Bounce",
            Electro = "Electro", ElecSwing = "Electro Swing",
            GeneralEDM = "General EDM", EDMTrap = "EDM Trap", Electrio = "Electrio",
            HandsUp = "Hands Up", EuroDance = "Eurodance",
            Rawstyle = "Rawstyle", Hardstyle = "Hardstyle", Hardcore = "Hardcore",
            DeepHouse = "Deep House", House = "House", MelHouse = "Melodic House", TropHouse = "Tropical House",
            ProgHouse = "Progressive House", ProgDream = "Progressive Dream", ProgPop = "Progressive Pop", NCSStyle = "NCS Style",
            ElecHouse = "Electro-House", TakingElectroLiteral = "Taking Electro Literal", Dudududu = "Dudu dudu",
            Downtempo = "Downtempo", Synthwave = "Synthwave";
        #endregion

        #region Drum Elements
        protected readonly static DrumKick Kick = new DrumKick();
        protected readonly static DrumClap Clap = new DrumClap();
        protected readonly static DrumHiHat HiHat = new DrumHiHat();
        protected readonly static DrumOpenHat OpenHat = new DrumOpenHat();
        protected readonly static DrumSnare Snare = new DrumSnare();
        #endregion

        public static List<string> BannedWords = new List<string>()
        {
            "devi", "er", "jorden", "rd.", "dem", "john", "collin", "matthew", "pnb", "feat.", "sko", "danyka", "capone", "fejrer", "uma", "jonny", "chiyoko",
            "thnks", "fr", "th", "mmrs", "pa", "wa", "zoe", "johnny", "cuore", "ghiacciato", "thie", "vs", "Ku'", "rita", "handzup", "faidherbe", "harri", "cozi",
            "defi", "cascada", "vs.", "mou", "emmaaa", "niya", "boten", "fugazi", "mtc", "mtc2", "roseanna", "titsepoken", "avem", "/", "brenton", "aloma", "mixie",
            "kayliana", "hotto", "kyoto", "b0y", "dine", "næ", "jp", "ta'", "d.", "myten", "ma,", "halve", "conrad", "na", "richard", "al", "nese", "kat", "aviation",
            "anna", "dutchman", "op", "-", "la", "bangarang", "alan", "nicktim", "pika", "theos", "maren", "da", "andrew", "sætran", "cascada,", "tinie", "dota",
            "lofi", "laura", "romero", "promiseland", "n", "'n'", "emi", "mc", "technobase.fm", "ellie", "pt.", "sætran,", "pt.", "lucid", "være", "det", "movie",
            "ku'", "dj", "de", "m.o.a.b", "r4v3", "video"
        };
    }
}