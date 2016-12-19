using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApiFileUpload.Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            var message=new HttpRequestMessage();
            var content = new MultipartFormDataContent();
            var files = new List<string> { "WebApiDoc01.png", "WebApiDoc02.png" };
            //var files = new List<string> { "WebApiDoc01.png"};
            string path = @"C:\Github\Projects\csharp\WebApiFileUpload.Api\WebApiFileUpload.Client\";
            foreach (var file in files)
            {
                var filestream = new FileStream(path + file, FileMode.Open);
                var fileName = System.IO.Path.GetFileName(path + file);
                content.Add(new StreamContent(filestream), "file", fileName);
                //StreamContent streamContent = new StreamContent(filestream);
                //streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            }
            content.Add(new StringContent("Hello"), "description");
            message.Method = HttpMethod.Post;
            message.Content = content;
            message.RequestUri = new Uri("http://localhost:8000/filesNoContentType");
            //message.RequestUri = new Uri("http://localhost:8000/api/test/files");

            var client = new HttpClient();

            client.SendAsync(message).ContinueWith(task =>
            {
                if (task.Result.IsSuccessStatusCode)
                {
                    var result = task.Result;
                    Console.WriteLine(result);
                }
            });

            Console.ReadLine();
        }
    }
}
