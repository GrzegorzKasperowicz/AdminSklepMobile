using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class AplicationDbContextFactory: IDesignTimeDbContextFactory<AdminShopMobileDbContext>
    {
        public AdminShopMobileDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminShopMobileDbContext>();
            optionsBuilder.UseSqlServer("Data Source=GRJEGOSZ;Initial Catalog=SklepAdmin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new AdminShopMobileDbContext(optionsBuilder.Options);
        }
    }
}