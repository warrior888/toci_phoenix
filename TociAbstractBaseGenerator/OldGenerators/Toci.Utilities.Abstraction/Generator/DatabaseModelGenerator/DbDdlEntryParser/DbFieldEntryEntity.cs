﻿using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlEntryParser
{
    public class DbFieldEntryEntity : IDbFieldEntryEntity
    {
        public string Name { get; set; }

        public string FieldTypeName { get; set; }
    }
}
