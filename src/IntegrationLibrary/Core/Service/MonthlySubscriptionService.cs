using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Core.Service.Interfaces;

namespace IntegrationLibrary.Core.Service;

public class MonthlySubscriptionService : IMonthlySubscriptionService
{
    private readonly IMonthlySubscriptionRepository _repository;
    private readonly IEmailService emailService;

    public MonthlySubscriptionService(IMonthlySubscriptionRepository repository, IEmailService emailService)
    {
        _repository = repository;
        this.emailService = emailService;
    }

    public IEnumerable<MonthlySubscription> GetAll()
    {
        return _repository.GetAll();
    }

    public void Create(MonthlySubscription subscription)
    {
        _repository.Create(subscription);
    }

    public MonthlySubscription GetLast()
    {
        return _repository.GetLast();
    }

    public void ChangeStatus(MonthlySubscriptionResponseDTO subscriptionResponse)
    {
        MonthlySubscription monthlySubscription = _repository.GetById(subscriptionResponse.hospitalSubscriptionId);
        if (monthlySubscription != null)
        {
            if (subscriptionResponse.Status == SubscriptionResponseStatus.REJECTED)
                monthlySubscription.ChangeStatus(SubscriptionStatus.REJECTED);
            else
                monthlySubscription.ChangeStatus(SubscriptionStatus.ACCEPTED);
            _repository.Update(monthlySubscription);
        }
    }

    public List<BloodDTO> GetBloodIfDelivered(MonthlySubscriptionDeliveryDTO subscriptionDeliveryDTO)
    {
        List<BloodDTO> bloodDTOs = new List<BloodDTO>();
        MonthlySubscription monthlySubscription = _repository.GetById(subscriptionDeliveryDTO.hospitalSubscriptionId);
        if (subscriptionDeliveryDTO.delivered)
        {
            if(monthlySubscription != null)
            {   
                foreach(Blood blood in monthlySubscription.RequestedBlood)
                {
                    GetBloodListDTO(bloodDTOs, blood);
                }
            }
        }else
        {
            emailService.SendRejectMonthlyDeliveryEmail(monthlySubscription.DeliveryDate.ToString()); ;
        }
        SetNextDeliveryDate(monthlySubscription);
        return bloodDTOs;
    }

    private void SetNextDeliveryDate(MonthlySubscription? monthlySubscription)
    {
        if(monthlySubscription != null)
        {
            monthlySubscription.SetNextDeliveryDate();
            _repository.Update(monthlySubscription);
        }
    }

    private static void GetBloodListDTO(List<BloodDTO> bloodDTOs, Blood blood)
    {
        BloodDTO bloodDTO = new BloodDTO();
        bloodDTO.Type = Enum.GetName(blood.BloodType.GetType(), blood.BloodType);
        bloodDTO.Quantity = blood.Quantity;
        bloodDTO.Id = (int)blood.BloodType + 1;
        bloodDTOs.Add(bloodDTO);
    }
}