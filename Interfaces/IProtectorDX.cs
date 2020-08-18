using ProtectorDX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtectorDX.Interfaces
{
    public interface IProtectorDX
    {
        Tuple<bool, Exception> ProtectConnectionStrings(Parameters parameters);
        Tuple<bool, Exception> UnProtectConnectionStrings(Parameters parameters);
    }
}
