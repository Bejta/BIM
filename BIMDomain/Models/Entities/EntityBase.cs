using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BIMDomain.Models.Entities
{
    public class EntityBase
    {
        [Required]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public Guid guidCreated { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public Guid guidUpdated { get; set; }

        [Required]
        public DateTime Updated { get; set; }
    }
}