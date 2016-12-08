using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var message=new HttpRequestMessage();
            var content = new MultipartFormDataContent();
            var files = new List<string> { "WebApiDoc01.png", "WebApiDoc02.png" };
            //var files = new List<string> { "WebApiDoc01.png"};
            foreach (var file in files)
            {
                var filestream = new FileStream(file, FileMode.Open);
                var fileName = System.IO.Path.GetFileName(file);
                content.Add(new StreamContent(filestream), "file", fileName);
            }

            message.Method = HttpMethod.Post;
            message.Content = content;
            message.RequestUri = new Uri("http://localhost:8000/api/test/filesNoContentType");
           // message.RequestUri = new Uri("http://localhost:8000/api/test/files");

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
