using StorageAccount.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StorageAccount
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var connectionString = "DefaultEndpointsProtocol=https;AccountName=mickewessenstorageacc;AccountKey=+Ggh1rnDgltapD8FWlbbeh7pcT/VphkQAPmpn9uLOoNeg629a8+x2Ly05TlgJqon4N0YmcQbm1LopaPxABo5aA==;EndpointSuffix=core.windows.net";
            var containerName = "mickewessenstorageacc";

            var fileName = $"myfile-{Guid.NewGuid()}.txt";
            var content = "This is the content of the file";

            var filePath = Path.Combine(@"C:\Users\Micke\Desktop\EC-WIN20\Files\mickewessenstorageacc\", fileName);
            var downloadPath = Path.Combine(@"C:\Users\Micke\Desktop\EC-WIN20\Files\mickewessenstorageacc\downloads", fileName);

            Console.WriteLine("Initialize Storage Account with containerName: " + containerName);
            await StorageService.InitializeStorageAsync(connectionString, containerName);

            Console.WriteLine("Creating and writing content in file: " + filePath);
            await StorageService.WriteToFileAsync(filePath, content);

            Console.WriteLine("Uploading file to Azure Storage Blob in container: " + containerName);
            await StorageService.UploadFileAsync(filePath);

            Console.WriteLine("Downloading file from Azure Storage Blob to: " + Path.GetDirectoryName(downloadPath));
            await StorageService.DownloadFileAsync(downloadPath);

            Console.WriteLine("Reading content from file: " + downloadPath);
            Console.WriteLine(await StorageService.ReadDownloadedFileAsync(downloadPath));
        }
    }
}
