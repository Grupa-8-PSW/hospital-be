﻿using IntegrationLibrary.Core.Model;
using Org.BouncyCastle.Asn1.Cmp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interface
{
    public interface IBloodBankConnectionService
    {
        public bool CheckForSpecificBloodType(int bloodBankId, string bloodType);
        Task<RestResponse> CheckForSpecificBloodTypeAmount(string bankName, string bloodType, double quantity);
    }
}
