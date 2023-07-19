using Core.Entities.Concrate;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.Entityframework.Context
{
    public class ETradeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DB85IPR;Database=ETradeDB;User Id=SA;Password=218921aa;Trusted_Connection=true;TrustServerCertificate=true");
        }
        DbSet<Product> Products;
        DbSet<Order> Orders;
        DbSet<OrderLine> OrderLines;
        DbSet<Adress> Adresses;
        DbSet<TelNumber> TelNumbers;
        DbSet<Category> Categories;
        DbSet<User> Users;
        DbSet<OperationClaim> OperationClaims;
        DbSet<UserOperationClaim> UserOperationClaims;
        DbSet<City> Cities;
        DbSet<Town> Towns;
    }
}
