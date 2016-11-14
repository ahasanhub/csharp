using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Owin.SelfHost
{
    public class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next): base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            Console.WriteLine("Begin Request");
            var client = context.Request.Headers.GetValues("Client")[0];
            Console.WriteLine(client);
            Console.WriteLine();
            await Next.Invoke(context);
            Console.WriteLine("End Request");
        }
        
    }
}
