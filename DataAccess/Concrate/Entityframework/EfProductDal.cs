﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.Entityframework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.Entityframework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ETradeContext> , IProductDal
    {
    }
}
