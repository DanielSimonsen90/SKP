namespace Pizzaria.SubApps
{
    partial class MeatApp
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
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.CheckPepperoni = new System.Windows.Forms.CheckBox();
            this.CheckSkinke = new System.Windows.Forms.CheckBox();
            this.CheckBacon = new System.Windows.Forms.CheckBox();
            this.CheckKylling = new System.Windows.Forms.CheckBox();
            this.CheckOkeskød = new System.Windows.Forms.CheckBox();
            this.CheckCotailPølser = new System.Windows.Forms.CheckBox();
            this.CheckKebab = new System.Windows.Forms.CheckBox();
            this.CheckTun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Location = new System.Drawing.Point(7, 204);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(170, 28);
            this.ButtonSelect.TabIndex = 8;
            this.ButtonSelect.Text = "Vælg";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // CheckPepperoni
            // 
            this.CheckPepperoni.AutoSize = true;
            this.CheckPepperoni.Location = new System.Drawing.Point(7, 8);
            this.CheckPepperoni.Name = "CheckPepperoni";
            this.CheckPepperoni.Size = new System.Drawing.Size(74, 17);
            this.CheckPepperoni.TabIndex = 9;
            this.CheckPepperoni.Text = "Pepperoni";
            this.CheckPepperoni.UseVisualStyleBackColor = true;
            this.CheckPepperoni.CheckedChanged += new System.EventHandler(this.CheckPepperoni_CheckedChanged);
            // 
            // CheckSkinke
            // 
            this.CheckSkinke.AutoSize = true;
            this.CheckSkinke.Location = new System.Drawing.Point(7, 30);
            this.CheckSkinke.Name = "CheckSkinke";
            this.CheckSkinke.Size = new System.Drawing.Size(59, 17);
            this.CheckSkinke.TabIndex = 10;
            this.CheckSkinke.Text = "Skinke";
            this.CheckSkinke.UseVisualStyleBackColor = true;
            this.CheckSkinke.CheckedChanged += new System.EventHandler(this.CheckSkinke_CheckedChanged);
            // 
            // CheckBacon
            // 
            this.CheckBacon.AutoSize = true;
            this.CheckBacon.Location = new System.Drawing.Point(7, 53);
            this.CheckBacon.Name = "CheckBacon";
            this.CheckBacon.Size = new System.Drawing.Size(57, 17);
            this.CheckBacon.TabIndex = 11;
            this.CheckBacon.Text = "Bacon";
            this.CheckBacon.UseVisualStyleBackColor = true;
            this.CheckBacon.CheckedChanged += new System.EventHandler(this.CheckBacon_CheckedChanged);
            // 
            // CheckKylling
            // 
            this.CheckKylling.AutoSize = true;
            this.CheckKylling.Location = new System.Drawing.Point(7, 76);
            this.CheckKylling.Name = "CheckKylling";
            this.CheckKylling.Size = new System.Drawing.Size(56, 17);
            this.CheckKylling.TabIndex = 12;
            this.CheckKylling.Text = "Kylling";
            this.CheckKylling.UseVisualStyleBackColor = true;
            this.CheckKylling.CheckedChanged += new System.EventHandler(this.CheckKylling_CheckedChanged);
            // 
            // CheckOkeskød
            // 
            this.CheckOkeskød.AutoSize = true;
            this.CheckOkeskød.Location = new System.Drawing.Point(7, 100);
            this.CheckOkeskød.Name = "CheckOkeskød";
            this.CheckOkeskød.Size = new System.Drawing.Size(69, 17);
            this.CheckOkeskød.TabIndex = 13;
            this.CheckOkeskød.Text = "Oksekød";
            this.CheckOkeskød.UseVisualStyleBackColor = true;
            this.CheckOkeskød.CheckedChanged += new System.EventHandler(this.CheckOksekød_CheckedChanged);
            // 
            // CheckCotailPølser
            // 
            this.CheckCotailPølser.AutoSize = true;
            this.CheckCotailPølser.Location = new System.Drawing.Point(7, 123);
            this.CheckCotailPølser.Name = "CheckCotailPølser";
            this.CheckCotailPølser.Size = new System.Drawing.Size(84, 17);
            this.CheckCotailPølser.TabIndex = 14;
            this.CheckCotailPølser.Text = "Cotail Pølser";
            this.CheckCotailPølser.UseVisualStyleBackColor = true;
            this.CheckCotailPølser.CheckedChanged += new System.EventHandler(this.CheckCotailPølser_CheckedChanged);
            // 
            // CheckKebab
            // 
            this.CheckKebab.AutoSize = true;
            this.CheckKebab.Location = new System.Drawing.Point(7, 146);
            this.CheckKebab.Name = "CheckKebab";
            this.CheckKebab.Size = new System.Drawing.Size(57, 17);
            this.CheckKebab.TabIndex = 15;
            this.CheckKebab.Text = "Kebab";
            this.CheckKebab.UseVisualStyleBackColor = true;
            this.CheckKebab.CheckedChanged += new System.EventHandler(this.CheckKebab_CheckedChanged);
            // 
            // CheckTun
            // 
            this.CheckTun.AutoSize = true;
            this.CheckTun.Location = new System.Drawing.Point(7, 169);
            this.CheckTun.Name = "CheckTun";
            this.CheckTun.Size = new System.Drawing.Size(45, 17);
            this.CheckTun.TabIndex = 16;
            this.CheckTun.Text = "Tun";
            this.CheckTun.UseVisualStyleBackColor = true;
            this.CheckTun.CheckedChanged += new System.EventHandler(this.CheckTun_CheckedChanged);
            // 
            // MeatApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 240);
            this.Controls.Add(this.CheckTun);
            this.Controls.Add(this.CheckKebab);
            this.Controls.Add(this.CheckCotailPølser);
            this.Controls.Add(this.CheckOkeskød);
            this.Controls.Add(this.CheckKylling);
            this.Controls.Add(this.CheckBacon);
            this.Controls.Add(this.CheckSkinke);
            this.Controls.Add(this.CheckPepperoni);
            this.Controls.Add(this.ButtonSelect);
            this.Name = "MeatApp";
            this.Text = "MeatApp";
            this.ResumeLayout(false);
            this.PerformLayout();
            LoadCheckBoxes();
        }

        #endregion
        private System.Windows.Forms.Button ButtonSelect;
        private System.Windows.Forms.CheckBox CheckPepperoni;
        private System.Windows.Forms.CheckBox CheckSkinke;
        private System.Windows.Forms.CheckBox CheckBacon;
        private System.Windows.Forms.CheckBox CheckKylling;
        private System.Windows.Forms.CheckBox CheckOkeskød;
        private System.Windows.Forms.CheckBox CheckCotailPølser;
        private System.Windows.Forms.CheckBox CheckKebab;
        private System.Windows.Forms.CheckBox CheckTun;
    }
}