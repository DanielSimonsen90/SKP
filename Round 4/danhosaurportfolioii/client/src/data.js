"use-strict"

import { LocationCollection, ScheduleItem, Item, ProjectCollection, Project, DanhoDate } from 'models'

const contact = {
    github: "DanielSimonsen90",
    phone: "20 95 61 77",
    email: "DanielSimonsen90@gmail.com"
};
  
const locationCollection = new LocationCollection(...[
    // new ScheduleItem("Folkeskole", new DanhoDate(2007, 8, 8), new DanhoDate(2017, 6, 15)),
    // new ScheduleItem("10. klasse", new DanhoDate(2017, 8, 8), new DanhoDate(2018, 6, 15)),
    new ScheduleItem("Grundforløb 1 & 2", new DanhoDate(2018, 8, 8), new DanhoDate(2019, 6, 28)),
    new ScheduleItem("Hovedforløb 1", new DanhoDate(2020, 1, 6), new DanhoDate(2020, 3, 13)),
    new ScheduleItem("Hovedforløb 2", new DanhoDate(2020, 8, 3), new DanhoDate(2020, 10, 9)),
    new ScheduleItem("Hovedforløb 3", new DanhoDate(2021, 4, 6), new DanhoDate(2021, 6, 18)),
    new ScheduleItem("Hovedforløb 4", new DanhoDate(2021, 10, 11), new DanhoDate(2021, 12, 17)),
    new ScheduleItem("Hovedforløb 5", new DanhoDate(2022, 9, 19), new DanhoDate(2022, 11, 25)),
    new ScheduleItem("Hovedforløb 6", new DanhoDate(2023, 11, 6), new DanhoDate(2023, 12, 8))
]).constructSKP();
  
const spareTime = [
    new Item("Discord", "Jeg bruger meget af min tid på Discord. Dette inkluderer min interesse for Discord bots, måden Discord er sat op på via css/html, og generelle permission handling."),
    new Item("FL Studio", "Jeg tilbringer nogle gange min fritid op at lave min egen musik, som jeg sætter på services som Spotify & SoundCloud."),
    new Item("Overwatch", "Som programmør er man naturligt interesseret i spil - Overwatch har jeg spillet i 1000 timer og elsker at spille det med mine venner."),
    new Item("Skolehjem", "Jeg bor på Aalborg Erhvervskollegium ved TECHCOLLEGE på Øster Uttrupvej")
];

