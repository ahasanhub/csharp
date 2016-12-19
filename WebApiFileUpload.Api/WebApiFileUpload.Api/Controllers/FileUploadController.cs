using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiFileUpload.Api.Controllers
{
    public class FileUploadController : ApiController
    {
        private static readonly string ServerUploadFolder = @"C:\Temp";
        [HttpPost,Route("api/test/files")]
        public async Task<FileResult> UploadSingleFile()
        {
            var streamProvider=new MultipartFormDataStreamProvider(ServerUploadFolder);
            await Request.Content.ReadAsMultipartAsync(streamProvider);
            return new FileResult
            {
                FileNames = streamProvider.FileData.Select(entry=>entry.LocalFileName),
                Names = streamProvider.FileData.Select(entry=>entry.Headers.ContentDisposition.FileName),
                ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
                Description = streamProvider.FormData["description"],
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
                DownloadLink = "TODO, will implement when file is persisited"
            };
        }
        [Route("filesNoContentType")]
        [HttpPost]
        [ValidateMimeMultipartContentFilter]
        public async Task<FileResult> UploadMultipleFiles2()
        {
            var provider = new MultipartFormDataStreamProvider(ServerUploadFolder);
            try
            {
                var streamProvider = StreamConversion();
                await streamProvider.ReadAsMultipartAsync(provider);
                var description = provider.FormData["description"];
                return new FileResult
                {
                    FileNames = provider.FileData.Select(entry => entry.LocalFileName),
                    Names = provider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
                    Description = provider.FormData["description"],
                    CreatedTimestamp = DateTime.UtcNow,
                    UpdatedTimestamp = DateTime.UtcNow,
                    DownloadLink = "TODO, will implement when file is persisited"
                };
            }
            catch (System.Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        private StreamContent StreamConversion()
        {
            Stream reqStream = Request.Content.ReadAsStreamAsync().Result;
            var tempStream = new MemoryStream();
            reqStream.CopyTo(tempStream);

            tempStream.Seek(0, SeekOrigin.End);
            var writer = new StreamWriter(tempStream);
            writer.WriteLine();
            writer.Flush();
            tempStream.Position = 0;

            var streamContent = new StreamContent(tempStream);
            foreach (var header in Request.Content.Headers)
            {
                streamContent.Headers.Add(header.Key, header.Value);
            }
            return streamContent;
        }
    }
}
