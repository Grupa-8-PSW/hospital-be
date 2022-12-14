using Castle.Core.Internal;
using IntegrationAPI.ExceptionHandler.Exceptions;

namespace IntegrationAPI.ExceptionHandler.Validators
{
    public static class RestockBloodValidator
    {

        public static void Validate(bool hasEnoughBlood)
        {
            if (!hasEnoughBlood)
            {
                throw new RestockBloodException("The blood bank does not have enough blood !");
            }
        }
    }
}
