﻿using IntegrationLibrary.Core.Model;
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

        public IEnumerable<UrgentRequest> GetAllBloodAmountsBetweenDates(DateTime start, DateTime end)
        {
            return _context.UrgentRequest.Where(u => u.ObtainedDate >= start && u.ObtainedDate <= end);
        }
        public IEnumerable<UrgentRequest> GetAllBloodAmountsBetweenDatesForBloodBank(DateTime start, DateTime end, int bloodBankId)
        {
            return _context.UrgentRequest.Where(u => u.ObtainedDate >= start && u.ObtainedDate <= end && u.BloodBankId == bloodBankId);
        }

    }
}
