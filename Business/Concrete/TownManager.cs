using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.BusinessRules;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TownManager : ITownService
    {
        ITownDal _townDal;

        public TownManager(ITownDal townDal)
        {
            _townDal = townDal;
        }

        [SecuredOperation("admin,moderator")]
        public IResult Add(Town town)
        {
            var result = BusinessRules.Run();
            if (result != null)
                return result;
            _townDal.Add(town);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(Town town)
        {
            _townDal.Delete(town);
            return new SuccessResult();
        }

        public IDataResult<List<Town>> GetAll()
        {
            return new Core.Utilities.Results.SuccessDataResult<List<Town>>(_townDal.GetAll().ToList());
        }

        public IDataResult<Town> GetById(int id)
        {
            return new Core.Utilities.Results.SuccessDataResult<Town>(_townDal.Get(c => c.CityID == id));
        }

        public IDataResult<Town> GetByName(string name)
        {
            return new Core.Utilities.Results.SuccessDataResult<Town>(_townDal.Get(c => c.TownName == name));
        }
        [SecuredOperation("admin,moderator")]
        public IResult Update(Town town)
        {
            var result = BusinessRules.Run();
            if (result != null)
                return result;
            _townDal.Update(town);
            return new SuccessResult();
        }
    }
}
