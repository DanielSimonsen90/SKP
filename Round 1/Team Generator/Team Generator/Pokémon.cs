using System;
using System.Drawing;
using System.Windows.Forms;

namespace Team_Generator
{
    public partial class Pokémon : Form
    {
        private static readonly Random Rand = new Random();
        private static readonly PocketMonster[][] PokémonList = SetPokéList();
        public Pokémon() => InitializeComponent();

        private void SearchButton_Click(object sender, EventArgs e) => GenerateTeam();

        private void GenerateTeam()
        {
            int Generation;
            PocketMonster SlotOne = PokémonList[Generation = Rand.Next(PokémonList.Length)][Rand.Next(PokémonList[Generation].Length)];
            PocketMonster SlotTwo = PokémonList[Generation = Rand.Next(PokémonList.Length)][Rand.Next(PokémonList[Generation].Length)];
            PocketMonster SlotThree = PokémonList[Generation = Rand.Next(PokémonList.Length)][Rand.Next(PokémonList[Generation].Length)];
            PocketMonster SlotFour = PokémonList[Generation = Rand.Next(PokémonList.Length)][Rand.Next(PokémonList[Generation].Length)];
            PocketMonster SlotFive = PokémonList[Generation = Rand.Next(PokémonList.Length)][Rand.Next(PokémonList[Generation].Length)];
            PocketMonster SlotSix = PokémonList[Generation = Rand.Next(PokémonList.Length)][Rand.Next(PokémonList[Generation].Length)];

            SetSlotOne(SlotOne);
            SetSlotTwo(SlotTwo);
            SetSlotThree(SlotThree);
            SetSlotFour(SlotFour);
            SetSlotFive(SlotFive);
            SetSlotSix(SlotSix);
        }

        #region SetSlotNumber
        private void SetSlotOne(PocketMonster Pokémon)
        {
            LabelSlotOne.Text = Pokémon.LabelText;
            TypeOneSlotOne.Image = FindType(Pokémon.TypeOne);
            TypeTwoSlotOne.Image = FindType(Pokémon.TypeTwo, TypeOneSlotOne.Image);
            FighterTypeSlotOne.Image = FindFighter(Pokémon.FighterType);
            PictureSlotOne.Image = new Bitmap(Pokémon.PictureLocation);
        }
        private void SetSlotTwo(PocketMonster Pokémon)
        {
            LabelSlotTwo.Text = Pokémon.LabelText;
            TypeOneSlotTwo.Image = FindType(Pokémon.TypeOne);
            TypeTwoSlotTwo.Image = FindType(Pokémon.TypeTwo, TypeOneSlotTwo.Image);
            FighterTypeSlotTwo.Image = FindFighter(Pokémon.FighterType);
            PictureSlotTwo.Image = new Bitmap(Pokémon.PictureLocation);
        }
        private void SetSlotThree(PocketMonster Pokémon)
        {
            LabelSlotThree.Text = Pokémon.LabelText;
            TypeOneSlotThree.Image = FindType(Pokémon.TypeOne);
            TypeTwoSlotThree.Image = FindType(Pokémon.TypeTwo, TypeOneSlotThree.Image);
            FighterTypeSlotThree.Image = FindFighter(Pokémon.FighterType);
            PictureSlotThree.Image = new Bitmap(Pokémon.PictureLocation);
        }
        private void SetSlotFour(PocketMonster Pokémon)
        {
            LabelSlotFour.Text = Pokémon.LabelText;
            TypeOneSlotFour.Image = FindType(Pokémon.TypeOne);
            TypeTwoSlotFour.Image = FindType(Pokémon.TypeTwo, TypeOneSlotFour.Image);
            FighterTypeSlotFour.Image = FindFighter(Pokémon.FighterType);
            PictureSlotFour.Image = new Bitmap(Pokémon.PictureLocation);
        }
        private void SetSlotFive(PocketMonster Pokémon)
        {
            LabelSlotFive.Text = Pokémon.LabelText;
            TypeOneSlotFive.Image = FindType(Pokémon.TypeOne);
            TypeTwoSlotFive.Image = FindType(Pokémon.TypeTwo, TypeOneSlotFive.Image);
            FighterTypeSlotFive.Image = FindFighter(Pokémon.FighterType);
            PictureSlotFive.Image = new Bitmap(Pokémon.PictureLocation);
        }
        private void SetSlotSix(PocketMonster Pokémon)
        {
            LabelSlotSix.Text = Pokémon.LabelText;
            TypeOneSlotSix.Image = FindType(Pokémon.TypeOne);
            TypeTwoSlotSix.Image = FindType(Pokémon.TypeTwo, TypeOneSlotSix.Image);
            FighterTypeSlotSix.Image = FindFighter(Pokémon.FighterType);
            PictureSlotSix.Image = new Bitmap(Pokémon.PictureLocation);
        }
        #endregion

