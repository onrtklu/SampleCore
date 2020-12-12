using SampleCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Service.Interfaces
{
    public interface IPersonService
    {
        Person GetPerson(string userName, string password);
        Person FindPerson(int id);
        void UpdatePerson(Person entity);
        void InsertPerson(Person entity);
        bool IsThere(string mail);
        Person GetProfile(string mail);
    }
}
