namespace Pizzaria
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuDisplayLabel = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            this.BasketDisplayLabel = new System.Windows.Forms.Label();
            this.DropdownMenu = new System.Windows.Forms.ComboBox();
            this.DropdownPizzaSizes = new System.Windows.Forms.ComboBox();
            this.BasketTotal = new System.Windows.Forms.Label();
            this.SizeWarningLabel = new System.Windows.Forms.Label();
            this.MenuWarningLabel = new System.Windows.Forms.Label();
            this.DropdownDoughs = new System.Windows.Forms.ComboBox();
            this.DropdownSauce = new System.Windows.Forms.ComboBox();
            this.DropdownCheese = new System.Windows.Forms.ComboBox();
            this.DropdownMeat = new System.Windows.Forms.ComboBox();
            this.DropdownSalad = new System.Windows.Forms.ComboBox();
            this.BasketListBox = new System.Windows.Forms.ListBox();
            this.DropdownSpice = new System.Windows.Forms.ComboBox();
            this.ButtonMeat = new System.Windows.Forms.Button();
            this.ButtonSalad = new System.Windows.Forms.Button();
            this.ButtonSpice = new System.Windows.Forms.Button();
            this.ShowMeatButton = new System.Windows.Forms.Button();
            this.ShowSaladButton = new System.Windows.Forms.Button();
            this.ShowSpiceButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.DropdownDrinks = new System.Windows.Forms.ComboBox();
            this.DropdownDrinkSizes = new System.Windows.Forms.ComboBox();
            this.BuyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MenuDisplayLabel
            // 
            this.MenuDisplayLabel.AutoSize = true;
            this.MenuDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuDisplayLabel.Location = new System.Drawing.Point(12, 51);
            this.MenuDisplayLabel.Name = "MenuDisplayLabel";
            this.MenuDisplayLabel.Size = new System.Drawing.Size(63, 24);
            this.MenuDisplayLabel.TabIndex = 1;
            this.MenuDisplayLabel.Text = "Menu";
            // 
            // SelectButton
            // 
            this.SelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectButton.Location = new System.Drawing.Point(288, 391);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(136, 47);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "VÆLG";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // BasketDisplayLabel
            // 
            this.BasketDisplayLabel.AutoSize = true;
            this.BasketDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasketDisplayLabel.Location = new System.Drawing.Point(736, 51);
            this.BasketDisplayLabel.Name = "BasketDisplayLabel";
            this.BasketDisplayLabel.Size = new System.Drawing.Size(52, 24);
            this.BasketDisplayLabel.TabIndex = 3;
            this.BasketDisplayLabel.Text = "Kurv";
            // 
            // DropdownMenu
            // 
            this.DropdownMenu.FormattingEnabled = true;
            this.DropdownMenu.Location = new System.Drawing.Point(12, 90);
            this.DropdownMenu.Name = "DropdownMenu";
            this.DropdownMenu.Size = new System.Drawing.Size(264, 21);
            this.DropdownMenu.TabIndex = 5;
            this.DropdownMenu.Text = "Pizza";
            this.DropdownMenu.SelectedIndexChanged += new System.EventHandler(this.DropdownMenu_SelectedIndexChanged);
            // 
            // DropdownPizzaSizes
            // 
            this.DropdownPizzaSizes.FormattingEnabled = true;
            this.DropdownPizzaSizes.Location = new System.Drawing.Point(12, 117);
            this.DropdownPizzaSizes.Name = "DropdownPizzaSizes";
            this.DropdownPizzaSizes.Size = new System.Drawing.Size(264, 21);
            this.DropdownPizzaSizes.TabIndex = 6;
            this.DropdownPizzaSizes.Text = "Størrelse";
            this.DropdownPizzaSizes.TextChanged += new System.EventHandler(this.DropdownSizes_TextChanged);
            // 
            // BasketTotal
            // 
            this.BasketTotal.AutoSize = true;
            this.BasketTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasketTotal.Location = new System.Drawing.Point(637, 409);
            this.BasketTotal.Name = "BasketTotal";
            this.BasketTotal.Size = new System.Drawing.Size(69, 20);
            this.BasketTotal.TabIndex = 7;
            this.BasketTotal.Text = "I alt: 0 kr";
            // 
            // SizeWarningLabel
            // 
            this.SizeWarningLabel.AutoSize = true;
            this.SizeWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.SizeWarningLabel.Location = new System.Drawing.Point(13, 74);
            this.SizeWarningLabel.Name = "SizeWarningLabel";
            this.SizeWarningLabel.Size = new System.Drawing.Size(139, 13);
            this.SizeWarningLabel.TabIndex = 8;
            this.SizeWarningLabel.Tag = "Warning";
            this.SizeWarningLabel.Text = "Indsæt venligst en størrelse!";
            this.SizeWarningLabel.Visible = false;
            // 
            // MenuWarningLabel
            // 
            this.MenuWarningLabel.AutoSize = true;
            this.MenuWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.MenuWarningLabel.Location = new System.Drawing.Point(9, 74);
            this.MenuWarningLabel.Name = "MenuWarningLabel";
            this.MenuWarningLabel.Size = new System.Drawing.Size(172, 13);
            this.MenuWarningLabel.TabIndex = 9;
            this.MenuWarningLabel.Tag = "Warning";
            this.MenuWarningLabel.Text = "Indsæt venligst en pizza eller drink!";
            this.MenuWarningLabel.Visible = false;
            // 
            // DropdownDoughs
            // 
            this.DropdownDoughs.FormattingEnabled = true;
            this.DropdownDoughs.Location = new System.Drawing.Point(12, 144);
            this.DropdownDoughs.Name = "DropdownDoughs";
            this.DropdownDoughs.Size = new System.Drawing.Size(264, 21);
            this.DropdownDoughs.TabIndex = 10;
            this.DropdownDoughs.Text = "Dej";
            this.DropdownDoughs.TextChanged += new System.EventHandler(this.DropdownDoughs_TextChanged);
            // 
            // DropdownSauce
            // 
            this.DropdownSauce.FormattingEnabled = true;
            this.DropdownSauce.Location = new System.Drawing.Point(12, 171);
            this.DropdownSauce.Name = "DropdownSauce";
            this.DropdownSauce.Size = new System.Drawing.Size(264, 21);
            this.DropdownSauce.TabIndex = 11;
            this.DropdownSauce.Text = "Sovs";
            this.DropdownSauce.TextChanged += new System.EventHandler(this.DropdownSauce_TextChanged);
            // 
            // DropdownCheese
            // 
            this.DropdownCheese.FormattingEnabled = true;
            this.DropdownCheese.Location = new System.Drawing.Point(12, 198);
            this.DropdownCheese.Name = "DropdownCheese";
            this.DropdownCheese.Size = new System.Drawing.Size(264, 21);
            this.DropdownCheese.TabIndex = 12;
            this.DropdownCheese.Text = "Ost";
            this.DropdownCheese.TextChanged += new System.EventHandler(this.DropdownCheese_TextChanged);
            // 
            // DropdownMeat
            // 
            this.DropdownMeat.FormattingEnabled = true;
            this.DropdownMeat.Location = new System.Drawing.Point(12, 225);
            this.DropdownMeat.Name = "DropdownMeat";
            this.DropdownMeat.Size = new System.Drawing.Size(264, 21);
            this.DropdownMeat.TabIndex = 13;
            this.DropdownMeat.Text = "Kød";
            this.DropdownMeat.TextChanged += new System.EventHandler(this.DropdownMeat_TextChanged);
            // 
            // DropdownSalad
            // 
            this.DropdownSalad.FormattingEnabled = true;
            this.DropdownSalad.Location = new System.Drawing.Point(12, 252);
            this.DropdownSalad.Name = "DropdownSalad";
            this.DropdownSalad.Size = new System.Drawing.Size(264, 21);
            this.DropdownSalad.TabIndex = 14;
            this.DropdownSalad.Text = "Salat";
            this.DropdownSalad.TextChanged += new System.EventHandler(this.DropdownSalad_TextChanged);
            // 
            // BasketListBox
            // 
            this.BasketListBox.FormattingEnabled = true;
            this.BasketListBox.Location = new System.Drawing.Point(599, 90);
            this.BasketListBox.Name = "BasketListBox";
            this.BasketListBox.Size = new System.Drawing.Size(189, 277);
            this.BasketListBox.TabIndex = 15;
            this.BasketListBox.SelectedIndexChanged += new System.EventHandler(this.BasketListBox_SelectedIndexChanged);
            // 
            // DropdownSpice
            // 
            this.DropdownSpice.FormattingEnabled = true;
            this.DropdownSpice.Location = new System.Drawing.Point(12, 279);
            this.DropdownSpice.Name = "DropdownSpice";
            this.DropdownSpice.Size = new System.Drawing.Size(264, 21);
            this.DropdownSpice.TabIndex = 16;
            this.DropdownSpice.Text = "Krydderi";
            this.DropdownSpice.TextChanged += new System.EventHandler(this.DropdownSpices_TextChanged);
            // 
            // ButtonMeat
            // 
            this.ButtonMeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMeat.Location = new System.Drawing.Point(16, 306);
            this.ButtonMeat.Name = "ButtonMeat";
            this.ButtonMeat.Size = new System.Drawing.Size(81, 34);
            this.ButtonMeat.TabIndex = 17;
            this.ButtonMeat.Text = "Kød";
            this.ButtonMeat.UseVisualStyleBackColor = true;
            this.ButtonMeat.Click += new System.EventHandler(this.ButtonMeat_Click);
            // 
            // ButtonSalad
            // 
            this.ButtonSalad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSalad.Location = new System.Drawing.Point(103, 306);
            this.ButtonSalad.Name = "ButtonSalad";
            this.ButtonSalad.Size = new System.Drawing.Size(81, 34);
            this.ButtonSalad.TabIndex = 18;
            this.ButtonSalad.Text = "Salat";
            this.ButtonSalad.UseVisualStyleBackColor = true;
            this.ButtonSalad.Click += new System.EventHandler(this.ButtonSalad_Click);
            // 
            // ButtonSpice
            // 
            this.ButtonSpice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSpice.Location = new System.Drawing.Point(190, 306);
            this.ButtonSpice.Name = "ButtonSpice";
            this.ButtonSpice.Size = new System.Drawing.Size(86, 34);
            this.ButtonSpice.TabIndex = 19;
            this.ButtonSpice.Text = "Krydderi";
            this.ButtonSpice.UseVisualStyleBackColor = true;
            this.ButtonSpice.Click += new System.EventHandler(this.ButtonSpice_Click);
            // 
            // ShowMeatButton
            // 
            this.ShowMeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowMeatButton.Location = new System.Drawing.Point(16, 346);
            this.ShowMeatButton.Name = "ShowMeatButton";
            this.ShowMeatButton.Size = new System.Drawing.Size(81, 34);
            this.ShowMeatButton.TabIndex = 20;
            this.ShowMeatButton.Text = "Gem Kød";
            this.ShowMeatButton.UseVisualStyleBackColor = true;
            this.ShowMeatButton.Click += new System.EventHandler(this.ShowMeatButton_Click);
            // 
            // ShowSaladButton
            // 
            this.ShowSaladButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowSaladButton.Location = new System.Drawing.Point(103, 346);
            this.ShowSaladButton.Name = "ShowSaladButton";
            this.ShowSaladButton.Size = new System.Drawing.Size(81, 34);
            this.ShowSaladButton.TabIndex = 21;
            this.ShowSaladButton.Text = "Gem Salat";
            this.ShowSaladButton.UseVisualStyleBackColor = true;
            this.ShowSaladButton.Click += new System.EventHandler(this.ShowSaladButton_Click);
            // 
            // ShowSpiceButton
            // 
            this.ShowSpiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowSpiceButton.Location = new System.Drawing.Point(190, 346);
            this.ShowSpiceButton.Name = "ShowSpiceButton";
            this.ShowSpiceButton.Size = new System.Drawing.Size(86, 34);
            this.ShowSpiceButton.TabIndex = 22;
            this.ShowSpiceButton.Text = "Gem Krydderi";
            this.ShowSpiceButton.UseVisualStyleBackColor = true;
            this.ShowSpiceButton.Click += new System.EventHandler(this.ShowSpiceButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(439, 391);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(136, 47);
            this.RemoveButton.TabIndex = 23;
            this.RemoveButton.Text = "FJERN";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // DropdownDrinks
            // 
            this.DropdownDrinks.FormattingEnabled = true;
            this.DropdownDrinks.Location = new System.Drawing.Point(299, 90);
            this.DropdownDrinks.Name = "DropdownDrinks";
            this.DropdownDrinks.Size = new System.Drawing.Size(264, 21);
            this.DropdownDrinks.TabIndex = 24;
            this.DropdownDrinks.Text = "Drink";
            this.DropdownDrinks.SelectedIndexChanged += new System.EventHandler(this.DropdownDrinks_SelectedIndexChanged);
            // 
            // DropdownDrinkSizes
            // 
            this.DropdownDrinkSizes.FormattingEnabled = true;
            this.DropdownDrinkSizes.Location = new System.Drawing.Point(299, 117);
            this.DropdownDrinkSizes.Name = "DropdownDrinkSizes";
            this.DropdownDrinkSizes.Size = new System.Drawing.Size(264, 21);
            this.DropdownDrinkSizes.TabIndex = 25;
            this.DropdownDrinkSizes.Text = "Størrelse";
            this.DropdownDrinkSizes.SelectedIndexChanged += new System.EventHandler(this.DropdownDrinkSizes_SelectedIndexChanged);
            // 
            // BuyButton
            // 
            this.BuyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuyButton.Location = new System.Drawing.Point(641, 373);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(118, 33);
            this.BuyButton.TabIndex = 26;
            this.BuyButton.Text = "Køb";
            this.BuyButton.UseVisualStyleBackColor = true;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.DropdownDrinkSizes);
            this.Controls.Add(this.DropdownDrinks);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ShowSpiceButton);
            this.Controls.Add(this.ShowSaladButton);
            this.Controls.Add(this.ShowMeatButton);
            this.Controls.Add(this.ButtonSpice);
            this.Controls.Add(this.ButtonSalad);
            this.Controls.Add(this.ButtonMeat);
            this.Controls.Add(this.DropdownSpice);
            this.Controls.Add(this.BasketListBox);
            this.Controls.Add(this.DropdownSalad);
            this.Controls.Add(this.DropdownMeat);
            this.Controls.Add(this.DropdownCheese);
            this.Controls.Add(this.DropdownSauce);
            this.Controls.Add(this.DropdownDoughs);
            this.Controls.Add(this.MenuWarningLabel);
            this.Controls.Add(this.SizeWarningLabel);
            this.Controls.Add(this.BasketTotal);
            this.Controls.Add(this.DropdownPizzaSizes);
            this.Controls.Add(this.DropdownMenu);
            this.Controls.Add(this.BasketDisplayLabel);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.MenuDisplayLabel);
            this.Name = "App";
            this.Text = "Simonsen Techs Pizzaria..?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label MenuDisplayLabel;
        private System.Windows.Forms.Label BasketDisplayLabel;
        private System.Windows.Forms.Label BasketTotal;
        internal System.Windows.Forms.ListBox BasketListBox;

        internal System.Windows.Forms.Label SizeWarningLabel;
        internal System.Windows.Forms.Label MenuWarningLabel;

        internal System.Windows.Forms.ComboBox DropdownDoughs;
        internal System.Windows.Forms.ComboBox DropdownSauce;
        internal System.Windows.Forms.ComboBox DropdownCheese;
        internal System.Windows.Forms.ComboBox DropdownMeat;
        internal System.Windows.Forms.ComboBox DropdownSalad;
        internal System.Windows.Forms.ComboBox DropdownSpice;

        private System.Windows.Forms.Button ButtonMeat;
        private System.Windows.Forms.Button ButtonSalad;
        private System.Windows.Forms.Button ButtonSpice;
        private System.Windows.Forms.Button ShowMeatButton;
        private System.Windows.Forms.Button ShowSaladButton;
        private System.Windows.Forms.Button ShowSpiceButton;

        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button RemoveButton;

        internal System.Windows.Forms.ComboBox DropdownMenu;
        internal System.Windows.Forms.ComboBox DropdownPizzaSizes;
        internal System.Windows.Forms.ComboBox DropdownDrinks;
        internal System.Windows.Forms.ComboBox DropdownDrinkSizes;
        private System.Windows.Forms.Button BuyButton;
    }
}

