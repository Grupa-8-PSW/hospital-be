using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IFloorRepository
    {
        IEnumerable<Floor> GetAll();
        Floor GetById(int id);

        IEnumerable<Floor> GetFloorsByBuildingId(int id);
    }
}
