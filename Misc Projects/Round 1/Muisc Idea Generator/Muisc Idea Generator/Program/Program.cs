using System;
using System.Collections.Generic;

namespace Muisc_Idea_Generator
{
    class Program
    {
        #region Global Variables
        static bool Generate = false;
        static List<Idea> IdeaList = new List<Idea>();
        #endregion

        #region LookingFor
        #region Variables
        static bool LookingFor = false;
        static int LFTitleItemCount = 0;
        static Idea LFIdea = new Idea();   //Genre, Artist, BPM, Scale, TitleItem
        static readonly bool[] LFItems = { false, false, false, false, false };
        static readonly string[] LFStrings = { "", "", "", "", "" };
        static string[] NewMain = LFIdea.Main;
        #endregion

        #region Methods
        static Genre LFGenre()
        {
            try
            {
                Console.WriteLine("Which Genre would you like to find?");
                if (LFStrings[1] == "")
                {
                    #region Find Category
                    string[] Options = { "Big Room", "Bounce", "Drum n' Stuff", "Dubstep", "Future", "Electro", "General", "Hype", "House", "Progressive House", "Electro House", "Old School", "Classic Genres" };
                    ListOptions(Options);
                    int x = System.Convert.ToInt32(Console.ReadLine()) - 1;
                    #endregion

                    Console.Clear();

                    #region Find Genre
                    Console.WriteLine($"You chose: {Options[x]}");
                    for (int y = 0; y < LFIdea.Genres[x].Length; y++)
                        Console.WriteLine($"[{y + 1}]: {LFIdea.Genres[x][y].GenreName}");
                    #endregion

                    Console.WriteLine();
                    LFItems[0] = true;

                    return LFIdea.Genres[x][System.Convert.ToInt32(Console.ReadLine()) - 1];
                }
                else
                {
                    #region Find Category
                    List<string> Options = new List<string>();
                    foreach (Track track in LFIdea.Artist.Tracks)
                    {
                        string CurrentGenre = track.Genre;
                        if (Options.Contains(CurrentGenre))
                        {
                            CurrentGenre = track.AdditionalGenre;
                            if (!Options.Contains(CurrentGenre) && CurrentGenre != null)
                                Options.Add(CurrentGenre);
                        }
                        else
                            Options.Add(CurrentGenre);
                    }
                    ListOptions(Options.ToArray());
                    int x = System.Convert.ToInt32(Console.ReadLine()) - 1;
                    #endregion

                    #region Find Genre
                    foreach (Genre genre in LFIdea.GenresNonCategorized)
                    {
                        if (genre.GenreName == Options.ToArray()[x])
                        {
                            LFItems[0] = true;
                            return genre;
                        }
                    }
                    return LFGenre();
                    #endregion
                }
            }
            catch
            {
                return LFGenre();
            }
        }
        static Artist LFArtist()
        {
            try
            {
                LFItems[1] = true;
                Console.WriteLine("Which Artist would you like to find?");
                if (LFIdea.Genre == null)
                {
                    for (int x = 0; x < LFIdea.Artists.Length; x++)
                        Console.WriteLine($"[{x + 1}]: {LFIdea.Artists[x].Name}");


                    return LFIdea.Artists[System.Convert.ToInt32(Console.ReadLine()) - 1];
                }
                else
                {
                    string Choice, Previous = "";
                    for (int x = 0; x < LFIdea.Genre.Songs.Count; x++)
                    {
                        Choice = LFIdea.Genre.Songs.ToArray()[x].ArtistName;
                        if (Choice != Previous)
                        {
                            Console.WriteLine($"[{x + 1}]: {Choice}");
                            Previous = Choice;
                        }
                    }

                    Choice = LFIdea.Genre.Songs.ToArray()[System.Convert.ToInt32(Console.ReadLine())].ArtistName;
                    foreach (Artist artist in LFIdea.Artists)
                        if (artist.Name == Choice)
                            return artist;
                    return LFArtist();
                }
            }
            catch
            {
                return LFArtist();
            }
        }
        static int LFBPM()
        {
            int Choice, MinBPM = 70, MaxBPM = 180;
            if (LFIdea.Genre != null)
            {
                MinBPM = LFIdea.Genre.MinBPM;
                MaxBPM = LFIdea.Genre.MaxBPM;
            }
            do
            {
                Console.WriteLine($"Pick a BPM between {MinBPM} and {MaxBPM}.");
                try
                {
                    LFItems[2] = true;
                    Choice = System.Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                catch
                {
                    LFItems[2] = false;
                    Console.Clear();
                    return 128;
                }
            } while (Choice < MinBPM || Choice > MaxBPM);
            return Choice;
        }
        static string LFScale()
        {
            try
            {
                #region Find Key
                Console.WriteLine("Which Key would you like to find?");
                string[] Options = { "A", "A#/Bb", "B", "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab" };
                ListOptions(Options);
                Console.WriteLine();
                string Key = Options[System.Convert.ToInt32(Console.ReadLine()) - 1];
                #endregion

                Console.Clear();

                #region Find Scale
                Console.WriteLine("What scale would you like to find?");
                Options = new string[] { Key + " Major", Key + " Minor" };
                ListOptions(Options);
                #endregion

                LFItems[3] = true;
                return Options[System.Convert.ToInt32(Console.ReadLine()) - 1];
            }
            catch
            {
                return LFScale();
            }
        }
        static string LFTitleItem()
        {
            try
            {
                LFItems[4] = true;
                Console.WriteLine("What Title Item would you like to find?");
                Console.WriteLine();
                ListOptions(LFIdea.Main);
                Console.WriteLine($"[{LFIdea.Main.Length + 2}]: <Custom Word>");

                string Choice = Convert.ToString(Convert.ToInt32(Console.ReadLine()) - 1);
                Console.Clear();

                if (Convert.ToInt32(Choice) > LFIdea.Main.Length) //If Custom word
                {
                    Console.WriteLine("What new word would you like to add & find?");
                    Console.WriteLine();
                    Choice = Console.ReadLine();

                    string[] NewerMain = new string[NewMain.Length + 1];
                    try
                    {
                        for (int x = 0; x < NewerMain.Length; x++)
                            NewerMain[x] = NewMain[x];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        NewerMain[NewMain.Length] = Choice;
                    }
                    NewMain = NewerMain;
                    return Choice;
                }
                else
                    return LFIdea.Main[Convert.ToInt32(Choice)];
            }
            catch
            {
                return LFTitleItem();
            }
        }
        #endregion
        #endregion

        #region View Previous Ideas
        static void ViewIdeas()
        {
            Console.WriteLine($"How would you like to view your ideas? ({IdeaList.Count} ideas)");
            string[] Options = { "Individiually", "Summary" };
            ListOptions(Options);
            ConsoleKey Choice = Console.ReadKey().Key;
            Console.Clear();
            switch (Choice)
            {
                case ConsoleKey.D1:
                    ViewIndividiually();
                    break;
                case ConsoleKey.D2:
                    ViewSummary();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
        static void ViewIndividiually()
        {
            Console.WriteLine($"Which of the {IdeaList.Count} ideas would you like to view?");
            int IntChoice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Idea PreIdea = IdeaList.ToArray()[IntChoice - 1];
            PreIdea.GetInfo(false);
        }
        static void ViewSummary()
        {
            for (int x = 0; x < IdeaList.Count; x++)
                Console.WriteLine($"[{x + 1}]: {IdeaList.ToArray()[x].Title}, {IdeaList.ToArray()[x].Genre.GenreName}, {IdeaList.ToArray()[x].BPM}");
            int Choice = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Clear();

            Idea PreIdea = IdeaList.ToArray()[Choice];
            PreIdea.GetInfo(false);
        }
        #endregion

        static void ListOptions(object[] Options)
        {
            for (int x = 0; x < Options.Length; x++)
                Console.WriteLine($"[{x + 1}]: {Options[x]}");
        }
        static void Main()
        {
            Console.Title = "Music Idea Generator [MIG]";
            while (!Generate)
            {
                #region Menu
                Console.WriteLine("-=: Music Idea Generator 2.0 :=-");
                string[] Options = new string[] { "Genre", "Artist", "BPM", "Scale", "Title Item" };
                Console.WriteLine();
                ListOptions(Options);
                if (IdeaList.Count >= 1)
                {
                    Console.WriteLine($"[6]: View Ideas ({IdeaList.Count} ideas)");
                    Console.WriteLine($"[7]: Clear Idea list");
                }
                if (LookingFor)
                {
                    if (IdeaList.Count == 0)
                        Console.WriteLine("[6]: Reset Specifications");
                    else
                        Console.WriteLine("[8]: Reset Specifications");

                    Console.WriteLine();
                    Console.WriteLine("-=: Specifications :=-");
                    for (int x = 0; x < LFItems.Length; x++)
                        if (LFItems[x])
                            Console.WriteLine($"{Options[x]}: {LFStrings[x]}");
                    Console.WriteLine();
                }
                else
                    Console.WriteLine();
                #endregion

                #region User Response
                Console.WriteLine();
                ConsoleKey Choice = Console.ReadKey().Key;
                Console.Clear();

                switch (Choice)
                {
                    case ConsoleKey.Enter: //If Generate
                        Generate = true;
                        break;
                    case ConsoleKey.D1: //If Specific Genre
                        LFIdea.Genre = LFGenre();
                        LFStrings[0] = LFIdea.Genre.GenreName;
                        LookingFor = true;
                        break;
                    case ConsoleKey.D2: //If Specific Artist
                        LFIdea.Artist = LFArtist();
                        LFStrings[1] = LFIdea.Artist.Name;
                        LookingFor = true;
                        break;
                    case ConsoleKey.D3:
                        LFIdea.BPM = LFBPM(); //If Specific BPM
                        LFStrings[2] = LFIdea.BPM.ToString();
                        LookingFor = true;
                        break;
                    case ConsoleKey.D4:
                        LFIdea.Scale = LFScale(); //If Specific Scale
                        LFStrings[3] = LFIdea.Scale;
                        LookingFor = true;
                        break;
                    case ConsoleKey.D5:
                        LFIdea.TitleItem[LFTitleItemCount] = LFTitleItem(); //If Specific TitleItem
                        if (LFStrings[4] != "")
                            LFStrings[4] += $", {LFIdea.TitleItem[LFTitleItemCount]}";
                        else
                            LFStrings[4] = LFIdea.TitleItem[LFTitleItemCount];
                        LFTitleItemCount++;
                        LookingFor = true;
                        break;
                    default:
                        break;
                }
                if (Choice == ConsoleKey.D6 && IdeaList.Count > 0) //If "View Ideas"
                    ViewIdeas();
                else if (Choice == ConsoleKey.D7 && IdeaList.Count > 0) //Clear idealist
                    IdeaList = new List<Idea>();
                else if (Choice == ConsoleKey.D6 && LookingFor && IdeaList.Count == 0 || //If Reset Specifications
                    Choice == ConsoleKey.D8 && LookingFor)
                {
                    LFIdea = new Idea();
                    LookingFor = false;
                    for (int x = 0; x < LFItems.Length; x++)
                    {
                        LFItems[x] = false;
                        LFStrings[x] = "";
                    }
                    LFTitleItemCount = 0;
                }
                Console.Clear();
                #endregion
            }
            while (Generate)
            {
                #region Generate New Idea
                DateTime StartTime = DateTime.Now;
                Idea idea = new Idea();
                idea.GenerateIdea(NewMain);
                Console.WriteLine("Generating idea...");
                #region If LFItems

                #region If Title
                if (LFItems[4])
                {
                    while (true)
                    {
                        if (!idea.Title.Contains(LFIdea.TitleItem[0]) && LFIdea.TitleItem[0] != "" || //If !Contain[0] && !""
                            !idea.Title.Contains(LFIdea.TitleItem[1]) && LFIdea.TitleItem[1] != "" || //If !Contain[1] && !""
                            !idea.Title.Contains(LFIdea.TitleItem[2]) && LFIdea.TitleItem[2] != "") //If !Contain[2] && !""
                        {
                            idea = new Idea();
                            idea.GenerateIdea(NewMain);
                        }
                        else
                            break;
                    }
                }
                #endregion

                if (LFItems[0])
                    idea.Genre = LFIdea.Genre;
                if (LFItems[1])
                    idea.Artist = LFIdea.Artist;
                if (LFItems[2])
                    idea.BPM = LFIdea.BPM;
                if (LFItems[3])
                    idea.Scale = LFIdea.Scale;
                #endregion
                Console.Clear();
                idea.GetReferenceSong(LFItems[0], LFItems[1]);
                idea.GetInfo(true);
                #endregion

                #region Estimated Time
                Console.WriteLine();
                TimeSpan EstimatedTime = DateTime.Now - StartTime;
                if (EstimatedTime.Seconds > 1)
                    Console.WriteLine($"Estimated time: {EstimatedTime}");
                #endregion

                #region Save "New Idea"
                Console.WriteLine();
                IdeaList.Add(idea);
                Console.WriteLine($"Idea #{IdeaList.Count}");
                #endregion

                #region User Response
                ConsoleKey Choice = Console.ReadKey().Key;
                switch (Choice)
                {
                    case ConsoleKey.Escape:
                        Generate = false;
                        Console.Clear();
                        Main();
                        break;
                    case ConsoleKey.X:
                        Generate = false;
                        break;
                    default:
                        break;
                }
                #endregion

                Console.Clear();
            }
        }
    }
}