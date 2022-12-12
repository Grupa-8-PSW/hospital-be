using HospitalAPI.DTO;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace HospitalAPI.Mapper
{
    public class ExaminationDoneMapper : IMapper<ExaminationDone, ExaminationDoneDTO>
    {
        public ExaminationDoneDTO toDTO(ExaminationDone examinationDone)
        {
            ExaminationDoneDTO examinationDoneDTO = new ExaminationDoneDTO();
            examinationDoneDTO.Id = examinationDone.Id;
            examinationDoneDTO.ExaminationId = examinationDone.ExaminationId;
            examinationDoneDTO.Record = examinationDone.Record;
            examinationDoneDTO.Prescriptions = new List<Prescription>(/*examinationDone.Prescriptions*/);//?
            examinationDoneDTO.Symptoms = new List<Symptom>(/*examinationDone.Symptoms*/);//?

            return examinationDoneDTO;
        }

        public Collection<ExaminationDoneDTO> toDTO(Collection<ExaminationDone> models)
        {
            return new Collection<ExaminationDoneDTO>(models
                .Select<ExaminationDone, ExaminationDoneDTO>((examinationDone) => this.toDTO(examinationDone))
                .ToList<ExaminationDoneDTO>());
        }

        public ExaminationDone toModel(ExaminationDoneDTO dto)
        {
            ExaminationDone examinationDone = new ExaminationDone();
            if (dto.Id.HasValue)
            {
                examinationDone.Id = dto.Id.Value;
            }
            examinationDone.ExaminationId = dto.ExaminationId;
            examinationDone.Record = dto.Record;
            examinationDone.Prescriptions = new List<Prescription>(/*dto.Prescriptions*/);  //?
            examinationDone.Symptoms = new List<Symptom>(/*dto.Symptoms*/); //?

            return examinationDone;
        }

        public Collection<ExaminationDone> toModel(Collection<ExaminationDoneDTO> dtos)
        {
            return (Collection<ExaminationDone>)dtos
                .Select<ExaminationDoneDTO, ExaminationDone>(dto => this.toModel(dto));
        }
    
    }
}
