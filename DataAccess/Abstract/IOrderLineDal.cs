using Core.DataAccess;
using Core.Entities.Concrate;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderLineDal : IEntityRepository<OrderLine>
    {
        List<OrderLineDetailDto> GetDetail(int userId);
    }
}
