namespace Pizzaria.SubApps
{
    partial class SaladApp
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
            this.CheckSalat = new System.Windows.Forms.CheckBox();
            this.CheckTomat = new System.Windows.Forms.CheckBox();
            this.CheckAgurk = new System.Windows.Forms.CheckBox();
            this.CheckPepperfrugt = new System.Windows.Forms.CheckBox();
            this.CheckAnanas = new System.Windows.Forms.CheckBox();
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckSalat
            // 
            this.CheckSalat.AutoSize = true;
            this.CheckSalat.Location = new System.Drawing.Point(12, 12);
            this.CheckSalat.Name = "CheckSalat";
            this.CheckSalat.Size = new System.Drawing.Size(50, 17);
            this.CheckSalat.TabIndex = 10;
            this.CheckSalat.Text = "Salat";
            this.CheckSalat.UseVisualStyleBackColor = true;
            this.CheckSalat.CheckedChanged += new System.EventHandler(this.CheckSalat_CheckedChanged);
            // 
            // CheckTomat
            // 
            this.CheckTomat.AutoSize = true;
            this.CheckTomat.Location = new System.Drawing.Point(12, 35);
            this.CheckTomat.Name = "CheckTomat";
            this.CheckTomat.Size = new System.Drawing.Size(56, 17);
            this.CheckTomat.TabIndex = 11;
            this.CheckTomat.Text = "Tomat";
            this.CheckTomat.UseVisualStyleBackColor = true;
            this.CheckTomat.CheckedChanged += new System.EventHandler(this.CheckTomat_CheckedChanged);
            // 
            // CheckAgurk
            // 
            this.CheckAgurk.AutoSize = true;
            this.CheckAgurk.Location = new System.Drawing.Point(12, 58);
            this.CheckAgurk.Name = "CheckAgurk";
            this.CheckAgurk.Size = new System.Drawing.Size(54, 17);
            this.CheckAgurk.TabIndex = 12;
            this.CheckAgurk.Text = "Agurk";
            this.CheckAgurk.UseVisualStyleBackColor = true;
            this.CheckAgurk.CheckedChanged += new System.EventHandler(this.CheckAgurk_CheckedChanged);
            // 
            // CheckPepperfrugt
            // 
            this.CheckPepperfrugt.AutoSize = true;
            this.CheckPepperfrugt.Location = new System.Drawing.Point(12, 81);
            this.CheckPepperfrugt.Name = "CheckPepperfrugt";
            this.CheckPepperfrugt.Size = new System.Drawing.Size(81, 17);
            this.CheckPepperfrugt.TabIndex = 13;
            this.CheckPepperfrugt.Text = "Pepperfrugt";
            this.CheckPepperfrugt.UseVisualStyleBackColor = true;
            this.CheckPepperfrugt.CheckedChanged += new System.EventHandler(this.CheckPepperfrugt_CheckedChanged);
            // 
            // CheckAnanas
            // 
            this.CheckAnanas.AutoSize = true;
            this.CheckAnanas.Location = new System.Drawing.Point(12, 104);
            this.CheckAnanas.Name = "CheckAnanas";
            this.CheckAnanas.Size = new System.Drawing.Size(62, 17);
            this.CheckAnanas.TabIndex = 14;
            this.CheckAnanas.Text = "Ananas";
            this.CheckAnanas.UseVisualStyleBackColor = true;
            this.CheckAnanas.CheckedChanged += new System.EventHandler(this.CheckAnanas_CheckedChanged);
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Location = new System.Drawing.Point(12, 147);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(170, 28);
            this.ButtonSelect.TabIndex = 15;
            this.ButtonSelect.Text = "Vælg";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // SaladApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 187);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.CheckAnanas);
            this.Controls.Add(this.CheckPepperfrugt);
            this.Controls.Add(this.CheckAgurk);
            this.Controls.Add(this.CheckTomat);
            this.Controls.Add(this.CheckSalat);
            this.Name = "SaladApp";
            this.Text = "SaladApp";
            this.ResumeLayout(false);
            this.PerformLayout();
            LoadCheckBoxes();
        }

        #endregion

        private System.Windows.Forms.CheckBox CheckSalat;
        private System.Windows.Forms.CheckBox CheckTomat;
        private System.Windows.Forms.CheckBox CheckAgurk;
        private System.Windows.Forms.CheckBox CheckPepperfrugt;
        private System.Windows.Forms.CheckBox CheckAnanas;
        private System.Windows.Forms.Button ButtonSelect;
    }
}