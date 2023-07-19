using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TelNumber : IEntity
    {
        public int TelNumberID { get; set; }
        public int UserID { get; set; }
        public string PhoneNumber { get; set; }
    }
}
