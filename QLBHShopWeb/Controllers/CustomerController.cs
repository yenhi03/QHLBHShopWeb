using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBHShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerSvc customerSvc;
        public CustomerController()
        {
            customerSvc = new CustomerSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetCustomerByID(int id)
        {
            var res = new SingleRsp();
            res = customerSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("get_Alll")]
        public IActionResult GetCustomerAll()
        {
            var res = new SingleRsp();
            res.Data = customerSvc.All;
            return Ok(res);
        }
        [HttpDelete("delete-customer")]
        public IActionResult DeleteCustomer(int id)
        {
            var res = customerSvc.DeleteCustomer(id);
            return Ok(res);
        }


        [HttpPost("Create-customer")]
        public IActionResult CreateCustomer([FromBody] CustomerReq customerReq)
        {
            var res = new SingleRsp();
            res = customerSvc.CreateCustomer(customerReq);
            return Ok(res);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerReq customerReq)
        {
            var res = customerSvc.UpdateCustomer(id,customerReq);
            return Ok(res);
        }
        [HttpPost("Search-Customer")]
        public IActionResult SearchCustomer([FromBody] SearchCustomerReq searchCustomerReq)
        {
            //tao bien tra ve la SingleRespone
            var res = new SingleRsp();
            //Goi ham Read o lop Svc
            res.Data = customerSvc.SearchCustomer(searchCustomerReq);
            return Ok(res);
        }
    }
}
