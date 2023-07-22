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
    public interface IAdressService
    {
        IDataResult<List<AdressDetailDto>> GetDetail(int id);
        IResult Add(Adress adress);
        IResult Update(Adress adress);
        IResult Delete(Adress adress);
    }
}
