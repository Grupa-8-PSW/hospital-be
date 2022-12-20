using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class UrgentRequestService : IUrgentRequestService
    {
        private readonly IUrgentRequestRepository _urgentRequestRepository;
        public UrgentRequestService(IUrgentRequestRepository urgentRequestRepository) {
            _urgentRequestRepository = urgentRequestRepository;
        }

        public List<UrgentRequest> FindUrgentRequestsBetweenDates(DateTime fromDate, DateTime toDate)
        {
            List<UrgentRequest> validRequests = new List<UrgentRequest>();
            foreach(UrgentRequest urgentRequest in (List<UrgentRequest>)_urgentRequestRepository.GetAll())
            {
                if (fromDate.Ticks < urgentRequest.ObtainedDate.Ticks && urgentRequest.ObtainedDate.Ticks < toDate.Ticks)
                    validRequests.Add(urgentRequest);
            }
            if(validRequests.Count == 0)
                Console.WriteLine("Za ovaj period nema nabavljene krvi");

            return validRequests;
        }
    }
}
