using System;
using System.Collections.Generic;
using System.IO;
using Con_Air.Terry.Enum;
using Con_Air.Terry.Interfaces;

namespace Con_Air.Terry
{
    public class BinaryFileOperations : IBinaryFileOperations
    {
        protected string _format = "{0}{1}{2}";

        protected Dictionary<BinaryFileExtension, string> extensions = new Dictionary<BinaryFileExtension, string>
        {
            {BinaryFileExtension.Dll, ".dll"},
            {BinaryFileExtension.Exe, ".exe"}
        };

        protected byte[] GetBytesFromFile(string filePath)
        {
            byte[] byteArr;

            using (var stream = new FileStream(filePath, FileMode.Open))
            using (var binReader = new BinaryReader(stream))
            {
                 byteArr = binReader.ReadBytes(Convert.ToInt32(stream.Length));
            }

            return byteArr;
        }

        protected void WriteToFile(string filePath, string fileName, string base64Content, BinaryFileExtension extension)
        {
            var byteArr = Base64Operations.GetBytesFromBase64(base64Content);
            var fullPath = string.Format(_format, filePath, fileName, extensions[extension]);

            using (var stream = new FileStream(fullPath, FileMode.Create))
                using (var binWriter = new BinaryWriter(stream))
                    binWriter.Write(byteArr);
        }
        
        public string GetBase64Representation(string filePath)
        {
            return Base64Operations.GetBase64FromByteArr(GetBytesFromFile(filePath));
        }

        public byte[] GetByteArrRepresentation(string filePath)
        {
            return GetBytesFromFile(filePath);
        }

        public void CreateFile(string filePath, string fileName, string base64Content, BinaryFileExtension extension)
        {
            WriteToFile(filePath, fileName, base64Content, extension);
        }
    }
}