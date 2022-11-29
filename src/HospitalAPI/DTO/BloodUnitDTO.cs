using HospitalLibrary.Core.Enums;

namespace HospitalAPI.DTO
{
    public class BloodUnitDTO
    {
        public int Id { get; set; }
        public DateTime DatePrescribed { get; set; }
        public BloodType BloodType { get; set; }
        public int Amount { get; set; }
    }
}
