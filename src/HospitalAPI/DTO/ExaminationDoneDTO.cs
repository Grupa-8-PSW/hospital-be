using HospitalAPI.Web.Dto;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class ExaminationDoneDTO
    {
        public int? Id { get; set; }
        public int ExaminationId { get; set; }
        public ExaminationDTO ExaminationDTO { get; set; } 
        public List<Symptom> Symptoms { get; set; }
        public string Record { get; set; }
        public List<Prescription> Prescriptions { get; set; }    //dto?

        public ExaminationDoneDTO()
        {
        }

        public ExaminationDoneDTO(int? id, int examinationId, ExaminationDTO examinationDTO, List<Symptom> symptoms, string record, List<Prescription> prescriptions)
        {
            Id = id;
            ExaminationId = examinationId;
            ExaminationDTO = examinationDTO;
            Symptoms = symptoms;
            Record = record;
            Prescriptions = prescriptions;
        }
    }
}
