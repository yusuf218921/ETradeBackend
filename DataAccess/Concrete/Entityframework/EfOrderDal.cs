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
    public class EfOrderDal : EfEntityRepositoryBase<Order, ETradeContext>, IOrderDal
    {
        public List<OrderDetailDto> GetDetail(int userId)
        {
            using (ETradeContext  context = new ETradeContext())
            {
                var result = from o in context.Orders
                             join user in context.Users on o.UserID equals user.UserID
                             join adress in context.Adresses on o.AdressID equals adress.AdressID
                             where o.UserID == userId
                             select new OrderDetailDto()
                             {
                                OrderID = o.OrderID,
                                Firstname = user.Firstname,
                                Lastname = user.Lastname,
                                AdressText = adress.AdressText,
                                Date = o.Date,
                                TotalPrice = o.TotalPrice, 
                             };
                return result.ToList();
            }
        }
    }
}
