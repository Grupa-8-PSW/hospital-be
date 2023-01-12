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
        TenderOffer AcceptTenderOffer(TenderOffer tenderOffer);
        public TenderOffer Create(TenderOffer tenderOffer);
        IEnumerable<TenderOffer> GetAll();
        TenderOffer GetById(int tenderID);
        IEnumerable<TenderOffer> getOffersForTender(int tenderID);
        public void changeStatusForOffers(TenderOffer acceptedTenderOffer);
        List<double> GetBloodPerMonth(int year, string bloodType);

        List<decimal> GetMoneyPerMonth(int year);
    }
}
