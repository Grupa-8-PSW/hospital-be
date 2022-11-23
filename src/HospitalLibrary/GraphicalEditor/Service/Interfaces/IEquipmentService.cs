using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<Equipment> GetAll();

        IEnumerable<Equipment> Search(string name);

        IEnumerable<Equipment> GetEquipmentByRoomId(int id);
    }
}
