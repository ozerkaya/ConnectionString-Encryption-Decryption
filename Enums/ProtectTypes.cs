using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProtectorDX.Enums
{

    public enum ProtectTypes
    {
        [Description(".Net Framework Web Project")]
        WEB_CONFIG = 1,
        [Description(".Net Framework Executable Project")]
        APP_CONFIG = 2,
        [Description(".Net Core Web Project")]
        APP_SETTINGS = 3,

    }
}
