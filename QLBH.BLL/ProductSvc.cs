using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QLBH.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;

        //Select hết sp
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res; 
        }

        #endregion
        //Xóa sp theo id
        public SingleRsp DeleteProduct(int id)
        {
            var res = new SingleRsp();
            try
            {
                var product = productRep.Read(id);
                if (product == null)
                {
                    res.SetError("Khong tim thay product");
                }
                // Delete the employee from the database
                productRep.DeleteProduct(product);
                res.SetMessage("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
                res.SetMessage("Failed to delete PRODUCT.");
            }

            return res;
        }

        //thêm Sp

        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.CategoryId = productReq.CategoryId;
            product.Item = productReq.Item;
            product.Price = productReq.Price;
            product.Quantity = productReq.Quantity;
            res = productRep.CreateProduct(product);
                
            return res;
        }

        //Cập nhật san phẩm
        public SingleRsp UpdateProduct(int id, ProductReq productReq)
        {
            var res = new SingleRsp();
            var product = productRep.Read(id);
            product.CategoryId = productReq.CategoryId;
            product.Item = productReq.Item;
            product.Price = productReq.Price;
            product.Quantity = productReq.Quantity;
            res = productRep.UpdateProduct(product);
            return res;
        }
        //tìm kiếm id
        public object SearchProduct(SearchProductReq s)
        {
            var res = new SingleRsp();
            //Lấy ds sp
            var products = productRep.SearchProduct(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset=s.Size * (s.Page- 1);
            pCount = products.Count;
            totalPages = (pCount % s.Size) == 0? pCount / s.Size : 1 + (pCount / s.Size);
            var p = new
            {
                Data = products.Skip(offset).Take(s.Size).ToList(),
                page = s.Page,
                Size = s.Size
            };
            res.Data= p;
            return res;
        }
        // tìm kiếm theo khoảng giá
        public SingleRsp SearchProductInPriceRange(int minPrice, int maxPrice)
        {
            var res = productRep.SearchProductInPriceRange(minPrice, maxPrice);
            return res;
        }
        public ProductSvc()
        { 
            productRep = new ProductRep();
        }
    }
}
