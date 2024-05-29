using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Req
{
    public class UserReq
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
    }
}
