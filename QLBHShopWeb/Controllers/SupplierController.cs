using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBHShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private SupplierSvc supplierSvc;
        public SupplierController()
        {
            supplierSvc = new SupplierSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetSupplierByID(int id)
        {
            var res = new SingleRsp();
            res = supplierSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("get_Alll")]
        public IActionResult GetSupplierAll()
        {
            var res = new SingleRsp();
            res.Data = supplierSvc.All;
            return Ok(res);
        }
        [HttpDelete("delete-Supplier")]
        public IActionResult DeleteSupplier(int id)
        {
            var res = supplierSvc.DeleteSupplier(id);
            return Ok(res);
        }


        [HttpPost("Create-Supplier")]
        public IActionResult CreateSupplier([FromBody] SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            res = supplierSvc.CreateSupplier(supplierReq);
            return Ok(res);
        }

        [HttpPut("UpdateSupplier/{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody] SupplierReq supplierReq)
        {
            var res = supplierSvc.UpdateSupplier(id, supplierReq);
            return Ok(res);
        }
        [HttpPost("Search-Supplier")]
        public IActionResult SearchSupplier([FromBody] SearchSupplierReq searchSupplierReq)
        {
            //tao bien tra ve la SingleRespone
            var res = new SingleRsp();
            //Goi ham Read o lop Svc
            res.Data = supplierSvc.SearchSupplier(searchSupplierReq);
            return Ok(res);
        }
    }
}
