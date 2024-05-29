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
    public class CustomerSvc : GenericSvc<CustomerRep, Customer>
    {
        private CustomerRep customerRep;

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
        public SingleRsp DeleteCustomer(int id)
        {
            var res = new SingleRsp();
            try
            {
                var customer = customerRep.Read(id);
                if (customer == null)
                {
                    res.SetError("Khong tim thay customer");
                }
                // Delete the employee from the database
                customerRep.DeleteCustomer(customer);
                res.SetMessage("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
                res.SetMessage("Failed to delete customer.");
            }

            return res;
        }

        //thêm 

        public SingleRsp CreateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();
            Customer customer = new Customer();
            customer.Surname= customerReq.Surname;
            customer.FirstName = customerReq.FirstName;
            customer.Title= customerReq.Title;
            customer.EmailCus= customerReq.EmailCus;
            customer.PhoneNumber= customerReq.PhoneNumber;
            customer.BuildingNumber = customerReq.BuildingNumber;
            customer.City= customerReq.City;
            customer.Country= customerReq.Country;
            customer.Area= customerReq.Area;
            res = customerRep.CreateCustomer(customer);

            return res;
        }

        //Cập nhật 
        public SingleRsp UpdateCustomer(int id, CustomerReq customerReq)
        {
            var res = new SingleRsp();
            var customer = customerRep.Read(id);
            customer.Surname = customerReq.Surname;
            customer.FirstName = customerReq.FirstName;
            customer.Title = customerReq.Title;
            customer.EmailCus = customerReq.EmailCus;
            customer.PhoneNumber = customerReq.PhoneNumber;
            customer.BuildingNumber = customerReq.BuildingNumber;
            customer.City = customerReq.City;
            customer.Country = customerReq.Country;
            customer.Area = customerReq.Area;
            res = customerRep.UpdateCustomer(customer);
            return res;
        }

        public object SearchCustomer(SearchCustomerReq s)
        {
            var res = new SingleRsp();
            //Lấy ds sp
            var customers = customerRep.SearchCustomer(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = customers.Count;
            totalPages = (pCount % s.Size) == 0 ? pCount / s.Size : 1 + (pCount / s.Size);
            var p = new
            {
                Data = customers.Skip(offset).Take(s.Size).ToList(),
                page = s.Page,
                Size = s.Size
            };
            res.Data = p;
            return res;
        }
        public CustomerSvc()
        {
            customerRep = new CustomerRep();
        }
    }

}
