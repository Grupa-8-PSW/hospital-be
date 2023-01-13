using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalAPI.DTO
{
    public class AppointmentEventDTO
    {
        public int AggregateId { get; set; }
        public DateRange SelectedSlot { get; set; }
    }
}
