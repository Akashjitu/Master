using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using FileUpload.Service;
using FileUploadContract;

namespace AppHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var httpUrl = new Uri("http://localhost:8090/FileService");
            var host = new ServiceHost(typeof (FileService), httpUrl);

            var smb = new ServiceMetadataBehavior {HttpGetEnabled = true};
            var wshttpbind = new WSHttpBinding
            {
                AllowCookies = true,
                CloseTimeout = new TimeSpan(1, 10, 0),
                ReceiveTimeout = new TimeSpan(1, 10, 0),
                MaxReceivedMessageSize = 2147483647,
                MaxBufferPoolSize = 2147483647,
                SendTimeout = new TimeSpan(1, 10, 0)
            };

            host.AddServiceEndpoint
                (typeof (IFileService), wshttpbind, "");

            host.Description.Behaviors.Add(smb);

            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now + host.BaseAddresses[0]);
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();
            Console.WriteLine("Listening FileService Host");
            Console.ReadLine();
        }
    }
}