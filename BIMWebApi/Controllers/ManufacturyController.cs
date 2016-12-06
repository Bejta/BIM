using BIMDomain.Models;
using BIMDomain.Models.DAL;
using BIMDomain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIMDomain.Models.Entities;
using System.Web.Http.Description;

namespace BIMWebApi.Controllers
{
    public class ManufacturyController : ApiController
    {

        private BIMObjectContext db = new BIMObjectContext();
        private IService _service;

        public ManufacturyController()
            : this (new Service())
        { }
        public ManufacturyController(IService service)
        {
            _service = service;
        }

        // GET: api/Manufactury
        public IEnumerable<Manufactury> GetManufacturies()
        {
            return _service.GetAllManufacturies();
        }

        // GET: api/Manufacturies/5
        [ResponseType(typeof(Manufactury))]
        public IHttpActionResult GetManufactury(int id)
        {
            Manufactury manufactury = db.Manufacturies.Find(id);
            if (manufactury == null)
            {
                return NotFound();
            }

            return Ok(manufactury);
        }

        // GET: api/manufacturies/5/products
        public List<Product> GetProductsByManufactoryID(int manufactoryId)
        {
            List<Product> products = _service.GetProductsByManufacturyId(manufactoryId);
            return products;
        }
    }
}
