using Renci.SshNet;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdisonUploader
{
    public partial class EdisonUploader : Form
    {
        private string _host, _username, _password;
        private FileSystemWatcher _watcher;
        private Button[] _buttons;
        private bool[] _buttonStates;

        public EdisonUploader()
        {
            InitializeComponent();

            // store the buttons and their initial values
            _buttons = new Button[] { settingsButton, testConnectionButton, 
                setWatchButton, stopWatchButton, browseButton, uploadElfButton };
            _buttonStates = new bool[] { settingsButton.Enabled, testConnectionButton.Enabled, 
                setWatchButton.Enabled, stopWatchButton.Enabled, browseButton.Enabled, uploadElfButton.Enabled };
        }

        private void EdisonUploader_Load(object sender, EventArgs e)
        {
            // Load the settings
            _host = Properties.Settings.Default.Host;
            _username = Properties.Settings.Default.Username;
            _password = Properties.Settings.Default.Password;

            if (!HasConnectionSettings())
            {
                // if not everything is set launch the Settings Dialog first
                LaunchSettingsDialog();
            }
        }

        #region ClickHandlers

        private void settingsButton_Click(object sender, EventArgs e)
        {
            LaunchSettingsDialog();
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons();
            statusTextBox.Text += "Testing Connection..." + Environment.NewLine;
            new Action(async () =>
            {
                string result = await Task.Run<string>(() => TestConnectionSettings());
                statusTextBox.Text += result;
                ReturnButtonsToPrevState();
            }).Invoke();
        }

        private void uploadElfButton_Click(object sender, EventArgs e)
        {
            DisableAllButtons();
            statusTextBox.Text += "Uploading..." + Environment.NewLine;
            new Action(async () =>
            {
                string result = await Task.Run<string>(() => UploadElf());
                statusTextBox.Text += result;
                ReturnButtonsToPrevState();
            }).Invoke();
        }

        private void setWatchButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Path.GetTempPath();
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            watchFolderTextBox.Text = dialog.SelectedPath;
            _watcher = new FileSystemWatcher(dialog.SelectedPath, "*.elf");
            _watcher.IncludeSubdirectories = true;
            _watcher.Created += new FileSystemEventHandler(OnChanged);
            _watcher.EnableRaisingEvents = true;
            stopWatchButton.Enabled = true;
            setWatchButton.Enabled = false;
        }

        private void stopWatchButton_Click(object sender, EventArgs e)
        {
            _watcher.Dispose();
            _watcher = null;
            watchFolderTextBox.Text = "";
            stopWatchButton.Enabled = false;
            setWatchButton.Enabled = true;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (!string.IsNullOrWhiteSpace(filenameTextBox.Text))
            {
                dialog.InitialDirectory = Path.GetDirectoryName(filenameTextBox.Text);
            }
            dialog.Filter = "elf files (*.elf)|*.elf";
            dialog.RestoreDirectory = true;
            dialog.Title = "Select file to upload.";
            dialog.CheckFileExists = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filenameTextBox.Text = dialog.FileName;
                uploadElfButton.Enabled = true;
            }
        }

        #endregion

        private void LaunchSettingsDialog()
        {
            SettingsDialog settings = new SettingsDialog(_host, _username, _password);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                // Use the values typed in
                _host = settings.Host;
                _username = settings.Username;
                _password = settings.Password;
            }
        }

        private bool HasConnectionSettings()
        {
            return !string.IsNullOrWhiteSpace(_host) &&
                !string.IsNullOrWhiteSpace(_username) &&
                !string.IsNullOrWhiteSpace(_password);
        }

        private string TestConnectionSettings()
        {
            try
            {
                new ElfUploader(_host, _username, _password).TestConnect();
            }
            catch (Exception ex)
            {
                return "Connection Failed:" + Environment.NewLine + ex.Message + Environment.NewLine;
            }

            return "Connection Successful." + Environment.NewLine;
        }

        private void DisableAllButtons()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttonStates[i] = _buttons[i].Enabled;
                _buttons[i].Enabled = false;
            }
        }

        private void ReturnButtonsToPrevState()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Enabled = _buttonStates[i];
            }
        }

        private string UploadElf()
        {
            try
            {
                var uploader = new ElfUploader(_host, _username, _password);
                uploader.MoveOldElfFile();
                uploader.UploadeFile(filenameTextBox.Text);
                uploader.SetPermissionsAndRestart();
            }
            catch (Exception ex)
            {
                return "Upload Failed:" + Environment.NewLine + ex.Message + Environment.NewLine;
            }

            return "Upload Successful." + Environment.NewLine;
        }

        private void AddLineToStatusBox(string line)
        {
            if (statusTextBox.InvokeRequired)
            {
                statusTextBox.BeginInvoke((MethodInvoker) delegate { AddLineToStatusBox(line); });
            }
            else
            {
                statusTextBox.Text += line;
            }
        }

        private void PrompForFileChange(string file, WatcherChangeTypes changeType)
        {
            if (statusTextBox.InvokeRequired)
            {
                statusTextBox.BeginInvoke((MethodInvoker)delegate { PrompForFileChange(file, changeType); });
            }
            else
            {
                DialogResult result = MessageBox.Show(this,
                string.Format("The file {0} was {1}.{2} Would you like to set it to the upload path?",
                file, changeType, Environment.NewLine), "File Change Detected", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    filenameTextBox.Text = file;
                    uploadElfButton.Enabled = true;
                }
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            AddLineToStatusBox("File: " + e.FullPath + " " + e.ChangeType + Environment.NewLine);

            // If the browse button isn't enabled, then the software is busy, don't show a message box
            if (!browseButton.Enabled)
                return;

            PrompForFileChange(e.FullPath, e.ChangeType);
        }
    }
}
