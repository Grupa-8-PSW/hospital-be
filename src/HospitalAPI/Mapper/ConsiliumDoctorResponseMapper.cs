using System.Collections.ObjectModel;
using HospitalAPI.Responses;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mapper;

public class ConsiliumDoctorResponseMapper : IResponseMapper<Doctor, ConsiliumDoctorResponse>
{
    public ConsiliumDoctorResponse ToDto(Doctor model)
    {
        return new ConsiliumDoctorResponse
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
    }

    public List<ConsiliumDoctorResponse> ToDto(List<Doctor> models)
    {
        return models.Select(ToDto).ToList();
    }
}