using IntegrationLibrary.Core.Model;
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
        Task<byte[]> GeneratePdf(List<UrgentRequest> urgentRequests, DateTime fromDate, DateTime toDate);
    }
}
