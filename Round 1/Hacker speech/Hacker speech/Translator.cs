using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Translator
{
    public partial class AWTranslator : Form
    {
        //Make the Forms Application
        public AWTranslator()
        {
            //Create components
            InitializeComponent();

            //Set the default size
            AWEncryptSplitter.Width = ((ClientSize.Width / 100) * 50);
            SetSize(AWEncryptSplitter.Width, ClientSize.Height);
        }

        //Encryption and whatever is needed for it
        #region Encrypt
        /// <summary>
        /// What happens when AWEncrypter's text changes?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AWEncrypter_TextChanged(object sender, EventArgs e)
        {
            //Save SelectionStart (The index of where the selection is)
            var SelectionStart = AWEncrypter.SelectionStart;

            //Run Encryption and replace the Encrypter text
            AWEncrypter.Text = Encrypt(AWEncrypter.Text);

            //Put the saved SelectionStart back to its original position, since the SelectionStart is now set to 0, due to the text replacement.
            AWEncrypter.SelectionStart = SelectionStart;
        }

        /// <summary>
        /// Encrypts input
        /// </summary>
        /// <param name="input">Encrypts this string</param>
        /// <returns></returns>
        private string Encrypt(string input)
        {
            //Run decrypter on the other window - but without making it loop back and forth
            AWDecrypter.Text = DecryptSolo(input);

            if (!Casing)
                return input.Replace('G', '6')
                    .ToLower()
                    .Replace('g', '9')
                    .Replace('b', '8')
                    .Replace('t', '7')
                    .Replace('s', '5')
                    .Replace('a', '4')
                    .Replace('ä', '4')
                    .Replace('â', '4')
                    .Replace('á', '4')
                    .Replace('à', '4')
                    .Replace('ã', '4')
                    .Replace('e', '3')
                    .Replace('ë', '3')
                    .Replace('ê', '3')
                    .Replace('é', '3')
                    .Replace('è', '3')
                    .Replace('z', '2')
                    .Replace('i', '1')
                    .Replace('ï', '1')
                    .Replace('î', '1')
                    .Replace('í', '1')
                    .Replace('ì', '1')
                    .Replace('o', '0')
                    .Replace('ö', '0')
                    .Replace('ô', '0')
                    .Replace('ó', '0')
                    .Replace('ò', '0');
            else
                return input.ToUpper()
                .Replace('G', '6')
                .Replace('B', '8')
                .Replace('T', '7')
                .Replace('S', '5')
                .Replace('A', '4')
                .Replace('Ä', '4')
                .Replace('Â', '4')
                .Replace('Á', '4')
                .Replace('À', '4')
                .Replace('Ã', '4')
                .Replace('E', '3')
                .Replace('Ë', '3')
                .Replace('Ê', '3')
                .Replace('É', '3')
                .Replace('È', '3')
                .Replace('Z', '2')
                .Replace('I', '1')
                .Replace('Ï', '1')
                .Replace('Î', '1')
                .Replace('Í', '1')
                .Replace('Ì', '1')
                .Replace('O', '0')
                .Replace('Ö', '0')
                .Replace('Ô', '0')
                .Replace('Ó', '0')
                .Replace('Ò', '0');
        }

        /// <summary>
        /// Decrypts this input without changing AWEncrypter
        /// </summary>
        /// <param name="input">String to decrypt</param>
        /// <returns></returns>
        private string DecryptSolo(string input)
        {
            //Replace the encrypted input with the decryption
            if (!Casing)
                return input.Replace('6', 'g')
                    .ToLower()
                    .Replace('9', 'g')
                    .Replace('8', 'b')
                    .Replace('7', 't')
                    .Replace('5', 's')
                    .Replace('4', 'a')
                    .Replace('3', 'e')
                    .Replace('2', 'z')
                    .Replace('1', 'i')
                    .Replace('0', 'o');
            else
                return input.Replace('6', 'g')
                    .ToUpper()
                    .Replace('9', 'G')
                    .Replace('8', 'B')
                    .Replace('7', 'T')
                    .Replace('5', 'S')
                    .Replace('4', 'A')
                    .Replace('3', 'E')
                    .Replace('2', 'Z')
                    .Replace('1', 'I')
                    .Replace('0', 'O');
        }
        #endregion

        //Decryption and whatever is needed for it
        #region Decrypt
        /// <summary>
        /// What happens when AWDecrypter's text changes?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AWDecrypter_TextChanged(object sender, EventArgs e)
        {
            //Remember the SelectionStart (The index of where the User was)
            var SelectionStart = AWDecrypter.SelectionStart;

            //Run decrypter 
            AWDecrypter.Text = Decrypt(AWDecrypter.Text);

            //Insert SelectionStart, as the program forgot about it in the text replacement
            AWDecrypter.SelectionStart = SelectionStart;
        }

        /// <summary>
        /// Decrypts input
        /// </summary>
        /// <param name="input">string to decrypt</param>
        /// <returns></returns>
        private string Decrypt(string input)
        {
            //Run encrypter but without changing the decrypter to avoid loops
            AWEncrypter.Text = EncryptSolo(input);

            //Replace the encrypted text with a decrypt
            if (!Casing)
                return input.Replace('6', 'g')
                    .ToLower()
                    .Replace('9', 'g')
                    .Replace('8', 'b')
                    .Replace('7', 't')
                    .Replace('5', 's')
                    .Replace('4', 'a')
                    .Replace('3', 'e')
                    .Replace('2', 'z')
                    .Replace('1', 'i')
                    .Replace('0', 'o');
            else
                return input.Replace('6', 'g')
                    .ToUpper()
                    .Replace('9', 'G')
                    .Replace('8', 'B')
                    .Replace('7', 'T')
                    .Replace('5', 'S')
                    .Replace('4', 'A')
                    .Replace('3', 'E')
                    .Replace('2', 'Z')
                    .Replace('1', 'I')
                    .Replace('0', 'O');
        }

        /// <summary>
        /// Encrypts this input without changing AWDecrypter
        /// </summary>
        /// <param name="input">string to encrypt</param>
        /// <returns></returns>
        private string EncryptSolo(string input)
        {
            //Replace the decrypted text with an encrypt
            if (!Casing)
                return input.Replace('G', '6')
                    .ToLower()
                    .Replace('g', '9')
                    .Replace('b', '8')
                    .Replace('t', '7')
                    .Replace('s', '5')
                    .Replace('a', '4')
                    .Replace('ä', '4')
                    .Replace('â', '4')
                    .Replace('á', '4')
                    .Replace('à', '4')
                    .Replace('ã', '4')
                    .Replace('e', '3')
                    .Replace('ë', '3')
                    .Replace('ê', '3')
                    .Replace('é', '3')
                    .Replace('è', '3')
                    .Replace('z', '2')
                    .Replace('i', '1')
                    .Replace('ï', '1')
                    .Replace('î', '1')
                    .Replace('í', '1')
                    .Replace('ì', '1')
                    .Replace('o', '0')
                    .Replace('ö', '0')
                    .Replace('ô', '0')
                    .Replace('ó', '0')
                    .Replace('ò', '0');
            else
                return input.ToUpper()
                .Replace('G', '6')
                .Replace('B', '8')
                .Replace('T', '7')
                .Replace('S', '5')
                .Replace('A', '4')
                .Replace('Ä', '4')
                .Replace('Â', '4')
                .Replace('Á', '4')
                .Replace('À', '4')
                .Replace('Ã', '4')
                .Replace('E', '3')
                .Replace('Ë', '3')
                .Replace('Ê', '3')
                .Replace('É', '3')
                .Replace('È', '3')
                .Replace('Z', '2')
                .Replace('I', '1')
                .Replace('Ï', '1')
                .Replace('Î', '1')
                .Replace('Í', '1')
                .Replace('Ì', '1')
                .Replace('O', '0')
                .Replace('Ö', '0')
                .Replace('Ô', '0')
                .Replace('Ó', '0')
                .Replace('Ò', '0');
        }
        #endregion

        //Themes and whatever is needed for it
        #region Themes

        #region General
        /// <summary>
        /// Set the list of <see cref="AllThemes"/>
        /// </summary>
        private static bool SetList = true;

        /// <summary>
        /// List of all available themes
        /// </summary>
        private static readonly List<Themes> AllThemes = new List<Themes>();

        /// <summary>
        /// When User selects a theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //We need to set the list of themes, before changing one - this "theme" isn't visible
            //Adds one to amountPressed
            if (SetList)
                SearchForTheme("Isn't visible");

            //If pressed is higher than the amount of items in AllThemes, set Dark Theme
            else if (ThemesBox.SelectedIndex == 0)
            {
                SearchForTheme("Dark");
            }   //Dark

            //If pressed = 2, set Darker Theme
            if (ThemesBox.SelectedIndex == 1)
                SearchForTheme("Darker");

            //If pressed = 3, set Light Theme
            else if (ThemesBox.SelectedIndex == 2)
                SearchForTheme("Light");

            //If pressed = 4, set Rainbow Theme
            else if (ThemesBox.SelectedIndex == 3)
                SearchForTheme("Rainbow");

            //If pressed = 5, set Rave Theme
            else if (ThemesBox.SelectedIndex == 4)
                SearchForTheme("Rave");

            //If pressed = 6, User gets epilepsi
            else if (ThemesBox.SelectedIndex == 5)
                SearchForTheme("Epilepsi");

        }

        /// <summary>
        /// Searches for inserted theme
        /// </summary>
        /// <param name="theme">Name of theme to search for</param>
        private void SearchForTheme(string theme)
        {
            //Create all Themes
            #region All Themes Individually
            //Themes <name> = new Theme(ButtonFore, ButtonBack, ButtonText, BoxFore, BoxBack);
            Themes Dark = new Themes(Color.DarkGray, Color.Black, Color.Lime, Color.Black);
            Themes Darker = new Themes(Color.Red, Color.Black, Color.Red, Color.Black);
            Themes Light = new Themes(Color.Black, Color.White, Color.Black, Color.White);
            Themes Rainbow = new Themes(Color.Orange, Color.Black, Color.Orange, Color.Black);
            Themes Rave = new Themes(Color.Red, Color.Black, Color.Yellow, Color.Purple);
            Themes Epilepsi = new Themes(Color.White, Color.Gray, Color.Pink, Color.Magenta);
            #endregion

            //Set the list of AllThemes
            #region AllThemes List

            //Only run this, if SetList is true - otherwise there's no reason for it!
            if (SetList)
            {
                AllThemes.Add(Dark);
                AllThemes.Add(Darker);
                AllThemes.Add(Light);
                AllThemes.Add(Rainbow);
                AllThemes.Add(Rave);
                AllThemes.Add(Epilepsi);

                //The list has now been set, and therefore no longer needs to be set - so SetList is false, to prevent mess in amountPressed
                SetList = false;
            }
            #endregion

            //If the rainbow themes aren't in use, disable RainbowTimer
            if (ThemesBox.SelectedIndex < 3 || ThemesBox.SelectedIndex > 5)
                RainbowTimer.Enabled = false;
            else
                RainbowTimer.Enabled = true;

            //Set the theme, if it matches the "theme" input
            #region Switch Theme
            if (theme == "Dark")
                SetTheme(Dark);
            else if (theme == "Darker")
                SetTheme(Darker);
            else if (theme == "Light")
                SetTheme(Light);
            else if (theme == "Rainbow")
            //Since rainbow is a complicated theme - it has its own method
            {
                SetRainbowTheme();
                RainbowTimer.Interval = 500;
            }
            else if (theme == "Rave")
            {
                SetRainbowTheme();
                RainbowTimer.Interval = 75;
            }
            else if (theme == "Epilepsi")
            {
                SetRainbowTheme();
                RainbowTimer.Interval = 1;
            }
            #endregion
        }

        /// <summary>
        /// Switches UI to the theme
        /// </summary>
        /// <param name="theme">Name of theme to switch to</param>
        private void SetTheme(Themes theme)
        {
            ThemesBox.ForeColor = theme.DropdownForeground;
            CaseButton.ForeColor = theme.DropdownForeground;
            ThemesBox.BackColor = theme.DropdownBackground;
            CaseButton.BackColor = theme.DropdownBackground;
            AWEncrypter.ForeColor = theme.BoxForeground;
            AWEncrypter.BackColor = theme.BoxBackground;
            AWDecrypter.ForeColor = AWEncrypter.ForeColor;
            AWDecrypter.BackColor = AWEncrypter.BackColor;
        }
        #endregion

        #region Rainbow Theme

        /// <summary>
        /// Set Default "Rainbow Theme"
        /// </summary>
        /// <returns>Varaibles to replace current values of the theme</returns>
        private static Color[] SetDefaultRainbow()
        {
            //Default colors
            #region Color Indexes
            ColorIndexes[0] = 9;
            ColorIndexes[1] = 7;
            ColorIndexes[2] = 0;
            ColorIndexes[3] = 1;
            #endregion

            //Initiate the default colors
            #region Set Colors
            Color ButtonBack = AllFixedColors[8];
            Color ButtonFore = AllFixedColors[6];
            Color AWBack = AllFixedColors[ColorIndexes[2]];
            Color AWFore = AllFixedColors[ColorIndexes[3]];
            #endregion

            //Put into Objects array
            Color[] Objects = { ButtonBack, ButtonFore, AWBack, AWFore };
            return Objects;
        }

        /// <summary>
        /// Index indicates the variable being changed - <see cref="SetDefaultRainbow"/>
        /// </summary>
        private readonly Color[] VariableColors = SetDefaultRainbow(); //4, [0], [1], [2], [3]

        /// <summary>
        /// All Fixed/Set Colors
        /// </summary>
        /// <returns>Fixed Color Array to ++ for chroma feeling</returns>
        private static Color[] FixedColors()
        {
            Color Red = Color.FromArgb(255, 0, 0), Orange = Color.FromArgb(245, 108, 66),
                Yellow = Color.FromArgb(255, 235, 10), Green = Color.FromArgb(30, 255, 0),
                Blue = Color.FromArgb(0, 229, 255), Purple = Color.FromArgb(13, 0, 255),
                Pink = Color.FromArgb(255, 0, 230), White = Color.FromArgb(255, 255, 255),
                Gray = Color.FromArgb(120, 120, 120), Black = Color.FromArgb(0, 0, 0);

            Color[] AllColors = { Red, Orange, Yellow, Green, Blue, Purple, Pink, White, Gray, Black };
            return AllColors;
        }

        /// <summary>
        /// All fixed colors - <see cref="FixedColors"/>
        /// </summary>
        static readonly Color[] AllFixedColors = FixedColors(); //10, [0], [1], [2], [3], [4], [5], [6], [7], [8], [9]

        /// <summary>
        /// Keeps track of what ID of Color the variable is
        /// </summary>
        private static readonly int[] ColorIndexes = new int[9];

        /// <summary>
        /// Sets the default Rainbow theme
        /// </summary>
        private void SetRainbowTheme()
        {
            ThemesBox.BackColor = VariableColors[0];
            CaseButton.BackColor = VariableColors[0];
            ThemesBox.ForeColor = VariableColors[1];
            CaseButton.ForeColor = VariableColors[1];
            AWEncrypter.BackColor = VariableColors[2];
            AWEncrypter.ForeColor = VariableColors[3];
            AWDecrypter.BackColor = VariableColors[2];
            AWDecrypter.ForeColor = VariableColors[3];
        }

        /// <summary>
        /// Timer that switches the Rainbow Theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RainbowTimer_Tick(object sender, EventArgs e)
        {
            /*ButtonBack    [0]
             * ButtonFore   [1]
             * AWBack       [2]
             * AWFore       [3]*/

            //AWFore x2
            ChangeColor(3, 1);
            //AWBack x1;
            ChangeColor(2, 1);
            //ButtonFore x1
            ChangeColor(1, 1);
            //ButtonBack x1;
            ChangeColor(0, 1);
        }

        private void ChangeColor(int Index, int Condition)
        {
            //Run loop as long as inserted Condition allows
            for (int x = 0; x <= Condition; x++)
            {
                //Up the color index and set the theme, else reset the color index
                try
                {
                    ColorIndexes[Index] += x;
                    VariableColors[Index] = AllFixedColors[ColorIndexes[Index]];
                    //Set the theme to the new color
                    InitiateTheme();
                }
                catch
                {
                    ColorIndexes[Index] = 0;
                    VariableColors[Index] = AllFixedColors[ColorIndexes[Index]];
                    //Set the theme to the new color
                    InitiateTheme();
                }
            }
        }

        /// <summary>
        /// Set current values with new values
        /// </summary>
        private void InitiateTheme()
        {
            ThemesBox.BackColor = VariableColors[0];
            CaseButton.BackColor = VariableColors[0];
            ThemesBox.ForeColor = VariableColors[1];
            CaseButton.ForeColor = VariableColors[1];
            AWEncrypter.BackColor = VariableColors[2];
            AWDecrypter.BackColor = VariableColors[2];
            AWEncrypter.ForeColor = VariableColors[3];
            AWDecrypter.ForeColor = VariableColors[3];
        }

        #endregion

        #endregion

        //Small and big sizes IT ALL MATTERS
        #region Sizes
        /// <summary>
        /// What happens when the application's size is changed?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AWTranslator_SizeChanged(object sender, EventArgs e)
        {
            //Find new Splitter position to split the 2 windows equally
            AWEncryptSplitter.Width = ((ClientSize.Width / 100) * 50);

            //Set the new size of each window, to match the Splitter Width & Window Height
            SetSize(AWEncryptSplitter.Width, ClientSize.Height);
        }

        /// <summary>
        /// Set the Width & Height of AWEncrypter, AWDecryper, AWEncrtyperSplitter & AWDecrypter.Location
        /// </summary>
        /// <param name="Width">Width to change</param>
        /// <param name="Height">Height to change</param>
        private void SetSize(int Width, int Height)
        {
            #region Width
            //Set the width to be the same for each window
            AWDecrypter.Width = Width;
            AWEncrypter.Width = Width;

            //Replace the Decrypter location with a new one
            AWDecrypter.Location = new Point(Width, 0);
            #endregion

            #region Height
            //Set the heigh to be equal of each window
            AWDecrypter.Height = Height;
            AWEncrypter.Height = Height;
            #endregion
        }

        /// <summary>
        /// Debug size; tells Splitter, ClientSize & normal Height, tells ClientSize & normal Width
        /// </summary>
        /// <param name="needSpace">True: 10 rows of WriteLine. False: ..."Which is now set to:"</param>
        private void TellUser(bool needSpace)
        {
            //How much space is needed in the console?
            #region Need Space
            if (needSpace)
                for (int x = 0; x < 10; x++)
                    Console.WriteLine();
            else
            {
                Console.WriteLine();
                Console.WriteLine("Which is now set to:");
            }
            #endregion

            //Write the variable's properties in console for debug
            Console.WriteLine("Splitter Width: " + AWEncryptSplitter.Width);
            Console.WriteLine("ClientSize Height: " + ClientSize.Height);
            Console.WriteLine("ClientSize Width: " + ClientSize.Width);
            Console.WriteLine();
            Console.WriteLine("\"Width\": " + Width);
            Console.WriteLine("\"Height\": " + Height);
        }
        #endregion

        //Upper and Lowercase matters too!
        #region Casing
        bool Casing = false;
        private void CaseButton_Click(object sender, EventArgs e)
        {
            if (Casing)
            {
                CaseButton.Text = "70 UPP3R";
                Casing = false;
                AWEncrypter.Text = AWEncrypter.Text.ToLower();
            }
            else
            {
                CaseButton.Text = "70 l0w3r";
                Casing = true;
                AWEncrypter.Text = AWEncrypter.Text.ToUpper();
            }
        }
        #endregion
    }
}