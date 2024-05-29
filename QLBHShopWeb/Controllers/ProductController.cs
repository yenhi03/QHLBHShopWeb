using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBHShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetProductByID(int id)
        {
            var res = new SingleRsp();
            res = productSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("get_Alll")]
        public IActionResult GetProductAll()
        {
            var res = new SingleRsp();
            res.Data = productSvc.All;
            return Ok(res);
        }
        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(int id)
        {
            var res = productSvc.DeleteProduct(id);
            return Ok(res);
        }


        [HttpPost("Create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductReq productReq )
        {
            var res = productSvc.UpdateProduct(id, productReq);
            return Ok(res);
        }
        [HttpPost("Search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            //tao bien tra ve la SingleRespone
            var res = new SingleRsp();
            //Goi ham Read o lop Svc
            res.Data = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }

        [HttpPost("search-product-by-price-range")]
        public IActionResult SearchProductByPriceRange(int minPrice, int maxPrice)
        {
            //tao bien tra ve la SingleRespone
            var rsp = new SingleRsp();
            //Goi ham Read o lop Svc
            rsp = productSvc.SearchProductInPriceRange(minPrice, maxPrice);
            return Ok(rsp);
        }

    }
}
