using System.Collections.ObjectModel;
using HospitalAPI.DTO;
using HospitalAPI.Responses;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mapper;

public class ExaminationDocumentMapper : IMapper<ExaminationDone, ExaminationDocumentResponse>
{
    public ExaminationDocumentResponse toDTO(ExaminationDone model)
    {
        var report = model.Record;
        var from = model.Examination.DateRange.Start;
        var to = model.Examination.DateRange.End;
        var doctor = model.Examination.Doctor.FullName;
        var patient = model.Examination.Patient.FullName;
        var prescriptions = model.Prescriptions.Select(x => new ExaminationDocumentPrescriptionDTO
        {
            Items = x.PrescriptionItem.Select(y => new ExaminationDocumentPrescriptionItemDTO
            {
                Code = y.MedicalDrug.Code,
                Name = y.MedicalDrug.Name,
                Quantity = y.MedicalDrug.Amount
            }).ToList()
        }).ToList();

        return new ExaminationDocumentResponse
        {
            From = from,
            To = to,
            Report = report,
            Doctor = doctor,
            Patient = patient,
            Prescriptions = prescriptions
        };
    }



    public ExaminationDone toModel(ExaminationDocumentResponse dto)
    {
        throw new NotImplementedException();
    }

    public Collection<ExaminationDocumentResponse> toDTO(Collection<ExaminationDone> models)
    {
        return new Collection<ExaminationDocumentResponse>(models.Select(toDTO).ToList());
    }

    public Collection<ExaminationDone> toModel(Collection<ExaminationDocumentResponse> dtos)
    {
        throw new NotImplementedException();
    }
}