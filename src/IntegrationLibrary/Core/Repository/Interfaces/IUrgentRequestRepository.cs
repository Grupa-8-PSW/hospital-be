using IntegrationLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.Interfaces
{
    public interface IUrgentRequestRepository
    {
        UrgentRequest SaveUrgentRequest(UrgentRequest urgentRequest);

        IEnumerable<UrgentRequest> GetAll();

        IEnumerable<UrgentRequest> GetAllBloodAmountsBetweenDates(DateTime start, DateTime end);

        IEnumerable<UrgentRequest> GetAllBloodAmountsBetweenDatesForBloodBank(DateTime start, DateTime end, int bloodBankId);
    }
}
