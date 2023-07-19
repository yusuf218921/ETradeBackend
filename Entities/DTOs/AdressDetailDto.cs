using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AdressDetailDto : IDto
    {
        public int AdressID { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string AdressText { get; set; }
    }
}
