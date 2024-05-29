using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static QLBH.BLL.StatisticSvc;

namespace QLBHShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly StatisticService _statisticService;

        public StatisticController()
        {
            _statisticService = new StatisticService();
        }

        [HttpPost("annual-revenue/{year}")]
        public ActionResult<decimal> GetAnnualRevenue(int year)
        {
            var result = _statisticService.GetTotalRevenueByYear(year);
            return Ok(result);
        }

        [HttpPost("monthly-revenue/{year}")]
        public ActionResult<Dictionary<int, decimal>> GetMonthlyRevenue(int year)
        {
            var result = _statisticService.GetTotalRevenueByMonth(year);
            return Ok(result);

        }

        [HttpGet("customer-orders")]
        public IActionResult GetTotalOrdersByCustomer()
        {
            try
            {
                var result = _statisticService.GetTotalOrdersByCustomer();
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
