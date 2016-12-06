using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMDomain.Models.Entities
{
    public class Product : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please browse your image")]
        //[ValidateFile]
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Required field")]
        [ForeignKey("Manufactury")]
        public int ManufacturyID { get; set; }

        public virtual Manufactury Manufactury { get; set; }
    }
}