using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class GenderStatistic
    {
        public int Male { get; set; }
        public int Female { get; set; }

        public GenderStatistic()
        {
            Male = 0;
            Female = 0;
        }

        public GenderStatistic(int male, int female)
        {
            Male = male;
            Female = female;
        }
    }
}
