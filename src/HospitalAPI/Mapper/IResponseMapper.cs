using HospitalAPI.Web.Mapper;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Mapper;

public interface IResponseMapper<Model, Dto>
{
    Dto ToDto(Model model);
    List<Dto> ToDto(List<Model> models);
}