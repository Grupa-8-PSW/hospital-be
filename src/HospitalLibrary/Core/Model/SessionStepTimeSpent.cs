using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class SessionStepTimeSpent
    {
        public int StepOne { get; set; }
        public int StepTwo { get; set; }
        public int StepThree { get; set; }
        public int StepFour { get; set; }

        public SessionStepTimeSpent()
        {
            StepOne = 0;
            StepTwo = 0;
            StepThree = 0;
            StepFour = 0;
        }

        public SessionStepTimeSpent(int one, int two, int three, int four)
        {
            StepOne = one; StepTwo = two; StepThree = three; StepFour = four;
        }
        public bool Check()
        {
            if (StepOne == 0 || StepTwo == 0 || StepThree == 0
                || StepFour == 0) return false;
            return true;
        }
    }
}
