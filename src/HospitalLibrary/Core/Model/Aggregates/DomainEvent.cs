using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model.Aggregates
{
    public abstract class DomainEvent
    {
        public DomainEvent(int aggregateId)
        {
            Id = aggregateId;
        }
        public virtual int Id { get; set; }
    }
}