const SKP = {
    1: [
        new Project("Big Project", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 7),
            description: [
              "Et spil jeg blev inspireret af, da vores grundforløbslærer gav os en opgave med XML database. " + 
              "Jeg havde ingen anelese om hvad jeg lavede, og kom ikke langt med det..."
            ],
            display: false
        }),
        new Project("CleanEmotes", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 4),
            description: [
              "Ét af mine \"joke programmer\" - der var ingen udfordring, ikke en ordenligt pointe - det var bare en joke."
            ],
            display: false
        }),
        new Project("ezdab", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 15),
            description: [
                "En lille figur der dabber - en slags animation i konsol vindue."
            ],
            display: false
        }),
        new Project("Hacker Speech", {
            language: 'C#',
            projectType: 'Windows Forms', 
            createdAt: new DanhoDate(2019, 9, 19),
            description: [
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
            ]
        }),
        new Project("Human", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 12),
            description: [
              "Dating simulator, hvor kvindens karakter bliver randomizet, " + 
              "og hvor alle ens handlinger har betydning på, hvordan forholdet kommer til at gå."
            ],
            display: false,
        }),
        new Project("Idea Generator", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 12),
            description: [
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
            ]
        }),
        new Project("Making Coffee", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 11),
            description: [
              "Ét af mine \"joke programmer\", der gav en bruger interaction til, " + 
              "om min kammerart Andreas skulle lave kaffe til os eller ej."
            ],
            display: false,
        }),
        new Project("Music Idea Generator", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 4),
            description: [
              "Rework af Idea Generator - dette inkluderer:",
              "• Reference Artists: Tilfeldigt musiker fra den genre der er blevet valgt",
              "• Reference Track: Tilfeldig sang fra musikeren, der har den genre der er blevet valgt",
              "• Mulighed for at sortere efter bestemt property - leder du efter en bestemt genre? bestemt bpm? bestemt artist?"
            ]
        }),
        new Project("PixelSpark", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 4),
            description: [
              "PixelSpark er en Minecraft server jeg spillede på, som har et hieraki af forskellige ranks.",
              "Det hieraki ville jeg prøve at bygge i C#"
            ]
        }),
        new Project("Pokémon I guess", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 23),
            description: [
              "Ligesom med PixelSpark projektet, har jeg i dette prøvet at bygge klassestrukturen op med domæne på Pokémon"
            ]
        }),
        new Project("Random", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 9, 26),
            description: [
                "Jeg har lige lært lidt omkring klasser og hvordan man randomizer - " + 
                "så det skulle testes i dette projekt med domæne på biler - " + 
                "jeg kan godt lide at prøve nye ting af..."
            ]
        }),
        new Project("RandomSWCharacter", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 12, 17),
            description: [
                "Da jeg er glad for randomizers og klassehierakier, lavede jeg et program der lavede sin egen Star Wars karakter",
                "Ligesom min Music Idea Generators, randomizer RandomSWCharacter forskellige properties på subklasser, sådan at der kommer en tilfeldig karakter ud."
            ]
        }),
        new Project("Team Generator", {
            language: 'C#',
            projectType: 'Windows Forms',
            createdAt: new DanhoDate(2019, 11, 12),
            description: [
                "Jeg ville tage mine randomization programmer til næste niveau, og lave en team generator til både Pokémon og Overwatch",
                "Når programmet starter, bliver man præsenteret for 2 valgmuligheder: Pokémon eller Overwatch.",
                "Når man har valgt et spil, kan man trykke på Search knappen så tosset man har lyst til - og det laver et nyt hold hver gang.",
                "Som Overwatch, vælger den 2 tanks, 2 damage og 2 support. " +
                "Det er én main-tank, én off-tank, 2 forskellige damage, én main support & én off-support.",
                "Som Pokémon, vælger den 3 physical attackers & 3 special attackers."
            ]
        })
    ],
    2: [
        new Project("Guess number", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 5, 18),
            description: [
                "Simpelt \"Gæt et tal\" spil, der gemmer highscore."
            ]
        }),
        new Project("MIG 2.0", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 6, 3),
            description: [
                "Rework af MIG projektet, da jeg ville prøve at implementere den nye viden fra Hovedforløb 1"
            ],
        }),
        new Project("Pizzaria", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 5, 19),
            description: [
                "Stereotypiske pizzaria bestillings-program, der skal kunne håndtere bruger specifikationer."
            ],
            baseLink: "Mini Projekter/Uge 14"
        }),
        new Project("MyWatch", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 6, 17),
            description: [
                "Alt hvad et ur kan, kan dette program - om det er alarmer, stopur, tidtagning og endda se klokken på en lidt kreativ måde..."
            ],
            baseLink: "Mini Projekter/Uge 25"
        }),
        new Project("VPFCalculator", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 5, 18),
            description: [
                "Lommeregner i WPF, der bl.a. kan udregne arealet af figurer."
            ]
        })
    ],
    3: [
        new Project("Dancord", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 11, 2),
            description: [
                "Min egen version af Discord.",
                "Jeg er stor fan af Discord, og har brugt meget tid på at læse og forstår deres opbygning - " + 
                "både HTML/CSS mæssigt, men også deres klassestruktur.",
                "Så derfor, ville jeg prøve at lave min egen struktur i WPF, men kom aldrig længere end login siden...", "",
                "På et tidspunkt kunne jeg godt forestille mig, at jeg laver en 2.0 i ASP.Net, " + 
                "eftersom denne hjemmeside er det første produkt jeg har lavet i ASP.Net Core."
            ]
        }),
        new Project("DanhosaurPortfolio", {
            language: 'C#',
            projectType: 'ASP.NET Core',
            createdAt: new DanhoDate(2020, 11, 15),
            description: [
                "DanhosaurPortfolio var min første portfolio side, som er 100% bygget i ASP.NET Core, og er mit første ASP.NET projekt.",
                "",
                "Formålet med projektet er, at det er en hjemmeside jeg kan sende rundt til virksomheder, " + 
                "så virksomhederne får en idé af, hvad det er jeg kan som programmør.",
                "Dog efter at have kommet på Hovedforløb 3, blev jeg hurtig enig med mig selv om, at jeg skulle lave min portfolio side om, i Vue.js, " + 
                "eftersom jeg foretrækker at arbejde med Javascript, når det gælder kodning af hjemmesider.", "",
                "Tilbage på sporet, var projektet bl.a. det første projekt jeg dokumenterede via Microsofts \"DevOps\", " + 
                "så min instruktør kunne følge med i min produktion af hjemmesiden."
            ]
        }),
        new Project("RandomSWCharacter 2.0", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 11, 24),
            description: [
                "Rework af min tidligere RandomSWCharacter - dette inkludere bedre kodestruktur, " + 
                "da det er flere måneder siden jeg sidst lavede min originale RandomSWCharacter"
            ]
        }),
        new Project("LoginSystemDB", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2021, 1, 12),
            description: [
                "Min instruktør bad mig om at lege med databaser. " + 
                "Så jeg ville lave et simpelt login system, der gemte på brugernavne og adgangskoder.",
                "Dog eftersom jeg følte at det var let sluppet fra, valgte jeg at implementere et messaging-system, " + 
                "så den også gemte på beskeder sendt af tidligere brugere."
            ]
        })
    ],
    4: [
        new Project("DanhosaurPortfolioii", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 6, 21),
            description: [
                "Et remake af DanhosaurPortfolio fra ASP.Net Core til Vue.js, hvor jeg har indblandet eget modul, og arbejdet i komponenter."
            ],
        })
    ]
}
const Hovedforløb = {
    1: [
        new Project("awesomeboi", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 1, 15),
            description: [
                "Vores Grundlæggende programmeringslærer lavede en opgave, " + 
                "hvor vi skulle finde ud af, hvad det magiske tal var, for at få en bestemt sætning. " + 
                "Programmet skrev han på tavlen."
            ],
            display: false,
            hasLink: false,
        }),
        new Project("NetworkCalc", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 1, 9),
            description: [
                "Et program der kan udregne subnet maske og antallet af subnets af et netværk, via en ip med /-notation."
            ],
            hasLink: false
        }),
        new Project("WebRefresh", {
            language: 'Website',
            projectType: 'Website',
            createdAt: new DanhoDate(2020, 2, 6),
            description: [
                "Clientside hjemmeside, der skulle fortælle om os selv.",
                "Se på http://dani146d.web.techcollege.dk/Webpages/index.html"
            ],
            baseLink: 'WebRefresh'
        })
    ],
    2: [
        new Project("File Details", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 10, 30),
            description: [
                "Vælg en mappe eller en fil på computeren, og få en masse oplysninger omkring en fil."
            ]
        }),
        new Project("H2ClientSide", {
            language: 'Website',
            projectType: 'Website',
            createdAt: new DanhoDate(2020, 10, 1),
            description: [
                "Lommeregner i Javascript, jQuery & Typescript."
            ]
        }),
        new Project("OOP", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 10, 8),
            description: [
                "Objekt Orienteret Programmering projekt, hvor vi skulle lære om controllers, " + 
                "libraries & at flytte ting fra én type applikation til en anden."
            ]
        }),
        new Project("The Hungry Philosophers", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 9, 2),
            description: [
                "Projekt hvor vi skulle lære om Threads & locks."
            ]
        }),
        new Project("TicTacToe", {
            language: 'Website',
            projectType: 'Website',
            createdAt: new DanhoDate(2020, 2, 20),
            description: [
                "Projekt hvor vi skulle lave vores egen clientside side, " + 
                "hvor at informationen kom fra en server, for at vise at det er ligegyldigt hvordan siden ser ud."
            ]
        })
    ],
    3: [
        new Project("ORM", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2021, 4, 12),
            description: [
                "I database programmering, ville vores lærer have at vi skulle lave vores egen Object Relational Mapping klasse, " + 
                "så vi fik en god forståelse af ledet mellem code-behind og database objekthåndtering.",
            ],
            baseLink: 'Database programmering/ORM'
        }),
        new Project("DanhosMessages", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2021, 4, 28),
            description: [
                "En afsluttende opgave, hvor jeg brugte EntityFramework til at binde mine modeller til en database, " + 
                "så jeg havde både login- og messagesystem"
            ],
            baseLink: 'Database programmering/Final Assignment'
        }),
        new Project("MyWebserver", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2021, 4, 25),
            description: [
                "Da vi startede med GUI Programmering III, synes vores lærer at det kunne være sjovt at vi lavede vores egen webserver, " + 
                "så vi fik en lille forståelse af, hvordan en webserver fungerer.",
                "Her brugte vi HttpListeners, til at lytte til URL gets, og håndterede dem i vores C# kode."
            ],
            baseLink: "GUI Programmering"
        }),
        new Project("Vue.js", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 4, 28),
            description: [
                "Som start i GUI Programmering III, startede vi ud med at udforske Vue.js.",
                "Udover min \"komponent viden\" fra tidligere WPF projekter, var det første gang jeg legede med komponenter - " + 
                "og det var noget jeg nød rigtig meget.",
                "Eftersom jeg længe har haft lyst til at lære React.js, blev jeg relativ glad for at starte med Vue.js, " + 
                "da de minder meget om hinaden.",
                "",
                "Selve projektet er én stor klump af udforskning af forskellige Vue problemstillinger, og sætte de fleste af dem til brug."
            ],
            baseLink: 'GUI Programmering'
        }),
        new Project("vuepos", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 5, 10),
            description: [
                "Et mere reelt projekt ved brug af Vue.js",
                "Sammen med mine kammerarter, Lasse & Mihaela, havde vi gruppe projekt om at lave en webshop, der havde en Employee og Admin mode.",
                "",
                "Som employee, skulle du kunne \"bippe\" produkter ind i kassen, og altid kunne følge med i, " + 
                "hvad den endelige sum for produkterne ville være. " +
                "Når så ordren var blevet placeret, skal man kunne se en historik over solgte produkter i Admin mode.",
                "Som admin, skal du kunne oprette eller slette produkter. Desuden skal du også have en ordrehistorik."
            ],
            collab: {
                github: 'TheOnlySlothman',
                repo: 'vuepos'
            }
        }),
        new Project("XMLintro", {
            language: 'XML',
            projectType: 'WPF',
            createdAt: new DanhoDate(2021, 5, 25),
            description: [
                "Upload XML, XSL & XSD filer til programmet, og den vil konvertere en XML fil baseret på XSL'en, " + 
                "og verificere den nye XML fil ved brug af XSD filen, og give et endeligt output, som konvertereingen var successfuld eller ej."
            ],
            baseLink: 'XML/Intro/csharp/XMLintro'
        }),
        new Project("pewpew", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2021, 6, 8),
            description: [
                "Game Design I - vi fik ret frie hylder til at lave et spil, men jeg valgte at tage imod en udfordring.",
                "Jeg ville forsøge og lave et 2D spil, hvor man er spiller, der skal skyde fjender. Spillet var ment som et endless spil."
            ],
            display: false,
            baseLink: 'Game Design I'
        }),
        new Project("Interrupts", {
            language: 'C',
            projectType: 'ATmega168',
            createdAt: new DanhoDate(2021, 4, 6),
            description: [
                "Interrupts er et projekt, hvor vi skulle experimentere med interrupts i vores ATmega168.",
                "Programmet laver et interrupt hvert sekund, hvor jeg kan tilmelde callbacks via \"hercules\", " +
                "og på den måde bestemme, hvilke callbacks jeg vil have, ATmegaen skal køre." 
            ]
        })
    ]
}
const Other = {
    0: [
        new Project("Gymleader-timer", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 7, 9),
            description: [
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
            ]
        }),
        new Project("DanhoLibrary", {
            language: 'C#',
            projectType: 'Library',
            createdAt: new DanhoDate(2019, 11, 24),
            description: [
                "Mit eget library som er en stor hjælp i mine C# projekter...",
                "Der har været op til flere gange, hvor jeg har lavet noget i bl.a. et konsol projekt, og jeg har lavet den samme metode om og om igen... så lavede jeg et library...", "",
                "Derfor gav det mening for mig, at lave et library til alle mine metoder og basis objekt opbyggelser.",
                "Derudover er den også stoppet til med forskellige slags extensions."
            ]
        }),
        new Project("PinguPackage", {
            language: 'TypeScript',
            projectType: 'Library',
            createdAt: new DanhoDate(2020, 10, 12),
            description: [
                "\"PinguPackage\", er et TypeScript modul, som jeg bruger i forbindelse med udvikling af mit Pingu projekt. " + 
                "PinguPackage fungerer som et library, som min Discord bot, Pingu, er stærkt afhængig af.",
                "",
                "PinguPackage er mit første projekt i TypeScript, og jeg er stor fan af det. " + 
                "Med min C# viden som baggrund, var det virkelig underligt at kode i JavaScript, da sproget knap nok er type stærkt. " +
                "Så derfor lavede jeg mit library i TypeScript. " + 
                "Jeg kan rigtig godt lide at alt er type stærkt, " + 
                "og har også brugt rigtig meget tid på at give mig så meget hjælp som overhoved muligt, " + 
                "når jeg koder Pingu i mit Pingu projekt.",
            ]
        }),
        new Project("Pingu", {
            language: 'JavaScript',
            projectType: 'Node.js',
            createdAt: new DanhoDate(2019, 11, 15),
            description: [
                "Min egen Discord bot, som jeg stadig arbejder på.",
                "Jeg har altid været stor fan af Discord. Da jeg så kom på grundforløb 2, ville jeg virkelig gerne lave min helt egen Discord bot. " +
                "Det blev ikke til noget, før jeg kom på Skolepraktik. Mine kammerarter, "+ 
                "Lasse, Nikolai & Andreas, lavede alle sammen Discord bots sammen med mig. " +
                "Selvom vi ikke arbejdede på den samme bot, delte vi alligevel vores viden med hinanden, " + 
                "viste vores kommandoer og features, og blev inspireret af hinandens arbejde.", "",
                "Som skrevet, arbejder jeg stadig på Pingu. Mit mål med Pingu, er at Pingu skal være alle de bots, " + 
                "som jeg kan lide, i én + andre features. " +
                "Pingu er et projekt, der får mig til at undre mig over, hvordan andre har kodet deres scripts og bots. " +
                "Når andres bots kan noget bestemt, som jeg synes er fedt, vil jeg prøve mit bedste på at lave det selv - " + 
                "det synes jeg trodsalt er den bedste måde at lære på.", "",
                "Pingu er det projekt jeg er mest stolt over i min programmeringskarriere. Der er altid noget at forbedre eller bygge på. " +
                "Derudover ligger den også i min interesse i Discord - " + 
                "så det er generelt bare fedt at udvikle et produkt til noget man alligevel bruger meget tid på."
            ]
        }),
        new Project("Discord Bot Interface", {
            language: 'EJS',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 2, 26),
            description: [
                "Discord Bot Interface er et projekt, hvor man skal kunne logge ind som sin Discord bot, " + 
                "og kunne bruge den som var den en normal Discord bruger.",
                "Projektet gør brug af Node.js webserver og selvfølgelig en række HTML sider og Discord.js modulet."
            ],
            display: false,
            hasLink: false
        }),
        new Project("DanhoLibraryJS", {
            language: 'TypeScript',
            projectType: 'Library',
            createdAt: new DanhoDate(2021, 5, 13),
            description: [
                "Ligesom mit DanhoLibrary i C#, ville jeg have et DanhoLibrary til JavaScript.",
                "Jeg kom tit i situationer, hvor jeg ikke forstod, hvorfor f.eks. HTMLCollection ikke havde en .array(), " + 
                "eller hvorfor jeg ikke havde en måde at bruge Node.js' EventEmitter klasse i vanilla JavaScript.",
                "",
                "Så jeg lavede naturligvis mit eget library til situationen. Alle modifikationer og extentions kan læses på projektets README fil."
            ]
        }),
        new Project("Dancord", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 5, 30),
            description: [
                "Som vist i nogle af mine andre projekter, er jeg rigtig glad for Discord, og den måde det er bygget op på.",
                "Jeg har tidligere forsøgt at lave en \"Dancord\" før i WPF, men har siden da indset, at det ville være meget nemmere i Vue.js."
            ]
        })
    ]
}

