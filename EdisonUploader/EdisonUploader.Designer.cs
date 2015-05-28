namespace EdisonUploader
{
    partial class EdisonUploader
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
            this.settingsButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadElfButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.setWatchButton = new System.Windows.Forms.Button();
            this.stopWatchButton = new System.Windows.Forms.Button();
            this.watchFolderTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(16, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTextBox.BackColor = System.Drawing.Color.White;
            this.statusTextBox.Location = new System.Drawing.Point(12, 168);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(410, 171);
            this.statusTextBox.TabIndex = 1;
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Location = new System.Drawing.Point(97, 12);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(100, 23);
            this.testConnectionButton.TabIndex = 2;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output:";
            // 
            // uploadElfButton
            // 
            this.uploadElfButton.Enabled = false;
            this.uploadElfButton.Location = new System.Drawing.Point(349, 110);
            this.uploadElfButton.Name = "uploadElfButton";
            this.uploadElfButton.Size = new System.Drawing.Size(74, 23);
            this.uploadElfButton.TabIndex = 4;
            this.uploadElfButton.Text = "Upload ELF";
            this.uploadElfButton.UseVisualStyleBackColor = true;
            this.uploadElfButton.Click += new System.EventHandler(this.uploadElfButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Elf File:";
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.BackColor = System.Drawing.Color.White;
            this.filenameTextBox.Location = new System.Drawing.Point(61, 112);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.ReadOnly = true;
            this.filenameTextBox.Size = new System.Drawing.Size(201, 20);
            this.filenameTextBox.TabIndex = 6;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(268, 110);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // setWatchButton
            // 
            this.setWatchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setWatchButton.Location = new System.Drawing.Point(332, 45);
            this.setWatchButton.Name = "setWatchButton";
            this.setWatchButton.Size = new System.Drawing.Size(90, 23);
            this.setWatchButton.TabIndex = 8;
            this.setWatchButton.Text = "Set Watch";
            this.setWatchButton.UseVisualStyleBackColor = true;
            this.setWatchButton.Click += new System.EventHandler(this.setWatchButton_Click);
            // 
            // stopWatchButton
            // 
            this.stopWatchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopWatchButton.Enabled = false;
            this.stopWatchButton.Location = new System.Drawing.Point(332, 73);
            this.stopWatchButton.Name = "stopWatchButton";
            this.stopWatchButton.Size = new System.Drawing.Size(90, 23);
            this.stopWatchButton.TabIndex = 9;
            this.stopWatchButton.Text = "Cancel Watch";
            this.stopWatchButton.UseVisualStyleBackColor = true;
            this.stopWatchButton.Click += new System.EventHandler(this.stopWatchButton_Click);
            // 
            // watchFolderTextBox
            // 
            this.watchFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchFolderTextBox.BackColor = System.Drawing.Color.White;
            this.watchFolderTextBox.Location = new System.Drawing.Point(107, 47);
            this.watchFolderTextBox.Name = "watchFolderTextBox";
            this.watchFolderTextBox.ReadOnly = true;
            this.watchFolderTextBox.Size = new System.Drawing.Size(219, 20);
            this.watchFolderTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Watch Directory:";
            // 
            // EdisonUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 351);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.watchFolderTextBox);
            this.Controls.Add(this.stopWatchButton);
            this.Controls.Add(this.setWatchButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.filenameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uploadElfButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testConnectionButton);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.settingsButton);
            this.MinimumSize = new System.Drawing.Size(450, 390);
            this.Name = "EdisonUploader";
            this.Text = "Edison Uploader";
            this.Load += new System.EventHandler(this.EdisonUploader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button testConnectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uploadElfButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button setWatchButton;
        private System.Windows.Forms.Button stopWatchButton;
        private System.Windows.Forms.TextBox watchFolderTextBox;
        private System.Windows.Forms.Label label3;
    }
}

