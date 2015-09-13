using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeComb.ChinaTelecom.Website.Models
{
    public class OperatingViewModel
    {
        public string Unit { get; set; }
        public int TimeOut { get; set; }
        public int TimeOut4H { get; set; }
        public int WillTimeOut { get; set; }
        public double Average { get; set; }
        public int Count { get; set; }
    }
}
