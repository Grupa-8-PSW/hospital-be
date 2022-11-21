using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodUnitRequestDTO
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }

        public BloodUnitRequestDTO(int? id, string type, int amount, string reason, string creationDate)
        {
            Id = id;
            Type = type;
            Amount = amount;
            Reason = reason;
            CreationDate = creationDate;
        }

        public void toDTO(BloodUnitRequest model)
        {
            Id = model.Id;
            Type = model.Type;
            Amount = model.Amount;
            Reason = model.Reason;
            CreationDate = model.CreationDate.ToString("dd/MM/yyyy");
        }

        

        public BloodUnitRequest toModel()
        {
            BloodUnitRequest bloodUnitRequest = new BloodUnitRequest();
            if (Id.HasValue)
            {
                bloodUnitRequest.Id = Id.Value;
            }
            bloodUnitRequest.Type = Type;
            bloodUnitRequest.Amount = Amount;
            bloodUnitRequest.Reason = Reason;
            bloodUnitRequest.CreationDate = DateTime.ParseExact(CreationDate, "dd/MM/yyyy", null).ToUniversalTime();
            return bloodUnitRequest;
        }

        
    }
}
