using SampleCore.Core.Entities;
using SampleCore.Data.GenericRepository;
using SampleCore.Data.UnitofWork;
using SampleCore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCore.Service.Services
{
    public class SampleCoreService : ISampleCoreService
    {
        private readonly IGenericRepository<SampleCoreEntity> _sampleRepository;
        public SampleCoreService(IUnitofWork uow)
        {
            _sampleRepository = uow.GetRepository<SampleCoreEntity>();
        }
        public SampleCoreEntity FindEntity(int id)
        {
            return _sampleRepository.Find(id);
        }
        public void InsertEntity(SampleCoreEntity requestLog)
        {
            _sampleRepository.Insert(requestLog);
        }
        public void UpdateEntity(SampleCoreEntity entity)
        {
            _sampleRepository.Update(entity);
        }
        public void DeleteEntity(SampleCoreEntity entity)
        {
            _sampleRepository.Delete(entity);
        }
        public List<SampleCoreEntity> GetAll()
        {
            return _sampleRepository.GetAll().ToList();
        }
    }
}
