namespace Translator
{
    partial class AWTranslator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWTranslator));
            this.AWEncryptSplitter = new System.Windows.Forms.Splitter();
            this.AWDecrypter = new System.Windows.Forms.TextBox();
            this.AWEncrypter = new System.Windows.Forms.TextBox();
            this.RainbowTimer = new System.Windows.Forms.Timer(this.components);
            this.whatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CaseButton = new System.Windows.Forms.Button();
            this.ThemesBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AWEncryptSplitter
            // 
            this.AWEncryptSplitter.Location = new System.Drawing.Point(0, 0);
            this.AWEncryptSplitter.Margin = new System.Windows.Forms.Padding(0);
            this.AWEncryptSplitter.Name = "AWEncryptSplitter";
            this.AWEncryptSplitter.Size = new System.Drawing.Size(520, 402);
            this.AWEncryptSplitter.TabIndex = 5;
            this.AWEncryptSplitter.TabStop = false;
            // 
            // AWDecrypter
            // 
            this.AWDecrypter.BackColor = System.Drawing.SystemColors.MenuText;
            this.AWDecrypter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AWDecrypter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AWDecrypter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AWDecrypter.ForeColor = System.Drawing.Color.Lime;
            this.AWDecrypter.Location = new System.Drawing.Point(520, 0);
            this.AWDecrypter.Margin = new System.Windows.Forms.Padding(0);
            this.AWDecrypter.Multiline = true;
            this.AWDecrypter.Name = "AWDecrypter";
            this.AWDecrypter.Size = new System.Drawing.Size(485, 402);
            this.AWDecrypter.TabIndex = 7;
            this.AWDecrypter.Text = "Decrypt here...";
            this.AWDecrypter.TextChanged += new System.EventHandler(this.AWDecrypter_TextChanged);
            // 
            // AWEncrypter
            // 
            this.AWEncrypter.BackColor = System.Drawing.SystemColors.MenuText;
            this.AWEncrypter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AWEncrypter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AWEncrypter.ForeColor = System.Drawing.Color.Lime;
            this.AWEncrypter.Location = new System.Drawing.Point(0, 0);
            this.AWEncrypter.Margin = new System.Windows.Forms.Padding(0);
            this.AWEncrypter.Multiline = true;
            this.AWEncrypter.Name = "AWEncrypter";
            this.AWEncrypter.Size = new System.Drawing.Size(518, 402);
            this.AWEncrypter.TabIndex = 13;
            this.AWEncrypter.Text = "3ncryp7 h3r3...";
            this.AWEncrypter.TextChanged += new System.EventHandler(this.AWEncrypter_TextChanged);
            // 
            // RainbowTimer
            // 
            this.RainbowTimer.Interval = 50;
            this.RainbowTimer.Tick += new System.EventHandler(this.RainbowTimer_Tick);
            // 
            // whatToolStripMenuItem
            // 
            this.whatToolStripMenuItem.Name = "whatToolStripMenuItem";
            this.whatToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // CaseButton
            // 
            this.CaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CaseButton.AutoSize = true;
            this.CaseButton.BackColor = System.Drawing.SystemColors.MenuText;
            this.CaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaseButton.ForeColor = System.Drawing.Color.Lime;
            this.CaseButton.Location = new System.Drawing.Point(0, 367);
            this.CaseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CaseButton.Name = "CaseButton";
            this.CaseButton.Size = new System.Drawing.Size(161, 35);
            this.CaseButton.TabIndex = 14;
            this.CaseButton.Text = "70 UPP3RC453";
            this.CaseButton.UseVisualStyleBackColor = false;
            this.CaseButton.Click += new System.EventHandler(this.CaseButton_Click);
            // 
            // ThemesBox
            // 
            this.ThemesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ThemesBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.ThemesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThemesBox.ForeColor = System.Drawing.Color.Lime;
            this.ThemesBox.FormattingEnabled = true;
            this.ThemesBox.Items.AddRange(new object[] {
            "Dark Theme",
            "Darker Theme",
            "Light Theme",
            "Rainbow Theme",
            "Rave Theme",
            "Epilepsi Theme"});
            this.ThemesBox.Location = new System.Drawing.Point(848, 374);
            this.ThemesBox.Name = "ThemesBox";
            this.ThemesBox.Size = new System.Drawing.Size(157, 28);
            this.ThemesBox.TabIndex = 15;
            this.ThemesBox.SelectedIndexChanged += new System.EventHandler(this.ThemesBox_SelectedIndexChanged);
            // 
            // AWTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1005, 402);
            this.Controls.Add(this.ThemesBox);
            this.Controls.Add(this.CaseButton);
            this.Controls.Add(this.AWEncrypter);
            this.Controls.Add(this.AWDecrypter);
            this.Controls.Add(this.AWEncryptSplitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(518, 210);
            this.Name = "AWTranslator";
            this.Text = "4L4N W4LK3R 7R4N5L470R";
            this.SizeChanged += new System.EventHandler(this.AWTranslator_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Splitter AWEncryptSplitter;
        public System.Windows.Forms.TextBox AWDecrypter;
        public System.Windows.Forms.TextBox AWEncrypter;
        private System.Windows.Forms.Timer RainbowTimer;
        private System.Windows.Forms.ToolStripMenuItem whatToolStripMenuItem;
        public System.Windows.Forms.Button CaseButton;
        private System.Windows.Forms.ComboBox ThemesBox;
    }
}

