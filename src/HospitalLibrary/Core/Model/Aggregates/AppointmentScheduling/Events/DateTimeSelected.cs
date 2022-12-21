using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model.Aggregates;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events
{
    public class DateSelected : DomainEvent
    {
        public DateSelected(int id, DateTime date) : base(id)
        {
            Date = date;
        }

        public DateTime Date { get; private set; }

    }
}
