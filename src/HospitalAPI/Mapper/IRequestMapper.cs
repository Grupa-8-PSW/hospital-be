namespace HospitalAPI.Mapper;

public interface IRequestMapper<Model, Dto>
{
    Model ToModel(Dto dto);
}