const projects = (function getProjects() {
    let result = new ProjectCollection(contact.github, locationCollection);

    const arrays = [SKP, Hovedforløb, Other];

    for (const obj of arrays) {
        for (let i = 0; i <= Object.keys(obj).length; i++) {
            if (obj[i]) {
                result.append(...obj[i])
            }
        }
    }

    return result.sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime());

})();

import Home from './components/Home';
import About from './components/About';
import ProjectsIndex from './components/Projects';
import Projects from './components/Projects/Projects';
import Plan from './components/Plan';
import Admin from './components/Admin';
import NotFound from './components/Shared/NotFound';

/**@param {string[]} routes 
 * @param {any} component 
 * @param {any[]} children*/
 const makeRoutes = (routes, component, ...props) => 
 routes.map(route => {
   let result = { path: route, component };
   
   if (props.length) return { ...result, ...props.reduce((obj, i) => Object.assign(obj, ...props[i])) }
   return result;
 });

const homeRoutes = makeRoutes(['', '/home', '/hjem'], Home);
const aboutRoutes = makeRoutes(['/about', '/om'], About);

//domain.com/projects?language=CSharp&projectType=Library
const projectsRoutes = makeRoutes(['/projects', '/projekter'], ProjectsIndex, {
 children: makeRoutes([':filter'], Projects)
})
const planRoutes = makeRoutes(['/plan'], Plan);
const adminRoutes = makeRoutes(['/admin'], Admin);
const notFoundRoutes = makeRoutes(['*'], NotFound);

