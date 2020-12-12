using SampleCore.Core.Entities;
using SampleCore.Core.Entities.Common;
using SampleCore.Data.GenericRepository;
using SampleCore.Data.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Service.Abstracts
{
    public abstract class APersonService
    {
        internal readonly IUnitofWork _uow;
        internal readonly IGenericRepository<Lookup> _lookupRepository;
        internal readonly IGenericRepository<Person> _personRepository;
        internal APersonService(IUnitofWork uow)
        {
            _uow = uow;
            _lookupRepository = uow.GetRepository<Lookup>();
            _personRepository = uow.GetRepository<Person>();
        }
    }
}
