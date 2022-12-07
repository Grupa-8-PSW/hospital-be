using Castle.Core.Internal;
using IntegrationAPI.ExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.ExceptionHandler.Validators
{
    public static class BloodChekingValidator
    {
        public static void Validate(string type, double amount)
        {
            if (type.IsNullOrEmpty())
            {
                throw new BloodCheckingException("Blood Type is Empty.");
            }
            else if(amount < 0)
            {
                throw new BloodCheckingException("Amount can't be negative!");
            }
        }
    }
}
