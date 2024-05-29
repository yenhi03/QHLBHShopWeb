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
    public class EmployeeRep : GenericRep<ShopContext, Employee>
    {
        #region -- Overrides --
        //Select 
        public override Employee Read(int id)
        {
            var res = All.FirstOrDefault(e => e.EmployeeId== id);
            return res;
        }


        #endregion
        #region -- Methods --


        //Xóa theo id

        public int Remove(int id)
        {
            var m = base.All.First(e => e.EmployeeId == id);
            m = base.Delete(m);
            return m.EmployeeId;
        }

        public SingleRsp DeleteEmployee(Employee employee)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Employees.Remove(employee);
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

        //Tìm kiếm Employee theo name 
        public List<Employee> SearchEmployee(string keyWord)
        {
            return All.Where(x => x.Name.Contains(keyWord)).ToList();

        }


        #region -- Methods --
        //thêm
        public SingleRsp CreateEmployee(Employee employee)
        {
            var res = new SingleRsp();
            var context = new ShopContext();
            using (var tran = context.Database.BeginTransaction())
            {
                try
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetMessage("Tao Employee thanh cong");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage("Tao Employee that bai");
                }

            }
            return res;
        }
        #endregion
        //Cập nhật
        public SingleRsp UpdateEmployee(Employee employee)
        {
            var res = new SingleRsp();
            using (var context = new ShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Employees.Update(employee);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Employee thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Employee that bai");
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
