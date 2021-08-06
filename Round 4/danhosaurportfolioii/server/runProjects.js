const { Project, DanhoDate, ProjectCollection, LocationCollection, ScheduleItem } = require('../client/src/node_modules/models')

const SKP = {
    1: [
        new Project("Big Project", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 7),
            description: {
                Dansk: [
                    "Et spil jeg blev inspireret af, da vores grundforløbslærer gav os en opgave med XML database. " + 
                    "Jeg havde ingen anelese om hvad jeg lavede, og kom ikke langt med det..."
                ],
                English: [
                    "A game I was inspired to make, when our basics teacher gave us an assignment with an XML databse. " +
                    "I had no clue what I was doing, and didn't get very far..."
                ]
            },
            display: false
        }),
        new Project("CleanEmotes", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 4),
            description: {
                Dansk: ["Ét af mine \"joke programmer\" - der var ingen udfordring, ikke en ordenligt pointe - det var bare en joke."],
                English: ["One of my \"joke programs\" - there was no challenge and no point - it was just a joke."]
            },
            display: false
        }),
        new Project("ezdab", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 15),
            description: {
                Dansk: ["En lille figur der dabber - en slags animation i konsol vindue."],
                English: ["A little figure dabbing - an amination in a console window."]
            },
            
            display: false
        }),
        new Project("Hacker Speech", {
            language: 'C#',
            projectType: 'Windows Forms', 
            createdAt: new DanhoDate(2019, 9, 19),
            description: {
                Dansk: [
                    "En translator, der oversætter fra normal sprog til \"Hacker\" sprog med indbyggede temaer.",
                    "Dette projekt var ren og skær for sjov - men alligevel også for at gå lidt væk fra vores konsolapplikationer. " +
                    "Idéen er at man, i én af delene i vinduet, skriver en sætning. Den sætning bliver så \"oversat\" til \"hacker sprog\". ",
                    "Billedet burde gerne illustrere, hvordan oversætteren fungere.",
                    "Programmet blev primært udviklet af mig, men også med hjælp fra mine kammerarter, Andreas & Michael.",
                    "Der blev leget meget med string.Replace(), men også med vores \"themes\", som kan ses nede i højre hjørne.",
                    "Der er:",
                    "• \"Dark Theme\", som er den, der bliver vist nu","" +
                    "• \"Darker Theme\", som ændrer lime skriften til rød",
                    "• \"Light Theme\", som viser den basale sort på hvid interface",
                    "• \"Rave Theme\", som får alle komponenterne til at blinke i alle farver."
                ],
                English: [
                    "A translator translating from normal text to \"hacker\" text with some built-in themes.",
                    "The project was made solely for enterainment, but also to get away from console applications. " +
                    "The idea is that you pick a side in the window and type a sentence. The sentence then gets \"translated\" to either \"hacking text\" or real text-. ",
                    "The image should illustrate how the translator works.", "",
                    "The program was primarily developed by me, but with a help by my buddies Andreas & Michael.",
                    "There was a bunch of string.Replace() playing, but also with our \"themes\", located in the bottom right corner.",
                    "We have the following themes:",
                    "• \"Dark Theme\", which is the one visible",
                    "• \"Darker Theme\", changing the lime text to red",
                    "• \"Light Theme\", showing the classic black on white",
                    "• \"Rave Theme\", making all of the components change colors of the rainbow - like a chroma theme."
                ]
            },
        }),
        new Project("Human", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 12),
            description: {
                Dansk: [
                    "Dating simulator, hvor kvindens karakter bliver randomizet, " + 
                    "og hvor alle ens handlinger har betydning på, hvordan forholdet kommer til at gå."
                ],
                English: [
                    "Dating simulator, where the woman's character gets randomized, " +
                    "and where all player actions have impact on how the relationship is developing."
                ]
            },
            display: false,
        }),
        new Project("Idea Generator", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 12),
            description: {
                Dansk: [
                    "Eftersom én af mine interesser er musik, valgte jeg at blande både programmering og musik sammen - " +
                    "så jeg skabte et program, der giver mig tilfeldige idéer til, hvad for noget musik jeg skulle lave.", "",
                    "Som vist på billedet, giver min Idea Generator en hel masse forskellige værdier. ", "",
                    "Den viser:",
                    "• Navn: En tilfeldig udvælging af præ-defineret ord, sat op i en sætning fra 2 - 5 ord.",
                    "• Genre: Genre titel, som jeg har defineret baseret på mine playlist navne",
                    "• BPM: Tilfeldigt tal mellem minimum & maksimum i den genre",
                    "• Song Length: Minut tal tilfeldigt valgt fra 1 - 5 minutter, sekund tal tilfeldigt fra 0 - 59",
                    "• Song key: Hvilken tangent & skala sangen skal følge - også tilfeldigt",
                    "• Drum layout: Drum class med properties der er tilfeldigt valgt fra, hvad den genre kunne have af elementer",
                    "• Synth layout: Synth class med properties der hver har sin egen wave og alt fra 0 - 2 effekter på dem.",
                    "• Instruments: Klaver, trumpet, guitar & violin booleans - hvis de er true bliver de vist"
                ],
                English: [
                    "Since music is another interest of mine, I chose to mix both my programming and music interests together - " + 
                    "so I craeted a program, that gives me random ideas to my next music projects.", "",
                    "As shown in the image, my Idea Generator gives a bunch of different values.", "",
                    "It shows:",
                    "• Name: A randomly selected name from pre-defined words, selecting 2 - 5 words.",
                    "• Genre: Genre title, based on my playlist names",
                    "• BPM: Random number between min & max from the typical genre BPMs",
                    "• Song Length: Minute randomized from 1 - 5 minutes, second randomized from 0 - 59",
                    "• Song key: Which key & scale should the song be in - also randomized",
                    "• Drum layout: Drum class with properties randomized from the what the genre typically would have",
                    "• Synth layout: Synth class with properties, where each wave have + - 2 effects on them",
                    "• Instruments: Piano, horn, guitar & violin booleans - if true, they'll show on screen"
                ]
            },
        }),
        new Project("Making Coffee", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 11),
            description: {
                Dansk: [
                    "Ét af mine \"joke programmer\", der gav en bruger interaction til, " + 
                    "om min kammerart Andreas skulle lave kaffe til os eller ej."
                ],
                English: [
                    "One of my \"joke programs\", giving the user an interaction, whether or not my buddy Andreas was making coffee for us or not"
                ]
            },
            display: false,
        }),
        new Project("Music Idea Generator", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 4),
            description: {
                Dansk: [
                    "Rework af Idea Generator - dette inkluderer:",
                    "• Reference Artists: Tilfeldigt musiker fra den genre der er blevet valgt",
                    "• Reference Track: Tilfeldig sang fra musikeren, der har den genre der er blevet valgt",
                    "• Mulighed for at sortere efter bestemt property - leder du efter en bestemt genre? bestemt bpm? bestemt artist?"
                ],
                English: [
                    "Rework of Idea Generator - this includes:",
                    "• Reference Artist: Randomly chosen artist from the chosen genre",
                    "• Reference Track: Random track from the artist, matching the genre",
                    "• Option to filter ideas after a specific property - searching for a specific genre? specific bpm? specific artist?"
                ]
            }
        }),
        new Project("PixelSpark", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 11, 4),
            description: {
                Dansk: [
                    "PixelSpark er en Minecraft server jeg spillede på, som har et hieraki af forskellige ranks.",
                    "Det hieraki ville jeg prøve at bygge i C#"
                ],
                English: [
                    "PixelSpark is a Minecraft server I played, that has a heiarchy of different ranks.",
                    "I wanted to build that hiearchy in C# to play with inheritance"
                ]
            }
        }),
        new Project("Pokémon I guess", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 8, 23),
            description: {
                Dansk: ["Ligesom med PixelSpark projektet, har jeg i dette prøvet at bygge klassestrukturen op med domæne på Pokémon"],
                English: ["Like the PixelSpark project, I wanted to try to build the class structure of Pokémon"]
            }
        }),
        new Project("Random", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 9, 26),
            description: {
                Dansk: ["Jeg har lige lært lidt omkring klasser og hvordan man randomizer - så det skulle testes i dette projekt med domæne på biler."],
                English: ["I've leart about classic and randomization - therefore I wanted to test it in a project with the domain of cars."]
            }
        }),
        new Project("RandomSWCharacter", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2019, 12, 17),
            description: {
                Dansk: [
                    "Da jeg er glad for randomizers og klassehierakier, lavede jeg et program der lavede sin egen Star Wars karakter.",
                    "Ligesom min Music Idea Generators, randomizer RandomSWCharacter forskellige properties på subklasser, " + 
                    "sådan at der kommer en tilfeldig karakter ud."
                ],
                English: [
                    "Since I enjoy randomizers and class hierachies, I made a program that made a random Star Wars character.",
                    "Just like my Music Idea Generator, it randomizes different properties on subclasses, returning a random character."
                ]
            }
        }),
        new Project("Team Generator", {
            language: 'C#',
            projectType: 'Windows Forms',
            createdAt: new DanhoDate(2019, 11, 12),
            description: {
                Dansk: [
                    "Jeg ville tage mine randomization programmer til næste niveau, og lave en team generator til både Pokémon og Overwatch",
                    "Når programmet starter, bliver man præsenteret for 2 valgmuligheder: Pokémon eller Overwatch.",
                    "Når man har valgt et spil, kan man trykke på Search knappen så tosset man har lyst til - og det laver et nyt hold hver gang.",
                    "Som Overwatch, vælger den 2 tanks, 2 damage og 2 support. " +
                    "Det er én main-tank, én off-tank, 2 forskellige damage, én main support & én off-support.",
                    "Som Pokémon, vælger den 3 physical attackers & 3 special attackers."
                ],
                English: [
                    "I wanted to take my randomization to the next level, and made a Team Generator for both Pokémon and Overwatch - the two games I enjoy playing a lot.",
                    "When the program starts, the user gets presented to options: Pokémon or Overwatch.",
                    "When a game has been chosen, the user can click the Search button as much as they want - a new team with be made every time.",
                    "In Overwatch, the program choses 2 tanks, 2 damage & 2 support. " +
                    "A main-tank, off-tank, 2 different damage characters, a main support and an off-support.",
                    "In Pokémon, it choses 3 physical attackers & 3 special attackers."
                ]
            }
        })
    ],
    2: [
        new Project("Guess number", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 5, 18),
            description: {
                Dansk: ["Simpelt \"Gæt et tal\" spil, der gemmer highscore."],
                English: ["Simple \"Guess a number\" game, saving a highscore"]
            }
        }),
        new Project("MIG 2.0", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 6, 3),
            description: {
                Dansk: ["Rework af Music Idea Generator projektet, da jeg ville prøve at implementere den nye viden fra Hovedforløb 1"],
                English: ["Rework of the Musical Idea Generator, since I wanted to try to implement my new knowledge from Hovedforløb 1"]
            }
        }),
        new Project("Pizzaria", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 5, 19),
            description: {
                Dansk: ["Stereotypiske pizzaria bestillings-program, der skal kunne håndtere bruger specifikationer."],
                English: ["Stereotypical pizzaria ordering program, that should take user specifications on orders."]
            },
            baseLink: "Mini Projekter/Uge 14"
        }),
        new Project("MyWatch", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 6, 17),
            description: {
                Dansk: ["Alt hvad et ur kan, kan dette program - om det er alarmer, stopur, tidtagning og endda se klokken på en lidt kreativ måde..."],
                English: ["Everything a watch can do, this can too - whether it's alarms, stopwatch, timers & even see the time in a creative way..."]
            },
            baseLink: "Mini Projekter/Uge 25"
        }),
        new Project("VPFCalculator", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 5, 18),
            description: {
                Dansk: ["Lommeregner i WPF, der bl.a. kan udregne arealet af figurer."],
                English: ["Calculator in WPF, that can also calculate the area of figures."]
            }
        })
    ],
    3: [
        new Project("Dancord", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 11, 2),
            description: {
                Dansk: [
                    "Min egen version af Discord.",
                    "Jeg er stor fan af Discord, og har brugt meget tid på at læse og forstår deres opbygning - " + 
                    "både HTML/CSS mæssigt, men også deres klassestruktur.",
                    "Så derfor, ville jeg prøve at lave min egen struktur i WPF, men kom aldrig længere end login siden...", "",
                    "Dog har jeg re-krearet det i Vue.js, da jeg blev introduceret til Vue.js på Hovedforløb 3."
                ],
                English: [
                    "My own version of Discord",
                    "I'm a big fan of Discord, and spent a lot of my time reading and understanding its structure - " +
                    "both in HTML/CSS, but also it's class structure.",
                    "I then wanted to make my own structure in WPF, but never got further than the login page...", "",
                    "However, I did recreate it in Vue.js, when I was introduced to Vue.js in Hovedforløb 3."
                ]
            }
        }),
        new Project("DanhosaurPortfolio", {
            language: 'C#',
            projectType: 'ASP.NET Core',
            createdAt: new DanhoDate(2020, 11, 15),
            description: {
                Dansk: [
                    "DanhosaurPortfolio var min første portfolio side, som er 100% bygget i ASP.NET Core, og er mit første ASP.NET projekt.",
                    "",
                    "Formålet med projektet er, at det er en hjemmeside jeg kan sende rundt til virksomheder, " + 
                    "så virksomhederne får en idé af, hvad det er jeg kan som programmør.",
                    "Dog efter at have kommet på Hovedforløb 3, blev jeg hurtig enig med mig selv om, at jeg skulle lave min portfolio side om, i Vue.js, " + 
                    "eftersom jeg foretrækker at arbejde med Javascript, når det gælder kodning af hjemmesider.", "",
                    "Tilbage på sporet, var projektet bl.a. det første projekt jeg dokumenterede via Microsofts \"DevOps\", " + 
                    "så min instruktør kunne følge med i min produktion af hjemmesiden."
                ],
                English: [
                    "DanhosaurPortfolio was my first portfolio site, built 100% in ASP.NEt Core, and is my first ASP.NET projcet.", "",
                    "The purpose of the website was to send it to different companies, to show them what I'm capable of as a programmer.",
                    "Though, since you're reading this on the new one, I decided I wanted to rebuild the project in Vue.js, "+ 
                    "since I prefer working in JavaScript, when it comes to websites.",
                    "Back to the project though, this was also the first time documenting my progress, work and plan using Microsoft's \"DevOps\", " + 
                    "so my instructor could follow my production of the website."
                ]
            }
        }),
        new Project("RandomSWCharacter 2.0", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 11, 24),
            description: {
                Dansk: [
                    "Rework af min tidligere RandomSWCharacter - dette inkludere bedre kodestruktur, " + 
                    "da det er flere måneder siden jeg sidst lavede min originale RandomSWCharacter."
                ],
                English: [
                    "Rework fo my previous RandomSWCharacter - this includes better code structure, " + 
                    "since it was months ago I last made my original RandomSWCharacer."
                ]
            }
        }),
        new Project("LoginSystemDB", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2021, 1, 12),
            description: {
                Dansk: [
                    "Min instruktør bad mig om at lege med databaser. " + 
                    "Så jeg ville lave et simpelt login system, der gemte på brugernavne og adgangskoder.",
                    "Dog eftersom jeg følte at det var let sluppet fra, valgte jeg at implementere et messaging-system, " + 
                    "så den også gemte på beskeder sendt af tidligere brugere."
                ],
                English: [
                    "My instructor wanted me to play with databases. " +
                    "So I made a simple login system, that saved usernames and passwords.",
                    "However, since I felt like it was an easy task, I decided to implement a messaging system, " + 
                    "that saved the sent messages from logged in users."
                ]
            }
        })
    ],
    4: [
        new Project("danhosaurportfolioii", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 6, 21),
            description: {
                Dansk: [
                    "Et remake af DanhosaurPortfolio fra ASP.NET Core til Vue.js, hvor jeg har indblandet eget modul, og arbejdet i komponenter, " + 
                    "taler med en API og gemmer projekter i en MongoDB."
                ],
                English: [
                    "A remake of DanhosaurPortfolio from ASP.NET Core to Vue.js, where I've included own module, worked in components, " + 
                    "talking to an API and saving projects in a MongoDB."
                ]
            }
        })
    ]
}
const Hovedforløb = {
    1: [
        new Project("awesomeboi", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 1, 15),
            description: {
                Dansk: [
                    "Vores Grundlæggende programmeringslærer lavede en opgave, " + 
                    "hvor vi skulle finde ud af, hvad det magiske tal var, for at få en bestemt sætning. " + 
                    "Programmet skrev han på tavlen."
                ],
                English: [
                    "Our basic-programming teacher made an assignment, where we had to figure out, what the magical number was, " + 
                    "in order to achieve a specific sentence. " +
                    "The program was written on the blackboard."
                ]
            },
            display: false,
            hasLink: false,
        }),
        new Project("NetworkCalc", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 1, 9),
            description: {
                Dansk: ["Et program der kan udregne subnet maske og antallet af subnets af et netværk, via en ip med /-notation."],
                English: ["A program calculating the subnet mask and amount of subnets in a network, using an ip with slash-notation"]
            },
            hasLink: false
        }),
        new Project("WebRefresh", {
            language: 'Website',
            projectType: 'Website',
            createdAt: new DanhoDate(2020, 2, 6),
            description: {
                Dansk: [
                    "Clientside hjemmeside, der skulle fortælle om os selv.",
                    "Se på http://dani146d.web.techcollege.dk/Webpages/index.html"
                ],
                English: [
                    "Clientside website to tell us about ourselves.",
                    "See the website at http://dani146d.web.techcollege.dk/Webpages/index.html"
                ]
            },
            baseLink: 'WebRefresh'
        })
    ],
    2: [
        new Project("File Details", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 9, 16),
            description: {
                Dansk: ["Vælg en mappe eller en fil på computeren, og få en masse oplysninger omkring en fil."],
                English: ["Choose a folder or a file on the computer, and get lots of information about a file."]
            }
        }),
        new Project("H2ClientSide", {
            language: 'Website',
            projectType: 'Website',
            createdAt: new DanhoDate(2020, 9, 17),
            description: {
                Dansk: ["Lommeregner i Javascript, jQuery & Typescript."],
                English: ["Calculator in JavaScript, jQuery & Typescript."]
            }
        }),
        new Project("H2OOP", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 10, 8),
            description: {
                Dansk: [
                    "Objekt Orienteret Programmering projekt, hvor vi skulle lære om controllers, " + 
                    "libraries & at flytte ting fra én type applikation til en anden, uden at ødelægge programmet."
                ],
                English: [
                    "Object Oriented Programming project, to learn about controllers, " + 
                    "libraries and the ability to move things from an application type to another, without breaking the program"
                ]
            }
        }),
        new Project("TheHungryPhilosophers", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2020, 9, 2),
            description: {
                Dansk: ["Projekt hvor vi skulle lære om Threads & locks."],
                English: ["Project about threads and locks."]
            }
        }),
        new Project("TicTacToe", {
            language: 'Website',
            projectType: 'Website',
            createdAt: new DanhoDate(2020, 2, 20),
            description: {
                Dansk: [
                    "Projekt hvor vi skulle lave vores egen clientside side, " + 
                    "hvor at informationen kom fra en server, for at vise at det er ligegyldigt hvordan siden ser ud."
                ],
                English: [
                    "Project where we made our own clientside website, and the information to display came from a server, to teach us, "+ 
                    "that it doesn't matter how the website looks, as long as we display the data we recieve."
                ]
            }
        })
    ],
    3: [
        new Project("ORM", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2021, 4, 12),
            description: {
                Dansk: [
                    "I database programmering, ville vores lærer have at vi skulle lave vores egen Object Relational Mapping klasse, " + 
                    "så vi fik en god forståelse af ledet mellem code-behind og database objekthåndtering.",
                ],
                English: [
                    "In database programming, our teacher wanted us to make our own Object Relational Mapping class, " +
                    "so we could get a good understanding of the layer between the code-behind and a database object."
                ]
            },
            baseLink: 'Database programmering/ORM'
        }),
        new Project("DanhosMessages", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2021, 4, 28),
            description: {
                Dansk: [
                    "En afsluttende opgave, hvor jeg brugte EntityFramework til at binde mine modeller til en database, " + 
                    "så jeg havde både login- og messagesystem"
                ],
                English: [
                    "Final assignment, where I used EntityFramework to bind my models to a database, so I had both a login and messaging system."
                ]
            },
            baseLink: 'Database programmering/Final Assignment'
        }),
        new Project("MyWebserver", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2021, 4, 25),
            description: {
                Dansk: [
                    "Da vi startede med GUI Programmering III, synes vores lærer at det kunne være sjovt at vi lavede vores egen webserver, " + 
                    "så vi fik en lille forståelse af, hvordan en webserver fungerer med HTTP anmodninger.",
                    "Her brugte vi HttpListeners, til at lytte til URL gets, og håndterede dem i vores C# kode."
                ],
                English: [
                    "When we started GUI Programming III, our teacher thought it would be fun to make our own webserver, " + 
                    "so we could get a slight understanding of how a webserver works with HTTP requests.",
                    "We used HttpListeners to listen to URL gets and handle them in our C# code."
                ]
            },
            baseLink: "GUI Programmering"
        }),
        new Project("Vue.js", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 4, 28),
            description: {
                Dansk: [
                    "Som start i GUI Programmering III, startede vi ud med at udforske Vue.js.",
                    "Udover min \"komponent viden\" fra tidligere WPF projekter, var det første gang jeg legede med komponenter - " + 
                    "og det var noget jeg nød rigtig meget.",
                    "Eftersom jeg længe har haft lyst til at lære React.js, blev jeg relativ glad for at starte med Vue.js, " + 
                    "da de minder meget om hinaden.",
                    "",
                    "Selve projektet er én stor klump af udforskning af forskellige Vue problemstillinger, og sætte de fleste af dem til brug."
                ],
                English: [
                    "To start off GUI Programming III, we explored the wonders of Vue.js",
                    "Despite my \"component knowledge\" from previous WPF projects, this was the first time I played with components - " + 
                    "and I enjoyed it a ton",
                    "Since I've been wanting to learn React.js for a long time, I was very excited to start with Vue.js, " +
                    "since they remind of eachother a lot", "",
                    "The project itself was a big mess of experimentation of all sorts of Vue tasks and making a use for them."
                ]
            },
            baseLink: 'GUI Programmering'
        }),
        new Project("vuepos", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 5, 10),
            description: {
                Dansk: [
                    "Et mere reelt projekt ved brug af Vue.js",
                    "Sammen med mine kammerarter, Lasse & Mihaela, havde vi gruppe projekt om at lave en webshop, der havde en Employee og Admin mode.",
                    "",
                    "Som employee, skulle du kunne \"bippe\" produkter ind i kassen, og altid kunne følge med i, " + 
                    "hvad den endelige sum for produkterne ville være. " +
                    "Når så ordren var blevet placeret, skal man kunne se en historik over solgte produkter i Admin mode.",
                    "Som admin, skal du kunne oprette eller slette produkter. Desuden skal du også have en ordrehistorik."
                ],
                English: [
                    "A proper project in Vue.js",
                    "Together with my classmates, Lasse & Mihaela, we had a group project to make a webshop, that supported Employee & Admin mode.", "",
                    "As employee, you could \"scan\" the products in the cashieer and always follow along with the final sum of the products.",
                    "When the order was placed, you could see it in the history of sold proudcts in the sites Admin mode",
                    "As admin, you could create, update and delete proeducts. And of course, see the previously placed orders."
                ]
            },
            collab: {
                github: 'TheOnlySlothman',
                repo: 'vuepos'
            }
        }),
        new Project("XMLintro", {
            language: 'XML',
            projectType: 'WPF',
            createdAt: new DanhoDate(2021, 5, 25),
            description: {
                Dansk: [
                    "Upload XML, XSL & XSD filer til programmet, og den vil konvertere en XML fil baseret på XSL'en, " + 
                    "og verificere den nye XML fil ved brug af XSD filen, og give et endeligt output, som konvertereingen var successfuld eller ej."
                ],
                English: [
                    "Upload XML, XSL & XSD files to the program, and it'll convert to an XML file based on the XSL, " + 
                    "and verify the new XML file using the XSD file, and give a final result of the conversion."
                ]  
            },
            baseLink: 'XML/Intro/csharp/XMLintro'
        }),
        new Project("pewpew", {
            language: 'C#',
            projectType: 'Console',
            createdAt: new DanhoDate(2021, 6, 8),
            description: {
                Dansk: [
                    "Game Design I - vi fik ret frie hylder til at lave et spil, men jeg valgte at tage imod en udfordring.",
                    "Jeg ville forsøge og lave et 2D spil, hvor man er spiller, der skal skyde fjender. Spillet var ment som et endless spil."
                ],
                English: [
                    "Game Design I - there were not limits whatsoever, but I chose to take upon a challenge...",
                    "I wanted to make a 2D game, where the player shoots enemies as an endless game, in console."
                ]  
            },
            display: false,
            baseLink: 'Game Design I'
        }),
        new Project("Interrupts", {
            language: 'C',
            projectType: 'ATmega168',
            createdAt: new DanhoDate(2021, 4, 6),
            description: {
                Dansk: [
                    "Interrupts er et projekt, hvor vi skulle experimentere med interrupts i vores ATmega168.",
                    "Programmet laver et interrupt hvert sekund, hvor jeg kan tilmelde callbacks via \"hercules\", " +
                    "og på den måde bestemme, hvilke callbacks jeg vil have, ATmegaen skal køre." 
                ],
                English: [
                    "Interrupts is a project where we played with interrupts in our ATmega168, as our first proper Embedded programming assignment.",
                    "The program runs an interrupt every second, and then the user can assign/remove callbacks using \"hercules\", " +
                    "and therefore have full control over, which callbacks for the ATmega to run."
                ]  
            },
            baseLink: `Embedded Controller/Embedded II/Interrupts`
        })
    ]
}
const Other = {
    0: [
        new Project("Gymleader-timer", {
            language: 'C#',
            projectType: 'WPF',
            createdAt: new DanhoDate(2020, 7, 9),
            description: {
                Dansk: [
                    "Jeg arbejdede på en Pixelmon server, hvor jeg var Gym leader. " +
                    "Én af vores regler er, at efter at man har haft en kamp, skal man vente i en halv time, før man kan udfordre gymmet igen. " +
                    "Dette projekt hjalp både mig, men også mine andre gym leaders med at holde styr på vores challengers.", "",
                    "Programmet er baseret på en normal timer, og med mit tidligere MyWatch projekt, havde jeg allerede en god idé om, " + 
                    "hvordan jeg ville opnå mit resultat.",
                    "For at bruge programmet, skal man vælge om gymmet man har været vikar for, er et regulært eller et advanceret gym. " + 
                    "Som vist på billedet, har hvert gym sin egen type(r), og også delt op i 2 med 4 gyms. " +
                    "Dette er grundet den måde vores gym-system er sat op på serveren. Man har de første 4 og de sidste 4 i hver gym-line. " +
                    "Jeg har derfor gjort det mere brugervenligt, med at dele vores gyms op i regular/advanced og first/last 4.",
                    "Når man så har valgt enten regular eller advanced, bliver knapperne der er under katekorien låst op, " + 
                    "og knappen man trykkede på bliver låst. Dette er for at vise brugeren, hvilken knap brugeren trykkede på. " +
                    "Efter man har valgt sit gym, skal man indsætte udfordrens navn i tekstboksen. Derudover er timeren sat til 30 minutter som standard, " + 
                    "da det er den tid en udfordrer skal vente. " +
                    "Det kan selvfølgelig justeres, hvis man glemmer at tilføje en udfordrer til timeren.", "",
                    "Timerene i højre viser brugerens navn, det gym de kæmpede imod, og hvor lang deres ventetid er. - " + 
                    "Det er selvfølgelig kun vikaren der kan se den information, da udfordrerne ikke har programmet.",
                    "Når én af timerne er færdige, får brugeren en pop-up med en meddelelse om, at udfordrens ventetid er ovre."
                ],
                English: [
                    "I worked on a Pixelmon server, where I was a Gym leader." + 
                    "One of our rules was, that once you've had your challenge, you would be on a 30 minute cooldown, " + 
                    "before you can challenge the same gym again.",
                    "This project helped me but also some of my gym leader colleagues to keep track of our challengers.", "",
                    "The program was based on a normal timer, and since I had previous with watches, thanks to my MyWatch project, " + 
                    "I had a slight idea how I wanted to approach the project.",
                    "To use the program, you would need to select if the gym you have substitured for was a regular or an advanced gym. " +
                    "As sign in the picture, each gym has its own type(s), and also split up into 2 with 4 gyms. ",
                    "This is because of how our gym system was set up on the server. A substitute typically only had either the first 4 or the last 4 in each gym-line.",
                    "I then made it more user-friendly by splitting our first & last 4, and also our regular/advanced gyms.",
                    "When you've selected either regular or advanced, the buttons in the category then becomes clickable. " + 
                    "Once you've selected your gym, you need to insert the challengers name in the textbox. The timer is sat to 30 minutes as default value, ",
                    "since that is the time the challenger's cooldown is on.",
                    "However, if the gym leader forgot to put the challenger on the timer, the timer can be changed, and even updated.", "",
                    "The timers on the left shows the user's name, the gym they fought against, and how long their cooldown is on.",
                    "Only the substitute can see this information, since the challengers are not supposed to be using the program.",
                    "Once the timers are done, the user gets a pop-up with a message saying which challenger's time is up."
                ]
            },
            spareTime: true
        }),
        new Project("DanhoLibrary", {
            language: 'C#',
            projectType: 'Library',
            createdAt: new DanhoDate(2019, 11, 24),
            description: {
                Dansk: [
                    "Mit eget library som er en stor hjælp i mine C# projekter...",
                    "Der har været op til flere gange, hvor jeg har lavet noget i bl.a. et konsol projekt, og jeg har lavet den samme metode om og om igen... så lavede jeg et library...", "",
                    "Derfor gav det mening for mig, at lave et library til alle mine metoder og basis objekt opbyggelser.",
                    "Derudover er den også stoppet til med forskellige slags extensions."
                ],
                English: [
                    "My own library, that has been a huge help in my C# projects...",
                    "There have been tons of occations, where I've made something in a console project, and made the same method repeatedly...",
                    "It therefore made sense to make a library for all my methods and basic objects.",
                    "It is also filled with different kinds of extentions."
                ]
            },
            spareTime: true
        }),
        new Project("PinguPackage", {
            language: 'TypeScript',
            projectType: 'Library',
            createdAt: new DanhoDate(2020, 10, 12),
            description: {
                Dansk: [
                    "\"PinguPackage\", er et TypeScript modul, som jeg bruger i forbindelse med udvikling af mit Pingu projekt. " + 
                    "PinguPackage fungerer som et library, som min Discord bot, Pingu, er stærkt afhængig af.",
                    "",
                    "PinguPackage er mit første projekt i TypeScript, og jeg er stor fan af det. " + 
                    "Med min C# viden som baggrund, var det virkelig underligt at kode i JavaScript, da sproget knap nok er type stærkt. " +
                    "Så derfor lavede jeg mit library i TypeScript. " + 
                    "Jeg kan rigtig godt lide at alt er type stærkt, " + 
                    "og har også brugt rigtig meget tid på at give mig så meget hjælp som overhoved muligt, " + 
                    "når jeg koder Pingu i mit Pingu projekt.",
                ],
                English: [
                    "\"PinguPackage\" is a TypeScript module, that I use for my Pingu project. " + 
                    "PinguPackage works like a library my Discord bot, Pingu, is heavily dependent on.", "",
                    "PinguPackage is also my first TypeScript project, and I've since then become a big fan of it. " + 
                    "With my C# knowledge as my background, it was weird to code in JavaScript, since the language barely cares about types. " +
                    "So I made my library in TypeScript. " + "I'm a big fan of assigning types to my code, and use a lot of my time to help myself as much as possible, when I code Pingu.",
                ]
            },
            spareTime: true
        }),
        new Project("Pingu", {
            language: 'JavaScript',
            projectType: 'Node.js',
            createdAt: new DanhoDate(2019, 11, 15),
            description: {
                Dansk: [
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
                ],
                English: [
                    "My own Discord bot I work on.",
                    "I've always been a big fan of Discord. Since I started on Grundforløb 2 (Basic Course 2), I've been dying to make my very own Discord bot.",
                    "However, since I was a beginner a programming, it wasnt until I started in Skolepraktik I began with the project. " + 
                    "My buddies, Lasse, Nikolai & Andreas, all made Discord bots with me. And even though we didn't work on the same bot, " + 
                    "we still shared knowledge with each other from the Discord.js docs and random Javascript knowledge, since none of us had really worked in Javacript before.", "",
                    "My goal is to make Pingu the best Discord bot there is. My big inspiration lies in the popular Discord bots. " + 
                    "I like to \"steal\" their features, and recreate them in Pingu - it's something I really enjoy, as I find it the best way to learn.",
                    "Pingu is the project I'm most proud of in my programming career. There's always something to improve and develop. " +
                    "It also just lies in my interest in Discord - so it's generally just amazing to develop a product for something I use a ton of time on anyway."
                ]
            },
            spareTime: true
        }),
        new Project("Discord Bot Interface", {
            language: 'EJS',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 2, 26),
            description: {
                Dansk: [
                    "Discord Bot Interface er et projekt, hvor man skal kunne logge ind som sin Discord bot, " + 
                    "og kunne bruge den som var den en normal Discord bruger.",
                    "Projektet gør brug af Node.js webserver og selvfølgelig en række HTML sider og Discord.js modulet."
                ],
                English: [
                    "Discord Bot Interface is a project, where yo ucan log in as your Discord bot, " +
                    "and us eif as if it was a normal Discord user.",
                    "The project uses a Node.js webserver, a selection of HTML pages and the Discord.js module."
                ]
            },
            display: false,
            hasLink: false,
            spareTime: true
        }),
        new Project("DanhoLibraryJS", {
            language: 'TypeScript',
            projectType: 'Library',
            createdAt: new DanhoDate(2021, 5, 13),
            description: {
                Dansk: [
                    "Ligesom mit DanhoLibrary i C#, ville jeg have et DanhoLibrary til JavaScript.",
                    "Jeg kom tit i situationer, hvor jeg ikke forstod, hvorfor f.eks. HTMLCollection ikke havde en .array(), " + 
                    "eller hvorfor jeg ikke havde en måde at bruge Node.js' EventEmitter klasse i vanilla JavaScript.",
                    "",
                    "Så jeg lavede naturligvis mit eget library til situationen. Alle modifikationer og extentions kan læses på projektets README fil."
                ],
                English: [
                    "Like my DanhoLibrary in C#, I wanted to make a DanhoLibrary in JavaScript",
                    "I often ran into situations, where I didn't understand why, like HTMLCollection didn't have a .aray(), " + 
                    "or why I couldn't use the Node.js EventEmitter calss in vanilla JavaScript." , "",
                    "So I obviously made my own library for situation. All modifications and extentions can be read in the project's README file."
                ]
            },
            spareTime: true
        }),
        new Project("Dancord", {
            language: 'Vue.js',
            projectType: 'Website',
            createdAt: new DanhoDate(2021, 5, 30),
            description: {
                Dansk: [
                    "Som vist i nogle af mine andre projekter, er jeg rigtig glad for Discord, og den måde det er bygget op på.",
                    "Jeg har tidligere forsøgt at lave en \"Dancord\" før i WPF, men har siden da indset, at det ville være meget nemmere i Vue.js."
                ],
                English: [
                    "As shown in my other projects, I'm a Discord fanboy, and the way its sat up.",
                    "I've previously attempted to make a \"Dancord\" before in WPF, but since then realized it would be easier in Vue.js."
                ]
            },
            spareTime: true
        })
    ]
}

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

