using System;

namespace ErrorsAndMessages.Exceptions
{
    [Flags]
    public enum ApiErrors
    {
        Ok = 0,
        IdMissing = 1,
        WrongId = 2,
        DataMissing = 4,
        PasswordMissing = 8,
        NameMissing = 16,
        WrongData = 32,
        WrongBase64 = 64
    }
}