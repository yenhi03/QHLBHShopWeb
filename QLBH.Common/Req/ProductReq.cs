using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class ProductReq
    {
        public int? CategoryId { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