const routes = [homeRoutes, aboutRoutes, projectsRoutes, planRoutes, adminRoutes, notFoundRoutes].reduce((result, route) => result.concat(...route));

import axios from 'axios';
// import { port } from '../../server/index';
const port = 8081;

export class API {
    static url = `http://localhost:${port}/api/projects`
    /**@param {Project} project*/
    static async createProject(project) {
        return axios.post(API.url, { 
            postData: JSON.stringify({
                ...project,
                _id: (await this.getProjects()).length + 1
            }) 
        })
    }
    /**@returns {Promise<Project[]>}*/
    static async getProjects() {
        const response = await axios.get(API.url);
        return response.data.map(item => {
            const { year, month, day } = item.createdAt;
            let result = new Project(item.name, {
                ...item,
                createdAt: new DanhoDate(year, month, day)
            });
            result.link = item.link;
            return result;
        });
    }
    static updateProject(current, updated) {
        return axios.put(`${API.url}/${current._id}`, updated);
    }
    static deleteProject(project) {
        return axios.delete(`${API.url}/${project._id}`)
    }
}

// projects.forEach(p => API.createProject(p));

export { 
    contact, locationCollection, spareTime, projects, 
    homeRoutes, aboutRoutes, projectsRoutes, planRoutes, adminRoutes, notFoundRoutes,
    routes 
}