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

        public List<ExaminationDTO> ExeminationDTOs { get; set; }

        public SchedulesDTO(List<ExaminationDTO> exeminations, List<EquipmentTransferDTO> transfers)
        {
            EquipmentTransferDTOs = transfers;
            ExeminationDTOs = exeminations;
        }

    }
}