        #region Pokémon Data
        private static PocketMonster[][] SetPokéList()
        {
            PocketMonster[] GenerationOne =
            {
                new PocketMonster("Aerodactyl", "Rock", "Flying", "Physical", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Aerodactyl.png"),
                new PocketMonster("Arcanine", "Fire", null, "Physical", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Arcanine.png"),
                new PocketMonster("Beedrill", "Bug", "Flying", "Physical", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Beedrill.png"),
                new PocketMonster("Charizard", "Fire", "Flying", RandomType(), 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Charizard.png"),
                new PocketMonster("Dragonite", "Dragon", "Flying", "Physical", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Dragonite.png"),
                new PocketMonster("Gengar", "Ghost", "Poison", "Special", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Gengar.png"),
                new PocketMonster("Gyarados", "Water", "Flying", "Physical", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Gyarados.png"),
                new PocketMonster("Lapras", "Water", "Ice", "Special", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Lapras.png"),
                new PocketMonster("Mewtwo", "Psychic", null, "Special", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Mewtwo.png"),
                new PocketMonster("Nidoking", "Poison", "Ground", RandomType(), 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Nidoking.png"),
                new PocketMonster("Rattata", "Normal", null, "Physical", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Rattata.png"),
                new PocketMonster("Spearow", "Normal", "Flying", "Physical", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Spearow.png"),
                new PocketMonster("Zapdos", "Electric", "Flying", "Special", 1, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 1/Zapdos.png"),
            };
            PocketMonster[] GenerationTwo =
            {
                new PocketMonster("Ampharos", "Electric", null, "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Ampharos.png"),
                new PocketMonster("Celebi", "Psychic", "Grass", "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Celebi.png"),
                new PocketMonster("Heracross", "Bug", "Fighting", "Physical", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Heracross.png"),
                new PocketMonster("Ho-Oh", "Fire", "Flying", "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Ho-Oh.png"),
                new PocketMonster("Houndoom", "Fire", "Dark", "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Houndoom.png"),
                new PocketMonster("Kingdra", "Water", "Dragon", "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Kingdra.png"),
                new PocketMonster("Lugia", "Psychic", "Flying", "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Lugia.png"),
                new PocketMonster("Magcargo", "Fire", "Rock", "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Magcargo.png"),
                new PocketMonster("Porygon2", "Normal", null, "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Porygon2.png"),
                new PocketMonster("Raikou", "Electric", null, "Special", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Raikou.png"),
                new PocketMonster("Scizor", "Bug", "Steel", "Physical", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Scizor.png"),
                new PocketMonster("Typhlosion", "Fire", null, "Physical", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Typhlosion.png"),
                new PocketMonster("Tyranitar", "Rock", "Dark", "Physical", 2, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 2/Tyranitar.png")
            };
            PocketMonster[] GenerationThree =
            {
                new PocketMonster("Absol", "Dark", null, "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Absol.png"),
                new PocketMonster("Aggron", "Rock", "Steel", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Aggron.png"),
                new PocketMonster("Altaria", "Dragon", "Flying", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Altaria.png"),
                new PocketMonster("Blaziken", "Fire", "Fighting", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Blaziken.png"),
                new PocketMonster("Breloom", "Grass", "Fighting", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Breloom.png"),
                new PocketMonster("Corphish", "Water", null, "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Corphish.png"),
                new PocketMonster("Deoxys", "Psychic", null, "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Deoxys.png"),
                new PocketMonster("Dustox", "Bug", "Flying", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Dustox.png"),
                new PocketMonster("Flygon", "Dragon", "Flying", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Flygon.png"),
                new PocketMonster("Gardevoir", "Psychic", "Fairy", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Gardevoir.png"),
                new PocketMonster("Groudon", "Ground", null, "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Groudon.png"),
                new PocketMonster("Kecleon", "Normal", null, "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Kecleon.png"),
                new PocketMonster("Kyogre", "Water", null, "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Kyogre.png"),
                new PocketMonster("Latias", "Dragon", "Flying", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Latias.png"),
                new PocketMonster("Latios", "Dragon", "Flying", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Latios.png"),
                new PocketMonster("Ludicolo", "Water", "Grass", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Ludicolo.png"),
                new PocketMonster("Mawile", "Steel", "Fairy", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Mawile.png"),
                new PocketMonster("Metagross", "Steel" ,"Psychic", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Metagross.png"),
                new PocketMonster("Mightyena", "Dark", null, "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Mightyena.png"),
                new PocketMonster("Milotic", "Water", null, "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Milotic.png"),
                new PocketMonster("Mudkip", "Water", null, "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Mudkip.png"),
                new PocketMonster("Ninjask", "Bug", "Flying", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Ninjask.png"),
                new PocketMonster("Pelipper", "Water", "Flying", "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Pelipper.png"),
                new PocketMonster("Rayquaza", "Dragon", "Flying", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Rayquaza.png"),
                new PocketMonster("Sableye", "Ghost", "Dark", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Sableye.png"),
                new PocketMonster("Salamence", "Dragon", "Flying", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Salamence.png"),
                new PocketMonster("Sceptile", "Grass", null, "Special", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Sceptile.png"),
                new PocketMonster("Sharpedo", "Water","Dark","Physical",3,"C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Sharpedo.png"),
                new PocketMonster("Shedinja", "Bug", "Ghost", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Shedinja.png"),
                new PocketMonster("Shiftry", "Grass", "Dark", "Physical", 3, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Siftry.png"),
                new PocketMonster("Zangoose", "Normal", null, "Physical", 3,"C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 3/Zangoose.png")
            };
            PocketMonster[] GenerationFour =
            {
                new PocketMonster("Abomasnow", "Ice", "Grass", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Abomasnow.png"),
                new PocketMonster("Buizel", "Water", null, "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Buizel.png"),
                new PocketMonster("Buneary", "Normal", null, "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Buneary.png"),
                new PocketMonster("Darkrai", "Dark", null, "Special", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Darkrai.png"),
                new PocketMonster("Dialga", "Dragon", "Steel", "Special", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Dialga.png"),
                new PocketMonster("Drapion", "Poison", "Dark", "Physical",4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Drapion.png"),
                new PocketMonster("Electivire", "Electric", null, "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Electivire.png"),
                new PocketMonster("Gallade", "Psychic", "Fighting", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Gallade.png"),
                new PocketMonster("Gliscor", "Ground", "Flying", "Physical",4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Gliscor.png"),
                new PocketMonster("Honchkrow", "Dark", "Flying", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Honchkrow.png"),
                new PocketMonster("Infernape", "Fire", "Fighting", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Infernape.png"),
                new PocketMonster("Lucario", "Fighting", "Steel", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Lucario.png"),
                new PocketMonster("Luxray", "Electric", null, "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Luxray.png"),
                new PocketMonster("Mamoswine", "Ice", "Ground", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Mamoswine.png"),
                new PocketMonster("Staraptor", "Normal", "Flying", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Staraptor.png"),
                new PocketMonster("Togekiss", "Fairy", "Flying", "Special", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Togekiss.png"),
                new PocketMonster("Torterra", "Grass", "Ground", "Special", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Torterra.png"),
                new PocketMonster("Weavile", "Ice", "Dark", "Physical", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Weavile.png"),
                new PocketMonster("Yanmega", "Bug", "Flying", "Special", 4, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 4/Yanmega.png")
            };
            PocketMonster[] GenerationFive =
            {
                new PocketMonster("Accelgor" ,"Bug", null, "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Accelgor.png"),
                new PocketMonster("Bisharp", "Dark", "Steel", "Physical", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Bisharp.png"),
                new PocketMonster("Braviary", "Normal", "Flying", "Physical", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Braviary.png"),
                new PocketMonster("Chandelure", "Ghost", "Fire", "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Chandelure.png"),
                new PocketMonster("Galvantula", "Electric", "Bug", "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Galvantula.png"),
                new PocketMonster("Golurk", "Ghost", "Ground", "Physical", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Golurk.png"),
                new PocketMonster("Gothitelle", "Psychic", null, "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Gothitelle.png"),
                new PocketMonster("Hydreigon", "Dragon", "Dark", "Physical", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Hydreigon.png"),
                new PocketMonster("Klinklang", "Steel", null, "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Klinklang.png"),
                new PocketMonster("Krookodile", "Ground", "Dark", "Physical", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Krookodile.png"),
                new PocketMonster("Reshiram", "Dragon", "Fire", "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Reshiram.png"),
                new PocketMonster("Scolipede", "Bug", "Poison", "Physical", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Scolipede.png"),
                new PocketMonster("Volcarona", "Bug", "Fire", "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Volcarona.png"),
                new PocketMonster("Zekrom", "Dragon", "Electric", "Special", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Zekrom.png"),
                new PocketMonster("Zoroark", "Dark", null, "Physical", 5, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 5/Zoroark.png")
            };
            PocketMonster[] GenerationSix =
            {
                new PocketMonster("Delphox", "Fire", "Psychic", "Special", 6, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 6/Delphox.png"),
                new PocketMonster("Greninja", "Water", "Dark", RandomType(), 6, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 6/Greninja.png"),
                new PocketMonster("Noivern", "Dragon", "Flying", "Special", 6, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 6/Noivern.png"),
                new PocketMonster("Talonflame", "Fire", "Flying", "Special", 6, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 6/Talonflame.png"),
                new PocketMonster("Trevenant", "Grass", "Ghost", "Physical", 6, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 6/Trevenant.png"),
                new PocketMonster("Yveltal", "Dark", "Dragon", "Special", 6, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 6/Yveltal.png")
            };
            PocketMonster[] GenerationSeven =
            {
                new PocketMonster("Araquanid", "Bug", "Water", "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Araquanid.png"),
                new PocketMonster("Crabominable", "Ice", "Fighting", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Crabominable.png"),
                new PocketMonster("Decidueye", "Grass", "Ghost", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Decidueye.png"),
                new PocketMonster("Golisopod", "Bug", "Water", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Golisopod.png"),
                new PocketMonster("Incineroar", "Fire", "Dark", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Incineroar.png"),
                new PocketMonster("Komala", "Normal", null, "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Komala.png"),
                new PocketMonster("Kommo-o", "Dragon", "Fighting", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Kommo-o.png"),
                new PocketMonster("Lunala", "Psychic", "Ghost", "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Lunala.png"),
                new PocketMonster("Lycanroc", "Rock", null, "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Lycanroc.png"),
                new PocketMonster("Magearna", "Steel", "Fairy", "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Magearna.png"),
                new PocketMonster("Marshadow", "Ghost", "Fighting", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Marshadow.png"),
                new PocketMonster("Mimikyu", "Ghost", "Fairy", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Mimikyu.png"),
                new PocketMonster("Mudsdale", "Ground", null, "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Mudsdale.png"),
                new PocketMonster("Necrozma", "Psychic", null, "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Necrozma.png"),
                new PocketMonster("Salazzle", "Poison", "Fire", "Special", 7 , "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Salazzle.png"),
                new PocketMonster("Solgaleo", "Psychic", "Steel", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Solgaleo.png"),
                new PocketMonster("Tapu Koko", "Electric", "Fairy", "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Tapu Koko.png"),
                new PocketMonster("Toxapex", "Poison", "Water", "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Toxapex.png"),
                new PocketMonster("Tsareena", "Grass", null, "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Tsareena.png"),
                new PocketMonster("Turtonator", "Dragon", "Fire", "Physical", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Turtonator.png"),
                new PocketMonster("Vikavolt", "Bug", "Electric", "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Vikavolt.png"),
                new PocketMonster("Wishiwashi", "Water", null, "Special", 7, "C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Sprites/Generation 7/Wishiwashi.png")
            };

            return new PocketMonster[][] { GenerationOne, GenerationTwo, GenerationThree, GenerationFour, GenerationFive, GenerationSix, GenerationSeven };
        }
        private static string RandomType() =>  Rand.Next(2) == 1 ? "Physical" : "Special";
        
        private Image FindFighter(string Type)
        {
            switch (Type)
            {
                case "Physical":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Fighting/Physical.png");
                case "Special":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Fighting/Special.png");
                default:
                    return null;
            }
        }
        private Image FindType(string Type)
        {
            switch (Type)
            {
                case "Bug":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Bug.png");
                case "Dark":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Dark.png");
                case "Dragon":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Dragon.png");
                case "Electric":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Electric.png");
                case "Fairy":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Fairy.png");
                case "Fighting":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Fighting.png");
                case "Fire":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Fire.png");
                case "Flying":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Flying.png");
                case "Ghost":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Ghost.png");
                case "Grass":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Grass.png");
                case "Ground":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Ground.png");
                case "Ice":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Ice.png");
                case "Normal":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Normal.png");
                case "Poison":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Poison.png");
                case "Psychic":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Psychic.png");
                case "Rock":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Rock.png");
                case "Steel":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Steel.png");
                case "Water":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Water.png");
            }
            return null;
        }
        private Image FindType(string Type, Image Type1)
        {
            switch (Type)
            {
                case "Bug":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Bug.png");
                case "Dark":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Dark.png");
                case "Dragon":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Dragon.png");
                case "Electric":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Electric.png");
                case "Fairy":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Fairy.png");
                case "Fighting":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Fighting.png");
                case "Fire":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Fire.png");
                case "Flying":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Flying.png");
                case "Ghost":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Ghost.png");
                case "Grass":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Grass.png");
                case "Ground":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Ground.png");
                case "Ice":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Ice.png");
                case "Normal":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Normal.png");
                case "Poison":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Poison.png");
                case "Psychic":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Psychic.png");
                case "Rock":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Rock.png");
                case "Steel":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Steel.png");
                case "Water":
                    return new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Pokémon/Types/Water.png");
                default:
                    return Type1;
            }
        }
        #endregion

        private void Pokémon_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);
    }
}
