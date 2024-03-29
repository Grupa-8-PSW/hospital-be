﻿using System;
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

        IEnumerable<Equipment> Search(string name, int? amount);

        IEnumerable<Equipment> GetEquipmentByRoomId(int id);

        Equipment GetEquipmentByRoomIdAndName(int roomId, string name);

        void CreateEquipTransfer(EquipmentTransfer equipTrans);

        void Create(Equipment equip);

        void Update(Equipment equip);

        IEnumerable<EquipmentTransfer> GetEquipmentTransferByRoomId(int id);
    }
}
