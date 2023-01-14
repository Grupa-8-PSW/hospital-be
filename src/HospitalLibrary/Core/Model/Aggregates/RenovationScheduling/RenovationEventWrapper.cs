using HospitalLibrary.GraphicalEditor.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Core.Model.Aggregates.RenovationScheduling
{
    public class RenovationEventWrapper : BaseEntityModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AggregateId { get; set; }
        [Column(TypeName = "json")]
        public object Data { get; set; }
        public RenovationEventType EventType { get; set; }

        public RenovationEventWrapper(int aggregateId, object data, RenovationEventType eventType)
        {
            AggregateId = aggregateId;
            Data = data;
            EventType = eventType;
        }

        public RenovationEventWrapper()
        {
        }
    }
}
