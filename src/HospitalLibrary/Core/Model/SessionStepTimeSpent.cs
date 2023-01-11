using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class SessionStepTimeSpent
    {
        public int StepOneMin { get; set; }
        public int StepTwoMin { get; set; }
        public int StepThreeMin { get; set; }
        public int StepFourMin { get; set; }

        public SessionStepTimeSpent()
        {
            StepOneMin = 0;
            StepTwoMin = 0;
            StepThreeMin = 0;
            StepFourMin = 0;
        }

        public SessionStepTimeSpent(int one, int two, int three, int four)
        {
            StepOneMin = one; StepTwoMin = two; StepThreeMin = three; StepFourMin = four;
        }
        public bool Check()
        {
            if (StepOneMin == 0 || StepTwoMin == 0 || StepThreeMin == 0
                || StepFourMin == 0) return false;
            return true;
        }
    }
}
