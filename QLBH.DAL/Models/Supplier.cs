using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            SupplierInvs = new HashSet<SupplierInv>();
        }

        public int SupplierId { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Material { get; set; }

        public virtual ICollection<SupplierInv> SupplierInvs { get; set; }
    }
}
