using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ETradeContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ETradeContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.UserID
                             select new OperationClaim { OperationClaimID = operationClaim.OperationClaimID, OperationClaimName = operationClaim.OperationClaimName };
                return result.ToList();
            }
        }
    }
}
