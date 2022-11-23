using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Util;
using HospitalLibrary.Core.Validation;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using MailKit;
using MigraDoc.DocumentObjectModel;
using MimeKit.IO.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class TreatmentHistoryService : ITreatmentHistoryService
    {
        private readonly ITreatmentHistoryRepository _treatmentHistoryRepository;
        private readonly IRoomService _roomService;
        private readonly IPatientService _patientService;
        private readonly IBedRepository _bedRepository;
        public TreatmentHistoryService(ITreatmentHistoryRepository treatmentHistoryRepository, IRoomService roomService,
            IPatientService patientService, IBedRepository bedRepository)
        {
            _treatmentHistoryRepository = treatmentHistoryRepository;
            _roomService = roomService;
            _patientService = patientService;
            _bedRepository = bedRepository;
        }

        public IEnumerable<TreatmentHistory> GetAll()
        {
            return _treatmentHistoryRepository.GetAll();
        }

        public TreatmentHistory GetById(int id)
        {
            return _treatmentHistoryRepository.GetById(id);
        }

        public bool Create(TreatmentHistory treatmentHistory)
        {
            treatmentHistory.StartDate = DateTime.UtcNow;
            treatmentHistory.EndDate = null;
            treatmentHistory.Active = true;
            treatmentHistory.Patient = _patientService.GetById(treatmentHistory.PatientId);
            treatmentHistory.Therapies = new List<Therapy>();
            treatmentHistory.DischargeReason = "";
            treatmentHistory.Room = _roomService.GetById(treatmentHistory.RoomId);

            foreach (Bed bed in treatmentHistory.Room.Beds)
            {
                if (bed.Available)
                {
                    treatmentHistory.Bed = bed;
                    treatmentHistory.Bed.Available = false;
                    treatmentHistory.BedId = bed.Id;
                    break;
                }
            }
            if (treatmentHistory.Bed == null)  return false;

            _bedRepository.Update(treatmentHistory.Bed);
            _treatmentHistoryRepository.Create(treatmentHistory);
            return true;
        }

        public bool Update(TreatmentHistory treatmentHistory)
        {
            treatmentHistory.StartDate = DateTime.SpecifyKind(treatmentHistory.StartDate, DateTimeKind.Utc);
            treatmentHistory.EndDate = (treatmentHistory.EndDate == null) ? null : DateTime.SpecifyKind((global::System.DateTime)treatmentHistory.EndDate, DateTimeKind.Utc);

            _treatmentHistoryRepository.Update(treatmentHistory);
            return true;
        }

        public bool FinishTreatmentHistory(TreatmentHistory treatmentHistory)
        {
            treatmentHistory.Room = _roomService.GetById(treatmentHistory.RoomId);
            treatmentHistory.Bed = _bedRepository.GetById(treatmentHistory.BedId);
            treatmentHistory.Patient = _patientService.GetById(treatmentHistory.PatientId);
            treatmentHistory.Active = false;
            //treatmentHistory.Bed.Available = becomes false on chosen date
            return Update(treatmentHistory);
        }

        public void Delete(TreatmentHistory treatmentHistory)
        {
            _treatmentHistoryRepository.Delete(treatmentHistory);
        }
        public TreatmentHistory GetByIdEager(int id)
        {
            return _treatmentHistoryRepository.GetByIdEager(id);
        }

    }
}
