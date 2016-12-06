using BIMDomain.Models.Abstract;
using BIMDomain.Models.DAL;
using BIMDomain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BIMDomain.Models
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ImageManager _imageManager;
        private static readonly Guid _constantGuid = new Guid("ea817faf-50fd-4c5e-a330-2765d9497663");

        /*
         * Constructors
         */
        public Service()
            : this(new UnitOfWork(), new ImageManager())
        {
            //Empty...
        }

        public Service(IUnitOfWork unitOfWork, ImageManager imageManager)
        {
            _unitOfWork = unitOfWork;
            _imageManager = imageManager;
        }

        public Guid getGuid()
        {
            return _constantGuid;
        }

        #region Managing images functionality
        public bool isValidImage(Image image)
        {
            return _imageManager.IsValidImage(image);
        }

        public byte[] convertImageToByteArray(Image image)
        {
            return _imageManager.converterImageToByte(image);
        }

        public Image resizeImage(Image image)
        {
            return _imageManager.ResizeImage(image);
        }
        #endregion

        #region Database functionality

        public List<Manufactury> GetAllManufacturies()
        {
            var returnValue = _unitOfWork.ManufacturyRepository.Get().ToList();



            return returnValue;
        }
        public List<Product> GetAllProducts()
        {
            var returnValue = _unitOfWork.ProductRepository.Get().ToList();
            return returnValue;
        }
        public List<Product> GetProductsByManufacturyId(int manufacturyId)
        {
            var returnValue = _unitOfWork.ProductRepository.Get(o => o.Manufactury.Id == manufacturyId).ToList();
            return returnValue;
        }
        public Product GetProduct(int id)
        {
            Product product = _unitOfWork.ProductRepository.Get(c => c.Id == id).FirstOrDefault();
            return product;
        }
        public Manufactury GetManufactury(int id)
        {
            Manufactury manufactury = _unitOfWork.ManufacturyRepository.Get(c => c.Id == id).FirstOrDefault();
            return manufactury;
        }
        public bool InsertManufactury(Manufactury manufactury)
        {
            try
            {
                _unitOfWork.ManufacturyRepository.Insert(manufactury);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        public bool InsertProduct(Product product)
        {
            try
            {
                _unitOfWork.ProductRepository.Insert(product);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        public bool UpdateManufactury(Manufactury manufactury)
        {
            try
            {
                _unitOfWork.ManufacturyRepository.Update(manufactury);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                //e = e;
            }

            return false;
        }

        public bool DeleteManufactury(Manufactury manufactury)
        {
            try
            {
                _unitOfWork.ManufacturyRepository.Delete(manufactury);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                _unitOfWork.ProductRepository.Delete(product);
                _unitOfWork.Save();
                return true;
            }
            catch { }

            return false;
        }

        #endregion
    }
}