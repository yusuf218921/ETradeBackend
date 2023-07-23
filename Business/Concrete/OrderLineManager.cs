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
    public class OrderLineManager : IOrderLineService
    {
        IOrderLineDal _orderLineDal;
        IProductService _productManager;

        public OrderLineManager(IProductService productManager, IOrderLineDal orderLineDal)
        {
            _productManager = productManager;
            _orderLineDal = orderLineDal;
        }
        [SecuredOperation("admin,moderator,user")]
        [ValidationAspect(typeof(OrderLineValidator))]
        public IResult Add(OrderLine orderLine)
        {
            var result = BusinessRules.Run(CheckIfEqualsProductPriceAndUnitPrice(orderLine),CheckIfTotalPricaCalculateCorrect(orderLine));
            if (result != null)
                return result;
            _orderLineDal.Add(orderLine);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(OrderLine orderLine)
        {
            _orderLineDal.Delete(orderLine);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator")]
        public IDataResult<List<OrderLine>> GetAll()
        {
            throw new NotImplementedException();
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<OrderLine> GetById(int id)
        {
            return new SuccessDataResult<OrderLine>(_orderLineDal.Get(o=> o.OrderLineID == id));
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<List<OrderLine>> GetByOrderId(int orderId)
        {
            return new SuccessDataResult<List<OrderLine>>(_orderLineDal.GetAll(o => o.OrderID == orderId).ToList());
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<List<OrderLineDetailDto>> GetOrderLineDetail(int orderId)
        {
            return new SuccessDataResult<List<OrderLineDetailDto>>(_orderLineDal.GetDetail(orderId));
        }
        [SecuredOperation("admin,moderator,user")]
        [ValidationAspect(typeof(OrderLineValidator))]
        public IResult Update(OrderLine orderLine)
        {
            var result = BusinessRules.Run(CheckIfEqualsProductPriceAndUnitPrice(orderLine), CheckIfTotalPricaCalculateCorrect(orderLine));
            if (result != null)
                return result;
            _orderLineDal.Update(orderLine);
            return new SuccessResult();
        }
        private IResult CheckIfEqualsProductPriceAndUnitPrice(OrderLine orderLine)
        {
            if (orderLine.UnitPrice == _productManager.GetById(orderLine.ProductID).Data.UnitPrice)
                return new SuccessResult();
            return new ErrorResult();
        }
        private IResult CheckIfTotalPricaCalculateCorrect(OrderLine orderLine)
        {
            if (orderLine.UnitTotal == orderLine.Amount * orderLine.UnitPrice)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
