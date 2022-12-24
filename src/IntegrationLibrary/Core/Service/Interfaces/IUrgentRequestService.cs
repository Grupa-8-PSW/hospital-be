using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IUrgentRequestService
    {
        List<UrgentRequest> FindUrgentRequestsBetweenDates(DateTime fromDate, DateTime toDate);
        List<Blood> GetAllBloodAmountsBetweenDates(DateTime from, DateTime to);
        List<UrgentRequest> GetUniqueUrgentRequests(DateTime from, DateTime to);
        Task<byte[]> GeneratePdf(List<UrgentRequest> urgentRequests, DateTime fromDate, DateTime toDate);

    }
}
