using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public int? UserId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string EmailCus { get; set; }
        public string PhoneNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
