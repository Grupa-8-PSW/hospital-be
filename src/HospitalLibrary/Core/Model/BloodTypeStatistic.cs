using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class BloodTypeStatistic
    {
        public int ZeroPositive { get; set; }
        public int ZeroNegative { get; set; }
        public int APositive { get; set; }
        public int ANegative { get; set; }
        public int BPositive { get; set; }
        public int BNegative { get; set; }
        public int ABPositive { get; set; }
        public int ABNegative { get; set; }

        public BloodTypeStatistic()
        {
            ZeroPositive = 0;
            ZeroNegative = 0;
            APositive = 0;
            ANegative = 0;
            BPositive = 0;
            BNegative = 0;
            ABPositive = 0;
            ABNegative = 0;
        }

        public BloodTypeStatistic(int zeroPositive, int zeroNegative, int aPositive, int aNegative, int bPositive, int bNegative, int abPositive, int abNegative)
        {
            ZeroPositive = zeroPositive;
            ZeroNegative = zeroNegative;
            APositive = aPositive;
            ANegative = aNegative;
            BPositive = bPositive;
            BNegative = bNegative;
            ABPositive = abPositive;
            ABNegative = abNegative;
        }
    }
}
