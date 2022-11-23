using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Repository.Interfaces
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAll();

        IEnumerable<Equipment> GetEquipmentByRoomIdAndName(int id);

        Equipment GetEquipmentByRoomIdAndName(int roomId, string name);

        void CreateEquipTransfer(EquipmentTransfer equipTrans);

        void Create(Equipment equip);

        void Update(Equipment equip);
    }
}
