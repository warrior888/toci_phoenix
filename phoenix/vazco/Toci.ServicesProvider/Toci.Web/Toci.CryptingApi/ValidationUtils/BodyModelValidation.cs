using Toci.CryptingApi.Exceptions;
using Toci.CryptingApi.Models;

namespace Toci.CryptingApi.ValidationUtils
{
    public static class BodyModelValidation
    {
        public static void ValidateId(BodyModel model)
        {
            if (model.id < 1)
            {
                throw new WebApiTociApplicationException("Id missing, please provide an id in Your request", "litania do zalogowania", (int)ApiErrors.IdMissing);
            }
        }

        public static void ValidatePassword(BodyModel model)
        {
            
        }
        public static void ValidateName(BodyModel model)
        {

        }
        public static void ValidateData(BodyModel model)
        {

        }
    }
}