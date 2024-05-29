using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class SupplierInv
    {
        public int SupplierInvId { get; set; }
        public int SupplierId { get; set; }
        public int? ProductsId { get; set; }
        public DateTime? TransactionStamp { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Product Products { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
