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
    public class SupplierRep : GenericRep<ShopContext, Supplier>
    {
        #region -- Overrides --
        //Select  sp theo id
        public override Supplier Read(int id)
        {
            var res = All.FirstOrDefault(s => s.SupplierId == id);
            return res;
        }


        #endregion
        #region -- Methods --


        //Xóa sp theo id

        public int Remove(int id)
        {
            var m = base.All.First(i => i.SupplierId == id);
            m = base.Delete(m);
            return m.SupplierId;
        }

        public SingleRsp DeleteSupplier(Supplier supplier)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Suppliers.Remove(supplier);
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

        //Tìm kiếm sản phẩm theo Item
        public List<Supplier> SearchSupplier(string keyWord)
        {
            return All.Where(x => x.Company.Contains(keyWord)).ToList();

        }


        #region -- Methods --
        //thêm Sp
        public SingleRsp CreateSupplier(Supplier supplier)
        {
            var res = new SingleRsp();
            var context = new ShopContext();
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Suppliers.Add(supplier);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetMessage("Tao Supplier thanh cong");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage("Tao Supplier that bai");
                }

            }
            return res;
        }
        #endregion
        //Cập nhật san phẩm
        public SingleRsp UpdateSupplier(Supplier supplier)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Suppliers.Update(supplier);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Supplier thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Supplier that bai");
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
