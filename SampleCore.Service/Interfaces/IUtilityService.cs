using SampleCore.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Service.Interfaces
{
    public interface IUtilityService
    {
        List<LookupList> GetLookupLists();
        List<Parameters> GetParameters();
    }
}
