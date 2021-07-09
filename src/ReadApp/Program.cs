using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReadApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new HttpClient();

            using StreamReader reader = new StreamReader(await client.GetStreamAsync("https://localhost:5001/api/file"));

            while (reader.Peek() >= 0)
            {
               Console.WriteLine(await reader.ReadLineAsync());
            }

            //await client.GetStreamAsync("https://localhost:5001/api/file");


        }

        private static void DownloadFile(Uri url, long range, string downloadPath)
        {
            var client = new WebClient();

            client.Headers.Add(HttpRequestHeader.Range, "bytes=0-" + range);

            client.DownloadFile(url, downloadPath);
        }
    }
}
