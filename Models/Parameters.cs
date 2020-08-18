using ProtectorDX.Enums;
using ProtectorDX.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtectorDX.Models
{
    public class Parameters : IParemeters
    {
        public List<string> HostNames { get; set; }
        public ProtectTypes ProtectType { get; set; }
    }
}
