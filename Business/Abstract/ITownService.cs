using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITownService
    {
        IResult Add(Town town);
        IResult Update(Town town);
        IResult Delete(Town town);
        IDataResult<Town> GetByName(string name);
        IDataResult<Town> GetById(int id);
        IDataResult<List<Town>> GetAll();
    }
}
