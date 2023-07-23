using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderDetailDto : IDto
    {
        public int OrderID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal TotalPrice { get; set; }
        public string AdressText { get; set; }
        public DateTime Date { get; set; }
    }
}
