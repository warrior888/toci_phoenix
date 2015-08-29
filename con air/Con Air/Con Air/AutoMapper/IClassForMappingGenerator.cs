using System.Collections;
using System.Collections.Generic;

namespace Con_Air.AutoMapper
{
    public interface IClassForMappingGenerator
    {
        IEnumerable<IClassForMappingWrapper> GetAllClassForMapping();
    }
}