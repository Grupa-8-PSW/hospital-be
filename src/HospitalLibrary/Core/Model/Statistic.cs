using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Statistic
    {
        public AgeStatistic AgeStatistic { get; set; }
        public GenderStatistic GenderStatistic { get; set; }
        public BloodTypeStatistic BloodTypeStatistic { get; set; }

        public Statistic()
        {
            AgeStatistic =  new AgeStatistic();
            GenderStatistic = new GenderStatistic();
            BloodTypeStatistic = new BloodTypeStatistic();
        }

        public Statistic(AgeStatistic ageStatistic, GenderStatistic genderStatistic, BloodTypeStatistic bloodTypeStatistic)
        {
            AgeStatistic = ageStatistic;
            GenderStatistic = genderStatistic;
            BloodTypeStatistic = bloodTypeStatistic;
        }
    }
}
