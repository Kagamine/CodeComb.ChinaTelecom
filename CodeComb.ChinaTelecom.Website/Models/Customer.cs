using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeComb.ChinaTelecom.Website.Models
{
    public class Customer
    {
        [MaxLength(64)]
        public string Id { get; set; }

        [MaxLength(64)]
        public string Area { get; set; }

        [MaxLength(64)]
        public string Product { get; set; }

        [MaxLength(64)]
        public string Status { get; set; }

        public DateTime? ComplainTime { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? ReceiveTime { get; set; }

        public DateTime? BizRecoverTime { get; set; }

        public DateTime? FaultRecoverTime { get; set; }

        public DateTime? EndTime { get; set; }

        public DateTime? AccessTime { get; set; }

        [MaxLength(32)]
        public string Phone { get; set; }

        [MaxLength(64)]
        public string CustomerName { get; set; }

        [MaxLength(512)]
        public string FaultDetail { get; set; }

        [MaxLength(64)]
        public string FaultResource { get; set; }

        [MaxLength(64)]
        public string CustomerLevel { get; set; }

        [MaxLength(64)]
        public string RepairUnit { get; set; }

        [MaxLength(64)]
        public string RepairPost { get; set; }
        
        [MaxLength(512)]
        public string Address { get; set; }

        [MaxLength(64)]
        public string Account { get; set; }

        public string Content { get; set; }
    }
}
