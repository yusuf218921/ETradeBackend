﻿using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITelNumberService
    {
        IResult Add(TelNumber telNumber);
        IResult Update(TelNumber telNumber);
        IResult Delete(TelNumber telNumber);
        IDataResult<List<TelNumber>> GetByUserId(int userId);
    }
}
