using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Framework.Enums
{
    public enum ForbiddenAccessTypes
    {
        UnForbidden = 0,
        IsLogout = -1,
        PersonId = 1,
        Database = 2
    }
}
