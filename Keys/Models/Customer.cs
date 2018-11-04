using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Keys.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Your Name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter Your Address")]
        public string Address { get; set; }
    }
}