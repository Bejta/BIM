using BIMDomain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDomain.Models.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Manufactury> ManufacturyRepository { get; }

        void Save();
    }
}
