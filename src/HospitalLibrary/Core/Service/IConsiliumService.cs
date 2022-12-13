using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service;

public interface IConsiliumService
{
    Task<List<Consilium>> GetAll();
    Task<Consilium?> GetConsiliumById(int id);
    Task<Consilium?> CreateConsilium(Consilium consilium);
    Task<bool> UpdateConsilium(Consilium consilium);
    Task<bool> DeleteConsilium(int id);
    Task<List<Consilium>> GetAllIncludeDoctors();
}