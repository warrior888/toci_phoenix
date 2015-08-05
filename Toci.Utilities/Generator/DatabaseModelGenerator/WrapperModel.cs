using System.Collections.Generic;

namespace Toci.Utilities.Generator.DatabaseModelGenerator
{
    public class WrapperModel
    {
        //@"..\..\..\DbCrypting\VazcoDb\template.txt"
        public string TemplatePath { get; set; }
        public string DestinationPath { get; set; }
        public string ParentName { get; set; }
        public string NamespaceName { get; set; }

        public List<string> UsingsList;


    }
}