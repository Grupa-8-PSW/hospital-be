using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using System.Collections.ObjectModel;
using System.Globalization;

namespace HospitalAPI.Mapper
{
    public class PatientMapper : IMapper<Patient, PatientDTO>
    {
        public PatientDTO toDTO(Patient patient)
        {
            PatientDTO patientDTO = new PatientDTO();
            patientDTO.Id = patient.Id;
            patientDTO.FirstName = patient.FirstName;
            patientDTO.LastName = patient.LastName;
            return patientDTO;
        }

        public Collection<PatientDTO> toDTO(Collection<Patient> models)
        {
            return new Collection<PatientDTO>(models
                .Select<Patient, PatientDTO>((treatmentHistory) => this.toDTO(treatmentHistory)).ToList());
        }

        public Patient toModel(PatientDTO dto)
        {
            Patient patient = new Patient(dto.Id, dto.FirstName, dto.LastName);

            return patient;
        }

        public Collection<Patient> toModel(Collection<PatientDTO> dtos)
        {
            return (Collection<Patient>)dtos
                .Select<PatientDTO, Patient>(dto => this.toModel(dto));
        }
    }
}
