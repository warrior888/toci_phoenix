using System;

namespace Toci.CryptingApi.Exceptions
{
    [Flags]
    public enum ApiErrors
    {
        IdMissing = 1,
        WrongId = 2,
        DataMissing = 4,
        PasswordMissing = 8,
        NameMissing = 16
    }
}