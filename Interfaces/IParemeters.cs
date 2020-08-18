using ProtectorDX.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtectorDX.Interfaces
{
    public interface IParemeters
    {
        List<string> HostNames { get; set; }
        ProtectTypes ProtectType { get; set; }
    }
}
