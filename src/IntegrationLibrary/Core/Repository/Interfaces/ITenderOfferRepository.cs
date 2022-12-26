using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository.Interfaces
{
    public interface ITenderOfferRepository
    {
        public TenderOffer Create(TenderOffer tenderOffer);
        TenderOffer GetAcceptedOffer(int tenderID);
        IEnumerable<TenderOffer> GetAll();
        public IEnumerable<TenderOffer> GetAllByTennderID(int tenderID);
        public void UpdateTenderOffer(TenderOffer newTenderOffer);

        public TenderOffer GetAcceptOffer(int tenderId);
    }
}
