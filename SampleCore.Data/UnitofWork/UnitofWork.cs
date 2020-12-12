using SampleCore.Data.Context;
using SampleCore.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Data.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly SampleCoreContext _context;
        private bool disposed = false;

        public UnitofWork(SampleCoreContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
