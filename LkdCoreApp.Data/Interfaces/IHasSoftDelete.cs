using System;
using System.Collections.Generic;
using System.Text;

namespace LkdCoreApp.Data.Interfaces
{
    public interface IHasSoftDelete
    {
        bool IsDeleted { set; get; }
    }
}
