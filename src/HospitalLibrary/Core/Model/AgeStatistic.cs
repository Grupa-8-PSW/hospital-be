using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class AgeStatistic
    {
        public int ZeroToEighteen { get; set; }
        public int NineteenToSixtyFour { get; set; }
        public int SixtyFivePlus { get; set; }

        public AgeStatistic() {
            ZeroToEighteen = 0;
            NineteenToSixtyFour = 0;
            SixtyFivePlus = 0;
        }

        public AgeStatistic(int zeroToEighteen, int nineteenToSixtyFour, int sixtyFivePlus)
        {
            ZeroToEighteen = zeroToEighteen;
            NineteenToSixtyFour = nineteenToSixtyFour;
            SixtyFivePlus = sixtyFivePlus;
        }
    }
}
