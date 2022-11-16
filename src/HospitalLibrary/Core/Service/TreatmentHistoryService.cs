using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Validation;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
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

        public bool Create(TreatmentHistory treatmentHistory, int roomId)
        {
            treatmentHistory.StartDate = DateTime.UtcNow;
            treatmentHistory.EndDate = null;
            treatmentHistory.Active = true;
            treatmentHistory.Patient = _patientService.GetById(treatmentHistory.PatientId);
            treatmentHistory.Therapies = new List<Therapy>();
            treatmentHistory.DischargeReason = "";
            Room room = _roomService.GetById(roomId);
            foreach (Bed bed in room.Beds)
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
            _treatmentHistoryRepository.Update(treatmentHistory);
            return true;
        }

        public void Delete(TreatmentHistory treatmentHistory)
        {
            _treatmentHistoryRepository.Delete(treatmentHistory);
        }

    }
}
