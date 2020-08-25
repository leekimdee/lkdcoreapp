﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LkdCoreApp.Data.Interfaces
{
    public interface IDateTracking
    {
        DateTime CreatedDate { set; get; }

        DateTime ModifiedDate { set; get; }
    }
}
