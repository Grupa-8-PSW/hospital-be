﻿using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public interface ITenderOfferRepository
    {
        public tenderOfferDTO Create(tenderOfferDTO tenderOffer);
        IEnumerable<tenderOfferDTO> GetAll();

        public IEnumerable<tenderOfferDTO> GetAllByTennderID();
    }
}
