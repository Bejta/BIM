using BIMDomain.Models;
using BIMDomain.Models.Abstract;
using BIMDomain.Models.DAL;
using BIMDomain.Models.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BIMDomain.Controllers
{
    public class ManufacturyController : ApiController
    {

        //private BIMObjectContext db = new BIMObjectContext();
        private IService _service;

        public ManufacturyController()
            : this(new Service())
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
            //Manufactury manufactury = db.Manufacturies.Find(id);
            Manufactury manufactury = _service.GetManufactury(id);
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

        // DELETE: api/Manufactury/5
        [ResponseType(typeof(Manufactury))]
        public IHttpActionResult DeleteManufactury(int id)
        {
            //Manufactury manufactury = db.Manufacturies.Find(id);
            Manufactury manufactury = _service.GetManufactury(id);
            if (manufactury == null)
            {
                return NotFound();
            }

            if (!_service.DeleteManufactury(manufactury))
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            //db.Manufacturies.Remove(manufactury);


            return Ok(manufactury);
        }

        // PUT: api/Manufacturies/5
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody]JObject json)
        {

            Manufactury manufactury = json.ToObject<Manufactury>();
            //array.ToObject<List<SelectableEnumItem>>()
            
            //manufactury = JsonConvert.DeserializeObject<Manufactury>(json);


            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad request - Something went wrong!");
            }

            try
            {
                _service.InsertManufactury(manufactury);

            }
            catch (Exception e)
            {
                e = e;
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Manufactury inserted") ;
        }

        // PUT: api/Manufacturies/5
        //Post([FromBody]string schooltypeName)
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutManufactury(Manufactury manufactury)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        _service.InsertManufactury(manufactury);

        //    }
        //    catch (Exception e)
        //    {
        //        e = e;
        //    }

        //    return StatusCode(HttpStatusCode.OK);
        //}
    }
}
