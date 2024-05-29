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
    public class ProductRep : GenericRep<ShopContext, Product>
    {
        #region -- Overrides --
        //Select  sp theo id
        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductsId == id);
            return res;
        }


        #endregion
        #region -- Methods --


        //Xóa sp theo id

        public int Remove(int id)
        {
            var m = base.All.First(i => i.ProductsId == id);
            m = base.Delete(m);
            return m.ProductsId;
        }

        public SingleRsp DeleteProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Products.Remove(product);
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
        public List<Product> SearchProduct(string keyWord)
        {
            return All.Where(x => x.Item.Contains(keyWord)).ToList();
         
        }
        //tìm kiếm sp theo khoảng giá

        public SingleRsp SearchProductInPriceRange(int minPrice, int maxPrice)
        {
            var res = new SingleRsp();

            using (var context = new ShopContext())
            {
                if (minPrice > maxPrice)
                {
                    res.SetError("400", "Nhap gia min cao hon gia max");
                }
                else
                {
                    res.Data = context.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
                    if (res.Data == null)
                    {
                        res.SetError("404", "Khong tim thay san pham");
                    }
                }
            }
            return res;
        }

        #region -- Methods --
        //thêm Sp
        public SingleRsp CreateProduct(Product product)
        {
            var res = new SingleRsp();
            var context = new ShopContext();
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetMessage("Tao Prodcuct thanh cong");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage("Tao Product that bai");
                }

            }
            return res;
        }
        #endregion
        //Cập nhật san phẩm
        public SingleRsp UpdateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Products.Update(product);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Product thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Product that bai");
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
