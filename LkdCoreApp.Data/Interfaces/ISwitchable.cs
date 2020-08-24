using LkdCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LkdCoreApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
