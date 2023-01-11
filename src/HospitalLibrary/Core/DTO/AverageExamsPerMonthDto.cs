using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.DTO
{
    public class AverageExamsPerMonthDto
    {
        public List<MonthExamStatisticsDto> MonthExamStatisticsList { get; set; }

        public AverageExamsPerMonthDto() 
        {
            MonthExamStatisticsList = new List<MonthExamStatisticsDto>();
        }

        public AverageExamsPerMonthDto(List<MonthExamStatisticsDto> monthExamStatisticsList)
        {
            MonthExamStatisticsList = monthExamStatisticsList;
        }
    }
}
