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
            return _equRepository.GetEquipmentByRoomIdAndName(id);
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
            Equipment eqfrom = _equRepository.GetEquipmentByRoomIdAndName(equipTrans.FromRoomId, equipTrans.EquipmentName);
            eqfrom.Amount = eqfrom.Amount - equipTrans.Amount;
            Equipment eqto = _equRepository.GetEquipmentByRoomIdAndName(equipTrans.FromRoomId, equipTrans.EquipmentName);
            if (eqto == null){
                eqto.Amount = equipTrans.Amount;
                eqto.Name = equipTrans.EquipmentName;
                eqto.RoomId = equipTrans.ToRoomId;
                _equRepository.Create(eqto);
            }
            else
            {
                eqto.Amount = eqto.Amount + equipTrans.Amount;
                _equRepository.Update(eqto);
            }
            _equRepository.Update(eqfrom);
            
        }
    }
}
