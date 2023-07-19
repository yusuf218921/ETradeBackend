using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.Entityframework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.Entityframework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ETradeContext>, IUserDal
    {
    }
}
