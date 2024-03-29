﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IBloodBankService
    {
        IEnumerable<BloodBank> GetAll();
        void Create(BloodBank bloodBank);
        BloodBank GetById(int id);
        void Delete(BloodBank bloodBank);
        BloodBank GetByName(string bloodBankName);

        BloodBank GetByApiKey(string apiKey);
    }
}
