using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBHShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeSvc employeeSvc;
        public EmployeeController()
        {
            employeeSvc = new EmployeeSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetEmployeeByID(int id)
        {
            var res = new SingleRsp();
            res = employeeSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("get_Alll")]
        public IActionResult GetEmployeeAll()
        {
            var res = new SingleRsp();
            res.Data = employeeSvc.All;
            return Ok(res);
        }
        [HttpDelete("delete-Employee")]
        public IActionResult DeleteEmployee(int id)
        {
            var res = employeeSvc.DeleteEmployee(id);
            return Ok(res);
        }


        [HttpPost("Create-Employee")]
        public IActionResult CreateEmployee([FromBody] EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            res = employeeSvc.CreateEmployee(employeeReq);
            return Ok(res);
        }

        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeReq employeeReq)
        {
            var res = employeeSvc.UpdateEmployee(id, employeeReq);
            return Ok(res);
        }
        [HttpPost("Search-Employee")]
        public IActionResult SearchEmployee([FromBody] SearchEmployeeReq searchEmployeeReq)
        {
            //tao bien tra ve la SingleRespone
            var res = new SingleRsp();
            //Goi ham Read o lop Svc
            res.Data = employeeSvc.SearchEmployee(searchEmployeeReq);
            return Ok(res);
        }
    }
}
