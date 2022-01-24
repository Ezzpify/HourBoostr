using HourBoostr_Beta.Core.MultiBoostr;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui.MultiBoostr
{
    public partial class MultiBoostr : Form
    {
        internal Config Config;
        internal List<Instance> Instance;
        public MultiBoostr() => InitializeComponent();

        #region Header Controls
        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.This.BoostrSelectionScreen.Show();
            Program.This.MultiBoostr.Hide();
        } 
        #endregion

        #region Main Controls
        private void MultiBoostr_Load(object sender, EventArgs e)
        {
            Config = new();
            AccountListBox.Items.Clear();
            AccountListBox.Items.AddRange(GetAccountList());
            UpdateAccountPanel();
        }

        //Account list

        private void AddNewAccountButton_Click(object sender, EventArgs e)
        {

        }
        private void AccountListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAccountPanel();
        }

        private void StartIdlerButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            List<BoostrAccount> Accounts = new();
            foreach (var account in AccountListBox.Items)
            {
                var accountName = account.ToString();
                Accounts.Add(new BoostrAccount(accountName));
                count++;

                if (count % 10 == 0)
                {
                    Instance.Add(new(Accounts));
                    Accounts.Clear();
                }
            }
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
