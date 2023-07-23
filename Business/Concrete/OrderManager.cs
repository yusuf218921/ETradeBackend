using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IOrderLineService _orderLineService;

        public OrderManager(IOrderDal orderDal, IOrderLineService orderLineService)
        {
            _orderDal = orderDal;
            _orderLineService = orderLineService;
        }
        [SecuredOperation("admin,moderator,user")]
        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(Order order)
        {
            var result = BusinessRules.Run(CheckIfTotalPriceCorrect(order));
            if (result != null)
            {
                return result;
            }
            _orderDal.Add(order);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator,user")]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator")]
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll().ToList());
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<List<Order>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o=> o.UserID == userId).ToList());
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<List<OrderDetailDto>> GetDetail(int userId)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDal.GetDetail(userId));
        }
        [SecuredOperation("admin,moderator,user")]
        [ValidationAspect(typeof(OrderValidator))]
        public IResult Update(Order order)
        {
            var result = BusinessRules.Run(CheckIfTotalPriceCorrect(order));
            if (result != null)
            {
                return result;
            }
            _orderDal.Update(order);
            return new SuccessResult();
        }
        private IResult CheckIfTotalPriceCorrect(Order order)
        {
            var result = _orderLineService.GetByOrderId(order.OrderID);
            decimal totalPrice = 0;
            foreach (var item in result.Data)
            {
                totalPrice += item.UnitTotal;
            }
            if (order.TotalPrice == totalPrice)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
