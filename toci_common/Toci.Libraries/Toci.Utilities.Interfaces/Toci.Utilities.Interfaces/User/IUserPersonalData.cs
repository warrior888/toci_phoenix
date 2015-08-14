using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Utilities.Interfaces.User
{
    public interface IUserPersonalData
    {
        string Name { get; }

        string Surname { get; }

        string PhoneNumber { get; }

        string Email { get; }

        string PostalCode { get; }

        string City { get; }

        string Street { get; }

    }
}
