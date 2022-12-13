using HospitalAPI;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationTeamTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IntegrationLibrary.Core.Model.ValueObject;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests
{
    public class TenderOfferTests : BaseIntegrationTests
    {
        public TenderOfferTests(TestDatabaseFactory<IntegrationAPI.Startup> databaseFactory) : base(databaseFactory)
        {
        }

        private static ITenderOfferService SetUpTenderOfferService(IServiceScope scope)
        {
            return scope.ServiceProvider.GetRequiredService<ITenderOfferService>();
        }

        private static TenderOfferController SetupController(IServiceScope scope)
        {
            return new TenderOfferController(scope.ServiceProvider.GetRequiredService<ITenderOfferService>(), scope.ServiceProvider.GetRequiredService<IBloodBankConnectionService>());
        }

        [Fact]
        public void CreateTenderOffer()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            TenderOfferDTO dto = new TenderOfferDTO()
            {
                TenderID = 1,
                BloodAmounts = new List<BloodOfferDTO>()
                {
                    new BloodOfferDTO()
                    {
                        BloodAmount = 2,
                        BloodType = "A+",
                        PriceAmount = 12
                        
                    }
                },
                BloodBankUsername = "bloodBank",
                TenderOfferStatus = (int)TenderOfferStatus.WAITING
            };

            // Act
            var retVal = controller.CreateTenderOffer(dto) as OkObjectResult;

            //Assert
            TenderOffer createdTenderOffer = (TenderOffer)retVal.Value;
            Assert.IsType<OkObjectResult>(retVal);
            Assert.NotNull(retVal);
            Assert.True(ValidateObjectWritenInBase(dto, createdTenderOffer));

        }

        [Fact]
        public void ValidateAcceptedTender()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var service = SetUpTenderOfferService(scope);

            PrepareBase();
            IEnumerable<TenderOffer> offers = service.GetAll();
            TenderOffer acceptedTender = offers.First();
            acceptedTender.TenderOfferStatus = TenderOfferStatus.APPROVE;

            // Act
            service.changeStatusForOffers(acceptedTender);

            //Assert
            Assert.True(ValidateStatusForAllTenders(acceptedTender));

        }

        [Fact]
        public void GetOffersForTender()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            PrepareBase();

            //Act
            var retVal = controller.GetOffersForTender(1) as OkObjectResult;

            //Assert
            IEnumerable<TenderOfferDTO> offersForTender = (IEnumerable<TenderOfferDTO>)retVal.Value;
            Assert.IsType<OkObjectResult>(retVal);
            Assert.NotNull(retVal);
            Assert.True(offersForTender.Count().Equals(2));

        }


        private bool ValidateStatusForAllTenders(TenderOffer acceptedTender)
        {
            using var scope = Factory.Services.CreateScope();
            var service = SetUpTenderOfferService(scope);
            IEnumerable<TenderOffer> offers = service.getOffersForTender(1);

            foreach(TenderOffer offer in offers)
            {
                if (offer.Id.Equals(acceptedTender.Id) && (int)offer.TenderOfferStatus != (int)TenderOfferStatus.APPROVE)
                    return false;
                
                else if (offer.Id != acceptedTender.Id && (int)offer.TenderOfferStatus != (int)TenderOfferStatus.REJECT)
                    return false;
            }

            return true;

        }

        private bool ValidateObjectWritenInBase(TenderOfferDTO dto, TenderOffer retVal)
        {
            if(dto.TenderID.Equals(retVal.TenderID) &&
                compareLists(dto.BloodAmounts, retVal.Offers) &&
                dto.BloodBankUsername.Equals(retVal.BloodBankName))
                return true;

            return false;
        }

        private bool compareLists(List<BloodOfferDTO> boDTO, List<BloodOffer> bo)
        {
            for (int i = 0; i < boDTO.Count; i++)
            {
                if (!boDTO[i].BloodType.Equals(bo[i].BloodType) ||
                    !boDTO[i].BloodAmount.Equals(bo[i].BloodAmount) ||
                    !boDTO[i].PriceAmount.Equals(bo[i].Price.Amount))
                    return false;
            }
            return true;
        }


        private void PrepareBase()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            TenderOfferDTO dto = new TenderOfferDTO()
            {
                TenderID = 1,
                BloodAmounts = new List<BloodOfferDTO>()
                {
                    new BloodOfferDTO()
                    {
                        BloodAmount = 2,
                        BloodType = "A+",
                        PriceAmount = 12

                    }
                },
                BloodBankUsername = "bloodBank",
                TenderOfferStatus = (int)TenderOfferStatus.WAITING
            };


            TenderOfferDTO dto2 = new TenderOfferDTO()
            {
                TenderID = 1,
                BloodAmounts = new List<BloodOfferDTO>()
                {
                    new BloodOfferDTO()
                    {
                        BloodAmount = 2,
                        BloodType = "A+",
                        PriceAmount = 12

                    }
                },
                BloodBankUsername = "bloodBank",
                TenderOfferStatus = (int)TenderOfferStatus.WAITING
            };

            TenderOfferDTO dto3 = new TenderOfferDTO()
            {
                TenderID = 2,
                BloodAmounts = new List<BloodOfferDTO>()
                {
                    new BloodOfferDTO()
                    {
                        BloodAmount = 2,
                        BloodType = "A+",
                        PriceAmount = 12

                    }
                },
                BloodBankUsername = "bloodBank",
                TenderOfferStatus = (int)TenderOfferStatus.WAITING
            };

            controller.CreateTenderOffer(dto);
            controller.CreateTenderOffer(dto2);
            controller.CreateTenderOffer(dto3); 
        }
    }
}
