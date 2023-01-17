using HospitalLibrary.Core.Enums;

namespace HospitalAPI.DTO
{
    public class SpecializationEventDTO
    {
        public int AggregateId { get; set; }
        public DoctorSpecialization SelectedSpecialization { get; set; }
    }
}
