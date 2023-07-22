using Business.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdressManager : IAdressService
    {
        IAdressDal _adressDal;

        public AdressManager(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public IResult Add(Adress adress)
        {
            _adressDal.Add(adress);
            return new SuccessResult();
        }

        public IResult Delete(Adress adress)
        {
            _adressDal.Delete(adress);
            return new SuccessResult();
        }

        public IDataResult<List<AdressDetailDto>> GetDetail(int id)
        {
            return new Core.Utilities.Results.SuccessDataResult<List<AdressDetailDto>>(_adressDal.GetAdressDetail(id).ToList());
        }

        

        public IResult Update(Adress adress)
        {
            _adressDal.Update(adress);
            return new SuccessResult();
        }
    }
}
