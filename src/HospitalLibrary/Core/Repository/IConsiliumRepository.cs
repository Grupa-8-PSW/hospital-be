using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository;

public interface IConsiliumRepository
{
    public Task<List<Consilium>> GetAll();
    public Task<Consilium?> GetById(int id);
    public Task<Consilium?> Create(Consilium consilium);
    public Task<bool> Update(Consilium consilium);
    public Task<bool> Delete(int id);
    public Task<List<Consilium>> GetAllIncludeDoctors();
}