using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IRenovationService
    {
        IEnumerable<Renovation> GetAll();
        Renovation GetById(int id);
    }
}
