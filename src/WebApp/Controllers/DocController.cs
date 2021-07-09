using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class DocController : Controller
    {

        [Route("api/file")]
        public async Task GetFileStream()
        {
            this.Response.StatusCode = 200;
            this.Response.Headers.Add(HeaderNames.ContentType, "application/json");

            var outputStream = this.Response.Body;
            string filePath = @"E:\Projects\Archive\2021\01\Data\Firstnames.txt";

            using FileStream fs = System.IO.File.OpenRead(filePath);

            byte[] buf = new byte[1024];
            int count;

            while ((count = fs.Read(buf, 0, buf.Length)) > 0)
            {
                Console.WriteLine(Encoding.UTF8.GetString(buf, 0, count));
                await outputStream.WriteAsync(buf, 0, count);
            }


            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            var file = new StreamReader(@"c:\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                await outputStream.WriteAsync(Encoding.UTF8.GetBytes(line));
                counter++;
            }

            file.Close();
            await outputStream.FlushAsync();

        }
    }
}
