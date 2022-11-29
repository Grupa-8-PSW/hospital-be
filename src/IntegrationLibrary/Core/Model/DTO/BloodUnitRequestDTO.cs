using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
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

        public BloodUnitRequestDTO(int? id, int? doctorId, string type, int amountL, string reason, string creationDate, string managerComment, BloodUnitRequestStatus status)
        {
            Id = id;
            DoctorId = doctorId;
            Type = type;
            AmountL = amountL;
            Reason = reason;
            CreationDate = creationDate;
            ManagerComment = managerComment;
            Status = status;
        }

        public BloodUnitRequestDTO()
        {
        }
    }
}
