﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodUnitRequestDeliveryDTO
    {
        public int hospitalRequestId { get; set; }
        public bool delivered { get; set; }
        public string bloodBankApiKey { get; set; }
    }
}
