using System;
using System.Windows.Forms;
using HourBoostr_Beta.Core.MultiBoostr;
using Newtonsoft.Json;

namespace HourBoostr_Beta.Ui.MultiBoostr
{
    public partial class MultiBoostr : Form
    {
        private Instance Instance;
        public MultiBoostr() => InitializeComponent();

        #region Header Controls
        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.This.BoostrSelectionScreen.Show();
            Program.This.MultiBoostr.Hide();
        }
        private void ExitButton_Click(object sender, EventArgs e) => Program.This.Close();
        #endregion

        #region Main Controls
        private void MultiBoostr_Load(object sender, EventArgs e)
        {
            if(Instance == null) Instance = new();
            AccountListBox.Items.Clear();
            AccountListBox.Items.AddRange(GetAccountList());
            UpdateAccountPanel();
        }

        //Account list
        private void AccountListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAccountPanel();
        }
        private void AddNewAccountButton_Click(object sender, EventArgs e)
        {

        }

        //Account Panel
        private void UsernameInputBox_KeyUp(object sender, KeyEventArgs e)
        {
            AccountGroupBox.Text = UsernameInputBox.Text;
            if (AccountListBox.SelectedIndex >= 0)
            {
                AccountListBox.Items[AccountListBox.SelectedIndex] = UsernameInputBox.Text;
            }
        }
        #endregion

        private string[] GetAccountList()
        {
            return new[]{
                "Test", "Fallox"
            };
        }

        private void UpdateAccountPanel()
        {
            var hasAccounts = AccountListBox.Items.Count > 0;

            if (hasAccounts)
            {
                var noneselected = AccountListBox.SelectedIndex < 0;
                if (noneselected)
                    AccountListBox.SelectedIndex = 0;

                var item = AccountListBox.SelectedItem.ToString();
                var validitem = !string.IsNullOrEmpty(item);
                if (validitem)
                {
                    //-- Set account name
                    AccountGroupBox.Text = item;
                    UsernameInputBox.Text = item;


                }
            }
        }
    }
}
