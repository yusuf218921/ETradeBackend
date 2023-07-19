using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderLineDetailDto : IDto
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitTotal { get; set; }
    }
}
