using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class TemporaryExamStatisticsDto
    {
        public int Month { get; set; }
        public int ExamNum { get; set; }

        public TemporaryExamStatisticsDto() { }

        public TemporaryExamStatisticsDto(int month, int examNum)
        {
            Month = month;
            ExamNum = examNum;
        }
    }
}
