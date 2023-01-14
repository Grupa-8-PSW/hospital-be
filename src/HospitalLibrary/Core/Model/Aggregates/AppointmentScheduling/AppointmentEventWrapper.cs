using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling
{
    public class AppointmentEventWrapper : BaseEntityModel
    {
        public AppointmentEventWrapper() { }

        public AppointmentEventWrapper(int aggregateId, int patientId, Object data, EventType eventType)
        {
            AggregateId = aggregateId; 
            PatientId = patientId;
            Data = data;
            EventType = eventType;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AggregateId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        [Column(TypeName = "json")]
        public object Data { get; set; }
        public EventType EventType { get; set; }
    }
}
