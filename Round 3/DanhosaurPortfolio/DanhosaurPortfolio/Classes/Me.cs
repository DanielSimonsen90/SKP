using System;
using System.Collections.Generic;
using System.Linq;

namespace DanhosaurPortfolio.Classes
{
    public class Me
    {
        /// <summary>
        /// What is my name?
        /// </summary>
        public Name Name { get; } = new Name();
        /// <summary>
        /// How old am I?
        /// </summary>
        public int Age => GetYear(new DateTime(2001, 5, 3));
        /// <summary>
        /// How long have I been coding for? (Years)
        /// </summary>
        public int CodingFor => GetYear(new DateTime(2018, 8, 8));
        /// <summary>
        /// Converts <paramref name="start"/> to years
        /// </summary>
        /// <param name="start">Start date</param>
        /// <returns>Years as int</returns>
        private int GetYear(DateTime start) => Convert.ToInt32(Math.Floor((DateTime.Now - start).TotalDays / 365.25));
        /// <summary>
        /// Profile picture file
        /// </summary>
        public string ProfilePicture => "/Images/ProfilePicture.png";

        /// <summary>
        /// Returns whether I'm at school or SKP and when I switch
        /// </summary>
        public string Occupation => Schedules.WhereAmI(schedule => $"I øjebilkket er jeg på {schedule.Course} indtil {schedule.End.ToMyTime()}");
        /// <summary>
        /// My sparetime activities
        /// </summary>
        public Item[] SpareTime => new Item[]
        {
            new Item("Discord", "Jeg bruger meget af min tid på Discord. Dette inkluderer min interesse for Discord bots, måden Discord er sat op på via css/html, og generelle permission handling."),
            new Item("FL Studio", "Jeg tilbringer nogle gange min fritid op at lave min egen musik, som jeg sætter på services som Spotify & SoundCloud."),
            new Item("Overwatch", "Som programmør er man naturligt interesseret i spil - Overwatch har jeg spillet i 1000 timer og elsker at spille det med mine venner."),
            new Item("Skolehjem", "Jeg bor på Aalborg Erhvervskollegium ved TECHCOLLEGE på Øster Uttrupvej")
        };
        /// <summary>
        /// All my projects
        /// </summary>
        public Project[] Projects = new Project[]
        {
            #region SKP Round 1
            new Project("Big Project", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 8, 7), new string[]
            {
                "Et spil jeg blev inspireret af, da vores grundforløbslærer gav os en opgave med XML database. Jeg havde ingen anelese om hvad jeg lavede, og kom ikke langt med det..."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/BigProject", false),
            new Project("CleanEmotes", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 11, 4), new string[]
            {
                "Ét af mine \"joke programmer\" - der var ingen udfordring, ikke en ordenligt pointe - det var bare en joke"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/CleanEmotes", false),
            new Project("ezdab", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 8, 15), new string[]
            {
                "En lille figur der dabber - en slags animation i konsol vindue"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/ezdab", false),
            new Project("Hacker Speech", Languages.CSharp, ProjectTypes.WindowsForms, new DateTime(2019, 9, 19), new string[]
            {
                "En translator, der oversætter fra normal sprog til \"Hacker\" sprog med indbyggede temaer.",
                "Dette projekt var ren og skær for sjov - men alligevel også for at gå lidt væk fra vores konsolapplikationer. " +
                "Idéen er at man, i én af delene i vinduet, skriver en sætning. Den sætning bliver så \"oversat\" til \"hacker sprog\". ",
                "Billedet burde gerne illustrere, hvordan oversætteren fungere.",
                "Programmet blev primært udviklet af mig, men også med hjælp fra mine kammerarter, Andreas & Michael.",
                "Der blev leget meget med string.Replace(), men også med vores \"themes\", som kan ses nede i højre hjørne.",
                "Der er:",
                "• \"Dark Theme\", som er den, der bliver vist nu","" +
                "• \"Darker Theme\", som ændrer den grønne skrift til rød",
                "• \"Light Theme\", som viser den basale hvid på sort interface",
                "• \"Rave Theme\", som får alle komponenterne til at blinke i alle farver."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/Hacker%20speech"),
            new Project("Human", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 8, 12), new string[]
            {
                "Dating simulator, hvor kvindens karakter bliver randomizet, og hvor alle ens handlinger har betydning på, hvordan forholdet kommer til at gå."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/Human", false),
            new Project("Idea Generator", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 10, 21), new string[]
            {
                "Eftersom én af mine interesser er musik, valgte jeg at blande både programmering og musik sammen - " +
                "så jeg skabte et program, der giver mig tilfeldige idéer til, hvad for noget musik jeg skulle lave.", "",
                "Som vist på billedet, giver min Idea Generator en hel masse forskellige værdier. ", "",
                "Den viser:",
                "• Navn: En tilfeldig udvælging af præ-defineret ord, sat op i en sætning fra 2 - 5 ord.",
                "• Genre: Genre titel, som jeg har defineret baseret på mine playlist navne",
                "• BPM: Tilfeldigt tal mellem minimum & maksimum i den genre",
                "• Song Length længde: Minut tal tilfeldigt valgt fra 1 - 5 minutter, sekund tal tilfeldigt fra 0 - 59",
                "• Song key: Hvilken tangent & skala sangen skal følge - også tilfeldigt",
                "• Drum layout: Drum class med properties der er tilfeldigt valgt fra, hvad den genre kunne have af elementer",
                "• Synth layout: Synth class med properties der hver har sin egen wave og alt fra 0 - 2 effekter på dem.",
                "• Instruments: Klaver, trumpet, guitar & violin booleans - hvis de er true bliver de vist"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/Idea%20Generator"),
            new Project("Making Coffee", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 11, 11), new string[]
            {
                "Ét af mine \"joke programmer\", der gav en bruger interaction til, om min kammerart Andreas skulle lave kaffe til os eller ej"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/MakingCoffee", false),
            new Project("Music Idea Generator", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 11, 4), new string[]
            {
                "Rework af Idea Generator - dette inkluderer:",
                "• Reference Artists: Tilfeldigt musiker fra den genre der er blevet valgt",
                "• Reference Track: Tilfeldig sang fra musikeren, der har den genre der er blevet valgt",
                "• Mulighed for at sortere efter bestemt property - leder du efter en bestemt genre? bestemt bpm? bestemt artist?"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/Muisc%20Idea%20Generator"),
            new Project("PixelSpark", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 11, 4), new string[]
            {
                "PixelSpark er en Minecraft server jeg spillede på, som har et hieraki af forskellige ranks.",
                "Det hieraki ville jeg prøve at bygge i C#",
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/PixelSpark"),
            new Project("Pokémon I guess", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 8, 23), new string[]
            {
                "Ligesom med PixelSpark projektet, har jeg i dette prøvet at bygge klassestrukturen op med domæne på Pokémon"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/Pok%C3%A9mon%20I%20guess"),
            new Project("Random", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 9, 26), new string[]
            {
                "Jeg har lige lært lidt omkring klasser og hvordan man randomizer - så det skulle testes i dette projekt med domæne på biler - jeg kan godt lide at prøve nye ting af..."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/Random"),
            new Project("RandomSWCharacter", Languages.CSharp, ProjectTypes.Console, new DateTime(2019, 12, 17), new string[]
            {
                "Da jeg er glad for randomizers og klassehierakier, lavede jeg et program der lavede sin egen Star Wars karakter",
                "Ligesom min Music Idea Generators, randomizer RandomSWCharacter forskellige properties på subklasser, sådan at der kommer en tilfeldig karakter ud"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/RandomSWCharacter"),
            new Project("Team Generator", Languages.CSharp, ProjectTypes.WindowsForms, new DateTime(2019, 11, 12), new string[]
            {
                "Jeg ville tage mine randomization programmer til næste niveau, og lave en team generator til både Pokémon og Overwatch",
                "Når programmet starter, bliver man præsenteret for 2 valgmuligheder: Pokémon eller Overwatch.",
                "Når man har valgt et spil, kan man trykke på Search knappen så tosset man har lyst til - og det laver et nyt hold hver gang.",
                "Som Overwatch, vælger den 2 tanks, 2 damage og 2 support. " +
                "Det er én main-tank, én off-tank, 2 forskellige damage, én main support & én off-support.",
                "Som Pokémon, vælger den 3 physical attackers & 3 special attackers."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%201/Team%20Generator"),
            #endregion

            #region Hovedforløb 1
            new Project("awesomeboi", Languages.CSharp, ProjectTypes.Console, new DateTime(2020, 1, 15), new string[]
            {
                "Vores Grundlæggende programmeringslærer lavede en opgave, hvor vi skulle finde ud af, hvad det magiske tal var, for at få en bestemt sætning. Programmet skrev han på tavlen."
            }, Project.IntetLink, false),
            new Project("NetworkCalc", Languages.CSharp, ProjectTypes.Console, new DateTime(2020, 1, 9), new string[]
            {
                "Et program der kan udregne subnet maske og antallet af subnets af et netværk, via en ip med /-notation."
            }, Project.IntetLink, true),
            new Project("WebRefresh", Languages.Website, ProjectTypes.Website, new DateTime(2020, 2, 6), new string[]
            {
                "Clientside hjemmeside, der skulle fortælle om os selv.",
                "Se på http://dani146d.web.techcollege.dk/Webpages/index.html"
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%201/WebRefresh/WebRefresh"),
            #endregion

            #region Round 2
            new Project("Guess number", Languages.CSharp, ProjectTypes.WPF, new DateTime(2020, 5, 18), new string[]
            {
                "Simpelt \"Gæt et tal\" spil, der gemmer på highscore."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%202/Guess%20number"),
            new Project("MIG 2.0", Languages.CSharp, ProjectTypes.Console, new DateTime(2020, 6, 3), new string[]
            {
                "Rework af MIG projektet, da jeg ville prøve at implementere den nye viden fra Hovedforløb 1"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%202/MIG%202.0"),
            new Project("Pizzaria", Languages.CSharp, ProjectTypes.WPF, new DateTime(2020, 5, 19), new string[]
            {
                "Stereotypiske pizzaria bestillings-program, der skal kunne håndtere bruger specifikationer."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%202/Mini%20Projekter/Uge%2014/Pizzaria"),
            new Project("MyWatch", Languages.CSharp, ProjectTypes.WPF, new DateTime(2020, 6, 17), new string[]
            {
                "Alt hvad et ur kan, kan dette program - om det er alarmer, stopur, tidtagning og endda se klokken på en lidt kreativ måde..."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%202/Mini%20Projekter/Uge%2025/MyWatch"),
            new Project("WPFCalculator", Languages.CSharp, ProjectTypes.WPF, new DateTime(2020, 5, 18), new string[]
            {
                "Lommeregner i WPF, der bl.a. kan udregne arealet af figurer"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%202/VPFCalculator"),
            #endregion

            #region Hovedforløb 2
            new Project("File Details", Languages.CSharp, ProjectTypes.WPF, new DateTime(2020, 10, 30), new string[]
            {
                "Vælg en mappe eller en fil på computeren, og få en masse oplysninger omkring en fil."
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%202/File%20Details"),
            new Project("H2ClientSide", Languages.Website, ProjectTypes.Website, new DateTime(2020, 10, 1), new string[]
            {
                "Lommeregner i Javascript, jQuery & Typescript"
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%202/H2ClientSide"),
            new Project("ABC", Languages.CSharp, ProjectTypes.Console, new DateTime(2020, 10, 8), new string[]
            {
                "Objekt Orienteret Programmering projekt, hvor vi skulle lære om controllers, libraries & at flytte ting fra én type applikation til en anden"
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%202/H2OOP"),
            new Project("The Hungry Philosophers", Languages.CSharp, ProjectTypes.Console, new DateTime(2020, 9, 2), new string[]
            {
                "Projekt hvor vi skulle lære om Threads & locks"
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%202/TheHungryPhilosophers"),
            new Project("TicTacToe", Languages.Website, ProjectTypes.Website, new DateTime(2020, 10, 1), new string[]
            {
                "Projekt hvor vi skulle lave vores egen clientside side, hvor at informationen kom fra en server, for at vise at det er ligegyldigt hvordan siden ser ud."
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%202/TicTacToe"),
            #endregion 

            #region Round 3
            new Project("Dancord", Languages.CSharp, ProjectTypes.WPF, new DateTime(2020, 11, 2), new string[]
            {
                "Min egen version af Discord.",
                "Jeg er stor fan af Discord, og har brugt meget tid på at læse og forstår deres opbygning - både HTML/CSS mæssigt, men også deres klassestruktur.",
                "Så derfor, ville jeg prøve at lave min egen struktur i WPF, men kom aldrig længere end login siden...", "",
                "På et tidspunkt kunne jeg godt forestille mig, at jeg laver en 2.0 i ASP.Net, eftersom denne hjemmeside er det første produkt jeg har lavet i ASP.Net Core."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%203/Dancord"),
            new Project("DanhosaurPortfolio", Languages.CSharp, ProjectTypes.ASPNet, new DateTime(2020, 11, 15), new string[]
            {
                "Min DanhosaurPortfolio er den hjemmeside du er på nu.",
                "Den er 100% bygget i ASP.NET Core, og er mit første ASP.NET projekt.",
                "",
                "Formålet med projektet er, at det er en hjemmeside jeg kan sende rundt til virksomheder, så virksomhederne får en idé af, hvad det er jeg kan som programmør"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Round%203/DanhosaurPortfolio"),
            new Project("RandomSWCharacter 2.0", Languages.CSharp, ProjectTypes.Console, new DateTime(2020, 11, 24), new string[]
            {
                "Rework af min tidligere RandomSWCharacter - dette inkludere bedre kodestruktur, da det er flere måneder siden jeg sidst lavede min originale RandomSWCharacter"
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%203/RandomSWCharacter%202.0"),
            new Project("LoginSystemDB", Languages.CSharp, ProjectTypes.WPF, new DateTime(2021, 1, 12), new string[]
            {
                "Min instruktør bad mig om at lege med databaser. Så jeg ville lave et simpelt login system, der gemte på brugernavne og adgangskoder.",
                "Dog eftersom jeg følte at det var let sluppet fra, valgte jeg at implementere et messaging-system, så den også gemte på beskeder sendt af tidligere brugere."
            }, "https://github.com/DanielSimonsen90/SKP/tree/main/Misc%20Projects/Round%203/LoginSystemDB"),
            #endregion

            #region Hovedforløb 3
            new Project("ORM", Languages.CSharp, ProjectTypes.Console, new DateTime(2021, 04, 12), new string[]
            {
                "I database programmering, ville vores lærer have at vi skulle lave vores egen Object Relational Mapping klasse, så vi fik en god forståelse af ledet mellem code-behind og database objekthåndtering",
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%203/Database%20programmering/ORM/ORM"),
            new Project("DanhosMessages", Languages.CSharp, ProjectTypes.WPF, new DateTime(2021, 04, 28), new string[]
            {
                "En afsluttende opgave, hvor jeg brugte EntityFramework til at binde mine modeller til en database, så jeg havde både login- og messagesystem"
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%203/Database%20programmering/Final%20Assignment/DanhosMessages"),
            new Project("MyWebserver", Languages.CSharp, ProjectTypes.Console, new DateTime(2021, 04, 25), new string[]
            {
                "Da vi startede med GUI Programmering III, synes vores lærer at det kunne være sjovt at vi lavede vores egen webserver, så vi fik en lille forståelse af, hvordan en webserver fungerer.",
                "Her brugte vi HttpListeners, til at lytte til URL gets, og håndterede dem i vores C# kode."
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%203/GUI%20Programmering/MyWebserver"),
            new Project("Vue.js", Languages.VueJS, ProjectTypes.Website, new DateTime(2021, 04, 28), new string[]
            {
                "Som start i GUI Programmering III, startede vi ud med at udforske Vue.js.",
                "Udover min \"komponent viden\" fra tidligere WPF projekter, var det første gang jeg legede med komponenter - og det var noget jeg nød rigtig meget.",
                "Eftersom jeg længe har haft lyst til at lære React.js, blev jeg relativ glad for at starte med Vue.js, da de minder meget om hinaden.",
                "",
                "Selve projektet er én stor klump af udforskning af forskellige Vue problemstillinger, og sætte de fleste af dem til brug."
            }, "https://github.com/DanielSimonsen90/Education/tree/master/Hovedforl%C3%B8b%203/GUI%20Programmering/Vue.js"),
	        #endregion

            #region Other projects
            new Project("GymleaderTimer", Languages.CSharp, ProjectTypes.WPF, new DateTime(2020, 7, 9), new string[]
            {
                "Jeg arbejdede på en Pixelmon server, hvor jeg var Gym leader. " +
                "Én af vores regler er, at efter at man har haft en kamp, skal man vente i en halv time, før man kan udfordre gymmet igen. " +
                "Dette projekt hjalp både mig, men også mine andre gym leaders med at holde styr på vores challengers.", "",
                "Programmet er baseret på en normal timer, og med mit tidligere MyWatch projekt, havde jeg allerede en god idé om, hvordan jeg ville opnå mit resultat.",
                "For at bruge programmet, skal man vælge om gymmet man har været vikar for, er et regulært eller et advanceret gym. Som vist på billedet, har hvert gym sin egen type(r), og også delt op i 2 med 4 gyms. " +
                "Dette er grundet den måde vores gym-system er sat op på serveren. Man har de første 4 og de sidste 4 i hver gym-line. " +
                "Jeg har derfor gjort det mere brugervenligt, med at dele vores gyms op i regular/advanced og first/last 4.",
                "Når man så har valgt enten regular eller advanced, bliver knapperne der er under katekorien låst op, og knappen man trykkede på bliver låst. Dette er for at vise brugeren, hvilken knap brugeren trykkede på. " +
                "Efter man har valgt sit gym, skal man indsætte udfordrens navn i tekstboksen. Derudover er timeren sat til 30 minutter som standard, da det er den tid en udfordrer skal vente. " +
                "Det kan selvfølgelig justeres, hvis man glemmer at tilføje en udfordrer til timeren.", "",
                "Timerene i højre viser brugerens navn, det gym de kæmpede imod, og hvor lang deres ventetid er. - Det er selvfølgelig kun vikaren der kan se den information, da udfordrerne ikke har programmet.",
                "Når én af timerne er færdige, får brugeren en pop-up med en meddelelse om, at udfordrens ventetid er ovre."
            }, "https://github.com/DanielSimonsen90/Gymleader-timer"),
            new Project("DanhoLibrary", Languages.CSharp, ProjectTypes.Library, new DateTime(2019, 11, 24), new string[] 
            {
                "Mit eget library som er en stor hjælp i mine projekter...",
                "Der har været op til flere gange, hvor jeg har lavet noget i et konsol projekt, og jeg har lavet den samme metode om og om igen... så lavede jeg et library...", "",
                "På billedet ser du min ConsoleItems klasse, som faktisk er en gruppe partial klasser. Alle metoderne er statiske, fordi jeg aldrig har brug for en instans af ConsoleItems - ConsoleItems er bare en hjælp til mine konsolapplikationer.",
                "I mit DanhoLibrary, har jeg også andre klasser om min egen liste & egne extensions."
            }, "https://github.com/DanielSimonsen90/DanhoLibrary"),
            new Project("PinguPackage", Languages.TypeScript, ProjectTypes.Node, new DateTime(2020, 10, 12), new string[] 
            { 
                "\"PinguPackage\", er et TypeScript modul, som jeg bruger i forbindelse med udvikling af mit Pingu projekt. PinguPackage fungerer som et library, som Pingu er stærkt afhængig af.",
                "",
                "PinguPackage er mit første projekt i TypeScript, og jeg er stor fan af det. Med min C# viden som baggrund, var det virkelig underligt at kode i JavaScript, da spruget knap nok er type stærkt. " +
                "Så derfor lavede jeg mit library i TypeScript. Jeg kan rigtig godt lide at alt er type stærkt, og har også brugt rigtig meget tid på at give mig så meget hjælp som overhoved muligt, når jeg koder Pingu i mit Pingu projekt.",
            }, "https://github.com/DanielSimonsen90/PinguPackage"),
            new Project("Pingu", Languages.JavaScript, ProjectTypes.Node, new DateTime(2020, 10, 30), new string[]
            {
                "Min egen Discord bot, som jeg stadig arbejder på.",
                "Jeg har altid været stor fan af Discord. Da jeg så kom på grundforløb 2, ville jeg virkelig gerne lave min helt egen Discord bot. " +
                "Det blev ikke til noget, før jeg kom på Skolepraktik. Mine kammerarter, Lasse, Nikolai & Andreas, lavede alle sammen Discord bots sammen med mig. " +
                "Selvom vi ikke arbejdede på den samme bot, delte vi alligevel vores viden med hinanden, viste vores kommandoer og features, og blev inspireret af hinandens arbejde.", "",
                "Som skrevet, arbejder jeg stadig på Pingu. Mit mål med Pingu, er at Pingu skal være alle de bots, som jeg kan lide, i én + andre features. " +
                "Pingu er et projekt, der får mig til at undre mig over, hvordan andre har kodet deres scripts og bots. " +
                "Når andres bots kan noget bestemt, som jeg synes er fedt, vil jeg prøve mit bedste på at lave det selv - det synes jeg trodsalt er den bedste måde at lære på.", "",
                "Pingu er det projekt jeg er mest stolt over i min programmeringskarriere. Der er altid noget at forbedre eller bygge på. " +
                "Derudover ligger den også i min interesse i Discord - så det er generelt bare fedt at udvikle et produkt til noget man alligevel bruger meget tid på."
            }, "https://github.com/DanielSimonsen90/Pingu"),
            new Project("Discord Bot Interface", Languages.EJS, ProjectTypes.Node, new DateTime(2021, 02, 26), new string[]
            {
                "Discord Bot Interface er et projekt, hvor man skal kunne logge ind som sin Discord bot, og kunne bruge den som var den en normal Discord bruger.",
                "Projektet gør brug af Node.js webserver og selvfølgelig en række HTML sider og Discord.js modulet"
            }, Project.IntetLink, false) //Repository not created - hiding
            #endregion

        }.OrderByDescending(p => p.DateOfCreation).ToArray();
    }
}