using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
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
        IEnumerable<UrgentRequest> FindUrgentRequestsBetweenDates(DateTime fromDate, DateTime toDate);
        List<UrgentRequest> GetSummarizedUrgentRequests(DateTime from, DateTime to);
        Task<byte[]> GeneratePdf(List<UrgentRequest> urgentRequests, DateTime fromDate, DateTime toDate);
        UrgentRequestAllBanksStatisticDTO GetSummarizedRequests(DateTime from, DateTime to);
        QuantitiesPerBloodTypeStatisticDTO GetBloodAmountsPerTypeForAllBloodBanks(DateTime from, DateTime to);
        QuantitiesPerBloodTypeStatisticDTO GetBloodAmountsPerTypeForBloodBank(int bloodBankId, DateTime from, DateTime to);

    }
}
