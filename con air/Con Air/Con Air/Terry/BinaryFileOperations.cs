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

        protected string GetBase64FromFile(string filePath)
        {
            string result;

            using (var stream = new FileStream(filePath, FileMode.Open))
            using (var binReader = new BinaryReader(stream))
            {
                var byteArr = binReader.ReadBytes(Convert.ToInt32(stream.Length));
                result = Convert.ToBase64String(byteArr);
            }

            return result;
        }

        protected void WriteToFile(string filePath, string fileName, string base64Content, BinaryFileExtension extension)
        {
            var byteArr = Convert.FromBase64String(base64Content);
            var fullPath = string.Format(_format, filePath, fileName, extensions[extension]);

            using (var stream = new FileStream(fullPath, FileMode.Create))
                using (var binWriter = new BinaryWriter(stream))
                    binWriter.Write(byteArr);
        }
        
        public string GetBase64Representation(string filePath)
        {
            return GetBase64FromFile(filePath);
        }

        public void CreateFile(string filePath, string fileName, string base64Content, BinaryFileExtension extension)
        {
            WriteToFile(filePath, fileName, base64Content, extension);
        }
    }
}