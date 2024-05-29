using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            Designs = new HashSet<Design>();
            Orders = new HashSet<Order>();
            SupplierInvs = new HashSet<SupplierInv>();
        }

        public int ProductsId { get; set; }
        public int? CategoryId { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Design> Designs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SupplierInv> SupplierInvs { get; set; }
    }
}
