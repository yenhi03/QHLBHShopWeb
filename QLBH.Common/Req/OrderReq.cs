using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class OrderReq
    {
        public int CustomerId { get; set; }
        public int ProductsId { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public DateTime? OrdersDate { get; set; }
    }
}
