using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeComb.ChinaTelecom.Website.Models
{
    public class Log
    {
        public Guid Id { get; set; }

        public DateTime Time { get; set; }

        public int TotalCustomer { get; set; }

        public int PendingCustomer { get; set; }

        public int TotalProvider { get; set; }

        public int PendingProvider { get; set; }
    }
}
