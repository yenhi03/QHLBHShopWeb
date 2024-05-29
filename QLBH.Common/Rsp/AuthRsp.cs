using QLBH.Common.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Common.Rsp
{
    public class AuthRsp
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public UserRsp User { get; set; }
    }
}
