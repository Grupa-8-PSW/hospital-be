using System.Collections.ObjectModel;
using System.Globalization;
using HospitalAPI.Responses;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Mapper;

public class ConsiliumResponseMapper : IResponseMapper<Consilium, ConsiliumResponse>
{
    private IResponseMapper<Doctor, ConsiliumDoctorResponse> _doctorMapper;

    public ConsiliumResponseMapper(IResponseMapper<Doctor, ConsiliumDoctorResponse> doctorMapper)
    {
        _doctorMapper = doctorMapper;
    }

    public ConsiliumResponse ToDto(Consilium model)
    {
        return new ConsiliumResponse
        {
            Id = model.Id,
            Subject = model.Subject,
            Duration = model.Duration,
            From = model.Interval.From.ToString(CultureInfo.InvariantCulture),
            To = model.Interval.To.ToString(CultureInfo.InvariantCulture),
            Doctors = _doctorMapper.ToDto(model.Doctors)
        };
    }

    public List<ConsiliumResponse> ToDto(List<Consilium> models)
    {
        return models.Select(ToDto).ToList();
    }
}