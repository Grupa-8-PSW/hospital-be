using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model.Aggregates
{
    public abstract class DomainEvent
    {
        public DomainEvent(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
        public virtual DateTime Timestamp { get; set; }
    }
}
