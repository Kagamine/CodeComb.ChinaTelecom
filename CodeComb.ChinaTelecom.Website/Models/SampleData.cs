using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.DependencyInjection;

namespace CodeComb.ChinaTelecom.Website.Models
{
    public static class SampleData
    {
        public static async Task InitializeDatabase(IServiceProvider serviceProvider)
        {
            try
            {
                using (var db = serviceProvider.GetService<CTContext>())
                {
                    var sqlServerDatabase = db.Database;
                    if (sqlServerDatabase != null)
                    {
                        if (await sqlServerDatabase.EnsureCreatedAsync())
                        {
                            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                            var result = await userManager.CreateAsync(new User
                            {
                                Email = "1@1234.sh",
                                UserName = "Admin"
                            }, "ChinaTelecom123!@#");
                        }
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
