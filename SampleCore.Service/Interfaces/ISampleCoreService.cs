using SampleCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Service.Interfaces
{
    public interface ISampleCoreService
    {
        SampleCoreEntity FindEntity(int id);
        void InsertEntity(SampleCoreEntity requestLog);
        void UpdateEntity(SampleCoreEntity entity);
        void DeleteEntity(SampleCoreEntity entity);
        List<SampleCoreEntity> GetAll();
    }
}
