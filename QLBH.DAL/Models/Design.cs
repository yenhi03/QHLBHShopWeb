using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Design
    {
        public int DesignsId { get; set; }
        public int? ProductsId { get; set; }
        public string Material { get; set; }
        public int? Purity { get; set; }
        public string Finish { get; set; }
        public string Gems { get; set; }

        public virtual Product Products { get; set; }
    }
}
