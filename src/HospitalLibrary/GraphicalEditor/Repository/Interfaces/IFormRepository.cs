using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IFormRepository
    {
        IEnumerable<Form> GetAll();
        IEnumerable<Form> GetInformationsOfRooms(int id);
    }
}
