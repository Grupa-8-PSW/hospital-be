using HospitalLibrary.GraphicalEditor.Model;


namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IBuildingService
    {
        IEnumerable<Building> GetAll();
        Building GetById(int id);
    }
}
