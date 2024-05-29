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
    public class CustomerRep : GenericRep<ShopContext, Customer>
    {
        #region -- Overrides --
        //Select 
        public override Customer Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CustomerId == id);
            return res;
        }


        #endregion
        #region -- Methods --


        //Xóa theo id

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CustomerId == id);
            m = base.Delete(m);
            return m.CustomerId;
        }

        public SingleRsp DeleteCustomer(Customer customer)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Da xoa");
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

        //Tìm kiếm customer theo firstname 
        public List<Customer> SearchCustomer(string keyWord)
        {
            return All.Where(x => x.FirstName.Contains(keyWord)).ToList();

        }


        #region -- Methods --
        //thêm Sp
        public SingleRsp CreateCustomer(Customer customer)
        {
            var res = new SingleRsp();
            var context = new ShopContext();
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetMessage("Tao Customer thanh cong");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage("Tao Customer that bai");
                }

            }
            return res;
        }
        #endregion
        //Cập nhật san phẩm
        public SingleRsp UpdateCustomer(Customer customer)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customers.Update(customer);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Customer thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Customer that bai");
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
