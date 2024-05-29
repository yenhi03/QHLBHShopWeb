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
    public class OrderRep : GenericRep<ShopContext, Order>
    {
        #region -- Overrides --
        //Select 
        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrdersId == id);
            return res;
        }


        #endregion
        #region -- Methods --


        //Xóa theo id

        public int Remove(int id)
        {
            var m = base.All.First(o => o.OrdersId == id);
            m = base.Delete(m);
            return m.OrdersId;
        }

        public SingleRsp DeleteOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Remove(order);
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

        #region -- Methods --
        //thêm
        public SingleRsp CreateOrder(Order order)
        {
            var res = new SingleRsp();
            var context = new ShopContext();
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetMessage("Tao Order thanh cong");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage("Tao Order that bai");
                }

            }
            return res;
        }
        #endregion
        //Cập nhật
        public SingleRsp UpdateOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Update(order);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Order thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Order that bai");
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
