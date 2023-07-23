using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class TelNumberManager : ITelNumberService
    {
        ITelNumberDal _TelNumberDal;

        public TelNumberManager(ITelNumberDal telNumberDal)
        {
            _TelNumberDal = telNumberDal;
        }
        [ValidationAspect(typeof(TelValidator))]
        public IResult Add(TelNumber telNumber)
        {
            var result = BusinessRules.Run(CheckIfTelNumberExists(telNumber));
            if (result != null)
                return result;
            _TelNumberDal.Add(telNumber);
            return new SuccessResult();
        }

        public IResult Delete(TelNumber telNumber)
        {
            _TelNumberDal.Delete(telNumber);
            return new SuccessResult();
        }

        public IDataResult<List<TelNumber>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<TelNumber>>(_TelNumberDal.GetAll(t=> t.UserID == userId).ToList());
        }
        [ValidationAspect(typeof(TelValidator))]
        public IResult Update(TelNumber telNumber)
        {
            var result = BusinessRules.Run(CheckIfTelNumberExists(telNumber));
            if (result != null)
                return result;
            _TelNumberDal.Update(telNumber);
            return new SuccessResult();
        }
        private IResult CheckIfTelNumberExists(TelNumber telNumber)
        {
            if (_TelNumberDal.Get(t => t.PhoneNumber == telNumber.PhoneNumber) == null)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
