using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourBoostr_Beta.Core.MultiBoostr
{
    internal class Config
    {
        internal Config() 
        { 

        }



        internal bool FindAccount(string accountName)
        {
            return false;
        }

        internal BoostrAccount GetAccount(string accountName)
        {
            return new(accountName);
        }
    }
}
