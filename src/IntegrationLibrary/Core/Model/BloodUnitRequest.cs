using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;

namespace IntegrationLibrary.Core.Model
{
    public class BloodUnitRequest
    {
        public int Id { get; set; }
        public BloodType Type { get; set; }
        public int AmountL { get; set; }
        public string Reason { get; set; }
        public DateTime CreationDate { get; set; }

        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        public string ManagerComment { get; set; }

        public BloodUnitRequestStatus Status { get; set; }

        public BloodUnitRequest()
        {
        }

        public BloodUnitRequest(int id, BloodType type, int amountL, string reason, DateTime creationDate,
            BloodUnitRequestStatus status, string managerComment, int doctorId, Doctor doctor)
        {
            Id = id;
            Type = type;
            AmountL = amountL;
            Reason = reason;
            CreationDate = creationDate;
            Status = status;
            ManagerComment = managerComment;
            DoctorId = doctorId;
            Doctor = doctor;
        }

        public BloodUnitRequest(int id, BloodType type, int amountL, string reason, DateTime creationDate,
    BloodUnitRequestStatus status, string managerComment, int doctorId)
        {
            Id = id;
            Type = type;
            AmountL = amountL;
            Reason = reason;
            CreationDate = creationDate;
            Status = status;
            ManagerComment = managerComment;
            DoctorId = doctorId;

        }
    }
}

