using System;
using System.Collections.Generic;

namespace Muisc_Idea_Generator
{
    class Idea
    {
        public Idea()
        {
            SetDefaults();
        }

        #region Constructor
        readonly Random Rand = new Random();
        /// <summary>
        /// Set the Default values
        /// </summary>
        private void SetDefaults()
        {
            #region SetArtist
            #region Genre things
            #region Genre Lists
            List<Track> BigRoomList = new List<Track>(), SpinninList = new List<Track>(), BounceList = new List<Track>(), DrumstepList = new List<Track>(), DubstepList = new List<Track>(), MelDubstepList = new List<Track>(),
                ElectroList = new List<Track>(), ElectroSwingList = new List<Track>(), EDMTrapList = new List<Track>(), ElectrioList = new List<Track>(), PopList = new List<Track>(), EurodanceList = new List<Track>(),
                HandsUpList = new List<Track>(), HardcoreList = new List<Track>(), HardstyleList = new List<Track>(), HouseList = new List<Track>(), MelHouseList = new List<Track>(), TropHouseList = new List<Track>(),
                ProgHouseList = new List<Track>(), ProgDreamList = new List<Track>(), ProgPopList = new List<Track>(), ElecHouseList = new List<Track>(), DuduList = new List<Track>(), SynthwaveList = new List<Track>(),
                RockList = new List<Track>();
            #endregion
            #region String Genres
            string BigRoomString = "Big Room", SpinninString = "Spinnin' Records", BounceString = "Bounce", DrumstepString = "Drumstep", DubstepString = "Dubstep", MelDubstepString = "Melodic Dubstep",
                ElectroString = "Electro", ElectroswingString = "Electroswing", EDMTrapString = "EDM Trap", ElectrioString = "Electrio", PopString = "Pop", EurodanceString = "Eurodance",
                HandsUpString = "Hands Up", HardcoreString = "Hardcore", HardstyleString = "Hardstyle", HouseString = "House", MelHouseString = "Melodic House", TropHouseString = "Tropical House",
                ProgHouseString = "Progressive House", ProgDreamString = "Progressive Dream", ProgPopString = "Progressive Pop", ElecHouseString = "Electro-House", DuduString = "Dudu dudu",
                SynthwaveString = "Synthwave", RockString = "Rock, Metal etc.";
            #endregion
            #endregion

            #region Individual Artist
            #region 3LAU - ProgDream
            Track Song1 = new Track("How You Love Me", ProgDreamString, "3LAU");
            Track Song2 = new Track("Touch", ProgDreamString, "3LAU");

            Track[] Songs = { Song1, Song2 };
            Artist Blau = new Artist("3LAU", Songs);

            SetList(ProgDreamList, Songs);
            #endregion
            #region After Forever - Rock
            Song1 = new Track("Discord", RockString, "After Forever");
            Song2 = new Track("Come", RockString, "After Forever");
            Track Song3 = new Track("Boundaries Are Open", RockString, "After Forever");
            Track Song4 = new Track("Living Shields", RockString, "After Forever");
            Track Song5 = new Track("Being Everyone", RockString, "After Forever");
            Track Song6 = new Track("Only Everything", RockString, "After Forever");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6 };
            Artist AfterForever = new Artist("After Forever", Songs);

            SetList(RockList, Songs);
            #endregion
            #region Ahrix - ADDITIONAL | ProgHouse, ProgDream, ElecHouse, Dudu
            Song1 = new Track("A New Start", ProgHouseString, "Ahrix");
            Song2 = new Track("Daydream", ProgHouseString, "Ahrix")
            {
                AdditionalGenre = ProgDreamString
            };
            Song3 = new Track("Hope", ProgHouseString, "Ahrix");
            Song4 = new Track("New Era", ProgHouseString, "Ahrix")
            {
                AdditionalGenre = ProgDreamString
            };
            Song5 = new Track("Raising", ProgHouseString, "Ahrix");
            Song6 = new Track("Dreams", ProgDreamString, "Ahrix");
            Track Song7 = new Track("Evolving", ProgDreamString, "Ahrix");
            Track Song8 = new Track("Pure", ProgDreamString, "Ahrix");
            Track Song9 = new Track("Relief", ProgDreamString, "Ahrix");
            Track Song10 = new Track("Senreity", ProgDreamString, "Ahrix");
            Track Song11 = new Track("Carpe Diem", ProgDreamString, "Ahrix");
            Track Song12 = new Track("The Dreamer", ProgDreamString, "Ahrix");
            Track Song13 = new Track("Nova", ElecHouseString, "Ahrix")
            {
                AdditionalGenre = DuduString
            };
            Track Song14 = new Track("Euphoria", ElecHouseString, "Ahrix");
            Track Song15 = new Track("Left Behind", ElecHouseString, "Ahrix");
            Track Song16 = new Track("Forgiven", ElecHouseString, "Ahrix");
            Track Song17 = new Track("Courage", ElecHouseString, "Ahrix");
            Track Song18 = new Track("Ignite - Ahrix Remix", ElecHouseString, "Ahrix");
            Track Song19 = new Track("Moments", DuduString, "Ahrix");
            Track Song20 = new Track("Reborn", DuduString, "Ahrix");
            Track Song21 = new Track("Never Alone", DuduString, "Ahrix");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15, Song16, Song17, Song18, Song19, Song20, Song21 };
            Artist Ahrix = new Artist("Ahrix", Songs);

            Track[] TempSongs = { Song1, Song2, Song3, Song4, Song5 };
            SetList(ProgHouseList, TempSongs);
            TempSongs = new Track[] { Song2, Song4, Song6, Song7, Song8, Song9, Song10, Song11, Song12 };
            SetList(ProgDreamList, TempSongs);
            TempSongs = new Track[] { Song13, Song14, Song15, Song16, Song17, Song18 };
            SetList(ElecHouseList, TempSongs);
            TempSongs = new Track[] { Song13, Song19, Song20, Song21 };
            SetList(DuduList, TempSongs);
            #endregion
            #region Al Storm - Hardcore
            Song1 = new Track("Crash", HardcoreString, "Al Storm");
            Song2 = new Track("I Created A Monster", HardcoreString, "Al Storm");
            Song3 = new Track("Cannibalism!", HardcoreString, "Al Storm");
            Song4 = new Track("Here 2 Invade", HardcoreString, "Al Storm");

            Songs = new Track[] { Song1, Song2, Song3, Song4 };
            Artist AlStorm = new Artist("Al Storm", Songs);

