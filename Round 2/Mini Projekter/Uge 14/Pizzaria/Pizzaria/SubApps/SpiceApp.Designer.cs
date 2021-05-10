namespace Pizzaria.SubApps
{
    partial class SpiceApp
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
            this.CheckKarry = new System.Windows.Forms.CheckBox();
            this.CheckKanel = new System.Windows.Forms.CheckBox();
            this.CheckSalt = new System.Windows.Forms.CheckBox();
            this.CheckPepper = new System.Windows.Forms.CheckBox();
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckKarry
            // 
            this.CheckKarry.AutoSize = true;
            this.CheckKarry.Location = new System.Drawing.Point(12, 12);
            this.CheckKarry.Name = "CheckKarry";
            this.CheckKarry.Size = new System.Drawing.Size(50, 17);
            this.CheckKarry.TabIndex = 11;
            this.CheckKarry.Text = "Karry";
            this.CheckKarry.UseVisualStyleBackColor = true;
            this.CheckKarry.CheckedChanged += new System.EventHandler(this.CheckKarry_CheckedChanged);
            // 
            // CheckKanel
            // 
            this.CheckKanel.AutoSize = true;
            this.CheckKanel.Location = new System.Drawing.Point(12, 35);
            this.CheckKanel.Name = "CheckKanel";
            this.CheckKanel.Size = new System.Drawing.Size(53, 17);
            this.CheckKanel.TabIndex = 12;
            this.CheckKanel.Text = "Kanel";
            this.CheckKanel.UseVisualStyleBackColor = true;
            this.CheckKanel.CheckedChanged += new System.EventHandler(this.CheckKanel_CheckedChanged);
            // 
            // CheckSalt
            // 
            this.CheckSalt.AutoSize = true;
            this.CheckSalt.Location = new System.Drawing.Point(12, 58);
            this.CheckSalt.Name = "CheckSalt";
            this.CheckSalt.Size = new System.Drawing.Size(44, 17);
            this.CheckSalt.TabIndex = 13;
            this.CheckSalt.Text = "Salt";
            this.CheckSalt.UseVisualStyleBackColor = true;
            this.CheckSalt.CheckedChanged += new System.EventHandler(this.CheckSalt_CheckedChanged);
            // 
            // CheckPepper
            // 
            this.CheckPepper.AutoSize = true;
            this.CheckPepper.Location = new System.Drawing.Point(12, 81);
            this.CheckPepper.Name = "CheckPepper";
            this.CheckPepper.Size = new System.Drawing.Size(60, 17);
            this.CheckPepper.TabIndex = 14;
            this.CheckPepper.Text = "Pepper";
            this.CheckPepper.UseVisualStyleBackColor = true;
            this.CheckPepper.CheckedChanged += new System.EventHandler(this.CheckPepper_CheckedChanged);
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Location = new System.Drawing.Point(7, 120);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(170, 28);
            this.ButtonSelect.TabIndex = 15;
            this.ButtonSelect.Text = "Vælg";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // SpiceApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 158);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.CheckPepper);
            this.Controls.Add(this.CheckSalt);
            this.Controls.Add(this.CheckKanel);
            this.Controls.Add(this.CheckKarry);
            this.Name = "SpiceApp";
            this.Text = "SpiceApp";
            this.ResumeLayout(false);
            this.PerformLayout();
            LoadCheckBoxes();
        }

        #endregion

        private System.Windows.Forms.CheckBox CheckKarry;
        private System.Windows.Forms.CheckBox CheckKanel;
        private System.Windows.Forms.CheckBox CheckSalt;
        private System.Windows.Forms.CheckBox CheckPepper;
        private System.Windows.Forms.Button ButtonSelect;
    }
}