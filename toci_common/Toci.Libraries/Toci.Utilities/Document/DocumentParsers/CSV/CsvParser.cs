using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using Toci.Utilities.Abstraction.Document;
using Toci.Utilities.Interfaces;

namespace Toci.Utilities.Document.DocumentParsers.CSV
{
    public class CsvParser : DocumentInterpreter
    {
        private string _delimiter;
        public CsvParser(IDocumentResource documentResource, string delimiter = ",") : base(documentResource)
        {
            _delimiter = delimiter;
        }

        protected override StringBuilder Interpret(Stream stream)
        {
            StringBuilder result = new StringBuilder();
            TextFieldParser parser = new TextFieldParser(GetFilePath());
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(_delimiter);
            while (!parser.EndOfData)
            {
                //Process row
                string[] fields = parser.ReadFields();
                if (fields != null)
                    foreach (string field in fields)
                    {
                        result.Append(field);
                    }
            }
            parser.Close();
            return result;
        }
    }
}