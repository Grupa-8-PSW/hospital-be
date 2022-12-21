using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class PatientOnEachStepMinutesStatistic
    {
        public int StepOneMin { get; set; }
        public int StepTwoMin { get; set; }
        public int StepThreeMin { get; set; }
        public int StepFourMin { get; set; }
        public int StepFiveMin { get; set; }

        public PatientOnEachStepMinutesStatistic()
        {
            StepOneMin = 0;
            StepTwoMin = 0;
            StepThreeMin = 0;
            StepFourMin = 0;
            StepFiveMin = 0;
        }

        public PatientOnEachStepMinutesStatistic(int one, int two, int three, int four, int five)
        {
            StepOneMin = one; StepTwoMin = two; StepThreeMin = three; StepFourMin = four; StepFiveMin = five;
        }
        public bool Check()
        {
            if (StepOneMin == 0 || StepTwoMin == 0 || StepThreeMin == 0
                || StepFourMin == 0 || StepFiveMin == 0) return false;
            return true;
        }
    }
}
