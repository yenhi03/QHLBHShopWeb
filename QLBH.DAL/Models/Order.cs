using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Order
    {
        public int OrdersId { get; set; }
        public int CustomerId { get; set; }
        public int ProductsId { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public DateTime? OrdersDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Products { get; set; }
    }
}
