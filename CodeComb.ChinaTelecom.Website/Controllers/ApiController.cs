using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CodeComb.ChinaTelecom.Website.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeComb.ChinaTelecom.Website.Controllers
{
    public class ApiController : BaseController
    {
        // GET: /<controller>/
        public IActionResult GetLastCustomerId()
        {
            var customer = DB.Customers.OrderByDescending(x => x.Id).FirstOrDefault();
            if (customer == null)
                return Content("2000000000000000");
            else
                return Content(customer.Id);
        }

        public IActionResult GetLastProviderId()
        {
            var provider = DB.Providers.OrderByDescending(x => x.Id).FirstOrDefault();
            if (provider == null)
                return Content("2000000000000000");
            else
                return Content(provider.Id);
        }

        public IActionResult InsertCustomer(Customer customer)
        {
            if (DB.Customers.Any(x => x.Id == customer.Id))
                return Content("false");
            DB.Customers.Add(customer);
            DB.SaveChanges();
            return Content("true");
        }

        public IActionResult InsertProvider(Provider provider)
        {
            if (DB.Providers.Any(x => x.Id == provider.Id))
                return Content("false");
            DB.Providers.Add(provider);
            DB.SaveChanges();
            return Content("true");
        }
    }
}
