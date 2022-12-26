﻿using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface ITenderService
    {
        IEnumerable<Tender> GetAll();
        IEnumerable<Tender> GetActiveTenders();

        void Create(Tender tender);
        Tender GetById(int id);

        public void Delete(Tender tender);
        Tender UpdateStatus(int tenderID);
        List<Blood> GetAllBloodAmountsBetweenDates(DateTime from, DateTime to);

        public List<Dictionary<string, int>> GetBloodAmountsBetweenDates(DateTime from, DateTime to);

    }
}
