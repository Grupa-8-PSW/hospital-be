using HospitalLibrary.Core.Enums;

namespace HospitalAPI.DTO
{
    public class BloodUnitRequestDTO
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }
    }
}
