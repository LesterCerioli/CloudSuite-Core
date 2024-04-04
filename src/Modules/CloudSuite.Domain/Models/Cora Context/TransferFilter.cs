using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cora_Context
{
    public class TransferFilter
    {
        public TransferFilter(DateTime? startDate, DateTime? endDate, string? page)
        {
            StartDate = startDate;
            EndDate = endDate;
            Page = page;
        }

        public DateTime? StartDate {  get; private set; }
        public DateTime? EndDate { get; private set; }
        public string? Page {  get; private set; }
    }
}
