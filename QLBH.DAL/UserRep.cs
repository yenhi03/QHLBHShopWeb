using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{
    public class UserRep : GenericRep<ShopContext, User>
    {
        public UserRep() { }

        public override User Read(int id)
        {
            var res = All.FirstOrDefault(e => e.UserId == id);
            return res;
        }

        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            var context = new ShopContext();
            using (var tran = context.Database.BeginTransaction())
            {
                var checkuser = context.Users.FirstOrDefault(u => u.Name == user.Name || u.Email == user.Email);
                if (checkuser == null)
                {
                    try
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Tao user thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Tao user that bai");
                    }
                }
                else
                {
                    res.SetMessage("User da ton tai");
                    return res;
                }
            }
            return res;
        }

        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();

            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Users.Update(user);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update user thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update user that bai");
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteUser(User user)
        {
            var res = new SingleRsp();

            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Da xoa user");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Xoa that bai");
                    }
                }
            }
            return res;
        }

        public User GetUserByUsername(string username)
        {
            var res = All.FirstOrDefault(e => e.Name == username);
            return res;
        }
    }
}
