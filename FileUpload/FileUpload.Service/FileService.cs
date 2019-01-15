using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using FileUploadContract;
using FileUploadContract.Models;

namespace FileUpload.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class FileService : IFileService
    {
        private const string FileStorage = @"C:\FileStorage\";
        private const int BufferLen = 65000;
        public string Authenticate(string username, string password)
        {
            var name= ServiceSecurityContext.Current.PrimaryIdentity.Name;
            var authType = ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType;
            var isAuth = ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated;
            return $"Loging successful \n User Name: {name} \n Authentication Type: {authType} \n Authenticated: {isAuth}";
        }

        public void UploadFile(RemoteFileInfo request)
        {
            if (!Directory.Exists(FileStorage))
                Directory.CreateDirectory(FileStorage);

            FileStream targetStream;

            using (targetStream = new FileStream(Path.Combine(FileStorage, request.FileName), FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                var buffer = new byte[BufferLen];
                var count = 0;
                while ((count = request.FileByteStream.Read(buffer, 0, BufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                request.FileByteStream.Close();
            }
        }
        public List<Employee> GetData(string fileName)
        {
            return ReadCsvFile(fileName);
        }

        public List<Employee> ReadCsvFile(string fileName)
        {
            var values = File.ReadAllLines(Path.Combine(FileStorage, fileName))
                .Skip(1)
                .Select(Employee.FromCsv)
                .ToList();

            return values;
        }

        public Reference GetAllFileName()
        {
            var refData = new Reference
            {
                FilesName = Directory.GetFiles(FileStorage),
                SessionId = OperationContext.Current.SessionId
            };
            return refData;
        }
    }
}