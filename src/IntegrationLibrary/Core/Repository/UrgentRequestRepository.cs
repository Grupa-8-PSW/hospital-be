using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public class UrgentRequestRepository : IUrgentRequestRepository
    {

        private readonly IntegrationDbContext _context;


        public UrgentRequestRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public UrgentRequest SaveUrgentRequest(UrgentRequest urgentRequest)
        {
            _context.UrgentRequest.Add(urgentRequest);
            _context.SaveChanges();
            return urgentRequest;
        }

        public IEnumerable<UrgentRequest> GetAll()
        {
            var list = _context.UrgentRequest.ToList();
            return list;
        }
    }
}
