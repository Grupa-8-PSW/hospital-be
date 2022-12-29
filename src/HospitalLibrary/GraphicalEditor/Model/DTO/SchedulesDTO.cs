using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.GraphicalEditor.Model.DTO
{
    public class SchedulesDTO
    {
        public List<EquipmentTransferDTO> EquipmentTransferDTOs { get; set; }

        public List<ExaminationDTO> ExaminationDTOs { get; set; }

        public SchedulesDTO(List<ExaminationDTO> examinations, List<EquipmentTransferDTO> transfers)
        {
            EquipmentTransferDTOs = transfers;
            ExaminationDTOs = examinations;
        }

    }
}
