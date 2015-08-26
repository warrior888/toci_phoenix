using ErrorsAndMessages.Exceptions;
using Toci.CryptingApi.Models;

namespace Toci.CryptingApi.ValidationUtils
{
    public static class BodyModelValidation
    {
        private const string MissingPattern = "{0} missing, please provide a/an {0} in Your request";
        public static void ValidateId(BodyModel model)
        {
            if (model.id == default(int))
            {
                throw new WebApiTociApplicationException(MissingMsgGenerator("Id"), "litania do zalogowania", (int)ApiErrors.IdMissing);
            }
        }

        public static void ValidatePassword(BodyModel model)
        {
            if (model.password == default(string))
            {
                throw new WebApiTociApplicationException(MissingMsgGenerator("Password"), "litania do haslowania", (int)ApiErrors.PasswordMissing);
            }
        }
        public static void ValidateName(BodyModel model)
        {
            if (model.name == default(string))
            {
                throw new WebApiTociApplicationException(MissingMsgGenerator("Name"), "litania do nickowania", (int)ApiErrors.NameMissing);
            }
        }
        public static void ValidateData(BodyModel model)
        {
            if (model.data == default(string))
            {
                throw new WebApiTociApplicationException(MissingMsgGenerator("Data"), "litania do danowania", (int)ApiErrors.DataMissing);
            }
        }

        private static string MissingMsgGenerator(string missinFgield)
        {
            return string.Format(MissingPattern, missinFgield);
        }
    }
}