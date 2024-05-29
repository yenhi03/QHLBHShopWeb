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
    public class CategoryRep:GenericRep<ShopContext, Category>
    {
        public CategoryRep()
        {

        }
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(C => C.CategoryId == id);
            return res;
        }

        //Xóa category theo id

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }

        public SingleRsp DeleteCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Categories.Remove(category);
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

        //thêm Category
        public SingleRsp CreateCategory(Category category)
        {
            var res = new SingleRsp();
            var context = new ShopContext();
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetMessage("Tao Category thanh cong");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage("Tao Category that bai");
                }

            }
            return res;
        }

        //cập nhật category
        public SingleRsp UpdateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Categories.Update(category);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Category thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Category that bai");
                    }
                }
            }
            return res;
        }

        public List<Category> SearchCategory(string keyWord)
        {
            return All.Where(x => x.Name.Contains(keyWord)).ToList();

        }

    }
}
