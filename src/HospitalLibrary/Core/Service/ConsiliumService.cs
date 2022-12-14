using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service;

public class ConsiliumService : IConsiliumService
{
    private readonly IConsiliumRepository _consiliumRepository;

    public ConsiliumService(IConsiliumRepository consiliumRepository)
    {
        _consiliumRepository = consiliumRepository;
    }


    public async Task<List<Consilium>> GetAll()
    {
        return await _consiliumRepository.GetAll();
    }

    public async Task<Consilium?> GetConsiliumById(int id)
    {
        return await _consiliumRepository.GetById(id);
    }

    public async Task<Consilium?> CreateConsilium(Consilium consilium)
    {
        return await _consiliumRepository.Create(consilium);
    }

    public async Task<bool> UpdateConsilium(Consilium consilium)
    {
        return await _consiliumRepository.Update(consilium);
    }

    public async Task<bool> DeleteConsilium(int id)
    {
        return await _consiliumRepository.Delete(id);
    }

    public async Task<List<Consilium>> GetAllIncludeDoctors()
    {
        return await _consiliumRepository.GetAllIncludeDoctors();
    }


    public async Task<Consilium?> CreateConsiliumByRequest(ConsiliumRequest consiliumRequest)
    {

        throw new NotImplementedException();
        //return await _consiliumRepository.Create(consilium);
    }

}