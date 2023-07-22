using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfAdressDal : EfEntityRepositoryBase<Adress, ETradeContext>, IAdressDal
    {
        public List<AdressDetailDto> GetAdressDetail(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = from address in context.Adresses
                             join city in context.Cities on address.CityID equals city.CityID
                             join town in context.Towns on address.TownID equals town.TownID
                             where address.UserID == id
                             select new AdressDetailDto()
                             {
                                 AdressID = address.AdressID,
                                 City = city.CityName,
                                 Town = town.TownName,
                                 District = address.District,
                                 PostalCode = address.PostalCode,
                                 AdressText = address.AdressText
                             };
                return result.ToList();
            }
        }

        
    }
}
