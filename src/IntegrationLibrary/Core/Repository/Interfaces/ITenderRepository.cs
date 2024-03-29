﻿using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.Interfaces
{
    public interface ITenderRepository
    {
        IEnumerable<Tender> GetAll();
        void Create(Tender tender);
        Tender GetById(int id);
        void Delete(Tender tender);
        void Update(Tender tender);
        IEnumerable<Tender> GetActiveTenders();
        IEnumerable<Tender> GetAllBloodAmountsBetweenDates(DateTime start, DateTime end);

        public List<Tender> GetTendersBetweenDates(DateTime start, DateTime end);
    }
}
