using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class RegisterReq
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

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
    }
}
