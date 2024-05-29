using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual User User { get; set; }
    }
}
