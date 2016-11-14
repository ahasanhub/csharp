using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NugetDemo
{
    class MyClass
    {
        async Task DownloadAsync()
        {
            HttpClient client=new HttpClient();
            await client.GetStringAsync("");
        }
    }
}
