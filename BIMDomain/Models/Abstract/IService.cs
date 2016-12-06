using BIMDomain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMDomain.Models.Abstract
{
    public interface IService
    {
        Guid getGuid();

        #region Images
        bool isValidImage(Image image);
        Image resizeImage(Image image);
        byte[] convertImageToByteArray(Image image);
        #endregion

        /*
         * CRUD operations on Manufacture and Product entities
         * */
        #region Database

        //Delete
        bool DeleteManufactury(Manufactury manufactury);
        bool DeleteProduct(Product product);

        //Update
        bool UpdateManufactury(Manufactury manufactury);
        bool UpdateProduct(Product product);

        //Create
        bool InsertManufactury(Manufactury manufactury);
        bool InsertProduct(Product product);

        //Get
        List<Manufactury> GetAllManufacturies();
        Manufactury GetManufactury(int id);
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        List<Product> GetProductsByManufacturyId(int manufacturyId);

        #endregion
    }
}
