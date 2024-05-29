using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class CustomerInv
    {
        public int CustomerInvId { get; set; }
        public int CustomerId { get; set; }
        public int ProductsId { get; set; }
        public decimal Amount { get; set; }
        public int? Quantity { get; set; }
        public string AccountsMonth { get; set; }
        public int AccountsYear { get; set; }
        public DateTime? TransactionStamp { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Products { get; set; }
    }
}
