using System;
using System.Windows.Forms;

namespace EdisonUploader
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog(string host = "", string userName = "", string password = "")
        {
            InitializeComponent();
            usernameTextbox.Text = userName;
            hostTextbox.Text = host;
            passwordTextbox.Text = password;
        }

        public string Host { get { return hostTextbox.Text; } }
        public string Username { get { return usernameTextbox.Text; } }
        public string Password { get { return passwordTextbox.Text; } }

        private void showPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextbox.UseSystemPasswordChar = !showPasswordCheckbox.Checked;
        }

        private void hostTextbox_TextChanged(object sender, EventArgs e)
        {
            UpdateOKButton();
        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {
            UpdateOKButton();
        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            UpdateOKButton();
        }

        private void UpdateOKButton()
        {
            okButton.Enabled = !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Host) &&
                !string.IsNullOrWhiteSpace(Password);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Host = Host;
            Properties.Settings.Default.Username = Username;
            Properties.Settings.Default.Password = Password;
            Properties.Settings.Default.Save();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
