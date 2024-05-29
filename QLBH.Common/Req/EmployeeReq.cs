using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class EmployeeReq
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HireDate { get; set; }

    }
}
