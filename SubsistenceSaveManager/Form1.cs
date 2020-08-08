using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace SubsistenceSaveManager
{
    public partial class Form1 : Form
    {
        string steamdirectory = null;
        string currentsave = null;
        string currentbackup = null;

        string backupdirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\Backups";

        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        string[] savefilenames =
        {
            "saveFilesList.sav",
            "saveGame1.sav",
            "saveGame2.sav",
            "saveGame3.sav",
            "saveGame4.sav",
            "saveGame5.sav",
            "saveGame6.sav",
            "saveGame7.sav",
            "saveGame8.sav",
            "saveGame9.sav",
            "saveGame10.sav",
            "saveGame11.sav",
            "saveGame12.sav",
            "saveGame13.sav",
            "saveGame14.sav",
            "saveGame15.sav",
            "saveGame16.sav",
            "saveGame17.sav",
            "saveGame18.sav",
            "saveGame19.sav",
            "saveGame20.sav",
            "saveGame21.sav",
            "saveGame22.sav",
            "saveGame23.sav",
            "saveGame24.sav",
            "saveGame25.sav",
            "saveGame26.sav",
            "saveGame27.sav",
            "saveGame28.sav",
            "saveGame29.sav",
            "saveGame30.sav",
            "msp1.sav"
        };

        public static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void makeConfig()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager");
            }

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\Backups"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\Backups");
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\config.xml"))
            {
                using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\config.xml"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("<?xml version=\"1.0\"?>\n<Config>\n<SteamPath></SteamPath>\n</Config>");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        public void makeBackupsList()
        {
            BackupsList.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(backupdirectory);
            DirectoryInfo[] Files = d.GetDirectories();
            foreach (DirectoryInfo file in Files)
            {
                BackupsList.Items.Add(file.Name);
            }
        }

        string defaultSteamFolder = Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Steam\\steamapps\\common\\Subsistence";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager") && Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\Backups") && File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\config.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
                xmlDoc.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\config.xml"); // Load the XML document from the specified file

                XmlNodeList sp = xmlDoc.GetElementsByTagName("SteamPath");

                steamdirectory = sp[0].InnerText;

            }
            else
            {
                makeConfig();

                if (Directory.Exists(defaultSteamFolder))
                {
                    steamdirectory = defaultSteamFolder;
                }
                else
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        fbd.Description = "Select your subsistence folder";
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            steamdirectory = fbd.SelectedPath;
                            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
                            xmlDoc.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\config.xml"); // Load the XML document from the specified file

                            XmlNodeList sp = xmlDoc.GetElementsByTagName("SteamPath");

                            sp[0].InnerText = fbd.SelectedPath;

                            xmlDoc.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SubSaveManager\\config.xml");

                        }
                    }
                }
            }
            currentpathlabel.Text = "Game Path: " + steamdirectory;
            makeBackupsList();
        }

        private void BackupsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deletebackup.Enabled = true;
            restorebackup.Enabled = true;
            changebackupname.Enabled = true;
            namechangetext.Enabled = true;
            currentbackup = BackupsList.GetItemText(BackupsList.SelectedItem);
            namechangetext.Text = "";
        }

        private void createbackup_Click(object sender, EventArgs e)
        {
            makeBackupsList();
            string backupD = GetUniqueKey(5);
            Directory.CreateDirectory(backupdirectory + "\\" + backupD);
            foreach (string f in savefilenames)
            {
                if (File.Exists(steamdirectory + "\\Binaries\\Win32\\" + f)) {
                    File.Copy(steamdirectory + "\\Binaries\\Win32\\" + f, backupdirectory + "\\" + backupD + "\\" + f);
                }
                if (File.Exists(steamdirectory + "\\Binaries\\Win32\\MapData\\" + f))
                {
                    File.Copy(steamdirectory + "\\Binaries\\Win32\\MapData\\" + f, backupdirectory + "\\" + backupD + "\\" + f);
                }
            }
            makeBackupsList();
        }

        private void deletebackup_Click(object sender, EventArgs e)
        {
            makeBackupsList();
            Directory.Delete(backupdirectory + "\\" + currentbackup, true);
            deletebackup.Enabled = false;
            restorebackup.Enabled = false;
            changebackupname.Enabled = false;
            namechangetext.Enabled = false;
            namechangetext.Text = "";
            makeBackupsList();
        }

        private void deleteallbackups_Click(object sender, EventArgs e)
        {
            makeBackupsList();
            DirectoryInfo d = new DirectoryInfo(backupdirectory);
            DirectoryInfo[] Files = d.GetDirectories();
            foreach (DirectoryInfo file in Files)
            {
                Directory.Delete(backupdirectory + "\\" + file.Name);
            }
            deletebackup.Enabled = false;
            restorebackup.Enabled = false;
            changebackupname.Enabled = false;
            namechangetext.Enabled = false;
            namechangetext.Text = "";
            makeBackupsList();
        }

        private void restorebackup_Click(object sender, EventArgs e)
        {
            foreach (string f in savefilenames)
            {
                if (File.Exists(backupdirectory + "\\" + currentbackup + "\\" + f))
                {
                    if (f.ToString() != "msp1.sav")
                    {
                        File.Copy(backupdirectory + "\\" + currentbackup + "\\" + f, steamdirectory + "\\Binaries\\Win32\\" + f, true);
                    }
                    else
                    {
                        File.Copy(backupdirectory + "\\" + currentbackup + "\\" + f, steamdirectory + "\\Binaries\\Win32\\MapData\\" + f, true);
                    }
                }
            }
        }

        private void changebackupname_Click(object sender, EventArgs e)
        {
            makeBackupsList();
            try
            {
              Directory.Move(backupdirectory + "\\" + currentbackup, backupdirectory + "\\" + namechangetext.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Name!");
                namechangetext.Text = "";
                return;
            }
            namechangetext.Text = "";
            makeBackupsList();
        }
    }
       
}
