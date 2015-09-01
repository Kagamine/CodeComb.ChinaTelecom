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
        [HttpGet]
        public IActionResult GetLastCustomerId()
        {
            var customer = DB.Customers.OrderByDescending(x => x.Id).FirstOrDefault();
            if (customer == null)
                return Content("2000000000000000");
            else
                return Content(customer.Id);
        }

        [HttpGet]
        public IActionResult GetLastProviderId()
        {
            var provider = DB.Providers.OrderByDescending(x => x.Id).FirstOrDefault();
            if (provider == null)
                return Content("2000000000000000");
            else
                return Content(provider.Id);
        }

        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            if (DB.Customers.Any(x => x.Id == customer.Id))
            {
                var cust = DB.Customers.Where(x => x.Id == customer.Id).Single();
                cust.AccessTime = customer.AccessTime;
                cust.Account = customer.Account;
                cust.Address = customer.Address;
                cust.Area = customer.Area;
                cust.BizRecoverTime = customer.BizRecoverTime;
                cust.ComplainTime = customer.ComplainTime;
                cust.Content = customer.Content;
                cust.CreateTime = customer.CreateTime;
                cust.CustomerLevel = customer.CustomerLevel;
                cust.CustomerName = customer.CustomerName;
                cust.EndTime = customer.EndTime;
                cust.FaultDetail = customer.FaultDetail;
                cust.FaultRecoverTime = customer.FaultRecoverTime;
                cust.FaultResource = customer.FaultResource;
                cust.Phone = customer.Phone;
                cust.Product = customer.Product;
                cust.ReceiveTime = customer.ReceiveTime;
                cust.RepairPost = customer.RepairPost;
                cust.RepairUnit = customer.RepairUnit;
                cust.Status = customer.Status;
            }
            else
            {
                DB.Customers.Add(customer);
            }
            DB.SaveChanges();
            return Content("true");
        }

        [HttpPost]
        public IActionResult InsertProvider(Provider provider)
        {
            if (DB.Providers.Any(x => x.Id == provider.Id))
            {
                var prov = DB.Providers.Where(x => x.Id == provider.Id).Single();
                prov.AcceptTime = provider.AcceptTime;
                prov.Account = provider.Account;
                prov.Address = provider.Address;
                prov.Event = provider.Event;
                prov.Event2 = provider.Event2;
                prov.FinishTime = provider.FinishTime;
                prov.Product = provider.Product;
                prov.RepairPost = provider.RepairPost;
                prov.RepairUnit = provider.RepairUnit;
                prov.Status = provider.Status;
                prov.Time1 = provider.Time1;
                prov.Time2 = provider.Time2;
            }
            else
            {
                DB.Providers.Add(provider);
            }
            DB.SaveChanges();
            return Content("true");
        }
        
        public IActionResult Log()
        {
            DB.Logs.Add(new Log
            {
                Id = Guid.NewGuid(),
                Time = DateTime.Now,
                TotalCustomer = DB.Customers.Count(),
                TotalProvider = DB.Providers.Count(),
                PendingCustomer = DB.Customers.Where(x => x.Status == "正在处理中").Count(),
                PendingProvider = DB.Providers.Where(x => x.Status == "ACCEPT").Count()
            });
            DB.SaveChanges();
            return Content("true");
        }
    }
}
