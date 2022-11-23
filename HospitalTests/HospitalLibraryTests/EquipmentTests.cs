using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HospitalAPI.Controllers.Map;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Model.DTO;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace HospitalTests.HospitalLibraryTests
{
    public class EquipmentTests
    {

        [Fact]
        public void Finds_all_equipments()
        {
            IEquipmentService service = new EquipmentService(CreateStubRepository());
            EquipmentController controller = new EquipmentController(service);

            var equipments = ((OkObjectResult)controller.GetAll()).Value as List<EquipmentDTO>;

            Assert.NotNull(equipments);
            equipments.Count().ShouldBe(3);
        }

        [Fact]
        public void Find_equipment_by_room_id()
        {
            IEquipmentService service = new EquipmentService(CreateStubRepository());
            EquipmentController controller = new EquipmentController(service);

            List<EquipmentDTO> equipments = ((OkObjectResult)controller.GetEquipmentByRoomId(1))?.Value as List<EquipmentDTO>;

           
            equipments.Count().ShouldBe(2);
        }


        private IEquipmentRepository CreateStubRepository()
        {

            List<Equipment> equipments = new List<Equipment>();

            Equipment e1 = new Equipment(1, "Zavoji", 20, 1);
            Equipment e2 = new Equipment(2, "Stetoskop", 2, 1);
            Equipment e3 = new Equipment(3, "Flasteri", 35, 2);
         
            equipments.Add(e1);
            equipments.Add(e2);
            equipments.Add(e3);
            
            var stubRepository = new Mock<IEquipmentRepository>();
            stubRepository.Setup(m => m.GetAll()).Returns(equipments);

            return stubRepository.Object;
        }
    }
}
