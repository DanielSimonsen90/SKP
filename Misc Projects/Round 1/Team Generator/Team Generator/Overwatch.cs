using System;
using System.Drawing;
using System.Windows.Forms;

namespace Team_Generator
{
    public partial class Overwatch : Form
    {
        public Overwatch()
        {
            InitializeComponent();
        }

        private static readonly Random Rand = new Random();
        private static int RandomIndex;
        private void SearchButton_Click(object sender, EventArgs e)
        {
            GenerateTeam();
        }

        private void GenerateTeam()
        {
            GenerateTank();
            GenerateDamage();
            GenerateSupport();
        }

        #region Tanks
        #region Generate
        private void GenerateTank()
        {
            string[] Tanks = { "Reinhardt", "Orisa", "Winston", "Wreckingball" };
            LabelMainTank.Text = Tanks[RandomIndex = Rand.Next(Tanks.Length)];

            switch (RandomIndex)
            {
                case 0:
                    SetTank("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Main/Reinhardt.png");
                    break;
                case 1:
                    SetTank("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Main/Orisa.png", "Zarya");
                    break;
                case 2:
                    SetTank("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Main/Winston.png", "Roadhog", "Sigma");
                    break;
                case 3:
                    SetTank("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Main/Wreckingball.png"); 
                    break;
            }
        }
        private string GenerateOffTank()
        {
            string[] Tanks = { "D.Va", "Roadhog", "Sigma", "Zarya" };
            LabelOffTank.Text = Tanks[RandomIndex = Rand.Next(Tanks.Length)];

            switch (RandomIndex)
            {
                case 0:
                    PictureOffTank.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Off/D.Va.png");
                    break;
                case 1:
                    PictureOffTank.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Off/Roadhog.png");
                    break;
                case 2:
                    PictureOffTank.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Off/Sigma.png");
                    break;
                case 3:
                    PictureOffTank.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Tank/Off/Zarya.png");
                    break;
            }
            return Tanks[RandomIndex];
        }
        #endregion
        #region SetTank Methods
        private void SetTank(string Image)
        {
            PictureMainTank.Image = new Bitmap(Image);
            GenerateOffTank();
        }
        private void SetTank(string Image, string SeperationOne)
        {
            PictureMainTank.Image = new Bitmap(Image);
            string OffTank = GenerateOffTank();

            while (OffTank == SeperationOne)
                OffTank = GenerateOffTank();
        }
        private void SetTank(string Image, string SeperationOne, string SeperationTwo)
        {
            PictureMainTank.Image = new Bitmap(Image);
            string OffTank = GenerateOffTank();

            while (OffTank == SeperationOne || OffTank == SeperationTwo)
                OffTank = GenerateOffTank();
        }
        #endregion
        #endregion

        private void GenerateDamage()
        {
            string[] Damage = {"Ashe", "Bastion", "Doomfist", "Genji", "Hanzo", "Junkrat", "McCree", "Mei", "Pharah", "Reaper", "Soldier: 76", 
                "Sombra", "Symmetra", "Torbjörn", "Tracer", "Widowmaker"};
            LabelMainDPS.Text = Damage[RandomIndex = Rand.Next(Damage.Length)];
            switch (RandomIndex)
            {
                case 0:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Ashe.png");
                    break;
                case 1:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Bastion.png");
                    break;
                case 2:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Doomfist.png");
                    break;
                case 3:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Genji.png");
                    break;
                case 4:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Hanzo.png");
                    break;
                case 5:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Junkrat.png");
                    break;
                case 6:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/McCree.png");
                    break;
                case 7:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Mei.png");
                    break;
                case 8:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Pharah.png");
                    break;
                case 9:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Reaper.png");
                    break;
                case 10:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Soldier.png");
                    break;
                case 11:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Sombra.png");
                    break;
                case 12:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Symmetra.png");
                    break;
                case 13:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Torbjörn.png");
                    break;
                case 14:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Tracer.png");
                    break;
                case 15:
                    PictureMainDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Widowmaker.png");
                    break;

                default:
                    break;
            }

            LabelOffDPS.Text = Damage[RandomIndex = Rand.Next(Damage.Length)];

            while (LabelOffDPS.Text == LabelMainDPS.Text)
                LabelOffDPS.Text = Damage[RandomIndex = Rand.Next(Damage.Length)];

            switch (RandomIndex)
            {
                case 0:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Ashe.png");
                    break;
                case 1:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Bastion.png");
                    break;
                case 2:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Doomfist.png");
                    break;
                case 3:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Genji.png");
                    break;
                case 4:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Hanzo.png");
                    break;
                case 5:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Junkrat.png");
                    break;
                case 6:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/McCree.png");
                    break;
                case 7:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Mei.png");
                    break;
                case 8:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Pharah.png");
                    break;
                case 9:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Reaper.png");
                    break;
                case 10:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Soldier.png");
                    break;
                case 11:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Sombra.png");
                    break;
                case 12:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Symmetra.png");
                    break;
                case 13:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Torbjörn.png");
                    break;
                case 14:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Tracer.png");
                    break;
                case 15:
                    PictureOffDPS.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Damage/Widowmaker.png");
                    break;

                default:
                    break;
            }
        }

        #region Supports
        private void GenerateSupport()
        {
            string[] Supports = { "Ana", "Mercy", "Moira" };
            LabelMainSupport.Text = Supports[RandomIndex = Rand.Next(Supports.Length)];

            switch (RandomIndex)
            {
                case 0:
                    SetSupport("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Support/Main/Ana.png");
                    break;
                case 1:
                    SetSupport("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Support/Main/Mercy.png");
                    break;
                case 2:
                    SetSupport("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Support/Main/Moira.png", "Zenyatta", "Baptiste");
                    break;
            }
        }
        private string GenerateOffSupport()
        {
            string[] Supports = { "Baptiste", "Brigitte", "Lúcio", "Zenyatta" };
            LabelOffSupport.Text = Supports[RandomIndex = Rand.Next(Supports.Length)];

            switch (RandomIndex)
            {
                case 0:
                    PictureOffSupport.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Support/Off/Baptiste.png");
                    break;
                case 1:
                    PictureOffSupport.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Support/Off/Brigitte.png");
                    break;
                case 2:
                    PictureOffSupport.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Support/Off/Lúcio.png");
                    break;
                case 3:
                    PictureOffSupport.Image = new Bitmap("C:/Users/DanielSimonsen/Pictures/Team Generator/Overwatch/Heroes/Support/Off/Zenyatta.png");
                    break;
            }
            return Supports[RandomIndex];
        }
        private void SetSupport(string Image)
        {
            PictureMainSupport.Image = new Bitmap(Image);
            GenerateOffSupport();
        }
        private void SetSupport(string Image, string SeperationOne, string SeperationTwo)
        {
            PictureMainSupport.Image = new Bitmap(Image);
            string OffSupport = GenerateOffSupport();

            if (OffSupport == SeperationOne || OffSupport == SeperationTwo)
                SetSupport(Image, SeperationOne, SeperationTwo);
        }
        #endregion

        private void Overwatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
