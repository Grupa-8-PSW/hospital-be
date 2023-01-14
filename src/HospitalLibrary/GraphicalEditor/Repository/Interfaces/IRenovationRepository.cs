using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IRenovationRepository
    {
        IEnumerable<Renovation> GetAll();
        IEnumerable<Renovation> GetByRoomId(int id);
        Renovation GetById(int id);
    }
}
