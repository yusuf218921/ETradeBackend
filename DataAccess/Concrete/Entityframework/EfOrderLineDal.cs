using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfOrderLineDal : EfEntityRepositoryBase<OrderLine, ETradeContext>, IOrderLineDal
    {
        public List<OrderLineDetailDto> GetDetail(int orderId)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = from ol in context.OrderLines
                             join p in context.Products on ol.ProductID equals p.ProductID
                             join o in context.Orders on ol.OrderID equals o.OrderID
                             where o.OrderID == orderId
                             select new OrderLineDetailDto()
                             {
                                 OrderID = o.OrderID,
                                 OrderLineID = ol.OrderLineID,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 UnitTotal = ol.UnitTotal,
                                 Amount = ol.Amount
                             };
                return result.ToList();
            }
        }
    }
}
