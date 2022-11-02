using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IFloorService
    {
        IEnumerable<Floor> GetAll();
        Floor GetById(int id);

        IEnumerable<Floor> GetFloorsByBuildingId(int id);
    }
}
