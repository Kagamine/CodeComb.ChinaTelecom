using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                            //
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
