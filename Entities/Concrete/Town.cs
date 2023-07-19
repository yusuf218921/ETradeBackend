using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Town : IEntity
    {
        public int TownID { get; set; }
        public int CityID { get; set; }
        public string TownName { get; set; }
    }
}
