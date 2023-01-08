using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface ITenderOfferService
    {
        TenderOffer AcceptTenderOffer(TenderOffer tenderOffer, int tenderId);
        public TenderOffer Create(TenderOffer tenderOffer, int tenderId);
        IEnumerable<TenderOffer> GetAll();
        TenderOffer GetAcceptedByTenderId(int tenderID);
        IEnumerable<TenderOffer> GetOffersForTender(int tenderID);
    }
}
