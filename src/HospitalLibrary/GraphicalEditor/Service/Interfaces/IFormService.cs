using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IFormService
    {
        IEnumerable<Form> GetAll();
        IEnumerable<Form> GetInformationsOfRooms(int id);
    }
}
