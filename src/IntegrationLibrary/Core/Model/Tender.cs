using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class Tender
    {
        public int Id { get; set; }
        public TenderStatus Status { get; set; }
        public DateRange DateRange { get; set; }
        public List<Blood> Blood { get; set; }

        public Tender(TenderStatus status, DateRange dateRange, List<Blood> blood)
        {
            Status = status;
            DateRange = dateRange;
            Blood = blood;
        }



    }
}
