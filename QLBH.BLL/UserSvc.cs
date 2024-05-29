using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Common.Req;

namespace QLBH.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        UserRep userRep;

        public UserSvc()
        {
            userRep = new UserRep();
        }

        //Lấy user theo ID truyền vào
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);

            if (res.Data == null)

            {
                res.SetMessage("Khong tim thay user");
                res.SetError("404", "Khong tim thay user");
            }

            return res;
        }

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.Name = userReq.Name; ;
            user.Email = userReq.Email;
            user.Password = userReq.Password;
            user.IsAdmin = userReq.IsAdmin;
            //Nếu isAdmin khác 0 hoặc 1 thì gán mặc định là 0
            if (userReq.IsAdmin != 0 && userReq.IsAdmin != 1)
                user.IsAdmin = 0;
            userRep.CreateUser(user);
            return res;
        }

        public SingleRsp UpdateUser(int id, UserReq userReq)
        {
            var res = new SingleRsp();
            var user = userRep.Read(id);
            user.Name = userReq.Name;
            user.Email = userReq.Email;
            user.Password = userReq.Password;
            user.IsAdmin = userReq.IsAdmin;
            //Nếu isAdmin khác 0 hoặc 1 thì gán mặc định là 0
            if (userReq.IsAdmin != 0 && userReq.IsAdmin != 1)
                user.IsAdmin = 0;
            res = userRep.UpdateUser(user);
            return res;
        }

        public SingleRsp DeleteUser(int id)
        {
            var res = new SingleRsp();

            try
            {
                // Find the existing employee
                var user = userRep.Read(id);

                if (user == null)
                {
                    res.SetError("Khong tim thay user");
                }
                // Delete the employee from the database
                userRep.DeleteUser(user);
                res.SetMessage("Xoa user thanh cong");
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
                res.SetMessage("Xoa user that bai");
            }

            return res;
        }

        public SingleRsp GetUserByUsername(string username)
        {
            var res = new SingleRsp();
            res.Data = userRep.GetUserByUsername(username);
            if (res.Data == null)

            {
                res.SetMessage("Khong tim thay user");
                res.SetError("404", "Khong tim thay user");
            }
            return res;
        }
    }
}
