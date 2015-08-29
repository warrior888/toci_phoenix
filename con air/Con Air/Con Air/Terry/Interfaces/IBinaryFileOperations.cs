using System.Security.Cryptography.X509Certificates;
using Con_Air.Terry.Enum;

namespace Con_Air.Terry.Interfaces
{
    public interface IBinaryFileOperations
    {
        string GetBase64Representation(string filePath);
        void CreateFile(string filePath, string fileName, string base64Content, BinaryFileExtension extension);
    }
}