const projects = (function getProjects() {
    let result = new ProjectCollection("DanielSimonsen90", locationCollection);

    const arrays = [SKP, Hovedforløb, Other];

    for (const obj of arrays) {
        for (let i = 0; i <= Object.keys(obj).length; i++) {
            if (obj[i]) {
                result.append(...obj[i])
            }
        }
    }

    return result.sort((a, b) => a.createdAt.getTime() - b.createdAt.getTime());
})();

const express = require('express');
const router = express.Router();
const mongo = require('mongodb');
const mongoConnectionString = `mongodb+srv://DanhosaurPortfolioIIApplication:database-admin@danhosaurportfolioii.x1ocs.mongodb.net/DanhosaurPortfolioIIDB?retryWrites=true&w=majority`;
const fs = require('fs');
const axios = require('../client/node_modules/axios');

router.get('/', async (req, res) => {
    const client = await mongo.MongoClient.connect(mongoConnectionString, {
        useNewUrlParser: true,
        useUnifiedTopology: true
    });

    const errs = [];
    for (const project of projects) {
        const path = `./projects/${project.name}.png`;
        if (fs.existsSync(path)) {
            project.image = fs.readFileSync(path).toString('base64');
        }
        
        project._id = projects.indexOf(project);
        await axios.post(`http://localhost:8081/api/projects`, {
            postData: JSON.stringify(project)
        })
    }

    res.status(200).send(`<code>${JSON.stringify(errs, null, 4)}</code>`);
})

module.exports = router;