using BIMDomain.Models.Abstract;
using BIMDomain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace BIMDomain.Models.DAL
{
    internal class UnitOfWork : IUnitOfWork
    {
        //Fields
        private BIMObjectContext _context = new BIMObjectContext();

        private IRepository<Manufactury> _manufacturiesRepository;
        private IRepository<Product> _productsRepository;

        // Properties with getters and setters
        public IRepository<Manufactury> ManufacturyRepository
        {
            get
            {
                return _manufacturiesRepository ?? (_manufacturiesRepository = new Repository<Manufactury>(_context));
            }
        }
        public IRepository<Product> ProductRepository
        {
            get
            {
                return _productsRepository ?? (_productsRepository = new Repository<Product>(_context));
            }
        }


        /// <summary>
        /// Saves all changes made in the unit of work to the underlying database.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
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
        #endregion
    }
}