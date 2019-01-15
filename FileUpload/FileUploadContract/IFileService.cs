using System;
using System.Data;
using System.ServiceModel;
using FileUploadContract.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.ServiceModel.Security.Tokens;

namespace FileUploadContract
{

    [ServiceContract(SessionMode = SessionMode.Required, ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IFileService
    {
        [OperationContract()]
        string Authenticate(string username, string password);

        [OperationContract]
        void UploadFile(RemoteFileInfo request);

        [OperationContract]
        Reference GetAllFileName();

        [OperationContract]
        List<Employee> GetData(string fileName);
    }

    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream == null) return;
            FileByteStream.Close();
            FileByteStream = null;
        }
    }
}
