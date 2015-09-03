using System.Collections.Generic;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Generator.DatabaseModelGenerator
{
    public class WrapperModel : IWrapperModel
    {
        public string ParentName { get; set; }
        public string NamespaceName { get; set; }
        public List<string> UsingsList { get; set; }

        //@"..\..\..\DbCrypting\VazcoDb\template.txt"
        public string TemplatePath { get; set; }
        public string DestinationPath { get; set; }
        public string CsprojPath { get; set; }
        public string FolderPath { get; set; }
    }
}