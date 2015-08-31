using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using CodeComb.ChinaTelecom.Website.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeComb.ChinaTelecom.Website.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Operating(DateTime? time)
        {
            if (!time.HasValue)
                time = DateTime.Now;
            var timeout = time.Value.AddHours(-12);
            var timeout4h = time.Value.AddHours(-16);
            var willtimeout = time.Value.AddHours(-10);
            var ret = DB.Customers
                .ToList()
                .GroupBy(x => new { Unit = x.RepairUnit })
                .Select(x => new OperatingViewModel
                {
                    Unit = x.Key.Unit,
                    Count = x.Count(),
                    TimeOut = x.Where(y => timeout > y.ReceiveTime).Count(),
                    WillTimeOut = x.Where(y=>willtimeout>y.ReceiveTime).Count(),
                    Average = x
                        .Where(y => y.ReceiveTime.HasValue && y.EndTime.HasValue)
                        .Average(y => (y.EndTime.Value - y.ReceiveTime.Value).TotalHours),
                    TimeOut4H = x.Where(y => timeout4h > y.ReceiveTime).Count()
                });
            return View(ret);
        }
    }
}
