using BIMDomain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDomain.Models.Abstract
{
    public interface IBIMObjectContext
    {
        IDbSet<Manufactury> Manufacturies { get; set; }
        IDbSet<Product> Products { get; set; }
    }
}
