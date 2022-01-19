using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourBoostr_Beta.Core.MultiBoostr
{
    internal class BoostrAccount
    {
        private protected string AccountName;
        private protected string AccountPassword;
        private protected string LoginKey;

        internal BoostrAccount(string accountName)
        {
            var config = Program.This.MultiBoostr.Config;

            if (config.FindAccount(accountName))
            {
                var account = config.GetAccount(accountName);
                AccountName = account.AccountName;
                AccountPassword = account.AccountPassword;
                LoginKey = account.LoginKey;
            } 
        }
    }
}
