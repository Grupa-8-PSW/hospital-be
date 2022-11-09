using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.GraphicalEditor.Model;
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
    }
}
