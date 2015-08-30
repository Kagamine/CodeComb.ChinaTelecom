using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace CodeComb.ChinaTelecom.Website.Models
{
    public class CTContext : IdentityDbContext<User>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(e =>
            {
                e.Index(x => x.Account);
                e.Index(x => x.Area);
                e.Index(x => x.Product);
                e.Index(x => x.Status);
                e.Index(x => x.AccessTime);
                e.Index(x => x.BizRecoverTime);
                e.Index(x => x.ComplainTime);
                e.Index(x => x.CreateTime);
                e.Index(x => x.CustomerLevel);
                e.Index(x => x.CustomerName);
                e.Index(x => x.EndTime);
                e.Index(x => x.FaultRecoverTime);
                e.Index(x => x.FaultResource);
                e.Index(x => x.ReceiveTime);
                e.Index(x => x.RepairUnit);
                e.Index(x => x.RepairPost);
                e.Index(x => x.Product);
                e.Index(x => x.Phone);
                e.Index(x => x.Address);
            });

            builder.Entity<Provider>(e =>
            {
                e.Index(x => x.Product);
                e.Index(x => x.RepairUnit);
                e.Index(x => x.RepairPost);
                e.Index(x => x.Status);
                e.Index(x => x.Time1);
                e.Index(x => x.Time2);
                e.Index(x => x.AcceptTime);
                e.Index(x => x.FinishTime);
            });
        }
    }
}
