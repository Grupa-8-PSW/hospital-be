using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class MonthExamStatisticsDto
    {
        public int Month { get; set; }
        public double AverageExamNum { get; set; }

        public MonthExamStatisticsDto() { }

        public MonthExamStatisticsDto(int month, double averageExamNum)
        {
            Month = month;
            AverageExamNum = averageExamNum;
        }
    }
}
