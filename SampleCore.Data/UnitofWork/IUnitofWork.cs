using SampleCore.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Data.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        /// <summary>
        /// Değişiklikleri kaydet.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
