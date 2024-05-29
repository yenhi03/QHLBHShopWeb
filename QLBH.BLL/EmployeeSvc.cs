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
    public class EmployeeSvc : GenericSvc<EmployeeRep, Employee>
    {
        private EmployeeRep employeeRep;

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
        public SingleRsp DeleteEmployee(int id)
        {
            var res = new SingleRsp();
            try
            {
                var employee = employeeRep.Read(id);
                if (employee == null)
                {
                    res.SetError("Khong tim thay Employee");
                }
                // Delete the employee from the database
                employeeRep.DeleteEmployee(employee);
                res.SetMessage("Xoa thanh cong");
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
                res.SetMessage("Failed to delete Employee.");
            }

            return res;
        }

        //thêm 

        public SingleRsp CreateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            Employee employee = new Employee();
            employee.UserId= employeeReq.UserId;
            employee.Name= employeeReq.Name;
            employee.Position= employeeReq.Position;
            employee.Salary= employeeReq.Salary;
            employee.HireDate= employeeReq.HireDate;
            res = employeeRep.CreateEmployee(employee);

            return res;
        }

        //Cập nhật 
        public SingleRsp UpdateEmployee(int id, EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            var employee = employeeRep.Read(id);
            employee.Name = employeeReq.Name;
            employee.Position = employeeReq.Position;
            employee.Salary = employeeReq.Salary;
            employee.HireDate = employeeReq.HireDate;
            res = employeeRep.UpdateEmployee(employee);
            return res;
        }

        public object SearchEmployee(SearchEmployeeReq s)
        {
            var res = new SingleRsp();
            //Lấy ds sp
            var employees = employeeRep.SearchEmployee(s.Keyword);
            //xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = employees.Count;
            totalPages = (pCount % s.Size) == 0 ? pCount / s.Size : 1 + (pCount / s.Size);
            var p = new
            {
                Data = employees.Skip(offset).Take(s.Size).ToList(),
                page = s.Page,
                Size = s.Size
            };
            res.Data = p;
            return res;
        }
        public EmployeeSvc()
        {
            employeeRep = new EmployeeRep();
        }
    }
}
