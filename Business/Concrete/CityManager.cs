using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.BusinessRules;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        [SecuredOperation("admin,moderator")]
        public IResult Add(City city)
        {
            var result = BusinessRules.Run();
            if (result != null)
                return result;
            _cityDal.Add(city);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult();
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll().ToList());
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c=> c.CityID == id));
        }

        public IDataResult<City> GetByName(string name)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.CityName == name));
        }
        [SecuredOperation("admin,moderator")]
        public IResult Update(City city)
        {
            var result = BusinessRules.Run();
            if (result != null)
                return result;
            _cityDal.Update(city);
            return new SuccessResult();
        }
    }
}
