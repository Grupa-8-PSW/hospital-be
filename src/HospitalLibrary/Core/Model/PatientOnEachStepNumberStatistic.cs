using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class PatientOnEachStepNumberStatistic
    {
        public int StepOne { get; set; }
        public int StepTwo { get; set; }
        public int StepThree { get; set; }
        public int StepFour { get; set; }
        public int StepFive { get; set; }
        
        public PatientOnEachStepNumberStatistic()
        {
            StepOne = 0;
            StepTwo = 0;
            StepThree = 0;
            StepFour = 0;
            StepFive = 0;
        }
        
        public PatientOnEachStepNumberStatistic(int one, int two, int three, int four, int five)
        {
            StepOne = one; StepTwo = two; StepThree = three; StepFour = four; StepFive = five;
        }
        public bool Check()
        {
            if (StepOne == 0 || StepTwo == 0 || StepThree == 0
                || StepFour == 0 || StepFive == 0) return false;
            return true;
        }
    }
}
