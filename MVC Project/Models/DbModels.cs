using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Data.Entity;
using System.Web;

namespace MVC_Project.Models
{
    public class Product
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        [Required, StringLength(40), Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Unit Price"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Discount Rate"), DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Discount { get; set; }
    }
    public class ProductDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}