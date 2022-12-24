using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodUnitRequestMessageDTO
    {
        public int? hospitalRequestId { get; set; }
        public string type { get; set; }
        public int amountL { get; set; }
        public string deliveryDate { get; set; }

        public BloodUnitRequestMessageDTO(int? id, string _type, int _amountL, string _deliveryDate)
        {
            hospitalRequestId = id;
            type = _type;
            amountL = _amountL;
            deliveryDate = _deliveryDate;
        }

        public BloodUnitRequestMessageDTO()
        {

        }
    }
}
