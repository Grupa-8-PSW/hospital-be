using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class BloodOrderDTO
    {
        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string BankName { get; set; }
        public SubscriptionStatus OrderStatus { get; set; }
    }
}
