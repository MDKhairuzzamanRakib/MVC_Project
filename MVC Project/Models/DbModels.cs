using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace MVC_Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(40), Display(Name ="Product Name")]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}