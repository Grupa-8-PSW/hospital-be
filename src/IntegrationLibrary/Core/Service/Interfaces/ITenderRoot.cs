using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface ITenderRoot
    {
        public List<Dictionary<string, int>> GetBloodAmountsBetweenDates(DateTime from, DateTime to);
    }
}
