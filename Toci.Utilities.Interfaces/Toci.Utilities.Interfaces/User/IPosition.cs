﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Interfaces.User
{
    public interface IPosition //posada
    {
        string PostionName { get; }

        decimal MonthlyEarnings { get; }

        Dictionary<int,IPrivilege> PositionPrivileges { get; }

        Dictionary<int, IUser> GetSuperiors();

        Dictionary<int, IUser> GetSubordinates();
    }
}
