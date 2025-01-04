using Microsoft.EntityFrameworkCore;
using ORCL_MINIMAL_.NET.Models;

namespace ORCL_MINIMAL_.NET.EFCore
{
    public class ORCLContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=sys;Password=Xap1203*;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));DBA Privilege=SYSDBA");
        }
    }
}
