using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equRepository;

        public EquipmentService(IEquipmentRepository equRepository)
        {
            _equRepository = equRepository;
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _equRepository.GetAll();
        }

        public IEnumerable<Equipment> GetEquipmentByRoomId(int id)
        {
            return _equRepository.GetEquipmentByRoomId(id);
        }

        public  void CreateEquipTransfer(EquipmentTransfer equipTrans)
        {
            _equRepository.CreateEquipTransfer(equipTrans);
            //MoveEquipmentThread(equipTrans);
           
        }
        
        public void MoveEquipmentThread(EquipmentTransferDTO equipTrans)
        {
            ThreadStart action = new ThreadStart(() => CheckDatesForMoving(equipTrans));
            Thread th = new Thread(action);
            th.IsBackground = true;
            th.Start();

        }

        public void CheckDatesForMoving(EquipmentTransferDTO equipTrans)
        {
            while (true)
            {   
              
                if (equipTrans.EndDate >= DateTime.UtcNow)
                {
                    MoveEquipment(equipTrans);
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        public void MoveEquipment(EquipmentTransferDTO equipTrans)
        {
            Equipment eqFrom = new Equipment();
            Equipment eqTo = new Equipment();
            IEnumerable<Equipment> eqsFrom = _equRepository.GetEquipmentByRoomId(equipTrans.FromRoomId);
            foreach (var eq in eqsFrom)
            {
                if (eq.Name == equipTrans.EquipmentName)
                    eqFrom = eq;
            }
            //Equipment eqfrom = _equRepository.GetEquipmentByRoomIdAndName(equipTrans.FromRoomId, equipTrans.EquipmentName);
            eqFrom.Amount = eqFrom.Amount - equipTrans.Amount;


            IEnumerable<Equipment> eqsTo = _equRepository.GetEquipmentByRoomId(equipTrans.ToRoomId);

            foreach (var eq in eqsTo)
            {
                if (eq.Name == equipTrans.EquipmentName)
                    eqTo = eq;
            }

            //Equipment eqto = _equRepository.GetEquipmentByRoomIdAndName(equipTrans.FromRoomId, equipTrans.EquipmentName);
            if (eqTo == null)
            {
                eqTo.Amount = equipTrans.Amount;
                eqTo.Name = equipTrans.EquipmentName;
                eqTo.RoomId = equipTrans.ToRoomId;
                _equRepository.Create(eqTo);
            }
            else
            {
                eqTo.Amount = eqTo.Amount + equipTrans.Amount;
                _equRepository.Update(eqTo);
            }
            _equRepository.Update(eqFrom);

        }
    }
}
