using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodRequestDelivery
    {
        public int Id { get; set; }
        public BloodType Type { get; set; }
        public int AmountL { get; set; }
        public DateTime DeliveryDate { get; set; }

        public BloodBank BloodBank { get; set; }
        public int BloodBankId { get; set; }

        public BloodRequestDelivery(int id, BloodType type, int amountL, DateTime deliveryDate, BloodBank bloodBank, int bloodBankId)
        {
            Id = id;
            Type = type;
            AmountL = amountL;
            DeliveryDate = deliveryDate;
            BloodBank = bloodBank;
            BloodBankId = bloodBankId;
        }

        public BloodRequestDelivery()
        {
        }
    }
}
