using SampleCore.Core.Constants;
using SampleCore.Core.Entities;
using SampleCore.Data.UnitofWork;
using SampleCore.Service.Abstracts;
using SampleCore.Service.Interfaces;
using SampleCore.Utilities.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCore.Service.Services
{
    public class PersonService : APersonService, IPersonService
    {
        public PersonService(IUnitofWork uow) : base(uow) { }
        public Person FindPerson(int id)
        {
            return _personRepository.Find(id);
        }
        public Person GetPerson(string userName, string password)
        {
            var result = _personRepository.GetAll().Where(p => p.email == userName).SingleOrDefault();
            if (result == null) return null;
            if (EnDeCode.Decrypt(result.sifre, StaticParams.SifrelemeParametresi) == password)
                return result;
            else
                return null;
        }
        public void InsertPerson(Person entity)
        {
            _personRepository.Insert(entity);
        }
        public void UpdatePerson(Person entity)
        {
            _personRepository.Update(entity);
        }
        public bool IsThere(string mail)
        {
            return _personRepository.GetAll().Where(p => p.email == mail).Count() > 0;
        }
        public Person GetProfile(string mail)
        {
            return _personRepository.GetAll().Where(p => p.email == mail).SingleOrDefault();
        }
    }
}
