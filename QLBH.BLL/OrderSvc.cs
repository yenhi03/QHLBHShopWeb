using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BLL
{
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        private OrderRep orderRep;

        //Select 
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        #endregion
        //Xóa
        public SingleRsp DeleteOrder(int id)
        {
            var res = new SingleRsp();
            try
            {
                var order = orderRep.Read(id);
                if (order == null)
                {
                    res.SetError("Khong tim thay Order");
                }
                // Delete the Order from the database
                orderRep.DeleteOrder(order);
                res.SetMessage("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
                res.SetMessage("Failed to delete Order.");
            }

            return res;
        }

        //thêm 

        public SingleRsp CreateOrder(OrderReq orderReq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.CustomerId = orderReq.CustomerId;
            order.ProductsId= orderReq.ProductsId;
            order.Price= orderReq.Price;
            order.Quantity= orderReq.Quantity;
            order.Month= orderReq.Month;
            order.Year= orderReq.Year;
            order.OrdersDate= orderReq.OrdersDate;
            res = orderRep.CreateOrder(order);

            return res;
        }

        //Cập nhật 
        public SingleRsp UpdateOrder(int id, OrderReq orderReq)
        {
            var res = new SingleRsp();
            var order = orderRep.Read(id);
            order.CustomerId = orderReq.CustomerId;
            order.ProductsId = orderReq.ProductsId;
            order.Price = orderReq.Price;
            order.Quantity = orderReq.Quantity;
            order.Month = orderReq.Month;
            order.Year = orderReq.Year;
            order.OrdersDate = orderReq.OrdersDate;
            res = orderRep.UpdateOrder(order);
            return res;
        }
        public OrderSvc()
        {
            orderRep = new OrderRep();
        }
    }
}
