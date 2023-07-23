using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderLineService
    {
        IResult Add(OrderLine orderLine);
        IResult Delete(OrderLine orderLine);
        IResult Update(OrderLine orderLine);
        IDataResult<List<OrderLine>> GetByOrderId(int orderId);
        IDataResult<OrderLine> GetById(int id);
        IDataResult<List<OrderLine>> GetAll();
        IDataResult<List<OrderLineDetailDto>> GetOrderLineDetail(int orderId);
    }
}
