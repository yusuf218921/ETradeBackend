using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Adress : IEntity
    {
        public int AdressID { get; set; }
        public int UserID { get; set; }
        public int CityID { get; set; }
        public int TownID { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string AdressText { get; set; }

    }
}
