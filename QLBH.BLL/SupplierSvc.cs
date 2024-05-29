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
    public class SupplierSvc : GenericSvc<SupplierRep, Supplier>
    {
        private SupplierRep supplierRep;

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
        public SingleRsp DeleteSupplier(int id)
        {
            var res = new SingleRsp();
            try
            {
                var supplier = supplierRep.Read(id);
                if (supplier == null)
                {
                    res.SetError("Khong tim thay product");
                }
                // Delete the  from the database
                supplierRep.DeleteSupplier(supplier);
                res.SetMessage("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
                res.SetMessage("Failed to delete PRODUCT.");
            }

            return res;
        }

        //thêm

        public SingleRsp CreateSupplier(SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            Supplier supplier = new Supplier();
            supplier.Company= supplierReq.Company;
            supplier.Country= supplierReq.Country;
            supplier.Material= supplierReq.Material;
            res = supplierRep.CreateSupplier(supplier);

            return res;
        }

        //Cập nhật san phẩm
        public SingleRsp UpdateSupplier(int id, SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            var supplier = supplierRep.Read(id);
            supplier.Company = supplierReq.Company;
            supplier.Country = supplierReq.Country;
            supplier.Material = supplierReq.Material;
            res = supplierRep.UpdateSupplier(supplier);
            return res;
        }

        public object SearchSupplier(SearchSupplierReq s)
        {
            var res = new SingleRsp();
            //Lấy ds sp
            var suppliers = supplierRep.SearchSupplier(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = suppliers.Count;
            totalPages = (pCount % s.Size) == 0 ? pCount / s.Size : 1 + (pCount / s.Size);
            var p = new
            {
                Data = suppliers.Skip(offset).Take(s.Size).ToList(),
                page = s.Page,
                Size = s.Size
            };
            res.Data = p;
            return res;
        }
        public SupplierSvc()
        {
            supplierRep = new SupplierRep();
        }
    }
}
