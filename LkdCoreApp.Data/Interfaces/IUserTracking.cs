using System;
using System.Collections.Generic;
using System.Text;

namespace LkdCoreApp.Data.Interfaces
{
    public interface IUserTracking<T>
    {
        T CreatedBy { get; set; }
        T ModifiedBy { get; set; }
    }
}
