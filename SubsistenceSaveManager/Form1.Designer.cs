namespace SubsistenceSaveManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.currentpathlabel = new System.Windows.Forms.Label();
            this.backupsLabel = new System.Windows.Forms.Label();
            this.BackupsList = new System.Windows.Forms.ListBox();
            this.createbackup = new System.Windows.Forms.Button();
            this.deletebackup = new System.Windows.Forms.Button();
            this.deleteallbackups = new System.Windows.Forms.Button();
            this.restorebackup = new System.Windows.Forms.Button();
            this.changebackupname = new System.Windows.Forms.Button();
            this.namechangetext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // currentpathlabel
            // 
            this.currentpathlabel.AutoSize = true;
            this.currentpathlabel.Location = new System.Drawing.Point(9, 415);
            this.currentpathlabel.Name = "currentpathlabel";
            this.currentpathlabel.Size = new System.Drawing.Size(37, 13);
            this.currentpathlabel.TabIndex = 9;
            this.currentpathlabel.Text = "{Path}";
            // 
            // backupsLabel
            // 
            this.backupsLabel.AutoSize = true;
            this.backupsLabel.Location = new System.Drawing.Point(622, 2);
            this.backupsLabel.Name = "backupsLabel";
            this.backupsLabel.Size = new System.Drawing.Size(49, 13);
            this.backupsLabel.TabIndex = 11;
            this.backupsLabel.Text = "Backups";
            // 
            // BackupsList
            // 
            this.BackupsList.FormattingEnabled = true;
            this.BackupsList.Location = new System.Drawing.Point(590, 18);
            this.BackupsList.Name = "BackupsList";
            this.BackupsList.Size = new System.Drawing.Size(120, 407);
            this.BackupsList.TabIndex = 12;
            this.BackupsList.SelectedIndexChanged += new System.EventHandler(this.BackupsList_SelectedIndexChanged);
            // 
            // createbackup
            // 
            this.createbackup.Location = new System.Drawing.Point(12, 18);
            this.createbackup.Name = "createbackup";
            this.createbackup.Size = new System.Drawing.Size(106, 23);
            this.createbackup.TabIndex = 13;
            this.createbackup.Text = "Create Backup";
            this.createbackup.UseVisualStyleBackColor = true;
            this.createbackup.Click += new System.EventHandler(this.createbackup_Click);
            // 
            // deletebackup
            // 
            this.deletebackup.Enabled = false;
            this.deletebackup.Location = new System.Drawing.Point(12, 76);
            this.deletebackup.Name = "deletebackup";
            this.deletebackup.Size = new System.Drawing.Size(106, 23);
            this.deletebackup.TabIndex = 14;
            this.deletebackup.Text = "Delete Backup";
            this.deletebackup.UseVisualStyleBackColor = true;
            this.deletebackup.Click += new System.EventHandler(this.deletebackup_Click);
            // 
            // deleteallbackups
            // 
            this.deleteallbackups.Location = new System.Drawing.Point(12, 47);
            this.deleteallbackups.Name = "deleteallbackups";
            this.deleteallbackups.Size = new System.Drawing.Size(106, 23);
            this.deleteallbackups.TabIndex = 15;
            this.deleteallbackups.Text = "Delete All Backups";
            this.deleteallbackups.UseVisualStyleBackColor = true;
            this.deleteallbackups.Click += new System.EventHandler(this.deleteallbackups_Click);
            // 
            // restorebackup
            // 
            this.restorebackup.Enabled = false;
            this.restorebackup.Location = new System.Drawing.Point(12, 105);
            this.restorebackup.Name = "restorebackup";
            this.restorebackup.Size = new System.Drawing.Size(106, 23);
            this.restorebackup.TabIndex = 16;
            this.restorebackup.Text = "Restore Backup";
            this.restorebackup.UseVisualStyleBackColor = true;
            this.restorebackup.Click += new System.EventHandler(this.restorebackup_Click);
            // 
            // changebackupname
            // 
            this.changebackupname.Enabled = false;
            this.changebackupname.Location = new System.Drawing.Point(478, 18);
            this.changebackupname.Name = "changebackupname";
            this.changebackupname.Size = new System.Drawing.Size(106, 23);
            this.changebackupname.TabIndex = 17;
            this.changebackupname.Text = "Change Name";
            this.changebackupname.UseVisualStyleBackColor = true;
            this.changebackupname.Click += new System.EventHandler(this.changebackupname_Click);
            // 
            // namechangetext
            // 
            this.namechangetext.Enabled = false;
            this.namechangetext.Location = new System.Drawing.Point(349, 21);
            this.namechangetext.Name = "namechangetext";
            this.namechangetext.Size = new System.Drawing.Size(123, 20);
            this.namechangetext.TabIndex = 18;
            this.namechangetext.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(722, 437);
            this.Controls.Add(this.namechangetext);
            this.Controls.Add(this.changebackupname);
            this.Controls.Add(this.restorebackup);
            this.Controls.Add(this.deleteallbackups);
            this.Controls.Add(this.deletebackup);
            this.Controls.Add(this.createbackup);
            this.Controls.Add(this.BackupsList);
            this.Controls.Add(this.backupsLabel);
            this.Controls.Add(this.currentpathlabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Subsistence Save Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label currentpathlabel;
        private System.Windows.Forms.Label backupsLabel;
        private System.Windows.Forms.ListBox BackupsList;
        private System.Windows.Forms.Button createbackup;
        private System.Windows.Forms.Button deletebackup;
        private System.Windows.Forms.Button deleteallbackups;
        private System.Windows.Forms.Button restorebackup;
        private System.Windows.Forms.Button changebackupname;
        private System.Windows.Forms.TextBox namechangetext;
    }
}

