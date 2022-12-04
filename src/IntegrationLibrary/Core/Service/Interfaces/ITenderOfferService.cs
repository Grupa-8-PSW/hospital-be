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
        public tenderOfferDTO Create(tenderOfferDTO tenderOffer);
        IEnumerable<tenderOfferDTO> GetAll();
    }
}
