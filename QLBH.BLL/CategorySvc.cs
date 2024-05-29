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

namespace QLBH.BLL
{
    public class CategorySvc:GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        //Xóa sp theo id
        public SingleRsp DeleteCategory(int id)
        {
            var res = new SingleRsp();
            try
            {
                var category = categoryRep.Read(id);
                if (category == null)
                {
                    res.SetError("Khong tim thay category ");
                }
                // Delete the employee from the database
                categoryRep.DeleteCategory(category);
                res.SetMessage("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
                res.SetMessage("Failed to delete category.");
            }

            return res;
        }

        //thêm Sp

        public SingleRsp CreateCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.Name= categoryReq.Name;
            res = categoryRep.CreateCategory(category);

            return res;
        }
        //cập nhật
        public SingleRsp UpdateCategory(int id, CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            var category = categoryRep.Read(id);
            category.Name = categoryReq.Name;
            res = categoryRep.UpdateCategory(category);
            return res;
        }

        public object SearchCategory(SearchCategoryReq s)
        {
            var res = new SingleRsp();
            //Lấy ds sp
            var categorys = categoryRep.SearchCategory(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = categorys.Count;
            totalPages = (pCount % s.Size) == 0 ? pCount / s.Size : 1 + (pCount / s.Size);
            var p = new
            {
                Data = categorys.Skip(offset).Take(s.Size).ToList(),
                page = s.Page,
                Size = s.Size
            };
            res.Data = p;
            return res;
        }
    }
}
