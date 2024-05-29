using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBHShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController() 
        {
            categorySvc= new CategorySvc();

        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(id);
            return Ok(res);
        }

        [HttpGet("get_Alll")]
        public IActionResult GetCategoryAll()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
        [HttpDelete("delete-product")]
        public IActionResult DeleteCategory(int id)
        {
            var res = categorySvc.DeleteCategory(id);
            return Ok(res);
        }


        [HttpPost("Create-product")]
        public IActionResult CreateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.CreateCategory(categoryReq);
            return Ok(res);
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryReq categoryReq)
        {
            var res = categorySvc.UpdateCategory(id, categoryReq);
            return Ok(res);
        }

        [HttpPost("Search-Category")]
        public IActionResult SearchCategory([FromBody] SearchCategoryReq searchCategoryReq)
        {
            //tao bien tra ve la SingleRespone
            var res = new SingleRsp();
            //Goi ham Read o lop Svc
            res.Data = categorySvc.SearchCategory(searchCategoryReq);
            return Ok(res);
        }
    }
}
