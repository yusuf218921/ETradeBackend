using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrate
{
    public class OperationClaim : IEntity
    {
        public int OperationClaimID { get; set; }
        public string OperationClaimName { get; set; }
    }
}
