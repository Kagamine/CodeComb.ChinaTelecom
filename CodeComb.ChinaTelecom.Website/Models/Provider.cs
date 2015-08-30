using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeComb.ChinaTelecom.Website.Models
{
    public class Provider
    {
        [MaxLength(64)]
        public string Id { get; set; }

        [MaxLength(64)]
        public string Product { get; set; }

        [MaxLength(32)]
        public string Status { get; set; }

        public DateTime? AcceptTime { get; set; }

        public DateTime? FinishTime { get; set; }

        public DateTime? Time1 { get; set; }

        public DateTime? Time2 { get; set; } 

        public string Event { get; set; }

        public string Event2 { get; set; }
        
        [MaxLength(64)]
        public string Account { get; set; }

        [MaxLength(64)]
        public string RepairUnit { get; set; }
        
        [MaxLength(64)]
        public string RepairPost { get; set; }

        [MaxLength(256)]
        public string Address { get; set; }
    }
}
