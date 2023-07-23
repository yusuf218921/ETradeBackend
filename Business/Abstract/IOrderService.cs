

using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
        IDataResult<List<Order>> GetByUserId(int userId);
        IDataResult<List<Order>> GetAll();
        IDataResult<List<OrderDetailDto>> GetDetail(int userId);
    }
}
