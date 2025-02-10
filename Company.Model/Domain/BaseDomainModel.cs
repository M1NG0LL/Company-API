using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Model.Domain
{
    public abstract class BaseDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public decimal? Salary { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime? WorkEndDate { get; set; }
        public bool? IsStillWorking { get; set; }
    }
}
