using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourBoostr_Beta.Core
{
    internal class Utils
    {
    }
}

//Bug fix: compiler throws this error because we're compiling .NET 5 features in .NET Framework
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}