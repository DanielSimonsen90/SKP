namespace Team_Generator
{
    partial class Menu
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
            this.ChooseGameLabel = new System.Windows.Forms.Label();
            this.ChoicePKMNButton = new System.Windows.Forms.Button();
            this.ChoiceOWButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChooseGameLabel
            // 
            this.ChooseGameLabel.AutoSize = true;
            this.ChooseGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseGameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ChooseGameLabel.Location = new System.Drawing.Point(268, 56);
            this.ChooseGameLabel.Name = "ChooseGameLabel";
            this.ChooseGameLabel.Size = new System.Drawing.Size(247, 39);
            this.ChooseGameLabel.TabIndex = 0;
            this.ChooseGameLabel.Text = "Choose Game";
            // 
            // ChoicePKMNButton
            // 
            this.ChoicePKMNButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoicePKMNButton.ForeColor = System.Drawing.Color.Blue;
            this.ChoicePKMNButton.Image = global::Team_Generator.Properties.Resources.Wallpaper_but_its_ugly1;
            this.ChoicePKMNButton.Location = new System.Drawing.Point(451, 139);
            this.ChoicePKMNButton.Name = "ChoicePKMNButton";
            this.ChoicePKMNButton.Size = new System.Drawing.Size(271, 241);
            this.ChoicePKMNButton.TabIndex = 2;
            this.ChoicePKMNButton.Text = "Pokémon";
            this.ChoicePKMNButton.UseVisualStyleBackColor = true;
            this.ChoicePKMNButton.Click += new System.EventHandler(this.ChoicePKMNButton_Click);
            // 
            // ChoiceOWButton
            // 
            this.ChoiceOWButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceOWButton.ForeColor = System.Drawing.Color.Yellow;
            this.ChoiceOWButton.Image = global::Team_Generator.Properties.Resources.Wallpaper_but_its_ugly;
            this.ChoiceOWButton.Location = new System.Drawing.Point(69, 139);
            this.ChoiceOWButton.Name = "ChoiceOWButton";
            this.ChoiceOWButton.Size = new System.Drawing.Size(271, 241);
            this.ChoiceOWButton.TabIndex = 1;
            this.ChoiceOWButton.Text = "Overwatch";
            this.ChoiceOWButton.UseVisualStyleBackColor = true;
            this.ChoiceOWButton.Click += new System.EventHandler(this.ChoiceOWButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChoicePKMNButton);
            this.Controls.Add(this.ChoiceOWButton);
            this.Controls.Add(this.ChooseGameLabel);
            this.Name = "Menu";
            this.Text = "Danho\'s Team Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChooseGameLabel;
        private System.Windows.Forms.Button ChoiceOWButton;
        private System.Windows.Forms.Button ChoicePKMNButton;
    }
}

