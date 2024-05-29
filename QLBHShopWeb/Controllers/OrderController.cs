using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBHShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderSvc orderSvc;
        public OrderController()
        {
            orderSvc = new OrderSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetOrderByID(int id)
        {
            var res = new SingleRsp();
            res = orderSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("get_Alll")]
        public IActionResult GetOrderAll()
        {
            var res = new SingleRsp();
            res.Data = orderSvc.All;
            return Ok(res);
        }
        [HttpDelete("delete-Order")]
        public IActionResult DeleteOrder(int id)
        {
            var res = orderSvc.DeleteOrder(id);
            return Ok(res);
        }


        [HttpPost("Create-Order")]
        public IActionResult CreateOrder([FromBody] OrderReq orderReq)
        {
            var res = new SingleRsp();
            res = orderSvc.CreateOrder(orderReq);
            return Ok(res);
        }

        [HttpPut("UpdateOrder/{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderReq orderReq)
        {
            var res = orderSvc.UpdateOrder(id, orderReq);
            return Ok(res);
        }
    }
}
