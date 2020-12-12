using SampleCore.Core.Entities;
using SampleCore.Core.Entities.Common;
using SampleCore.Data.GenericRepository;
using SampleCore.Data.UnitofWork;
using SampleCore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCore.Service.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly IGenericRepository<Parameters> _parametersRepository;
        private readonly IGenericRepository<LookupList> _lookupListRepository;
        private readonly IGenericRepository<Person> _personRepository;
        public UtilityService(IUnitofWork uow)
        {
            _parametersRepository = uow.GetRepository<Parameters>();
            _lookupListRepository = uow.GetRepository<LookupList>();
            _personRepository = uow.GetRepository<Person>();
        }
        public List<LookupList> GetLookupLists()
        {
            return _lookupListRepository.GetAll().ToList();
        }
        public List<Parameters> GetParameters()
        {
            return _parametersRepository.GetAll().ToList();
        }
        public bool AnyEmail(string email)
        {
            return _personRepository.GetAll().Any(p => p.email == email);
        }
    }
}
