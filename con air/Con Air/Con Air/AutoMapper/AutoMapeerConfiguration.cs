using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Con_Air.AutoMapper
{
    public class AutoMapeerConfiguration
    {
        private IClassForMappingGenerator _classForMapping;

        public AutoMapeerConfiguration(IClassForMappingGenerator classForMapping)
        {
            _classForMapping = classForMapping;
        }

        public void Configure()
        {
            IEnumerable<IClassForMappingWrapper> classForMapping =  _classForMapping.GetAllClassForMapping();

        }


    }
}