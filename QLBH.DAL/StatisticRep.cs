using QLBH.Common.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{
    public class StatisticRep : GenericRep<ShopContext, Order>
    {
        private readonly ShopContext shop;

        public StatisticRep()
        {
            shop = new ShopContext();
        }

        public decimal GetTotalRevenueByYear(int year)
        {
            var total = shop.Orders
                .Where(s => s.OrdersDate.HasValue && s.OrdersDate.Value.Year == year)
                .Sum(s => (s.Quantity * s.Price) ?? 0);
            return total;
        }

        public Dictionary<int, decimal> GetTotalRevenueByMonth(int year)
        {
            var monthlyRevenue = shop.Orders
                .Where(s => s.OrdersDate.HasValue && s.OrdersDate.Value.Year == year)
                .GroupBy(s => s.OrdersDate.Value.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Total = g.Sum(s => (decimal?)(s.Quantity * s.Price) ?? 0)
                })
                .ToDictionary(x => x.Month, x => x.Total);

            return monthlyRevenue;
        }

        public Dictionary<int, int> GetTotalOrdersByCustomer()
        {
            var ordersByCustomer = shop.Orders
                .GroupBy(order => order.CustomerId)
                .Select(group => new
                {
                    CustomerId = group.Key,
                    OrderCount = group.Count()
                })
                .ToDictionary(x => x.CustomerId, x => x.OrderCount);

            return ordersByCustomer;
        }
    }
}
