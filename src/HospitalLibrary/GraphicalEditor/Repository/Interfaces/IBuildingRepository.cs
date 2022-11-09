using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetAll();
        Building GetById(int id);
    }
}
