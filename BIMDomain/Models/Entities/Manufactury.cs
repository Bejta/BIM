using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BIMDomain.Models.Entities
{
    public class Manufactury : EntityBase
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please browse your image")]
       // [ValidateFile]
        public byte[] Logo { get; set; }

        /*
        [ValidateFile(ErrorMessage = "Please select a PNG image")]
        public HttpPostedFileBase Logo { get; set; }
        */

        public virtual ICollection<Product> Products { get; set; }

        public Manufactury()
        {
            Products = new HashSet<Product>();
        }
    }
}