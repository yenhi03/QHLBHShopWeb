using QLBH.Common.Rsp;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BLL
{
    public class StatisticSvc
    {
        public class StatisticService
        {
            private readonly StatisticRep _statisticRep;

            public StatisticService()
            {
                _statisticRep = new StatisticRep();
            }

            public SingleRsp GetTotalRevenueByYear(int year)
            {
                var res = new SingleRsp();
                var total= _statisticRep.GetTotalRevenueByYear(year);
                var result = new
                {
                    Year = year,
                    TongDoanhThu = total
                };
                res.Data= result;
                return res;
            }

            public SingleRsp GetTotalRevenueByMonth(int year)
            {
                var res = new SingleRsp();
                try
                {
                    var monthlyRevenue = _statisticRep.GetTotalRevenueByMonth(year);
                    var result = new
                    {
                        Year = year,
                        MonthlyRevenue = monthlyRevenue
                    };
                    res.Data = result;
                }
                catch (Exception ex)
                {
                    res.SetError(ex.StackTrace);
                }
                return res;
            }

            public SingleRsp GetTotalOrdersByCustomer()
            {
                var res = new SingleRsp();
                try
                {
                    var ordersByCustomer = _statisticRep.GetTotalOrdersByCustomer();
                    res.Data = ordersByCustomer;
                }
                catch (Exception ex)
                {
                    res.SetError(ex.StackTrace);
                }
                return res;
            }
        }

    }
}
