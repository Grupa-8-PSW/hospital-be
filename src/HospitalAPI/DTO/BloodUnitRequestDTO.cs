using HospitalLibrary.Core.Enums;
using NuGet.Packaging;

namespace HospitalAPI.DTO
{
    public class BloodUnitRequestDTO
    {
        public int? Id { get; set; }
        public int? DoctorId { get; set; }
        public string Type { get; set; }
        public int AmountL { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }
        public string ManagerComment { get; set; }
        public BloodUnitRequestStatus Status { get; set; }
    }
}
