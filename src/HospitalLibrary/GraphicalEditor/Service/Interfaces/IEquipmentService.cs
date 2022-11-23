using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;

namespace HospitalLibrary.GraphicalEditor.Service.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<Equipment> GetAll();

        IEnumerable<Equipment> GetEquipmentByRoomId(int id);

        void CreateEquipTransfer(EquipmentTransfer equipTrans);

        void MoveEquipmentThread(EquipmentTransferDTO  dto);
    }
}