            SetList(HardcoreList, Songs);
            #endregion
            #region Alan Walker - ADDITIONAL | ElecHouse, Dudu
            Song1 = new Track("Different World", ElecHouseString, "Alan Walker");
            Song2 = new Track("Faded", ElecHouseString, "Alan Walker")
            {
                AdditionalGenre = DuduString
            };
            Song3 = new Track("Ignite", ElecHouseString, "Alan Walker");
            Song4 = new Track("Sky", ElecHouseString, "Alan Walker");
            Song5 = new Track("On My Way", ElecHouseString, "Alan Walker");
            Song6 = new Track("Sing Me To Sleep", ElecHouseString, "Alan Walker");
            Song7 = new Track("The Spectre", ElecHouseString, "Alan Walker");
            Song8 = new Track("This Is Me - Alan Walker Relift", ElecHouseString, "Alan Walker");
            Song9 = new Track("Stranger Things - Alan Walker Remix", ElecHouseString, "Alan Walker");
            Song10 = new Track("Legends Never Die - Alan Walker Remix", ElecHouseString, "Alan Walker");
            Song11 = new Track("Are You Lonely", ElecHouseString, "Alan Walker");
            Song12 = new Track("Fade", ElecHouseString, "Alan Walker")
            {
                AdditionalGenre = DuduString
            };
            Song13 = new Track("Force", ElecHouseString, "Alan Walker")
            {
                AdditionalGenre = DuduString
            };
            Song14 = new Track("Spectre", ElecHouseString, "Alan Walker")
            {
                AdditionalGenre = DuduString
            };
            Song15 = new Track("Play", DuduString, "Alan Walker");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15 };
            Artist AlanWalker = new Artist("Alan Walker", Songs);

            SetList(ElecHouseList, Songs);
            ElecHouseList.Remove(Song15);
            TempSongs = new Track[] { Song2, Song12, Song13, Song14, Song15 };
            SetList(DuduList, TempSongs);
            #endregion
            #region Atef - ProgHouse
            Song1 = new Track("Abyss", ProgHouseString, "Atef");
            Song2 = new Track("Away", ProgHouseString, "Atef");
            Song3 = new Track("Promises", ProgHouseString, "Atef");
            Song4 = new Track("Spectrum", ProgHouseString, "Atef");

            Songs = new Track[] { Song1, Song2, Song3, Song4 };
            Artist Atef = new Artist("Atef", Songs);

            SetList(ProgHouseList, Songs);
            #endregion
            #region Avicii - ADDITIONAL | ProgHouse, ProgPop
            Song1 = new Track("Hey Brother", ProgHouseString, "Avicii");
            Song2 = new Track("I Could Be The One", ProgHouseString, "Avicii");
            Song3 = new Track("Levels", ProgHouseString, "Avicii");
            Song4 = new Track("Lonely Together", ProgHouseString, "Avicii");
            Song9 = new Track("The Days", ProgPopString, "Avicii");
            Song5 = new Track("The Nights", ProgHouseString, "Avicii")
            {
                AdditionalGenre = ProgPopString
            };
            Song6 = new Track("Waiting For Love", ProgHouseString, "Avicii")
            {
                AdditionalGenre = ProgPopString
            };
            Song7 = new Track("Wake Me Up", ProgHouseString, "Avicii");
            Song8 = new Track("Without You", ProgHouseString, "Avicii");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9 };
            Artist Avicii = new Artist("Avicii", Songs);

            SetList(ProgHouseList, Songs);
            TempSongs = new Track[] { Song5, Song6 };
            SetList(ProgPopList, TempSongs);
            #endregion
            #region Basshunter - Eurodance
            Song1 = new Track("When You Leave [Numa Numa] (Basshunter Remix)", EurodanceString, "Basshunter");
            Song2 = new Track("DotA", EurodanceString, "Basshunter");
            Song3 = new Track("Now You're Gone", EurodanceString, "Basshunter");
            Song4 = new Track("All I ever Wanted", EurodanceString, "Basshunter");
            Song5 = new Track("I Can Walk On Water", EurodanceString, "Basshunter");
            Song6 = new Track("Boten Anna", EurodanceString, "Basshunter");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6 };
            Artist Basshunter = new Artist("Basshunter", Songs);

            SetList(EurodanceList, Songs);
            #endregion
            #region Bassjackers - Spinnin
            Song1 = new Track("Derp", SpinninString, "Bassjackers");
            Song2 = new Track("Savior", SpinninString, "Bassjackers");
            Song3 = new Track("Wave Your Hands", SpinninString, "Bassjackers");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist Bassjackers = new Artist("Bassjackers", Songs);

            SetList(SpinninList, Songs);
            #endregion
            #region Brian Tuey - Rock
            Song1 = new Track("Lullaby Of A Deadman", RockString, "Brian Tuey");
            Song2 = new Track("The One", RockString, "Brian Tuey");
            Song3 = new Track("Beauty Of Annihilation", RockString, "Brian Tuey");
            Song4 = new Track("Twilight", RockString, "Brian Tuey");
            Song5 = new Track("Undone", RockString, "Brian Tuey");
            Song6 = new Track("115", RockString, "Brian Tuey");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6 };
            Artist BrianTuey = new Artist("Brian Tuey", Songs);

            SetList(RockList, Songs);
            #endregion
            #region Clavin Harris - ProgPop
            Song1 = new Track("We'll Be Coming Back", ProgPopString, "Calvin Harris");
            Song2 = new Track("Drinking from the Bottle", ProgPopString, "Calvin Harris");
            Song3 = new Track("Let's Go", ProgPopString, "Calvin Harris");
            Song4 = new Track("Blame", ProgPopString, "Calvin Harris");
            Song5 = new Track("Outside", ProgPopString, "Calvin Harris");
            Song6 = new Track("Together", ProgPopString, "Calvin Harris");
            Song7 = new Track("Summer", ProgPopString, "Calvin Harris");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7 };
            Artist CalvinHarris = new Artist("Calvin Harris", Songs);

            SetList(ProgPopList, Songs);
            #endregion
            #region Da Tweekaz - Hardstyle
            Song1 = new Track("On My Way - Da Tweekaz Remix", HardstyleString, "Da Tweekaz");
            Song2 = new Track("Bring Me To Life", HardstyleString, "Da Tweekaz");
            Song3 = new Track("How Far I'll Go", HardstyleString, "Da Tweekaz");
            Song4 = new Track("Keep On Rockin'", HardstyleString, "Da Tweekaz");
            Song5 = new Track("Letting Go", HardstyleString, "Da Tweekaz");
            Song6 = new Track("Bad Habbit", HardstyleString, "Da Tweekaz");
            Song7 = new Track("The Calling (Da Tweekaz Remix)", HardstyleString, "Da Tweekaz");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7 };
            Artist DaTweekaz = new Artist("Da Tweekaz", Songs);

            SetList(HardstyleList, Songs);
            #endregion
            #region Daniel Simonsen - ADDITIONAL | Hardcore, ProgHouse, ProgDream, ElecHouse, Dudu
            Song1 = new Track("Take Off", HardcoreString, "Daniel Simonsen");
            Song2 = new Track("Præsentation", HardcoreString, "Daniel Simonsen");
            Song3 = new Track("Abe-katten Carl", HardcoreString, "Daniel Simonsen");
            Song4 = new Track("Exploring Beyond Limits", ProgHouseString, "Daniel Simonsen");
            Song5 = new Track("Haunted", ProgHouseString, "Daniel Simonsen");
            Song6 = new Track("Summer", ProgHouseString, "Daniel Simonsen");
            Song7 = new Track("Toxicore", ProgHouseString, "Daniel Simonsen");
            Song8 = new Track("What Mom Requested", ProgHouseString, "Daniel Simonsen");
            Song9 = new Track("Next Level", ProgDreamString, "Daniel Simonsen");
            Song10 = new Track("Awaiting", ProgDreamString, "Daniel Simonsen");
            Song11 = new Track("Nearing The Ending", ProgDreamString, "Daniel Simonsen");
            Song12 = new Track("Dreams", ProgDreamString, "Daniel Simonsen");
            Song13 = new Track("Worried", ElecHouseString, "Daniel Simonsen")
            {
                AdditionalGenre = DuduString
            };
            Song14 = new Track("Amplified", ElecHouseString, "Daniel Simonsen")
            {
                AdditionalGenre = DuduString
            };
            Song15 = new Track("Miracle", ElecHouseString, "Daniel Simonsen")
            {
                AdditionalGenre = DuduString
            };

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15 };
            Artist DanielSimonsen = new Artist("Daniel Simonsen", Songs);

            TempSongs = new Track[] { Song1, Song2, Song3 };
            SetList(HardcoreList, TempSongs);
            TempSongs = new Track[] { Song4, Song5, Song6, Song7, Song8 };
            SetList(ProgHouseList, TempSongs);
            TempSongs = new Track[] { Song9, Song10, Song11, Song12 };
            SetList(ProgDreamList, TempSongs);
            TempSongs = new Track[] { Song13, Song14, Song15 };
            SetList(ElecHouseList, TempSongs);
            SetList(DuduList, TempSongs);
            #endregion
            #region DJ Gollum - HandsUp
            Song1 = new Track("Handzup Isn't Dead", HandsUpString, "DJ Gollum");
            Song2 = new Track("Historisk (DJ Gollum Radio Edit", HandsUpString, "DJ Gollum");
            Song3 = new Track("I'm a Passenger", HandsUpString, "DJ Gollum");
            Song4 = new Track("Poison", HandsUpString, "DJ Gollum");
            Song5 = new Track("Rockstar", HandsUpString, "DJ Gollum");
            Song6 = new Track("The Promiseland", HandsUpString, "DJ Gollum");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6 };
            Artist DJGollum = new Artist("DJ Gollum", Songs);

            SetList(HandsUpList, Songs);
            #endregion
            #region DVBBS - ADDITIONAL | BigRoom, Spinnin
            Song1 = new Track("Immortal", BigRoomString, "DVBBS")
            {
                AdditionalGenre = SpinninString
            };
            Song2 = new Track("Pyramids", BigRoomString, "DVBBS")
            {
                AdditionalGenre = SpinninString
            };
            Song3 = new Track("This Is Dirty", BigRoomString, "DVBBS")
            {
                AdditionalGenre = SpinninString
            };

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist DVBBS = new Artist("DVBBS", Songs);

            SetList(BigRoomList, Songs);
            SetList(SpinninList, Songs);
            #endregion
            #region Fall Out Boy - Rock
            Song1 = new Track("Centuries", RockString, "Fall Out Boy");
            Song2 = new Track("Uma Thurman", RockString, "Fall Out Boy");
            Song3 = new Track("Immortals", RockString, "Fall Out Boy");
            Song4 = new Track("The Carpal Tunnel Of Love", RockString, "Fall Out Boy");
            Song5 = new Track("Thnks fr th Mmrs", RockString, "Fall Out Boy");
            Song6 = new Track("The Last Of The Real Ones", RockString, "Fall Out Boy");
            Song7 = new Track("The Pheonix", RockString, "Fall Out Boy");
            Song8 = new Track("My Songs Know What You Did In The Dark", RockString, "Fall Out Boy");
            Song9 = new Track("Alone Together", RockString, "Fall Out Boy");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9 };
            Artist FallOutBoy = new Artist("Fall Out Boy", Songs);

            SetList(RockList, Songs);
            #endregion
            #region Flo Rida - Pop
            Song1 = new Track("My House", PopString, "Flo Rida");
            Song2 = new Track("Whistle", PopString, "Flo Rida");
            Song3 = new Track("I Cry", PopString, "Flo Rida");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist FloRida = new Artist("Flo Rida", Songs);

            SetList(PopList, Songs);
            #endregion
            #region FM-84 - Synthwave
            Song1 = new Track("Running in the Night", SynthwaveString, "FM-84");
            Song2 = new Track("Never Stop", SynthwaveString, "FM-84");
            Song3 = new Track("Neon Sunshine", SynthwaveString, "FM-84");
            Song4 = new Track("Outatime", SynthwaveString, "FM-84");

            Songs = new Track[] { Song1, Song2, Song3, Song4 };
            Artist FM84 = new Artist("FM-84", Songs);

            SetList(SynthwaveList, Songs);
            #endregion
            #region Italobrothers - HandsUp
            Song1 = new Track("Boom", HandsUpString, "Italobrothers");
            Song2 = new Track("Colours Of The Rainbow", HandsUpString, "Italobrothers");
            Song3 = new Track("Counting Down The Days", HandsUpString, "Italobrothers");
            Song4 = new Track("Cryin' In The Rain", HandsUpString, "Italobrothers");
            Song5 = new Track("Hasselhoff", HandsUpString, "Italobrothers");
            Song6 = new Track("Heaven", HandsUpString, "Italobrothers");
            Song7 = new Track("It Must Have Been Love", HandsUpString, "Italobrothers");
            Song8 = new Track("Love Is On Fire", HandsUpString, "Italobrothers");
            Song9 = new Track("Moonlight Shadow", HandsUpString, "Italobrothers");
            Song10 = new Track("Pandora", HandsUpString, "Italobrothers");
            Song11 = new Track("Put Your Hands Up In The Air", HandsUpString, "Italobrothers");
            Song12 = new Track("Radio Hardcore", HandsUpString, "Italobrothers");
            Song13 = new Track("Sleep When We're Dead", HandsUpString, "Italobrothers");
            Song14 = new Track("So Small", HandsUpString, "Italobrothers");
            Song15 = new Track("Stamp On The Ground", HandsUpString, "Italobrothers");
            Song16 = new Track("The Moon", HandsUpString, "Italobrothers");
            Song17 = new Track("This Is Nightlife", HandsUpString, "Italobrothers");
            Song18 = new Track("Underwater World", HandsUpString, "Italobrothers");
            Song19 = new Track("Upside Down", HandsUpString, "Italobrothers");
            Song20 = new Track("Where Are You Now", HandsUpString, "Italobrothers");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15, Song16, Song17, Song18, Song19, Song20 };
            Artist Italobrothers = new Artist("Italobrothers", Songs);

            SetList(HandsUpList, Songs);
            #endregion
            #region Jochen Miller - BigRoom
            Song1 = new Track("Scope", BigRoomString, "Jochen Miller");
            Song2 = new Track("Turn It Up", BigRoomString, "Jochen Miller");
            Song3 = new Track("United", BigRoomString, "Jochen Miller");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist JochenMiller = new Artist("Jochen Miller", Songs);

            SetList(BigRoomList, Songs);
            #endregion
            #region Joey Moe - HandsUp
            Song1 = new Track("Dobbeltslag", HandsUpString, "Joey Moe");
            Song2 = new Track("Jorden Er Giftig", HandsUpString, "Joey Moe");
            Song3 = new Track("Yo-Yo", HandsUpString, "Joey Moe");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist JoeyMoe = new Artist("Joey Moe", Songs);

            SetList(HandsUpList, Songs);
            #endregion
            #region K-391 - ADDITIONAL | Dudu, ElecHouse
            Song1 = new Track("Story of Envy", DuduString, "K-391")
            {
                AdditionalGenre = ElecHouseString
            };
            Song2 = new Track("Electrode", DuduString, "K-391")
            {
                AdditionalGenre = ElecHouseString
            };
            Song3 = new Track("Electro House 2012", DuduString, "K-391")
            {
                AdditionalGenre = ElecHouseString
            };
            Song4 = new Track("Dream Of Something Sweet", DuduString, "K-391");
            Song5 = new Track("Play", DuduString, "K-391");
            Song6 = new Track("Summertime", DuduString, "K-391");
            Song7 = new Track("This Is Felicitas", DuduString, "K-391");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7 };
            Artist K391 = new Artist("K-391", Songs);

            SetList(DuduList, Songs);
            TempSongs = new Track[] { Song1, Song2, Song3 };
            SetList(ElecHouseList, TempSongs);
            #endregion
            #region Knife Party - Dubstep
            Song1 = new Track("Power Glove", DubstepString, "Knife Party");
            Song2 = new Track("Interenet Friends", DubstepString, "Knife Party");
            Song3 = new Track("Bonfire", DubstepString, "Knife Party");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist KnifeParty = new Artist("Knife Party", Songs);

            SetList(DubstepList, Songs);
            #endregion
            #region Krewella - Dubstep, MelDubstep, Drumstep, Electrio
            Song1 = new Track("This Is Not The End", DubstepString, "Krewella");
            Song2 = new Track("Play Hard", DubstepString, "Krewella");
            Song3 = new Track("Killin' It", DubstepString, "Krewella");
            Song4 = new Track("Can't Control Myself", DubstepString, "Krewella");
            Song5 = new Track("One Minute", DubstepString, "Krewella");
            Song6 = new Track("Feel Me", DubstepString, "Krewella");
            Song7 = new Track("We Go Down", MelDubstepString, "Krewella");
            Song8 = new Track("Human", MelDubstepString, "Krewella");
            Song9 = new Track("Surrender The Throne", DrumstepString, "Krewella");
            Song10 = new Track("Come & Get It", DrumstepString, "Krewella");
            Song11 = new Track("Say Goodbye", DrumstepString, "Krewella");
            Song12 = new Track("Ring of Fire", ElectrioString, "Krewella");
            Song13 = new Track("Live for the Night", ElectrioString, "Krewella");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13 };
            Artist Krewella = new Artist("Krewella", Songs);

            TempSongs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6 };
            SetList(DubstepList, TempSongs);
            TempSongs = new Track[] { Song7, Song8 };
            SetList(MelDubstepList, TempSongs);
            TempSongs = new Track[] { Song9, Song10, Song11 };
            SetList(DrumstepList, TempSongs);
            TempSongs = new Track[] { Song12, Song13 };
            SetList(ElectrioList, TempSongs);
            #endregion
            #region Kygo - TropHouse
            Song1 = new Track("Firestone", TropHouseString, "Kygo");
            Song2 = new Track("Here For You", TropHouseString, "Kygo");
            Song3 = new Track("Stay", TropHouseString, "Kygo");
            Song4 = new Track("Stole The Show", TropHouseString, "Kygo");
            Song5 = new Track("Younger - Kygo Remix", TropHouseString, "Kygo");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5 };
            Artist Kygo = new Artist("Kygo", Songs);

            SetList(TropHouseList, Songs);
            #endregion
            #region Lensko - ElecHouse
            Song1 = new Track("Cetus", ElecHouseString, "Lensko");
            Song2 = new Track("Circles", ElecHouseString, "Lensko");
            Song3 = new Track("Titsepoken", ElecHouseString, "Lensko");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist Lensko = new Artist("Lensko", Songs);

            SetList(ElecHouseList, Songs);
            #endregion
            #region Lukas Graham - Pop
            Song1 = new Track("Lie", PopString, "Lukas Graham");
            Song2 = new Track("7 Years", PopString, "Lukas Graham");
            Song3 = new Track("Take The World By Storm", PopString, "Lukas Graham");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist LukasGraham = new Artist("Lukas Graham", Songs);

            SetList(PopList, Songs);
            #endregion
            #region Mako - ProgDream
            Song1 = new Track("I Won't Let You Walk Away", ProgDreamString, "Mako");
            Song2 = new Track("Not Alone", ProgDreamString, "Mako");
            Song3 = new Track("Smoke Filled Room", ProgDreamString, "Mako");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist Mako = new Artist("Mako", Songs);

            SetList(ProgDreamList, Songs);
            #endregion
            #region Marcus Mouya - ProgHouse
            Song1 = new Track("Despair", ProgHouseString, "Marcus Mouya");
            Song2 = new Track("Stay With Me", ProgHouseString, "Marcus Mouya");
            Song3 = new Track("The Colors In Your Eyes", ProgHouseString, "Marcus Mouya");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist MarcusMouya = new Artist("Marcus Mouya", Songs);

            SetList(ProgHouseList, Songs);
            #endregion
            #region Marshmello - EDMTrap
            Song1 = new Track("Everyday", EDMTrapString, "Marshmello");
            Song2 = new Track("Alone", EDMTrapString, "Marshmello");
            Song3 = new Track("FRIENDS", EDMTrapString, "Marshmello");
            Song4 = new Track("Happier", EDMTrapString, "Marshmello");
            Song5 = new Track("Here With Me", EDMTrapString, "Marshmello");
            Song6 = new Track("Summer", EDMTrapString, "Marshmello");
            Song7 = new Track("Blocks", EDMTrapString, "Marshmello");
            Song8 = new Track("Moving On", EDMTrapString, "Marshmello");
            Song9 = new Track("Silence", EDMTrapString, "Marshmello");
            Song10 = new Track("Keep It Mello", EDMTrapString, "Marshmello");
            Song11 = new Track("Wolves", EDMTrapString, "Marshmello");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11 };
            Artist Marshmello = new Artist("Marshmello", Songs);

            SetList(EDMTrapList, Songs);
            #endregion
            #region Mikkel Christiansen - Eurodance
            Song1 = new Track("Gøy På Landet", EurodanceString, "Mikkel Christiansen");
            Song2 = new Track("Limited Edition", EurodanceString, "Mikkel Christiansen");
            Song3 = new Track("Megos Alexandros", EurodanceString, "Mikkel Christiansen");
            Song4 = new Track("Navy Seals", EurodanceString, "Mikkel Christiansen");
            Song5 = new Track("Sains of Barthélemy", EurodanceString, "Mikkel Christiansen");
            Song6 = new Track("StoreSlem", EurodanceString, "Mikkel Christiansen");
            Song7 = new Track("Willy Nikkersen", EurodanceString, "Mikkel Christiansen");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7 };
            Artist MikkelChristiansen = new Artist("Mikkel Christiansen", Songs);

            SetList(EurodanceList, Songs);
            #endregion
            #region My Chemical Romance - Rock
            Song1 = new Track("Nanana", RockString, "My Chemical Romance");
            Song2 = new Track("Bulletproof Heart", RockString, "My Chemical Romance");
            Song3 = new Track("Planetary (GO!)", RockString, "My Chemical Romance");
            Song4 = new Track("The Only Hope For Me Is You", RockString, "My Chemical Romance");
            Song5 = new Track("Party Poison", RockString, "My Chemical Romance");
            Song6 = new Track("Welcome To The Black Parade", RockString, "My Chemical Romance");
            Song7 = new Track("Teenagers", RockString, "My Chemical Romance");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7 };
            Artist MyChemicalRomance = new Artist("My Chemical Romance", Songs);

            SetList(RockList, Songs);
            #endregion
            #region NerdOut - Pop
            Song1 = new Track("Born for This", PopString, "NerdOut");
            Song2 = new Track("I Need a Healer", PopString, "NerdOut");
            Song3 = new Track("Shadow Finds You", PopString, "NerdOut");
            Song4 = new Track("The Dragonblade", PopString, "NerdOut");

            Songs = new Track[] { Song1, Song2, Song3, Song4 };
            Artist NerdOut = new Artist("NerdOut", Songs);

            SetList(PopList, Songs);
            #endregion
            #region Nightcore - Hardcore
            Song1 = new Track("Everytime We Touch - Nightcore Edit", HardcoreString, "Nightcore");
            Song2 = new Track("Fireworks", HardcoreString, "Nightcore");
            Song3 = new Track("Dreamers", HardcoreString, "Nightcore");
            Song4 = new Track("We Own The Night", HardcoreString, "Nightcore");
            Song5 = new Track("Rising - Nightcore Edit", HardcoreString, "Nightcore");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5 };
            Artist Nightcore = new Artist("Nightcore", Songs);

            SetList(HardcoreList, Songs);
            #endregion
            #region OMFG - MelDubstep
            Song1 = new Track("Hello", MelDubstepString, "OMFG");
            Song2 = new Track("Ice Cream", MelDubstepString, "OMFG");
            Song3 = new Track("I Love You", MelDubstepString, "OMFG");
            Song4 = new Track("Meant for You", MelDubstepString, "OMFG");

            Songs = new Track[] { Song1, Song2, Song3, Song4 };
            Artist OMFG = new Artist("OMFG", Songs);

            SetList(MelDubstepList, Songs);
            #endregion
            #region Panda Eyes - MelDubstep
            Song1 = new Track("Galaxia", MelDubstepString, "Panda Eyes");
            Song2 = new Track("Immortal Flames", MelDubstepString, "Panda Eyes");
            Song3 = new Track("Highscore", MelDubstepString, "Panda Eyes");
            Song4 = new Track("KIKO", MelDubstepString, "Panda Eyes");
            Song5 = new Track("Colorblind", MelDubstepString, "Panda Eyes");
            Song6 = new Track("Lonely Island", MelDubstepString, "Panda Eyes");
            Song7 = new Track("Opposite Side", MelDubstepString, "Panda Eyes");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7 };
            Artist PandaEyes = new Artist("Panda Eyes", Songs);

            SetList(MelDubstepList, Songs);
            #endregion
            #region Panic! At The Disco - Pop, Rock
            Song1 = new Track("Victorious", PopString, "Panic! At The Disco");
            Song2 = new Track("Don't Threaten Me with a Good Time", PopString, "Panic! At The Disco");
            Song3 = new Track("Emperor's New Clothes", PopString, "Panic! At The Disco");
            Song4 = new Track("Crazy = Genius", PopString, "Panic! At The Disco");
            Song5 = new Track("LA Devotee", PopString, "Panic! At The Disco");
            Song6 = new Track("The Good, the Bad and the Dirty", PopString, "Panic! At The Disco");
            Song7 = new Track("House of Memories", PopString, "Panic! At The Disco");
            Song8 = new Track("Say Amen (Saturday Night)", PopString, "Panic! At The Disco");
            Song9 = new Track("Hey Look Ma, I Made It", PopString, "Panic! At The Disco");
            Song10 = new Track("High Hopes", PopString, "Panic! At The Disco");
            Song11 = new Track("Roaring 20s", PopString, "Panic! At The Disco");
            Song12 = new Track("Miss Jackson", PopString, "Panic! At The Disco");
            Song13 = new Track("Vegas Lights", PopString, "Panic! At The Disco");
            Song14 = new Track("I Write Sins Not Tradgedies", RockString, "Panic! At The Disco");
            Song15 = new Track("Death of a Bachelor", RockString, "Panic! At The Disco");
            Song16 = new Track("Dancing's Not A Crime", RockString, "Panic! At The Disco");
            Song17 = new Track("This Is Gospel", RockString, "Panic! At The Disco");
            Song18 = new Track("Nicotine", RockString, "Panic! At The Disco");
            Song19 = new Track("Girls / Girls / Boys", RockString, "Panic! At The Disco");
            Song20 = new Track("The Ballad of Mona Lisa", RockString, "Panic! At The Disco");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15, Song16, Song17, Song18, Song19, Song20 };
            Artist PanicAtTheDisco = new Artist("Panic! At The Disco", Songs);

            TempSongs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13 };
            SetList(PopList, TempSongs);
            TempSongs = new Track[] { Song14, Song15, Song16, Song17, Song18, Song19, Song20 };
            SetList(RockList, TempSongs);
            #endregion
            #region Pegboard Nerds - Dubstep, MelDubstep
            Song1 = new Track("This Is Not The End", DubstepString, "Pegboard Nerds");
            Song2 = new Track("Gunpoint / 2012 (Det Derfor)", DubstepString, "Pegboard Nerds");
            Song3 = new Track("Hero", DubstepString, "Pegboard Nerds");
            Song4 = new Track("Self Destruct", DubstepString, "Pegboard Nerds");
            Song5 = new Track("End Is Near", DubstepString, "Pegboard Nerds");
            Song6 = new Track("We Are One", DubstepString, "Pegboard Nerds");
            Song7 = new Track("Far Too Close - Pegboard Nerds Remix", MelDubstepString, "Pegboard Nerds");
            Song8 = new Track("Live for the Night - Pegboard Nerds Remix", MelDubstepString, "Pegboard Nerds");
            Song9 = new Track("Bassline Kickin", MelDubstepString, "Pegboard Nerds");
            Song10 = new Track("Emergency", MelDubstepString, "Pegboard Nerds");
            Song11 = new Track("Here It Comes", MelDubstepString, "Pegboard Nerds");
            Song12 = new Track("Pressure Cooker", MelDubstepString, "Pegboard Nerds");
            Song13 = new Track("Razor Sharp", MelDubstepString, "Pegboard Nerds");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13 };
            Artist PegboardNerds = new Artist("Pegboard Nerds", Songs);

            TempSongs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6 };
            SetList(DubstepList, TempSongs);
            TempSongs = new Track[] { Song7, Song8, Song9, Song10, Song11, Song12, Song13 };
            SetList(MelDubstepList, TempSongs);
            #endregion
            #region Proleter - Electroswing
            Song1 = new Track("April Showers", ElectroswingString, "Proleter");
            Song2 = new Track("Faidherbe Square", ElectroswingString, "Proleter");
            Song3 = new Track("It Don't Mean a Thing", ElectroswingString, "Proleter");
            Song4 = new Track("Can't Stop Me", ElectroswingString, "Proleter");
            Song5 = new Track("Throw It Back", ElectroswingString, "Proleter");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5 };
            Artist Proleter = new Artist("Proleter", Songs);

            SetList(ElectroSwingList, Songs);
            #endregion
            #region R3HAB - BigRoom
            Song1 = new Track("Flashlight", BigRoomString, "R3HAB");
            Song2 = new Track("Tiger", BigRoomString, "R3HAB");
            Song3 = new Track("Won't Stop Rocking", BigRoomString, "R3HAB");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist R3HAB = new Artist("R3HAB", Songs);

            SetList(BigRoomList, Songs);
            #endregion
            #region S3RL - Hardcore 
            Song1 = new Track("Never Let You Go", HardcoreString, "S3RL");
            Song2 = new Track("Take My Heart", HardcoreString, "S3RL");
            Song3 = new Track("River Flows In You - S3RL Mix", HardcoreString, "S3RL");
            Song4 = new Track("Neko Nation", HardcoreString, "S3RL");
            Song5 = new Track("Adrenalized", HardcoreString, "S3RL");
            Song6 = new Track("Again", HardcoreString, "S3RL");
            Song7 = new Track("Al Capone", HardcoreString, "S3RL");
            Song8 = new Track("All That I Need", HardcoreString, "S3RL");
            Song9 = new Track("And I'm Like", HardcoreString, "S3RL");
            Song10 = new Track("Avaline", HardcoreString, "S3RL");
            Song11 = new Track("Bass Slut", HardcoreString, "S3RL");
            Song12 = new Track("Beat All the Odds", HardcoreString, "S3RL");
            Song13 = new Track("Berserk", HardcoreString, "S3RL");
            Song14 = new Track("Bff", HardcoreString, "S3RL");
            Song15 = new Track("Candy", HardcoreString, "S3RL");
            Song16 = new Track("Casual N00b", HardcoreString, "S3RL");
            Song17 = new Track("Catchit", HardcoreString, "S3RL");
            Song18 = new Track("Cherry Pop", HardcoreString, "S3RL");
            Song19 = new Track("Chillcore", HardcoreString, "S3RL");
            Song20 = new Track("Click Bait", HardcoreString, "S3RL");
            Song21 = new Track("Crazy Ass Bitch", HardcoreString, "S3RL");
            Track Song22 = new Track("Da De da", HardcoreString, "S3RL");
            Track Song23 = new Track("Earth Bb", HardcoreString, "S3RL");
            Track Song24 = new Track("Electric Sky", HardcoreString, "S3RL");
            Track Song25 = new Track("Escape", HardcoreString, "S3RL");
            Track Song26 = new Track("Feel the Melody", HardcoreString, "S3RL");
            Track Song27 = new Track("Forbidden", HardcoreString, "S3RL");
            Track Song28 = new Track("Forever", HardcoreString, "S3RL");
            Track Song29 = new Track("Fugazi", HardcoreString, "S3RL");
            Track Song30 = new Track("Galleriet", HardcoreString, "S3RL");
            Track Song31 = new Track("Generic Holiday", HardcoreString, "S3RL");
            Track Song32 = new Track("Genre Police", HardcoreString, "S3RL");
            Track Song33 = new Track("Hentai", HardcoreString, "S3RL");
            Track Song34 = new Track("I'll See You Again", HardcoreString, "S3RL");
            Track Song35 = new Track("Hypnotoad", HardcoreString, "S3RL");
            Track Song36 = new Track("Inspiration", HardcoreString, "S3RL");
            Track Song37 = new Track("It's This Again", HardcoreString, "S3RL");
            Track Song38 = new Track("I Wanna Stay", HardcoreString, "S3RL");
            Track Song39 = new Track("I WIll Pick You up", HardcoreString, "S3RL");
            Track Song40 = new Track("Jaded Af", HardcoreString, "S3RL");
            Track Song41 = new Track("JP", HardcoreString, "S3RL");
            Track Song42 = new Track("LA", HardcoreString, "S3RL");
            Track Song43 = new Track("Let The Beat Go", HardcoreString, "S3RL");
            Track Song44 = new Track("Like This", HardcoreString, "S3RL");
            Track Song45 = new Track("Little Kandi Raver", HardcoreString, "S3RL");
            Track Song46 = new Track("Misleading Title", HardcoreString, "S3RL");
            Track Song47 = new Track("Mr. Vain", HardcoreString, "S3RL");
            Track Song48 = new Track("Mtc", HardcoreString, "S3RL");
            Track Song49 = new Track("Mtc2", HardcoreString, "S3RL");
            Track Song50 = new Track("Mtc Saga", HardcoreString, "S3RL");
            Track Song51 = new Track("Music Is My Savior", HardcoreString, "S3RL");
            Track Song52 = new Track("Mysten", HardcoreString, "S3RL");
            Track Song53 = new Track("Next Time", HardcoreString, "S3RL");
            Track Song54 = new Track("Nightcore This", HardcoreString, "S3RL");
            Track Song55 = new Track("Nostalgic", HardcoreString, "S3RL");
            Track Song56 = new Track("Now That I've Found You", HardcoreString, "S3RL");
            Track Song57 = new Track("Old Stuff", HardcoreString, "S3RL");
            Track Song58 = new Track("Operation Doomsday", HardcoreString, "S3RL");
            Track Song59 = new Track("Over The Rainbow", HardcoreString, "S3RL");
            Track Song60 = new Track("Pika Girl", HardcoreString, "S3RL");
            Track Song61 = new Track("Planet Rave", HardcoreString, "S3RL");
            Track Song62 = new Track("Pretty Rave Girl", HardcoreString, "S3RL");
            Track Song63 = new Track("Princess Bubbelgum", HardcoreString, "S3RL");
            Track Song64 = new Track("Public Service Announcement", HardcoreString, "S3RL");
            Track Song65 = new Track("Put Your Phones up", HardcoreString, "S3RL");
            Track Song66 = new Track("Quack Pack", HardcoreString, "S3RL");
            Track Song67 = new Track("R4v3 BOy", HardcoreString, "S3RL");
            Track Song68 = new Track("Ravers Mashup", HardcoreString, "S3RL");
            Track Song69 = new Track("Can't Bring Me Down", HardcoreString, "S3RL");
            Track Song70 = new Track("Rainbow Girl", HardcoreString, "S3RL");
            Track Song71 = new Track("Request", HardcoreString, "S3RL");
            Track Song72 = new Track("Scary Movie", HardcoreString, "S3RL");
            Track Song73 = new Track("Self Titled", HardcoreString, "S3RL");
            Track Song74 = new Track("Shroom", HardcoreString, "S3RL");
            Track Song75 = new Track("Shoulder Boulders", HardcoreString, "S3RL");
            Track Song76 = new Track("Silicon XX", HardcoreString, "S3RL");
            Track Song77 = new Track("Sorority House", HardcoreString, "S3RL");
            Track Song78 = new Track("Space Invader", HardcoreString, "S3RL");
            Track Song79 = new Track("Space-Time", HardcoreString, "S3RL");
            Track Song80 = new Track("Speechless", HardcoreString, "S3RL");
            Track Song81 = new Track("Spoiler Alert", HardcoreString, "S3RL");
            Track Song82 = new Track("Starlight Starbright", HardcoreString, "S3RL");
            Track Song83 = new Track("Summerbass", HardcoreString, "S3RL");
            Track Song84 = new Track("Tell Me What You Want", HardcoreString, "S3RL");
            Track Song85 = new Track("The Flying Dutchman", HardcoreString, "S3RL");
            Track Song86 = new Track("The Perfect Rave", HardcoreString, "S3RL");
            Track Song87 = new Track("The Power of Love of Power", HardcoreString, "S3RL");
            Track Song88 = new Track("Through the Years", HardcoreString, "S3RL");
            Track Song89 = new Track("To My Dream", HardcoreString, "S3RL");
            Track Song90 = new Track("Toxic", HardcoreString, "S3RL");
            Track Song91 = new Track("Transformers", HardcoreString, "S3RL");
            Track Song92 = new Track("Trillium", HardcoreString, "S3RL");
            Track Song93 = new Track("Upper Hand", HardcoreString, "S3RL");
            Track Song94 = new Track("Well, That Was Awkward", HardcoreString, "S3RL");
            Track Song95 = new Track("What Is a DJ?", HardcoreString, "S3RL");
            Track Song96 = new Track("When I Die", HardcoreString, "S3RL");
            Track Song97 = new Track("When I'm There", HardcoreString, "S3RL");
            Track Song98 = new Track("Where Did You Go", HardcoreString, "S3RL");
            Track Song99 = new Track("Whirlwind", HardcoreString, "S3RL");
            Track Song100 = new Track("Yeah Science", HardcoreString, "S3RL");
            Track Song101 = new Track("You're My Superhero", HardcoreString, "S3RL");
            Track Song102 = new Track("Press Play, Wal Away", HardcoreString, "S3RL");
            Track Song103 = new Track("My Girlfriend Is Raver", HardcoreString, "S3RL");
            Track Song104 = new Track("Blow The House", HardcoreString, "S3RL");
            Track Song105 = new Track("Let It Go - S3RL Remix", HardcoreString, "S3RL");

            Songs = new Track[] {Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15, Song16, Song17, Song18, Song19, Song20, Song21, Song22, Song23, Song24, Song25, Song26,
            Song27, Song28, Song29, Song30, Song31, Song32, Song33, Song34, Song35, Song36, Song37, Song38, Song39, Song40, Song41, Song42, Song43, Song44, Song45, Song46, Song47, Song48, Song49, Song50, Song51, Song52, Song52,
            Song53, Song54, Song55, Song56, Song57, Song58, Song59, Song60, Song61, Song62, Song63, Song64, Song65, Song66, Song67, Song68, Song69, Song70, Song71, Song72, Song73, Song74, Song75, Song76, Song77, Song78, Song79,
            Song80, Song81, Song82, Song83, Song84, Song85, Song86, Song87, Song88, Song89, Song90, Song91, Song92 ,Song93, Song94, Song95, Song96, Song97, Song98, Song99, Song100, Song101, Song102, Song103, Song104, Song105 };
            Artist S3RL = new Artist("S3RL", Songs);

            SetList(HardcoreList, Songs);
            #endregion
            #region Scott Brown - Hardcore
            Song1 = new Track("Neckbreaker", HardcoreString, "Scott Brown");
            Song2 = new Track("All About You", HardcoreString, "Scott Brown");
            Song3 = new Track("Beacuse of You", HardcoreString, "Scott Brown");
            Song4 = new Track("Energized", HardcoreString, "Scott Brown");
            Song5 = new Track("Taking Drugs?", HardcoreString, "Scott Brown");
            Song6 = new Track("Fly With You", HardcoreString, "Scott Brown");
            Song7 = new Track("How Many Sukkas?", HardcoreString, "Scott Brown");
            Song8 = new Track("Put Them Up", HardcoreString, "Scott Brown");
            Song9 = new Track("The Spark", HardcoreString, "Scott Brown");
            Song10 = new Track("To The Beat", HardcoreString, "Scott Brown");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10 };
            Artist ScottBrown = new Artist("Scott Brown", Songs);

            SetList(HardcoreList, Songs);
            #endregion
            #region SelloRekt / LA Dreams - Synthwave
            Song1 = new Track("Waves on the Pacific Ocean", SynthwaveString, "SelloRekt / LA Dreams");
            Song2 = new Track("Remnants", SynthwaveString, "SelloRekt / LA Dreams");
            Song3 = new Track("A Dystopian Fixation", SynthwaveString, "SelloRekt / LA Dreams");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist SelloRektLADreams = new Artist("SelloRekt / LA Dreams", Songs);

            SetList(SynthwaveList, Songs);
            #endregion
            #region Set It Off - ADDITIONAL | Pop, Rock
            Song1 = new Track("Dad's Song", PopString, "Set It Off")
            {
                AdditionalGenre = RockString
            };
            Song2 = new Track("Forever Stuck in Our Youth", PopString, "Set It Off");
            Song3 = new Track("Why Worry", PopString, "Set It Off")
            {
                AdditionalGenre = RockString
            };
            Song4 = new Track("Ancient History", PopString, "Set It Off")
            {
                AdditionalGenre = RockString
            };
            Song5 = new Track("Duality", PopString, "Set It Off");
            Song6 = new Track("Wolf In Sheep's Clothing", PopString, "Set It Off")
            {
                AdditionalGenre = RockString
            };
            Song7 = new Track("Bad Guy", PopString, "Set It Off");
            Song8 = new Track("Life Afraid", PopString, "Set It Off");
            Song9 = new Track("Something New", PopString, "Set It Off");
            Song10 = new Track("Uncontainable", PopString, "Set It Off");
            Song11 = new Track("Upside Down", PopString, "Set It Off");
            Song12 = new Track("Diamond Girl", PopString, "Set It Off");
            Song13 = new Track("Tug of War", PopString, "Set It Off");
            Song14 = new Track("Admit It", PopString, "Set It Off");
            Song15 = new Track("Hypnotized", PopString, "Set It Off");
            Song16 = new Track("I'll Sleep When I'm Dead", RockString, "Set It Off");
            Song17 = new Track("Nightmare", RockString, "Set It Off");
            Song18 = new Track("Plastic Primises", RockString, "Set It Off");
            Song19 = new Track("Dream Catcher", RockString, "Set It Off");
            Song20 = new Track("Freak Show", RockString, "Set It Off");
            Song21 = new Track("I'd Rather Drown", RockString, "Set It Off");
            Song22 = new Track("Partners In Crime", RockString, "Set It Off");
            Song23 = new Track("Kill The Lights", RockString, "Set It Off");
            Song24 = new Track("Dancing With The Devil", RockString, "Set It Off");
            Song25 = new Track("The Haunting", RockString, "Set It Off");
            Song26 = new Track("N.M.E.", RockString, "Set It Off");
            Song27 = new Track("Bleak December", RockString, "Set It Off");
            Song28 = new Track("For You Forever", RockString, "Set It Off");
            Song29 = new Track("Killer In The Mirror", RockString, "Set It Off");
            Song30 = new Track("Lonely Dance", RockString, "Set It Off");
            Song31 = new Track("Hourglass", RockString, "Set It Off");
            Song32 = new Track("Different Songs", RockString, "Set It Off");
            Song33 = new Track("Go To Bed Angry", RockString, "Set It Off");
            Song34 = new Track("Criminal Minds", RockString, "Set It Off");
            Song35 = new Track("No Disrespect", RockString, "Set It Off");
            Song36 = new Track("Stich Me Up", RockString, "Set It Off");
            Song37 = new Track("Raise No Fool", RockString, "Set It Off");
            Song38 = new Track("I Want You (Gone)", RockString, "Set It Off");
            Song39 = new Track("Midnight Thoughts", RockString, "Set It Off");

            Songs = new Track[] {Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song13, Song14, Song15, Song16, Song17, Song18, Song19, Song20, Song21, Song22, Song23, Song24, Song25, Song26,
            Song27, Song28, Song29, Song30, Song31, Song32, Song33, Song34, Song35, Song36, Song37, Song38, Song39};
            Artist SetItOff = new Artist("Set It Off", Songs);

            TempSongs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song13, Song14, Song15 };
            SetList(PopList, TempSongs);
            TempSongs = new Track[] { Song1, Song3, Song4, Song6, Song16, Song17, Song18, Song19, Song20, Song21, Song22, Song23, Song24, Song25, Song26, Song27, Song28, Song29, Song30, Song31, Song32, Song33, Song34, Song35, Song36, Song37, Song38, Song39 };
            SetList(RockList, TempSongs);
            #endregion
            #region Skrillex - ADDITIONAL | Dubstep, Electrio
            Song1 = new Track("Levels - Avicii(Skrillex Remix)", DubstepString, "Skrillex");
            Song2 = new Track("Cinema - Benny Benassi (Skrillex Remix)", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song3 = new Track("Holdin' On - I See MONSTAS (Skrillex Remix)", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song4 = new Track("Right In", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song5 = new Track("Bangarang", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song6 = new Track("Kyoto", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song7 = new Track("Summit", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song8 = new Track("First of the Year", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song9 = new Track("Rock N' Roll", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };
            Song10 = new Track("Kill EVERYBODY", DubstepString, "Skrillex")
            {
                AdditionalGenre = ElectrioString
            };

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10 };
            Artist Skrillex = new Artist("Skrillex", Songs);

            SetList(DubstepList, Songs);
            TempSongs = new Track[] { Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10 };
            SetList(ElectrioList, TempSongs);
            #endregion
            #region Stephen Walking - Electro
            Song1 = new Track("Ampersand", ElectroString, "Stephen Walking");
            Song2 = new Track("Birthday Cake", ElectroString, "Stephen Walking");
            Song3 = new Track("Full Grizzly", ElectroString, "Stephen Walking");
            Song4 = new Track("It Came from Planet Earth", ElectroString, "Stephen Walking");
            Song5 = new Track("One Man Moon Band", ElectroString, "Stephen Walking");
            Song6 = new Track("Pizza Plannet", ElectroString, "Stephen Walking");
            Song7 = new Track("Top of the World", ElectroString, "Stephen Walking");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7 };
            Artist StephenWalking = new Artist("Stephen Walking", Songs);

            SetList(ElectroList, Songs);
            #endregion
            #region Stonebank - ADDITIONAL | Electro, Hardcore, Hardstyle
            Song1 = new Track("Blast from the Past", ElectroString, "Stonebank");
            Song2 = new Track("Step up", ElectroString, "Stonebank");
            Song3 = new Track("The Entity", ElectroString, "Stonebank");
            Song4 = new Track("Cold Skin - Stonebank Remix", HardcoreString, "Stonebank");
            Song5 = new Track("All Night", HardcoreString, "Stonebank");
            Song6 = new Track("Be Alright", HardcoreString, "Stonebank");
            Song7 = new Track("By Your Side", HardcoreString, "Stonebank");
            Song8 = new Track("Lift You up", HardcoreString, "Stonebank");
            Song9 = new Track("Moving On", HardcoreString, "Stonebank");
            Song10 = new Track("Ripped to Pieces", HardcoreString, "Stonebank");
            Song11 = new Track("Stronger", HardcoreString, "Stonebank");
            Song12 = new Track("The Only One", HardcoreString, "Stonebank")
            {
                AdditionalGenre = HardstyleString
            };
            Song13 = new Track("The Pressure", HardcoreString, "Stonebank");
            Song14 = new Track("Who's Got Your Love", HardcoreString, "Stonebank")
            {
                AdditionalGenre = HardstyleString
            };

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14 };
            Artist Stonebank = new Artist("Stonebank", Songs);

            TempSongs = new Track[] { Song1, Song2, Song3 };
            SetList(ElectroList, TempSongs);
            TempSongs = new Track[] { Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14 };
            SetList(HardcoreList, TempSongs);
            TempSongs = new Track[] { Song12, Song14 };
            SetList(HardstyleList, TempSongs);
            #endregion
            #region Technikore - Hardcore
            Song1 = new Track("Superhuman - Technikore & JTS Remix", HardcoreString, "Technikore");
            Song2 = new Track("Pretty Rave Girl (Suae X Technikore Remix)", HardcoreString, "Technikore");
            Song3 = new Track("Gang Beasts", HardcoreString, "Technikore");
            Song4 = new Track("Worlds Collide", HardcoreString, "Technikore");
            Song5 = new Track("Nervous", HardcoreString, "Technikore");
            Song6 = new Track("Siren", HardcoreString, "Technikore");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6 };
            Artist Technikore = new Artist("Technikore", Songs);

            SetList(HardcoreList, Songs);
            #endregion
            #region The Material - Rock
            Song1 = new Track("Lift Vest", RockString, "The Material");
            Song2 = new Track("Born to Make a Sound", RockString, "The Material");
            Song3 = new Track("Tonight I'm Letting Go", RockString, "The Material");
            Song4 = new Track("Bottles", RockString, "The Material");
            Song5 = new Track("Gasoline", RockString, "The Material");
            Song6 = new Track("Mistakes", RockString, "The Material");
            Song7 = new Track("The One That Got Away", RockString, "The Material");
            Song8 = new Track("Appearances", RockString, "The Material");
            Song9 = new Track("Let You Down", RockString, "The Material");
            Song10 = new Track("What We Are", RockString, "The Material");
            Song11 = new Track("The Only One", RockString, "The Material");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11 };
            Artist TheMaterial = new Artist("The Material", Songs);

            SetList(RockList, Songs);
            #endregion
            #region Tobu - MelHouse
            Song1 = new Track("Tired - Steerner & Tobu Remix", MelHouseString, "Tobu");
            Song2 = new Track("Blessing", MelHouseString, "Tobu");
            Song3 = new Track("Candyland", MelHouseString, "Tobu");
            Song4 = new Track("Climb", MelHouseString, "Tobu");
            Song5 = new Track("Cloud 9", MelHouseString, "Tobu");
            Song6 = new Track("Colors", MelHouseString, "Tobu");
            Song7 = new Track("Floating", MelHouseString, "Tobu");
            Song8 = new Track("Good Times", MelHouseString, "Tobu");
            Song9 = new Track("Happy Ending", MelHouseString, "Tobu");
            Song10 = new Track("Higher", MelHouseString, "Tobu");
            Song11 = new Track("Hope", MelHouseString, "Tobu");
            Song12 = new Track("Infections", MelHouseString, "Tobu");
            Song13 = new Track("Life", MelHouseString, "Tobu");
            Song14 = new Track("Magic", MelHouseString, "Tobu");
            Song15 = new Track("Mesmerize", MelHouseString, "Tobu");
            Song16 = new Track("Running Away", MelHouseString, "Tobu");
            Song17 = new Track("Seven", MelHouseString, "Tobu");
            Song18 = new Track("Sprinkles", MelHouseString, "Tobu");
            Song19 = new Track("Sunburst", MelHouseString, "Tobu");
            Song20 = new Track("Sweet Story", MelHouseString, "Tobu");
            Song21 = new Track("You & I", MelHouseString, "Tobu");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15, Song16, Song17, Song18, Song19, Song20, Song21 };
            Artist Tobu = new Artist("Tobu", Songs);

            SetList(MelHouseList, Songs);
            #endregion
            #region Tristam - MelDubstep
            Song1 = new Track("Crave", MelDubstepString, "Tristam");
            Song2 = new Track("Far Away", MelDubstepString, "Tristam");
            Song3 = new Track("Extermination", MelDubstepString, "Tristam");
            Song4 = new Track("The Vine", MelDubstepString, "Tristam");
            Song5 = new Track("Till it's Over", MelDubstepString, "Tristam");
            Song6 = new Track("I Remember", MelDubstepString, "Tristam");
            Song7 = new Track("Too Simple", MelDubstepString, "Tristam");
            Song8 = new Track("Truth", MelDubstepString, "Tristam");
            Song9 = new Track("Razor Sharp", MelDubstepString, "Tristam");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9 };
            Artist Tristam = new Artist("Tristam", Songs);

            SetList(MelDubstepList, Songs);
            #endregion
            #region Twenty One Pilots - Pop
            Song1 = new Track("Stressed Out", PopString, "Twenty One Pilots");
            Song2 = new Track("Ride", PopString, "Twenty One Pilots");
            Song3 = new Track("Heathens", PopString, "Twenty One Pilots");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist TwentyOnePilots = new Artist("Twenty One Pilots", Songs);

            SetList(PopList, Songs);
            #endregion
            #region Ude af Kontrol - Bounce
            Song1 = new Track("Fuckboi", BounceString, "Ude af Kontrol");
            Song2 = new Track("Det Halve Ku' Være Nok", BounceString, "Ude af Kontrol");
            Song3 = new Track("Ta' Dine Sko Af", BounceString, "Ude af Kontrol");
            Song4 = new Track("Jantelov", BounceString, "Ude af Kontrol");
            Song5 = new Track("Næ", BounceString, "Ude af Kontrol");
            Song6 = new Track("Jumanji", BounceString, "Ude af Kontrol");
            Song7 = new Track("O.M.G.", BounceString, "Ude af Kontrol");
            Song8 = new Track("Op A", BounceString, "Ude af Kontrol");
            Song9 = new Track("Snehvide med de 7 små poser", BounceString, "Ude af Kontrol");
            Song10 = new Track("Ikk Giv Op", BounceString, "Ude af Kontrol");
            Song11 = new Track("Fejre Det Hele", BounceString, "Ude af Kontrol");
            Song12 = new Track("Ku Godt", BounceString, "Ude af Kontrol");
            Song13 = new Track("Velsignet - Har det godt pt.2", BounceString, "Ude af Kontrol");
            Song14 = new Track("Den Bedste Julesang Ever", BounceString, "Ude af Kontrol");
            Song15 = new Track("Douchebag", BounceString, "Ude af Kontrol");
            Song16 = new Track("Lækker Krop Grimt Fjæs", BounceString, "Ude af Kontrol");
            Song17 = new Track("Hælder Op", BounceString, "Ude af Kontrol");
            Song18 = new Track("Skru Op", BounceString, "Ude af Kontrol");
            Song19 = new Track("Spiller Dum", BounceString, "Ude af Kontrol");
            Song20 = new Track("Moshpit", BounceString, "Ude af Kontrol");
            Song21 = new Track("3xK", BounceString, "Ude af Kontrol");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11, Song12, Song13, Song14, Song15, Song16, Song17, Song18, Song19, Song20, Song21 };
            Artist UdeAfKontrol = new Artist("Ude Af Kontrol", Songs);

            SetList(BounceList, Songs);
            #endregion
            #region Vicetone ADDITIONAL | Spinnin, ProgDream, ProgHouse
            Song1 = new Track("Heartbeat", SpinninString, "Vicetone")
            {
                AdditionalGenre = ProgDreamString
            };
            Song2 = new Track("I'm On Fire", SpinninString, "Vicetone")
            {
                AdditionalGenre = ProgHouseString
            };
            Song3 = new Track("Pitch Black", SpinninString, "Vicetone")
            {
                AdditionalGenre = ProgHouseString
            };
            Song4 = new Track("Angels", ProgHouseString, "Vicetone");
            Song5 = new Track("Catch Me", ProgHouseString, "Vicetone");
            Song6 = new Track("Heat", ProgHouseString, "Vicetone");
            Song7 = new Track("Hope", ProgHouseString, "Vicetone");
            Song8 = new Track("No Way Out", ProgHouseString, "Vicetone");
            Song9 = new Track("What I've Waited for", ProgHouseString, "Vicetone");
            Song10 = new Track("Nothing Stopping Me", ProgDreamString, "Vicetone");
            Song11 = new Track("United We Dance", ProgDreamString, "Vicetone");

            Songs = new Track[] { Song1, Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9, Song10, Song11 };
            Artist Vicetone = new Artist("Vicetone", Songs);

            TempSongs = new Track[] { Song1, Song2, Song3 };
            SetList(SpinninList, TempSongs);
            TempSongs = new Track[] { Song2, Song3, Song4, Song5, Song6, Song7, Song8, Song9 };
            SetList(ProgHouseList, TempSongs);
            TempSongs = new Track[] { Song1, Song10, Song11 };
            SetList(ProgDreamList, TempSongs);
            #endregion
            #region Zedd - House
            Song1 = new Track("Break Free", HouseString, "Zedd");
            Song2 = new Track("Good Thing", HouseString, "Zedd");
            Song3 = new Track("I Want You To Know", HouseString, "Zedd");
            Song4 = new Track("Beautiful Now", HouseString, "Zedd");

            Songs = new Track[] { Song1, Song2, Song3, Song4 };
            Artist Zedd = new Artist("Zedd", Songs);

            SetList(HouseList, Songs);
            #endregion
            #region Zomboy - Dubstep
            Song1 = new Track("Here to Stay", DubstepString, "Zomboy");
            Song2 = new Track("Nuclear", DubstepString, "Zomboy");
            Song3 = new Track("City 2 City", DubstepString, "Zomboy");

            Songs = new Track[] { Song1, Song2, Song3 };
            Artist Zomboy = new Artist("Zomboy", Songs);

            SetList(DubstepList, Songs);
            #endregion
            #endregion

            Artists = new Artist[] {Blau, AfterForever, Ahrix, AlStorm, AlanWalker, Atef, Avicii, Basshunter, Bassjackers, BrianTuey, CalvinHarris, DaTweekaz, DanielSimonsen, DJGollum, DVBBS, FallOutBoy, FloRida, FM84, Italobrothers,
            JochenMiller, JoeyMoe, K391, KnifeParty, Krewella, Kygo, Lensko, LukasGraham, Mako, MarcusMouya, Marshmello, MikkelChristiansen, MyChemicalRomance, NerdOut, Nightcore, OMFG, PandaEyes, PanicAtTheDisco, PegboardNerds,
            Proleter, R3HAB, S3RL, ScottBrown, SelloRektLADreams, SetItOff, Skrillex, StephenWalking, Stonebank, Technikore, TheMaterial, Tobu, Tristam, TwentyOnePilots, UdeAfKontrol, Vicetone, Zedd, Zomboy};
            #endregion

            #region Set Genres
            string Major = "Major", Minor = "Minor", Neutral = "Neutral";

            #region Big Room
            string[,] DrumLibrary = SetDrumLibrary();
            Drums Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 2], DrumLibrary[2, 3], DrumLibrary[3, 0], DrumLibrary[4, 1], false, true, true, true);
            Synths Synths = new Synths(true, true, true, true);
            Instruments Instruments = new Instruments(true, false, true, true);

            Genre BigRoom = new Genre("Big Room", 126, 150, Drums, Synths, Instruments, Neutral, BigRoomList);
            Genre Spinnin = new Genre("Spinnin' Records", 125, 131, Drums, Synths, Instruments, Neutral, SpinninList);
            Genre[] BigRoomArray = { BigRoom, Spinnin };
            #endregion
            #region Bounce
            List<Track> NullList = new List<Track>();
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 1], DrumLibrary[1, 1], DrumLibrary[4, 1], false, true, true, false);
            Genre Bootleg = new Genre("Bootleg", 128, 140, Drums, Synths, Instruments, Neutral, NullList);
            Genre Bounce = new Genre("Bounce", 125, 175, Drums, Synths, Instruments, Neutral, BounceList);
            Genre MelbourneBounce = new Genre("Melbourne Bounce", 126, 128, Drums, Synths, Instruments, Major, NullList);
            Genre[] BounceArray = { Bootleg, Bounce, MelbourneBounce };
            #endregion
            #region Drum n' Stuff
            Drums = new Drums(DrumLibrary[0, 5], DrumLibrary[1, 2], DrumLibrary[2, 3], DrumLibrary[3, 0], DrumLibrary[4, 3], false, true, true, false);
            Synths = new Synths(true, true, true, false);
            Instruments = new Instruments(true, true, false, false);
            Genre Drumstep = new Genre("Drumstep", 110, 175, Drums, Synths, Instruments, Neutral, DrumstepList);

            Drums = new Drums(DrumLibrary[0, 0], DrumLibrary[0, 1], DrumLibrary[2, 1], DrumLibrary[3, 0], DrumLibrary[4, 1], false, true, true, false);
            Synths = new Synths(true, true, true, true);
            Genre DrumNBass = new Genre("Drum n' Bass", 160, 180, Drums, Synths, Instruments, Neutral, NullList);
            Genre[] DrumNStuffArray = { Drumstep, DrumNBass };
            #endregion
            #region Dubstep
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 2], DrumLibrary[2, 1], DrumLibrary[3, 2], DrumLibrary[4, 1], false, true, true, false);
            Synths = new Synths(true, true, true, true);
            Instruments = new Instruments(true, true, true, true);
            Genre Dubstep = new Genre("Dubstep", 125, 174, Drums, Synths, Instruments, Minor, DubstepList);
            Genre MelodicDubstep = new Genre("Melodic Dubstep", 105, 174, Drums, Synths, Instruments, Neutral, MelDubstepList);
            Genre[] DubstepArray = { Dubstep, MelodicDubstep };
            #endregion
            #region Future
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 3], DrumLibrary[3, 1], DrumLibrary[4, 3], false, true, true, true);
            Genre FutureBass = new Genre("Future Bass", 140, 170, Drums, Synths, Instruments, Major, NullList);
            Genre FutureFunk = new Genre("Future Funk", 90, 132, Drums, Synths, Instruments, Major, NullList);
            Genre FutureHouse = new Genre("Future House", 120, 160, Drums, Synths, Instruments, Neutral, NullList);
            Genre FutureBounce = new Genre("Future Bounce", 125, 128, Drums, Synths, Instruments, Neutral, NullList);
            Genre[] FutureArray = { FutureBass, FutureFunk, FutureHouse, FutureBounce };
            #endregion
            #region Electro
            #region Electro
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 3], DrumLibrary[3, 1], DrumLibrary[4, 1], false, true, true, false);
            Instruments = new Instruments(true, true, true, false);
            Genre Electro = new Genre("Electro", 100, 130, Drums, Synths, Instruments, Neutral, ElectroList);
            #endregion
            #region Electro-Swing
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 0], DrumLibrary[3, 0], DrumLibrary[4, 1], false, true, true, false);
            Synths = new Synths(false, false, false, false);
            Instruments = new Instruments(true, false, true, true);
            Genre Electroswing = new Genre("Electro-Swing", 90, 128, Drums, Synths, Instruments, Major, ElectroSwingList);
            #endregion
            Genre[] ElectroArray = { Electro, Electroswing };
            #endregion
            #region General
            #region General EDM
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 1], DrumLibrary[3, 2], DrumLibrary[4, 1], false, true, true, false);
            Synths = new Synths(true, true, true, true);
            Instruments = new Instruments(true, false, true, true);
            Genre GeneralEDM = new Genre("General EDM", 110, 140, Drums, Synths, Instruments, Neutral, NullList);
            #endregion
            #region EDM Trap
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 1], DrumLibrary[3, 1], DrumLibrary[4, 4], false, true, true, true);
            Synths = new Synths(true, true, false, true);
            Instruments = new Instruments(true, true, true, true);
            Genre EDMTrap = new Genre("EDM Trap", 95, 170, Drums, Synths, Instruments, Minor, EDMTrapList);
            #endregion
            #region Electrio
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 3], DrumLibrary[3, 1], DrumLibrary[4, 1], false, true, true, false);
            Synths = new Synths(true, true, true, true);
            Instruments = new Instruments(true, true, true, false);
            Genre Electrio = new Genre("Electrio", 100, 175, Drums, Synths, Instruments, Neutral, ElectrioList);
            #endregion
            #region Pop
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 3], DrumLibrary[3, 1], DrumLibrary[4, 1], false, true, true, false);
            Instruments = new Instruments(true, true, true, true);
            Genre Pop = new Genre("Pop", 75, 140, Drums, Synths, Instruments, Neutral, PopList);
            #endregion
            #region Psytrance
            Drums = new Drums(DrumLibrary[0, 4], DrumLibrary[1, 0], DrumLibrary[2, 1], DrumLibrary[3, 2], DrumLibrary[4, 1], false, true, true, false);
            Genre Psytrance = new Genre("Psytrance", 138, 145, Drums, Synths, Instruments, Neutral, NullList);
            #endregion
            #region Trap / Hip-Hop
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 0], DrumLibrary[2, 1], DrumLibrary[3, 1], DrumLibrary[4, 4], false, true, true, true);
            Synths = new Synths(true, true, false, true);
            Instruments = new Instruments(true, true, true, true);
            Genre TrapHipHop = new Genre("Trap/Hip-Hop", 135, 145, Drums, Synths, Instruments, Minor, NullList);
            #endregion
            Genre[] GeneralArray = { GeneralEDM, EDMTrap, Electrio, Pop, Psytrance, TrapHipHop };
            #endregion
            #region Hype
            #region Eurodance
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 0], DrumLibrary[3, 2], DrumLibrary[4, 1], true, true, true, false);
            Synths = new Synths(true, true, true, true);
            Instruments = new Instruments(true, true, true, true);
            Genre Eurodance = new Genre("Eurodance", 126, 155, Drums, Synths, Instruments, Major, EurodanceList);
            #endregion
            #region Hands Up
            Genre HandsUp = new Genre("Hands Up", 128, 170, Drums, Synths, Instruments, Major, HandsUpList);
            #endregion
            #region Hardcore
            Drums = new Drums(DrumLibrary[0, 5], DrumLibrary[1, 1], DrumLibrary[2, 3], DrumLibrary[3, 2], DrumLibrary[4, 5], false, true, true, false);
            Genre Hardcore = new Genre("Hardcore", 150, 180, Drums, Synths, Instruments, Major, HardcoreList);
            #endregion
            Genre Hardstyle = new Genre("Hardstyle", 150, 170, Drums, Synths, Instruments, Neutral, HardstyleList);
            Genre[] HypeArray = { Eurodance, HandsUp, Hardcore, Hardstyle };
            #endregion
            #region House
            #region House
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 0], DrumLibrary[3, 1], DrumLibrary[4, 1], false, true, true, false);
            Genre DeepHouse = new Genre("Deep House", 120, 130, Drums, Synths, Instruments, Major, NullList);
            Genre House = new Genre("House", 120, 130, Drums, Synths, Instruments, Neutral, HouseList);
            Genre MelodicHouse = new Genre("Melodic House", 128, 140, Drums, Synths, Instruments, Major, MelHouseList);
            #endregion
            Synths = new Synths(false, true, false, true);
            Instruments = new Instruments(true, true, true, false);
            Genre TropicalHouse = new Genre("Tropical House", 100, 128, Drums, Synths, Instruments, Major, TropHouseList)
            {
                ContainsSynths = false
            };
            Genre[] HouseArray = { DeepHouse, House, MelodicHouse, TropicalHouse };
            #endregion
            #region Progressive House
            Synths = new Synths(true, true, true, true);
            Instruments = new Instruments(true, true, true, true);
            Genre ProgressiveHouse = new Genre("Progressive House", 120, 135, Drums, Synths, Instruments, Neutral, ProgHouseList);
            Genre ProgressiveDream = new Genre("Progressive Dream", 110, 130, Drums, Synths, Instruments, Major, ProgDreamList);
            Genre ProgressivePop = new Genre("Progressive Pop", 125, 130, Drums, Synths, Instruments, Neutral, ProgPopList);
            Genre NCSStyle = new Genre("NCS Style", 128, 128, Drums, Synths, Instruments, Neutral, NullList);
            Genre[] ProgHouseArray = { ProgressiveHouse, ProgressiveDream, ProgressivePop, NCSStyle };
            #endregion
            #region Electro House
            Genre ElectroHouse = new Genre("Electro-House", 90, 175, Drums, Synths, Instruments, Neutral, ElecHouseList);
            Genre LiteralElectro = new Genre("Taking Electro Literal", 128, 130, Drums, Synths, Instruments, Neutral, NullList);
            Genre Dudududu = new Genre("Dudu dudu", 100, 130, Drums, Synths, Instruments, Neutral, DuduList);
            Genre[] ElecHouseArray = { ElectroHouse, LiteralElectro, Dudududu };
            #endregion
            #region Old School
            Drums = new Drums(DrumLibrary[0, 1], DrumLibrary[1, 1], DrumLibrary[2, 0], DrumLibrary[3, 0], DrumLibrary[4, 1], true, true, true, false);
            Genre Downtempo = new Genre("Downtempo", 100, 130, Drums, Synths, Instruments, Neutral, NullList);
            Genre Synthwave = new Genre("Synthwave", 90, 133, Drums, Synths, Instruments, Neutral, SynthwaveList);
            Genre[] OldSchoolArray = { Downtempo, Synthwave };
            #endregion
            #region Classic Genres
            #region Acoustic
            Drums = new Drums(DrumLibrary[0, 0], DrumLibrary[1, 1], DrumLibrary[2, 0], DrumLibrary[3, 0], DrumLibrary[4, 0], false, true, true, false);
            Synths = new Synths(false, false, false, false);
            Instruments = new Instruments(true, true, true, false);
            Genre Acoustic = new Genre("Acoustic", 80, 130, Drums, Synths, Instruments, Neutral, NullList)
            {
                ContainsSynths = false
            };
            #endregion
            Genre Country = new Genre("Country", 70, 120, Drums, Synths, Instruments, Neutral, NullList)
            {
                ContainsSynths = false
            };
            Genre Rock = new Genre("Rock, Metal, etc.", 80, 180, Drums, Synths, Instruments, Neutral, RockList)
            {
                ContainsSynths = false
            };

            Drums = new Drums(DrumLibrary[0, 2], DrumLibrary[1, 1], DrumLibrary[2, 2], DrumLibrary[3, 0], DrumLibrary[4, 2], false, true, true, false);
            Genre LoFi = new Genre("Lo-Fi", 70, 100, Drums, Synths, Instruments, Neutral, NullList)
            {
                ContainsSynths = false
            };

            Genre[] ClassicGenresArray = { Acoustic, Country, Rock, LoFi };
            #endregion

            Genres = new Genre[][] { BigRoomArray, BounceArray, DrumNStuffArray, DubstepArray, FutureArray, ElectroArray, GeneralArray, HypeArray, HouseArray, ProgHouseArray, ElecHouseArray,
                OldSchoolArray, ClassicGenresArray };
            GenresNonCategorized = new Genre[] {BigRoom, Spinnin, Bootleg, Bounce, MelbourneBounce, Drumstep, DrumNBass, Dubstep, MelodicDubstep, FutureBass, FutureFunk, FutureHouse, FutureBounce, Electro, Electroswing,
            GeneralEDM, EDMTrap, Electrio, Pop, Psytrance, TrapHipHop, Eurodance, HandsUp, Hardcore, Hardstyle, DeepHouse, House, MelodicHouse, TropicalHouse, ProgressiveHouse, ProgressiveDream, ProgressivePop, NCSStyle,
            ElectroHouse, LiteralElectro, Dudududu, Downtempo, Synthwave, Acoustic, Country, Rock, LoFi};

            foreach (Genre genre in GenresNonCategorized)
                genre.Drums.AllDrums = DrumLibrary;
            #endregion

            #region Set Main
            Main = new string[]{"Big", "Chunky", "Small", "Little", "The", "Black", "Blue", "Red", "White", "Winter", "Spring", "Summer", "Fall", "Addicted", "Adventure", "Admit", "After", "Alive",
            "All", "Alone", "You", "Back", "Bad", "Be", "Beautiful", "Better", "End", "Cold", "Cloud", "Color", "Come", "Death", "Different", "Don't", "Falling", "Far", "Feel", "Fire",
            "First", "Free", "Freak", "Ghost", "Girl", "Go", "God", "Gold", "Happy", "Hard", "Heart", "Heaven", "Hentai", "Heat", "Hero", "Home", "Empty", "Hope", "How", "I", "I'm",
            "In", "Illuminated", "Infinity", "It", "Kill", "Let", "Life", "Lonely", "Lost", "Love", "Memories", "Sun", "Moon", "Sword", "Shield", "My", "New", "Never", "No", "Old", "On",
            "Our", "Power", "Bussy", "Rain", "Run", "Running", "Round", "Square", "Sing", "Slow", "Stay", "Still", "Sweet", "Take", "This", "Time", "Together", "Untitled", "Waiting", "We",
                "Young", "Cum", "Experience", "Song"};
            #endregion
        }
        /// <summary>
        /// Converts <paramref name="Songs"/> into <paramref name="List"/>
        /// </summary>
        /// <param name="List">List to convert to</param>
        /// <param name="Songs">Songs array to convert</param>
        private void SetList(List<Track> List, Track[] Songs)
        {
            foreach (Track track in Songs)
                List.Add(track);
        }
        /// <summary>
        /// Default Drum library
        /// </summary>
        /// <returns>TempDrums[,]</returns>
        private string[,] SetDrumLibrary()
        {
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

            return TempDrums;
        }
        #endregion

        #region Genres
        /// <summary>
        /// Genres[Category][Genre]
        /// </summary>
        public Genre[][] Genres { get; set; }
        public Genre[] GenresNonCategorized { get; set; }
        public Genre Genre { get; set; }
        #endregion

        #region Artists
        public Artist[] Artists { get; set; }
        public Artist Artist { get; set; }
        #endregion

        #region Song
        public Track Song { get; set; }
        public void GetReferenceSong(bool LFGenre, bool LFArtist)
        {
            try
            {
                if (LFGenre && LFArtist)
                {
                    List<Track> SongsList = new List<Track>();
                    foreach (Track track in Artist.Tracks)
                        if (track.Genre == Genre.GenreName && !SongsList.Contains(track))
                            SongsList.Add(track);
                        else if (track.AdditionalGenre == Genre.GenreName && !SongsList.Contains(track))
                            SongsList.Add(track);
                    Song = SongsList.ToArray()[Rand.Next(SongsList.Count)];
                }
                else if (LFArtist)
                {
                    Song = Artist.Tracks[Rand.Next(Artist.Tracks.Length)];
                    foreach (Genre genre in GenresNonCategorized)
                    {
                        if (genre.GenreName == Song.Genre)
                            Genre = genre;
                    }
                }
                else
                    Song = Genre.Songs.ToArray()[Rand.Next(Genre.Songs.Count)];
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Title
        public string Title { get; set; }
        public string[] TitleItem = { "", "", "" };
        public string[] Main { get; set; }
        private string SetTitle(string[] WordsArray)
        {
            #region Variables
            string Title = "";
            #endregion

            for (int x = 0; x < Rand.Next(1, 4); x++)
                if (x >= 1)
                    Title += " " + WordsArray[Rand.Next(WordsArray.Length)];
                else
                    Title = WordsArray[Rand.Next(WordsArray.Length)];
            return Title;
        }
        #endregion

        #region BPM
        public int BPM = 0;
        public int RandomizeBPM(Genre genre)
        {
            int Min = genre.MinBPM, Max = genre.MaxBPM;
            return Rand.Next(Min, Max);
        }
        #endregion

        #region Scale
        public string Scale = "Scale";
        /// <summary>
        /// Set the scale of the song
        /// </summary>
        /// <param name="TypicalScale">The genre is typically in this scale</param>
        private void SetScale(string TypicalScale)
        {
            int ScalePercentage = Rand.Next(100);

            if (TypicalScale == "Major" && ScalePercentage > 25 ||
                TypicalScale == "Neutral" && ScalePercentage >= 50)
                Scale = SetRandomKey() + " Major";

            else if (TypicalScale == "Minor" && ScalePercentage > 25 ||
                TypicalScale == "Neutral" && ScalePercentage < 50)
                Scale = SetRandomKey() + " Minor";

            else if (TypicalScale == "Minor")
                Scale = SetRandomKey() + " Major";

            else //if (TypicalScale == "Major")
                Scale = SetRandomKey() + " Minor";
        }
        /// <summary>
        /// Set the Key of the song
        /// </summary>
        /// <returns></returns>
        private string SetRandomKey()
        {
            string[] Keys = { "A", "A#/Bb", "B", "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab" };
            return Keys[Rand.Next(Keys.Length)];
        }
        #endregion

        #region Stock Sounds
        public Drums Drums { get; set; }
        public Instruments Instruments { get; set; }
        private bool StockSounds = true;
        #endregion


        #region Get Idea
        public void GetInfo(bool RandomizeDrums)
        {
            if(StockSounds)
            {
                Drums = Genre.Drums;
                Instruments = Genre.Instruments;
                StockSounds = false;
            }
            else
            {
                Genre.Drums = Drums;
                Genre.Instruments = Instruments;
            }

            Console.WriteLine($"Song Name: {Title}");
            Console.WriteLine($"Genre: {Genre.GenreName}");
            Console.WriteLine($"BPM: {BPM}");
            Console.WriteLine($"Scale: {Scale}");
            Console.WriteLine();
            if (Song != null)
                if (Song.GetReferenceTrack())
                    Console.WriteLine();
            //if (RandomizeDrums)
                //Genre.Drums.RandomizeDrums();
            Genre.Drums.GetDrums();
            Console.WriteLine();
            Genre.Synths.GetSynths(Genre.ContainsSynths);
            Console.WriteLine();
            Genre.Instruments.GetInstruments();
        }
        public void GenerateIdea(string[] WordsArray)
        {
            #region Set Title
            Title = $"\"{SetTitle(WordsArray)}\"";
            if (Title == "")
                while (Title == "")
                    Title = $"\"{SetTitle(WordsArray)}\"";
            #endregion

            #region Set Genre
            int Category = Rand.Next(Genres.Length);
            Genre = Genres[Category][Rand.Next(Genres[Category].Length)];
            #endregion

            SetScale(Genre.TypicalScale);

            Genre.RandomSynth(15, Genre.Synths);
            BPM = RandomizeBPM(Genre);
        }
        #endregion
    }
}